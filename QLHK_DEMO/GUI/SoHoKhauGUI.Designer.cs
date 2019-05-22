namespace GUI
{
    partial class SoHoKhauGUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSoSoHoKhau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgayCap = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSoDangKy = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cbbChuHo = new System.Windows.Forms.ComboBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dGVNhanKhau = new System.Windows.Forms.DataGridView();
            this.btnXoaNhanKhau = new System.Windows.Forms.Button();
            this.btnSuaNhanKhau = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVNhanKhau)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số sổ hộ khẩu";
            // 
            // tbSoSoHoKhau
            // 
            this.tbSoSoHoKhau.Location = new System.Drawing.Point(88, 22);
            this.tbSoSoHoKhau.Name = "tbSoSoHoKhau";
            this.tbSoSoHoKhau.Size = new System.Drawing.Size(226, 20);
            this.tbSoSoHoKhau.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chủ hộ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa Chỉ";
            // 
            // tbDiaChi
            // 
            this.tbDiaChi.Location = new System.Drawing.Point(88, 115);
            this.tbDiaChi.Name = "tbDiaChi";
            this.tbDiaChi.Size = new System.Drawing.Size(311, 20);
            this.tbDiaChi.TabIndex = 3;
            this.tbDiaChi.Enter += new System.EventHandler(this.tbDiaChi_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ngày cấp";
            // 
            // dtpNgayCap
            // 
            this.dtpNgayCap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayCap.Location = new System.Drawing.Point(88, 84);
            this.dtpNgayCap.Name = "dtpNgayCap";
            this.dtpNgayCap.Size = new System.Drawing.Size(311, 20);
            this.dtpNgayCap.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Số đăng ký";
            // 
            // tbSoDangKy
            // 
            this.tbSoDangKy.Location = new System.Drawing.Point(88, 144);
            this.tbSoDangKy.Name = "tbSoDangKy";
            this.tbSoDangKy.Size = new System.Drawing.Size(311, 20);
            this.tbSoDangKy.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.cbbChuHo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbSoSoHoKhau);
            this.groupBox1.Controls.Add(this.dtpNgayCap);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbSoDangKy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbDiaChi);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 206);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phần thông tin sổ hộ khẩu";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(324, 21);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cbbChuHo
            // 
            this.cbbChuHo.FormattingEnabled = true;
            this.cbbChuHo.Location = new System.Drawing.Point(88, 52);
            this.cbbChuHo.Name = "cbbChuHo";
            this.cbbChuHo.Size = new System.Drawing.Size(311, 21);
            this.cbbChuHo.TabIndex = 2;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(69, 170);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(101, 23);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(69, 21);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dGVNhanKhau);
            this.groupBox2.Location = new System.Drawing.Point(12, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 241);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Phần thông tin nhân khẩu";
            // 
            // dGVNhanKhau
            // 
            this.dGVNhanKhau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVNhanKhau.Location = new System.Drawing.Point(9, 19);
            this.dGVNhanKhau.Name = "dGVNhanKhau";
            this.dGVNhanKhau.Size = new System.Drawing.Size(735, 196);
            this.dGVNhanKhau.TabIndex = 0;
            this.dGVNhanKhau.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVNhanKhau_CellContentClick);
            this.dGVNhanKhau.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVNhanKhau_CellContentDoubleClick);
            // 
            // btnXoaNhanKhau
            // 
            this.btnXoaNhanKhau.Location = new System.Drawing.Point(69, 141);
            this.btnXoaNhanKhau.Name = "btnXoaNhanKhau";
            this.btnXoaNhanKhau.Size = new System.Drawing.Size(101, 23);
            this.btnXoaNhanKhau.TabIndex = 9;
            this.btnXoaNhanKhau.Text = "Xóa Nhân khẩu";
            this.btnXoaNhanKhau.UseVisualStyleBackColor = true;
            this.btnXoaNhanKhau.Visible = false;
            this.btnXoaNhanKhau.Click += new System.EventHandler(this.btnXoaNhanKhau_Click);
            // 
            // btnSuaNhanKhau
            // 
            this.btnSuaNhanKhau.Location = new System.Drawing.Point(69, 112);
            this.btnSuaNhanKhau.Name = "btnSuaNhanKhau";
            this.btnSuaNhanKhau.Size = new System.Drawing.Size(101, 23);
            this.btnSuaNhanKhau.TabIndex = 9;
            this.btnSuaNhanKhau.Text = "Sửa Nhân khẩu";
            this.btnSuaNhanKhau.UseVisualStyleBackColor = true;
            this.btnSuaNhanKhau.Visible = false;
            this.btnSuaNhanKhau.Click += new System.EventHandler(this.btnSuaNhanKhau_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(69, 83);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(101, 23);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm Nhân khẩu";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnXoa);
            this.groupBox3.Controls.Add(this.btnXoaNhanKhau);
            this.groupBox3.Controls.Add(this.btnSuaNhanKhau);
            this.groupBox3.Controls.Add(this.btnThem);
            this.groupBox3.Controls.Add(this.btnOK);
            this.groupBox3.Controls.Add(this.btnHuy);
            this.groupBox3.Location = new System.Drawing.Point(546, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(241, 202);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thao tác";
            // 
            // btnXoa
            // 
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(69, 50);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(101, 23);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // SoHoKhauGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 477);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SoHoKhauGUI";
            this.Text = "Sổ hộ khẩu";
            this.Load += new System.EventHandler(this.SoHoKhauGUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVNhanKhau)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSoSoHoKhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpNgayCap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSoDangKy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dGVNhanKhau;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbbChuHo;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXoaNhanKhau;
        private System.Windows.Forms.Button btnSuaNhanKhau;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnXoa;
    }
}