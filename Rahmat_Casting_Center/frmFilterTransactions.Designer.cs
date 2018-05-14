namespace Rahmat_Casting_Center
{
    partial class frmFilterTransactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilterTransactions));
            this.rbStocksOut = new System.Windows.Forms.RadioButton();
            this.rbStocksIn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.find = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.rbCimages = new System.Windows.Forms.RadioButton();
            this.rbCasting = new System.Windows.Forms.RadioButton();
            this.rbDebt = new System.Windows.Forms.RadioButton();
            this.rbimages = new System.Windows.Forms.RadioButton();
            this.Label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbStocksOut
            // 
            this.rbStocksOut.AutoSize = true;
            this.rbStocksOut.Font = new System.Drawing.Font("Constantia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbStocksOut.Location = new System.Drawing.Point(17, 195);
            this.rbStocksOut.Name = "rbStocksOut";
            this.rbStocksOut.Size = new System.Drawing.Size(95, 22);
            this.rbStocksOut.TabIndex = 5;
            this.rbStocksOut.TabStop = true;
            this.rbStocksOut.Text = "Cash  A/C";
            this.rbStocksOut.UseVisualStyleBackColor = true;
            this.rbStocksOut.CheckedChanged += new System.EventHandler(this.rbStocksOut_CheckedChanged);
            // 
            // rbStocksIn
            // 
            this.rbStocksIn.AutoSize = true;
            this.rbStocksIn.Font = new System.Drawing.Font("Constantia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbStocksIn.Location = new System.Drawing.Point(27, 153);
            this.rbStocksIn.Name = "rbStocksIn";
            this.rbStocksIn.Size = new System.Drawing.Size(100, 22);
            this.rbStocksIn.TabIndex = 5;
            this.rbStocksIn.TabStop = true;
            this.rbStocksIn.Text = "Single A/C";
            this.rbStocksIn.UseVisualStyleBackColor = true;
            this.rbStocksIn.CheckedChanged += new System.EventHandler(this.rbStocksIn_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "End Date :";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Constantia", 10F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(251, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 42);
            this.button4.TabIndex = 16;
            this.button4.Text = "&Cancel";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(12, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 77);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Constantia", 10F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(52, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 42);
            this.button3.TabIndex = 15;
            this.button3.Text = "&Load Report";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "MMM-dd-yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(184, 56);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(138, 25);
            this.dtpEndDate.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Location = new System.Drawing.Point(-2, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 77);
            this.panel2.TabIndex = 53;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(9, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Transactions Report";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.find);
            this.GroupBox3.Controls.Add(this.label2);
            this.GroupBox3.Controls.Add(this.dtpStartDate);
            this.GroupBox3.Controls.Add(this.rbCimages);
            this.GroupBox3.Controls.Add(this.rbCasting);
            this.GroupBox3.Controls.Add(this.rbDebt);
            this.GroupBox3.Controls.Add(this.rbimages);
            this.GroupBox3.Controls.Add(this.rbStocksOut);
            this.GroupBox3.Controls.Add(this.rbStocksIn);
            this.GroupBox3.Controls.Add(this.dtpEndDate);
            this.GroupBox3.Controls.Add(this.label1);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.Location = new System.Drawing.Point(12, 81);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(444, 241);
            this.GroupBox3.TabIndex = 52;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Filter By";
            // 
            // find
            // 
            this.find.Font = new System.Drawing.Font("Consolas", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Location = new System.Drawing.Point(222, 106);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(100, 25);
            this.find.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Search by Account No. :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "MMM-dd-yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(184, 17);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(138, 25);
            this.dtpStartDate.TabIndex = 3;
            // 
            // rbCimages
            // 
            this.rbCimages.AutoSize = true;
            this.rbCimages.Font = new System.Drawing.Font("Constantia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCimages.Location = new System.Drawing.Point(147, 195);
            this.rbCimages.Name = "rbCimages";
            this.rbCimages.Size = new System.Drawing.Size(146, 22);
            this.rbCimages.TabIndex = 9;
            this.rbCimages.TabStop = true;
            this.rbCimages.Text = "Cash A/C Images";
            this.rbCimages.UseVisualStyleBackColor = true;
            // 
            // rbCasting
            // 
            this.rbCasting.AutoSize = true;
            this.rbCasting.Font = new System.Drawing.Font("Constantia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCasting.Location = new System.Drawing.Point(333, 195);
            this.rbCasting.Name = "rbCasting";
            this.rbCasting.Size = new System.Drawing.Size(80, 22);
            this.rbCasting.TabIndex = 8;
            this.rbCasting.TabStop = true;
            this.rbCasting.Text = "Casting";
            this.rbCasting.UseVisualStyleBackColor = true;
            this.rbCasting.CheckedChanged += new System.EventHandler(this.rbCasting_CheckedChanged);
            // 
            // rbDebt
            // 
            this.rbDebt.AutoSize = true;
            this.rbDebt.Font = new System.Drawing.Font("Constantia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDebt.Location = new System.Drawing.Point(346, 153);
            this.rbDebt.Name = "rbDebt";
            this.rbDebt.Size = new System.Drawing.Size(77, 22);
            this.rbDebt.TabIndex = 7;
            this.rbDebt.TabStop = true;
            this.rbDebt.Text = "DebtIn";
            this.rbDebt.UseVisualStyleBackColor = true;
            this.rbDebt.CheckedChanged += new System.EventHandler(this.rbDebt_CheckedChanged);
            // 
            // rbimages
            // 
            this.rbimages.AutoSize = true;
            this.rbimages.Font = new System.Drawing.Font("Constantia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbimages.Location = new System.Drawing.Point(161, 153);
            this.rbimages.Name = "rbimages";
            this.rbimages.Size = new System.Drawing.Size(155, 22);
            this.rbimages.TabIndex = 6;
            this.rbimages.TabStop = true;
            this.rbimages.Text = "Single A/C Images";
            this.rbimages.UseVisualStyleBackColor = true;
            this.rbimages.CheckedChanged += new System.EventHandler(this.rbimages_CheckedChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(72, 23);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(83, 17);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "Start Date :";
            // 
            // frmFilterTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(468, 417);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.GroupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFilterTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.RadioButton rbStocksOut;
        internal System.Windows.Forms.RadioButton rbStocksIn;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.RadioButton rbimages;
        internal System.Windows.Forms.RadioButton rbDebt;
        internal System.Windows.Forms.RadioButton rbCasting;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        internal System.Windows.Forms.RadioButton rbCimages;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox find;
        internal System.Windows.Forms.Label label2;
    }
}