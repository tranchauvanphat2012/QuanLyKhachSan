
namespace QLKS
{
    partial class ThanhToan
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
            this.label = new System.Windows.Forms.Label();
            this.txbKhachHang = new System.Windows.Forms.TextBox();
            this.txbTenPhong = new System.Windows.Forms.TextBox();
            this.txbTienThuePhong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbGhiChu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nhânViênThanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TmiTen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpkNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(52, 100);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(71, 17);
            this.label.TabIndex = 0;
            this.label.Text = "Mã Khách";
            // 
            // txbKhachHang
            // 
            this.txbKhachHang.Location = new System.Drawing.Point(138, 100);
            this.txbKhachHang.Name = "txbKhachHang";
            this.txbKhachHang.ReadOnly = true;
            this.txbKhachHang.Size = new System.Drawing.Size(100, 22);
            this.txbKhachHang.TabIndex = 1;
            // 
            // txbTenPhong
            // 
            this.txbTenPhong.Location = new System.Drawing.Point(431, 103);
            this.txbTenPhong.Name = "txbTenPhong";
            this.txbTenPhong.ReadOnly = true;
            this.txbTenPhong.Size = new System.Drawing.Size(144, 22);
            this.txbTenPhong.TabIndex = 3;
            // 
            // txbTienThuePhong
            // 
            this.txbTienThuePhong.Location = new System.Drawing.Point(749, 100);
            this.txbTienThuePhong.Name = "txbTienThuePhong";
            this.txbTienThuePhong.ReadOnly = true;
            this.txbTienThuePhong.Size = new System.Drawing.Size(126, 22);
            this.txbTienThuePhong.TabIndex = 5;
            this.txbTienThuePhong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(625, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tiền Thuê Phòng";
            // 
            // txbGhiChu
            // 
            this.txbGhiChu.Location = new System.Drawing.Point(138, 181);
            this.txbGhiChu.Multiline = true;
            this.txbGhiChu.Name = "txbGhiChu";
            this.txbGhiChu.Size = new System.Drawing.Size(737, 230);
            this.txbGhiChu.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ghi Chú";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(881, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "VNĐ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhânViênThanhToánToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(949, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nhânViênThanhToánToolStripMenuItem
            // 
            this.nhânViênThanhToánToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TmiTen});
            this.nhânViênThanhToánToolStripMenuItem.Name = "nhânViênThanhToánToolStripMenuItem";
            this.nhânViênThanhToánToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.nhânViênThanhToánToolStripMenuItem.Text = "Nhân Viên Thanh Toán";
            // 
            // TmiTen
            // 
            this.TmiTen.Name = "TmiTen";
            this.TmiTen.Size = new System.Drawing.Size(250, 26);
            this.TmiTen.Text = "Tên Người Thanh Thoán";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(382, 448);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(275, 45);
            this.btnThanhToan.TabIndex = 10;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ngày Thanh Toán";
            // 
            // dtpkNgay
            // 
            this.dtpkNgay.Enabled = false;
            this.dtpkNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkNgay.Location = new System.Drawing.Point(367, 26);
            this.dtpkNgay.Name = "dtpkNgay";
            this.dtpkNgay.Size = new System.Drawing.Size(143, 22);
            this.dtpkNgay.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Danh Sách Phòng";
            // 
            // ThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 552);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpkNgay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbGhiChu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbTienThuePhong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbTenPhong);
            this.Controls.Add(this.txbKhachHang);
            this.Controls.Add(this.label);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThanhToan";
            this.Load += new System.EventHandler(this.ThanhToan_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txbKhachHang;
        private System.Windows.Forms.TextBox txbTenPhong;
        private System.Windows.Forms.TextBox txbTienThuePhong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbGhiChu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nhânViênThanhToánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TmiTen;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpkNgay;
        private System.Windows.Forms.Label label1;
    }
}