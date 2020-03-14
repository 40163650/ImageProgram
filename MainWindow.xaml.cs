using System.Windows;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace NaverScraper
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private string GetLink(string imageHTML)
		{
			int startPos = imageHTML.IndexOf("http");
			int endPos = imageHTML.IndexOf("\" ");
			string URL = imageHTML[startPos..endPos];
			return URL;
		}

		private string GetImageName(string imageHTML, int numDigits)
		{
			int startPos = imageHTML.IndexOf("id") + 12;
			int endPos = imageHTML.IndexOf("\" onerror");
			string name = imageHTML[startPos..endPos];

			// Zero padding
			string num = name.Substring(6);
			string padded = "";
			if (num.Length < numDigits)
            {
				for(int i = 0; i < (numDigits - num.Length); i++)
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

		private async void DownloadChapter(HttpResponseMessage response, string dir)
		{
			// Get the response content.
			string responseContent = await response.Content.ReadAsStringAsync();

			int startPos = responseContent.IndexOf("<!-- 뷰어  -->");
			int endPos = responseContent.IndexOf("<!-- //뷰어 -->");

			if(startPos < 0 || endPos < 0)
			{
				MessageBox.Show("This program is too dumb to download this particular chapter!");
				return;
			}

			responseContent = responseContent[startPos..endPos];

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

		private async void BTN_Go_Click(object sender, RoutedEventArgs e)
		{
			bool valid = ValidateInput(out int startChap, out int endChap);

			if(!valid)
			{
				return;
			}

			HttpClient client = new HttpClient();

			for (int i = startChap; i <= endChap; i++)
			{
				string URL = "https://comic.naver.com/webtoon/detail.nhn?titleId=" + TB_TitleID.Text + "&no=" + i.ToString();
				// Get the response.
				HttpResponseMessage response = await client.GetAsync(URL);
				try
				{
					response.EnsureSuccessStatusCode(); // Ensure status 200
				}
				catch(HttpRequestException ex)
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
