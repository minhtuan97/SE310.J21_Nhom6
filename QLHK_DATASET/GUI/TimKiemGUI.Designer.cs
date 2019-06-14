namespace GUI
{
    partial class TimKiemGUI
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
            this.rdHoKhau = new System.Windows.Forms.RadioButton();
            this.rdNhanKhau = new System.Windows.Forms.RadioButton();
            this.tbTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.rdTamTru = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdHoKhau
            // 
            this.rdHoKhau.AutoSize = true;
            this.rdHoKhau.Checked = true;
            this.rdHoKhau.Location = new System.Drawing.Point(39, 12);
            this.rdHoKhau.Name = "rdHoKhau";
            this.rdHoKhau.Size = new System.Drawing.Size(80, 17);
            this.rdHoKhau.TabIndex = 2;
            this.rdHoKhau.TabStop = true;
            this.rdHoKhau.Text = "Sổ hộ khẩu";
            this.rdHoKhau.UseVisualStyleBackColor = true;
            // 
            // rdNhanKhau
            // 
            this.rdNhanKhau.AutoSize = true;
            this.rdNhanKhau.Location = new System.Drawing.Point(39, 59);
            this.rdNhanKhau.Name = "rdNhanKhau";
            this.rdNhanKhau.Size = new System.Drawing.Size(78, 17);
            this.rdNhanKhau.TabIndex = 2;
            this.rdNhanKhau.Text = "Nhân khẩu";
            this.rdNhanKhau.UseVisualStyleBackColor = true;
            // 
            // tbTimKiem
            // 
            this.tbTimKiem.Location = new System.Drawing.Point(147, 23);
            this.tbTimKiem.Name = "tbTimKiem";
            this.tbTimKiem.Size = new System.Drawing.Size(273, 20);
            this.tbTimKiem.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(427, 23);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // rdTamTru
            // 
            this.rdTamTru.AutoSize = true;
            this.rdTamTru.Location = new System.Drawing.Point(39, 35);
            this.rdTamTru.Name = "rdTamTru";
            this.rdTamTru.Size = new System.Drawing.Size(73, 17);
            this.rdTamTru.TabIndex = 5;
            this.rdTamTru.TabStop = true;
            this.rdTamTru.Text = "Sổ tạm trú";
            this.rdTamTru.UseVisualStyleBackColor = true;
            // 
            // TimKiemGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 88);
            this.Controls.Add(this.rdTamTru);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.tbTimKiem);
            this.Controls.Add(this.rdHoKhau);
            this.Controls.Add(this.rdNhanKhau);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimKiemGUI";
            this.Text = "Tìm kiếm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdHoKhau;
        private System.Windows.Forms.RadioButton rdNhanKhau;
        private System.Windows.Forms.TextBox tbTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.RadioButton rdTamTru;
    }
}