namespace NavScrapperForms
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.BTN_Go = new System.Windows.Forms.Button();
			this.TB_TitleID = new System.Windows.Forms.TextBox();
			this.TB_StartChapter = new System.Windows.Forms.TextBox();
			this.TB_EndChapter = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// BTN_Go
			// 
			this.BTN_Go.Location = new System.Drawing.Point(12, 101);
			this.BTN_Go.Name = "BTN_Go";
			this.BTN_Go.Size = new System.Drawing.Size(307, 23);
			this.BTN_Go.TabIndex = 3;
			this.BTN_Go.Text = "Let\'s-a-go!";
			this.BTN_Go.UseVisualStyleBackColor = true;
			this.BTN_Go.Click += new System.EventHandler(this.BTN_Go_Click);
			// 
			// TB_TitleID
			// 
			this.TB_TitleID.Location = new System.Drawing.Point(219, 23);
			this.TB_TitleID.Name = "TB_TitleID";
			this.TB_TitleID.Size = new System.Drawing.Size(100, 20);
			this.TB_TitleID.TabIndex = 0;
			// 
			// TB_StartChapter
			// 
			this.TB_StartChapter.Location = new System.Drawing.Point(219, 49);
			this.TB_StartChapter.Name = "TB_StartChapter";
			this.TB_StartChapter.Size = new System.Drawing.Size(100, 20);
			this.TB_StartChapter.TabIndex = 1;
			// 
			// TB_EndChapter
			// 
			this.TB_EndChapter.Location = new System.Drawing.Point(219, 75);
			this.TB_EndChapter.Name = "TB_EndChapter";
			this.TB_EndChapter.Size = new System.Drawing.Size(100, 20);
			this.TB_EndChapter.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Title ID:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Start Chapter:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "End Chapter:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 141);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TB_EndChapter);
			this.Controls.Add(this.TB_StartChapter);
			this.Controls.Add(this.TB_TitleID);
			this.Controls.Add(this.BTN_Go);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Naver Scrapper";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BTN_Go;
		private System.Windows.Forms.TextBox TB_TitleID;
		private System.Windows.Forms.TextBox TB_StartChapter;
		private System.Windows.Forms.TextBox TB_EndChapter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}

