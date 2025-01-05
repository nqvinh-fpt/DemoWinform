namespace HTMLScraper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnScraper = new Button();
            txtHtml = new TextBox();
            SuspendLayout();
            // 
            // btnScraper
            // 
            btnScraper.Location = new Point(12, 12);
            btnScraper.Name = "btnScraper";
            btnScraper.Size = new Size(94, 29);
            btnScraper.TabIndex = 0;
            btnScraper.Text = "Lấy HTML";
            btnScraper.UseVisualStyleBackColor = true;
            btnScraper.Click += btnScraper_Click;
            // 
            // txtHtml
            // 
            txtHtml.Location = new Point(12, 47);
            txtHtml.Multiline = true;
            txtHtml.Name = "txtHtml";
            txtHtml.ReadOnly = true;
            txtHtml.ScrollBars = ScrollBars.Vertical;
            txtHtml.Size = new Size(626, 582);
            txtHtml.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 641);
            Controls.Add(txtHtml);
            Controls.Add(btnScraper);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnScraper;
        private TextBox txtHtml;
    }
}
