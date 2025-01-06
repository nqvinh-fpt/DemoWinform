namespace ReantSim
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
            txtTokenAPI = new TextBox();
            btnShowNetword = new Button();
            dgvListNetwork = new DataGridView();
            btnBuySim = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvListNetwork).BeginInit();
            SuspendLayout();
            // 
            // txtTokenAPI
            // 
            txtTokenAPI.Location = new Point(12, 38);
            txtTokenAPI.Name = "txtTokenAPI";
            txtTokenAPI.Size = new Size(358, 27);
            txtTokenAPI.TabIndex = 0;
            // 
            // btnShowNetword
            // 
            btnShowNetword.Location = new Point(399, 38);
            btnShowNetword.Name = "btnShowNetword";
            btnShowNetword.Size = new Size(125, 29);
            btnShowNetword.TabIndex = 2;
            btnShowNetword.Text = "Show Netword";
            btnShowNetword.UseVisualStyleBackColor = true;
            btnShowNetword.Click += btnShowNetword_Click;
            // 
            // dgvListNetwork
            // 
            dgvListNetwork.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListNetwork.Location = new Point(12, 91);
            dgvListNetwork.Name = "dgvListNetwork";
            dgvListNetwork.RowHeadersWidth = 51;
            dgvListNetwork.Size = new Size(358, 262);
            dgvListNetwork.TabIndex = 3;
            // 
            // btnBuySim
            // 
            btnBuySim.Location = new Point(399, 91);
            btnBuySim.Name = "btnBuySim";
            btnBuySim.Size = new Size(125, 29);
            btnBuySim.TabIndex = 4;
            btnBuySim.Text = "Buy Sim";
            btnBuySim.UseVisualStyleBackColor = true;
            btnBuySim.Click += btnBuySim_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 5;
            label1.Text = "Tonken API";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 68);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 6;
            label2.Text = "List Network";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 375);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBuySim);
            Controls.Add(dgvListNetwork);
            Controls.Add(btnShowNetword);
            Controls.Add(txtTokenAPI);
            Name = "Form1";
            Text = "Rent Sim";
            ((System.ComponentModel.ISupportInitialize)dgvListNetwork).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTokenAPI;
        private Button button1;
        private Button btnShowNetword;
        private DataGridView dgvListNetwork;
        private Button btnBuySim;
        private Label label1;
        private Label label2;
    }
}
