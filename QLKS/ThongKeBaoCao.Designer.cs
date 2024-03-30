
namespace QLKS
{
    partial class ThongKeBaoCao
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpThu = new System.Windows.Forms.TabPage();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnThongKeThu = new System.Windows.Forms.Button();
            this.dtgvThongKeThu = new System.Windows.Forms.DataGridView();
            this.dtpkNgayKetThucBieuDo = new System.Windows.Forms.DateTimePicker();
            this.dtpkNgayBatDauBieuDo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpChi = new System.Windows.Forms.TabPage();
            this.btnLapHoaDon = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.vềCửaSổChínhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiTenNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeThu)).BeginInit();
            this.tpChi.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpThu);
            this.tabControl1.Controls.Add(this.tpChi);
            this.tabControl1.Location = new System.Drawing.Point(3, 30);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1333, 746);
            this.tabControl1.TabIndex = 0;
            // 
            // tpThu
            // 
            this.tpThu.Controls.Add(this.btnLamMoi);
            this.tpThu.Controls.Add(this.label5);
            this.tpThu.Controls.Add(this.txtTongTien);
            this.tpThu.Controls.Add(this.btnThongKeThu);
            this.tpThu.Controls.Add(this.dtgvThongKeThu);
            this.tpThu.Controls.Add(this.dtpkNgayKetThucBieuDo);
            this.tpThu.Controls.Add(this.dtpkNgayBatDauBieuDo);
            this.tpThu.Controls.Add(this.label3);
            this.tpThu.Controls.Add(this.label2);
            this.tpThu.Location = new System.Drawing.Point(4, 25);
            this.tpThu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpThu.Name = "tpThu";
            this.tpThu.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpThu.Size = new System.Drawing.Size(1325, 717);
            this.tpThu.TabIndex = 0;
            this.tpThu.Text = "Thu";
            this.tpThu.UseVisualStyleBackColor = true;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(597, 140);
            this.txtTongTien.Multiline = true;
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(709, 95);
            this.txtTongTien.TabIndex = 29;
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnThongKeThu
            // 
            this.btnThongKeThu.Location = new System.Drawing.Point(600, 301);
            this.btnThongKeThu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThongKeThu.Name = "btnThongKeThu";
            this.btnThongKeThu.Size = new System.Drawing.Size(262, 61);
            this.btnThongKeThu.TabIndex = 28;
            this.btnThongKeThu.Text = "Thống Kê";
            this.btnThongKeThu.UseVisualStyleBackColor = true;
            this.btnThongKeThu.Click += new System.EventHandler(this.btnThongKeThu_Click);
            // 
            // dtgvThongKeThu
            // 
            this.dtgvThongKeThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongKeThu.Location = new System.Drawing.Point(8, 21);
            this.dtgvThongKeThu.Name = "dtgvThongKeThu";
            this.dtgvThongKeThu.RowHeadersWidth = 51;
            this.dtgvThongKeThu.RowTemplate.Height = 24;
            this.dtgvThongKeThu.Size = new System.Drawing.Size(574, 538);
            this.dtgvThongKeThu.TabIndex = 27;
            // 
            // dtpkNgayKetThucBieuDo
            // 
            this.dtpkNgayKetThucBieuDo.Location = new System.Drawing.Point(1050, 93);
            this.dtpkNgayKetThucBieuDo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpkNgayKetThucBieuDo.Name = "dtpkNgayKetThucBieuDo";
            this.dtpkNgayKetThucBieuDo.Size = new System.Drawing.Size(256, 22);
            this.dtpkNgayKetThucBieuDo.TabIndex = 24;
            // 
            // dtpkNgayBatDauBieuDo
            // 
            this.dtpkNgayBatDauBieuDo.Location = new System.Drawing.Point(597, 93);
            this.dtpkNgayBatDauBieuDo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpkNgayBatDauBieuDo.Name = "dtpkNgayBatDauBieuDo";
            this.dtpkNgayBatDauBieuDo.Size = new System.Drawing.Size(265, 22);
            this.dtpkNgayBatDauBieuDo.TabIndex = 22;
            this.dtpkNgayBatDauBieuDo.Value = new System.DateTime(2023, 12, 16, 11, 52, 56, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1047, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Ngày kết thúc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(597, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Ngày bắt đầu";
            // 
            // tpChi
            // 
            this.tpChi.Controls.Add(this.btnLapHoaDon);
            this.tpChi.Controls.Add(this.button1);
            this.tpChi.Controls.Add(this.button2);
            this.tpChi.Controls.Add(this.dateTimePicker1);
            this.tpChi.Controls.Add(this.dateTimePicker2);
            this.tpChi.Controls.Add(this.label1);
            this.tpChi.Controls.Add(this.label4);
            this.tpChi.Controls.Add(this.panel1);
            this.tpChi.Location = new System.Drawing.Point(4, 25);
            this.tpChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpChi.Name = "tpChi";
            this.tpChi.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpChi.Size = new System.Drawing.Size(1325, 717);
            this.tpChi.TabIndex = 1;
            this.tpChi.Text = "Chi";
            this.tpChi.UseVisualStyleBackColor = true;
            // 
            // btnLapHoaDon
            // 
            this.btnLapHoaDon.Location = new System.Drawing.Point(845, 39);
            this.btnLapHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLapHoaDon.Name = "btnLapHoaDon";
            this.btnLapHoaDon.Size = new System.Drawing.Size(93, 23);
            this.btnLapHoaDon.TabIndex = 34;
            this.btnLapHoaDon.Text = "Lập hóa đơn";
            this.btnLapHoaDon.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1227, 46);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "In báo cáo";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(571, 37);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "Xem";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(308, 38);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(256, 22);
            this.dateTimePicker1.TabIndex = 31;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(5, 38);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker2.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Ngày kết thúc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Ngày bắt đầu";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(5, 74);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1315, 597);
            this.panel1.TabIndex = 27;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vềCửaSổChínhToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem,
            this.quảnLýToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1341, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // vềCửaSổChínhToolStripMenuItem
            // 
            this.vềCửaSổChínhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiTenNhanVien});
            this.vềCửaSổChínhToolStripMenuItem.Name = "vềCửaSổChínhToolStripMenuItem";
            this.vềCửaSổChínhToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.vềCửaSổChínhToolStripMenuItem.Text = "Thông tin cá nhân";
            this.vềCửaSổChínhToolStripMenuItem.Click += new System.EventHandler(this.vềCửaSổChínhToolStripMenuItem_Click);
            // 
            // tmiTenNhanVien
            // 
            this.tmiTenNhanVien.Name = "tmiTenNhanVien";
            this.tmiTenNhanVien.Size = new System.Drawing.Size(224, 26);
            this.tmiTenNhanVien.Text = "Tên nhân viên";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.quảnLýToolStripMenuItem.Text = "Quản Lý";
            this.quảnLýToolStripMenuItem.Click += new System.EventHandler(this.quảnLýToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(915, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 25);
            this.label5.TabIndex = 30;
            this.label5.Text = "Đến";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(1050, 301);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(247, 61);
            this.btnLamMoi.TabIndex = 31;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // ThongKeBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 637);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ThongKeBaoCao";
            this.Text = "Thống kê báo cáo";
            this.Load += new System.EventHandler(this.ThongKeBaoCao_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpThu.ResumeLayout(false);
            this.tpThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeThu)).EndInit();
            this.tpChi.ResumeLayout(false);
            this.tpChi.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpThu;
        private System.Windows.Forms.TabPage tpChi;
        private System.Windows.Forms.DateTimePicker dtpkNgayKetThucBieuDo;
        private System.Windows.Forms.DateTimePicker dtpkNgayBatDauBieuDo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnLapHoaDon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem vềCửaSổChínhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmiTenNhanVien;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.DataGridView dtgvThongKeThu;
        private System.Windows.Forms.Button btnThongKeThu;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label5;
    }
}