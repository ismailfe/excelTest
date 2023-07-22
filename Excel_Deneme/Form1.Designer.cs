namespace Excel_Deneme
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
            this.B_Oku = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Kaynak_Path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.B_KaynakYolu = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DGV_Excel1 = new System.Windows.Forms.DataGridView();
            this.DGV_SearchResult = new System.Windows.Forms.DataGridView();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.TB_Status = new System.Windows.Forms.TextBox();
            this.LBStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Excel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Oku
            // 
            this.B_Oku.Location = new System.Drawing.Point(18, 36);
            this.B_Oku.Name = "B_Oku";
            this.B_Oku.Size = new System.Drawing.Size(75, 23);
            this.B_Oku.TabIndex = 1;
            this.B_Oku.Text = "Oku";
            this.B_Oku.UseVisualStyleBackColor = true;
            this.B_Oku.Click += new System.EventHandler(this.B_Oku_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(138, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(268, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sayfa";
            // 
            // TB_Kaynak_Path
            // 
            this.TB_Kaynak_Path.Location = new System.Drawing.Point(138, 12);
            this.TB_Kaynak_Path.Name = "TB_Kaynak_Path";
            this.TB_Kaynak_Path.Size = new System.Drawing.Size(268, 20);
            this.TB_Kaynak_Path.TabIndex = 5;
            this.TB_Kaynak_Path.Text = "C:\\Users\\ISMAIL DEMIR\\Desktop\\EMIKON.xls";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kaynak";
            // 
            // B_KaynakYolu
            // 
            this.B_KaynakYolu.Location = new System.Drawing.Point(412, 10);
            this.B_KaynakYolu.Name = "B_KaynakYolu";
            this.B_KaynakYolu.Size = new System.Drawing.Size(75, 23);
            this.B_KaynakYolu.TabIndex = 1;
            this.B_KaynakYolu.Text = "Seç";
            this.B_KaynakYolu.UseVisualStyleBackColor = true;
            this.B_KaynakYolu.Click += new System.EventHandler(this.B_KaynakYolu_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "- - -";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(413, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(147, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "İlk Satırı Sütun Başlığı yap";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DGV_Excel1
            // 
            this.DGV_Excel1.AllowUserToAddRows = false;
            this.DGV_Excel1.AllowUserToDeleteRows = false;
            this.DGV_Excel1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Excel1.Location = new System.Drawing.Point(11, 76);
            this.DGV_Excel1.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_Excel1.Name = "DGV_Excel1";
            this.DGV_Excel1.RowTemplate.Height = 24;
            this.DGV_Excel1.Size = new System.Drawing.Size(965, 276);
            this.DGV_Excel1.TabIndex = 7;
            // 
            // DGV_SearchResult
            // 
            this.DGV_SearchResult.AllowUserToAddRows = false;
            this.DGV_SearchResult.AllowUserToDeleteRows = false;
            this.DGV_SearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SearchResult.Location = new System.Drawing.Point(11, 356);
            this.DGV_SearchResult.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_SearchResult.Name = "DGV_SearchResult";
            this.DGV_SearchResult.RowTemplate.Height = 24;
            this.DGV_SearchResult.Size = new System.Drawing.Size(965, 267);
            this.DGV_SearchResult.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(981, 240);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(373, 20);
            this.textBox3.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(981, 102);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(173, 20);
            this.dateTimePicker1.TabIndex = 10;
            this.dateTimePicker1.Value = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(981, 128);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(173, 20);
            this.dateTimePicker2.TabIndex = 10;
            this.dateTimePicker2.Value = new System.DateTime(2017, 12, 5, 0, 0, 0, 0);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1161, 102);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(67, 20);
            this.textBox4.TabIndex = 5;
            this.textBox4.Text = "12:20:00";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1162, 128);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(66, 20);
            this.textBox5.TabIndex = 5;
            this.textBox5.Text = "20:35:00";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1153, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 43);
            this.button2.TabIndex = 8;
            this.button2.Text = "Ara Time";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(981, 266);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(373, 20);
            this.textBox6.TabIndex = 5;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(981, 292);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(373, 20);
            this.textBox7.TabIndex = 5;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(981, 76);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(247, 20);
            this.textBox8.TabIndex = 5;
            this.textBox8.Text = "KAPAK";
            // 
            // TB_Status
            // 
            this.TB_Status.Location = new System.Drawing.Point(694, 16);
            this.TB_Status.Name = "TB_Status";
            this.TB_Status.Size = new System.Drawing.Size(373, 20);
            this.TB_Status.TabIndex = 5;
            // 
            // LBStatus
            // 
            this.LBStatus.AutoSize = true;
            this.LBStatus.Location = new System.Drawing.Point(645, 19);
            this.LBStatus.Name = "LBStatus";
            this.LBStatus.Size = new System.Drawing.Size(43, 13);
            this.LBStatus.TabIndex = 4;
            this.LBStatus.Text = "Status :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 623);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DGV_SearchResult);
            this.Controls.Add(this.DGV_Excel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.TB_Status);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.TB_Kaynak_Path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LBStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.B_KaynakYolu);
            this.Controls.Add(this.B_Oku);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Excel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button B_Oku;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Kaynak_Path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button B_KaynakYolu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridView DGV_Excel1;
        private System.Windows.Forms.DataGridView DGV_SearchResult;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox TB_Status;
        private System.Windows.Forms.Label LBStatus;
    }
}

