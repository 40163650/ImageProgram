using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace NavScrapperForms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			CB_Website.SelectedIndex = 0;
		}

		string startSearchTerm;
		string endSearchTerm;
		string chapterParameter;
		string webaddress;


		private string GetLink(string imageHTML)
		{
			int startPos = imageHTML.IndexOf("http");
			int endPos = imageHTML.IndexOf("\" ");
			string URL = imageHTML.Substring(startPos, endPos - startPos);
			return URL;
		}

		private string GetImageName(string imageHTML, int numDigits)
		{
			int startPos = imageHTML.IndexOf("id") + 12;
			int endPos = imageHTML.IndexOf("\" onerror");
			string name = imageHTML.Substring(startPos, endPos - startPos);

			// Zero padding
			string num = name.Substring(6);
			string padded = "";
			if (num.Length < numDigits)
			{
				for (int i = 0; i < (numDigits - num.Length); i++)
				{
					padded += "0";
				}
				padded += num;
			}
			else
			{
				return name;
			}

			string ret = name.Substring(0, 6) + padded;

			return ret;
		}

		public void SaveImage(string imageUrl, string filename, ImageFormat format)
		{
			WebClient client = new WebClient();
			client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.31 Safari/537.36");

			Stream stream = client.OpenRead(imageUrl);
			Bitmap bitmap = new Bitmap(stream);

			if (bitmap != null)
			{
				bitmap.Save(filename + ".png", format);
			}

			stream.Flush();
			stream.Close();
			client.Dispose();
		}
		//TODO: Cookies https://stackoverflow.com/questions/11164275/how-to-add-cookies-to-webrequest
		//gateAgePass: true <-- need to try and set this
		private async void DownloadChapter(HttpResponseMessage response, string dir)
		{
			// Get the response content.
			string responseContent = await response.Content.ReadAsStringAsync();

			int startPos = responseContent.IndexOf(startSearchTerm); //"<!-- 뷰어  -->"
			int endPos = responseContent.IndexOf(endSearchTerm); //"<!-- //뷰어 -->"

			if (startPos < 0 || endPos < 0)
			{
				MessageBox.Show("This program is too dumb to download this particular chapter!");
				return;
			}

			responseContent = responseContent.Substring(startPos, endPos - startPos);

			Regex regex = new Regex(@"image_[0-9]+");
			var matches = regex.Matches(responseContent);
			int bigLen = matches.Count.ToString().Length;

			string html = "";
			string[] lines = responseContent.Split('\n');

			int linesWritten = 0;
			for (int i = 0; i < lines.Length - 3; i++)
			{
				if (!string.IsNullOrWhiteSpace(lines[i]))
				{
					if (linesWritten > 1)
					{
						string trimmed = lines[i].Trim();
						string link = GetLink(trimmed);
						html += link + "\n";
						SaveImage(link, dir + "\\" + GetImageName(trimmed, bigLen), ImageFormat.Png);
					}
					else
					{
						linesWritten++;
					}
				}
			}
		}

		private bool ValidateInput(out int startChap, out int endChap)
		{
			startChap = -1;
			endChap = -1;

			if (string.IsNullOrWhiteSpace(TB_StartChapter.Text) || string.IsNullOrWhiteSpace(TB_TitleID.Text))
			{
				MessageBox.Show("You need to provide a title ID and a start chapter number!");
				return false;
			}

			if (string.IsNullOrWhiteSpace(TB_EndChapter.Text))
			{
				TB_EndChapter.Text = TB_StartChapter.Text;
			}

			bool res = int.TryParse(TB_StartChapter.Text, out startChap);
			if (!res || startChap < 0)
			{
				MessageBox.Show("Start chapter must be a positive whole number!");
				return false;
			}
			res = int.TryParse(TB_EndChapter.Text, out endChap);
			if (!res || endChap < 0)
			{
				MessageBox.Show("End chapter must be a positive whole number!");
				return false;
			}
			res = int.TryParse(TB_TitleID.Text, out int titleID);
			if (!res || titleID < 0)
			{
				MessageBox.Show("Title ID must be a positive whole number!");
				return false;
			}

			if (startChap > endChap)
			{
				MessageBox.Show("Start chapter number cannot be greater than end chapter number!");
				return false;
			}

			return true;
		}

		private async void BTN_Go_Click(object sender, EventArgs e)
		{
			bool valid = ValidateInput(out int startChap, out int endChap);

			if (!valid)
			{
				return;
			}

			string selectedWebsite = CB_Website.GetItemText(CB_Website.SelectedItem);
			if (selectedWebsite.Equals("Naver.com"))
			{
				startSearchTerm = "<!-- 뷰어  -->";
				endSearchTerm = "<!-- //뷰어 -->";
				chapterParameter = "&no=";
				webaddress = "https://comic.naver.com/webtoon/detail.nhn?titleId=";
			}
			else if(selectedWebsite.Equals("Prince of Prince"))
			{
				startSearchTerm = "<div class=\"viewer_img _img_viewer_area \" id=\"_imageList\">";
				endSearchTerm = "</div>";
				chapterParameter = "";
				webaddress = "https://www.webtoons.com/id/comedy/princes-prince/ep52/viewer?title_no=582&episode_no=";
				TB_TitleID.Text = "";
			}

			HttpClient client = new HttpClient();

			for (int i = startChap; i <= endChap; i++)
			{
				string URL = webaddress + TB_TitleID.Text + chapterParameter + i.ToString();
				// Get the response.
				HttpResponseMessage response = await client.GetAsync(URL);
				try
				{
					response.EnsureSuccessStatusCode(); // Ensure status 200
				}
				catch (HttpRequestException ex)
				{
					MessageBox.Show("Invalid URL: " + URL + "\nException:\n" + ex.Message);
					return;
				}

				string dir = TB_TitleID.Text + "_" + i.ToString();
				Directory.CreateDirectory(dir);

				DownloadChapter(response, dir);
			}

			client.Dispose();
		}
	}
}