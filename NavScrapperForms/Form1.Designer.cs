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
            this.CB_Website = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTN_Go
            // 
            this.BTN_Go.Location = new System.Drawing.Point(16, 157);
            this.BTN_Go.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_Go.Name = "BTN_Go";
            this.BTN_Go.Size = new System.Drawing.Size(409, 28);
            this.BTN_Go.TabIndex = 4;
            this.BTN_Go.Text = "Let\'s-a-go!";
            this.BTN_Go.UseVisualStyleBackColor = true;
            this.BTN_Go.Click += new System.EventHandler(this.BTN_Go_Click);
            // 
            // TB_TitleID
            // 
            this.TB_TitleID.Location = new System.Drawing.Point(292, 61);
            this.TB_TitleID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_TitleID.Name = "TB_TitleID";
            this.TB_TitleID.Size = new System.Drawing.Size(132, 22);
            this.TB_TitleID.TabIndex = 1;
            // 
            // TB_StartChapter
            // 
            this.TB_StartChapter.Location = new System.Drawing.Point(292, 93);
            this.TB_StartChapter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_StartChapter.Name = "TB_StartChapter";
            this.TB_StartChapter.Size = new System.Drawing.Size(132, 22);
            this.TB_StartChapter.TabIndex = 2;
            // 
            // TB_EndChapter
            // 
            this.TB_EndChapter.Location = new System.Drawing.Point(292, 125);
            this.TB_EndChapter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_EndChapter.Name = "TB_EndChapter";
            this.TB_EndChapter.Size = new System.Drawing.Size(132, 22);
            this.TB_EndChapter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start Chapter:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "End Chapter:";
            // 
            // CB_Website
            // 
            this.CB_Website.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Website.FormattingEnabled = true;
            this.CB_Website.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CB_Website.Items.AddRange(new object[] {
            "Naver.com",
            "Prince of Prince"});
            this.CB_Website.Location = new System.Drawing.Point(292, 30);
            this.CB_Website.Name = "CB_Website";
            this.CB_Website.Size = new System.Drawing.Size(132, 24);
            this.CB_Website.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Website:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 215);
            this.Controls.Add(this.CB_Website);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_EndChapter);
            this.Controls.Add(this.TB_StartChapter);
            this.Controls.Add(this.TB_TitleID);
            this.Controls.Add(this.BTN_Go);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
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
        private System.Windows.Forms.ComboBox CB_Website;
        private System.Windows.Forms.Label label4;
    }
}

