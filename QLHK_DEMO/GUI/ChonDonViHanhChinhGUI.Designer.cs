namespace GUI
{
    partial class ChonDonViHanhChinhGUI
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
            this.tbDiaChi = new System.Windows.Forms.TextBox();
            this.cbbXaPhuong = new System.Windows.Forms.ComboBox();
            this.cbbQuanHuyen = new System.Windows.Forms.ComboBox();
            this.cbbTinhThanh = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDiaChi
            // 
            this.tbDiaChi.Location = new System.Drawing.Point(12, 26);
            this.tbDiaChi.Name = "tbDiaChi";
            this.tbDiaChi.Size = new System.Drawing.Size(120, 20);
            this.tbDiaChi.TabIndex = 0;
            this.tbDiaChi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDiaChi_KeyDown);
            // 
            // cbbXaPhuong
            // 
            this.cbbXaPhuong.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbXaPhuong.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbXaPhuong.FormattingEnabled = true;
            this.cbbXaPhuong.Location = new System.Drawing.Point(138, 25);
            this.cbbXaPhuong.Name = "cbbXaPhuong";
            this.cbbXaPhuong.Size = new System.Drawing.Size(121, 21);
            this.cbbXaPhuong.TabIndex = 1;
            // 
            // cbbQuanHuyen
            // 
            this.cbbQuanHuyen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbQuanHuyen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbQuanHuyen.FormattingEnabled = true;
            this.cbbQuanHuyen.Location = new System.Drawing.Point(265, 25);
            this.cbbQuanHuyen.Name = "cbbQuanHuyen";
            this.cbbQuanHuyen.Size = new System.Drawing.Size(121, 21);
            this.cbbQuanHuyen.TabIndex = 1;
            this.cbbQuanHuyen.SelectedIndexChanged += new System.EventHandler(this.cbbQuanHuyen_SelectedIndexChanged);
            // 
            // cbbTinhThanh
            // 
            this.cbbTinhThanh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbTinhThanh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbTinhThanh.FormattingEnabled = true;
            this.cbbTinhThanh.Location = new System.Drawing.Point(392, 25);
            this.cbbTinhThanh.Name = "cbbTinhThanh";
            this.cbbTinhThanh.Size = new System.Drawing.Size(121, 21);
            this.cbbTinhThanh.TabIndex = 1;
            this.cbbTinhThanh.SelectedIndexChanged += new System.EventHandler(this.cbbTinhThanh_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(323, 67);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 22);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(426, 67);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 22);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ChonDonViHanhChinhGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 101);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbbTinhThanh);
            this.Controls.Add(this.cbbQuanHuyen);
            this.Controls.Add(this.cbbXaPhuong);
            this.Controls.Add(this.tbDiaChi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChonDonViHanhChinhGUI";
            this.Text = "Chọn đơn vị hành chính";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDiaChi;
        private System.Windows.Forms.ComboBox cbbXaPhuong;
        private System.Windows.Forms.ComboBox cbbQuanHuyen;
        private System.Windows.Forms.ComboBox cbbTinhThanh;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}