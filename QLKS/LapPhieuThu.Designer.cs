
namespace QLKS
{
    partial class LapPhieuThu
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
            this.btnLap = new System.Windows.Forms.Button();
            this.dtgvThongKeThu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeThu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLap
            // 
            this.btnLap.Location = new System.Drawing.Point(651, 330);
            this.btnLap.Name = "btnLap";
            this.btnLap.Size = new System.Drawing.Size(121, 23);
            this.btnLap.TabIndex = 0;
            this.btnLap.Text = "Lập ";
            this.btnLap.UseVisualStyleBackColor = true;
            this.btnLap.Click += new System.EventHandler(this.btnLap_Click);
            // 
            // dtgvThongKeThu
            // 
            this.dtgvThongKeThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongKeThu.Location = new System.Drawing.Point(2, 31);
            this.dtgvThongKeThu.Name = "dtgvThongKeThu";
            this.dtgvThongKeThu.RowHeadersWidth = 51;
            this.dtgvThongKeThu.RowTemplate.Height = 24;
            this.dtgvThongKeThu.Size = new System.Drawing.Size(804, 266);
            this.dtgvThongKeThu.TabIndex = 29;
            // 
            // LapPhieuThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 418);
            this.Controls.Add(this.dtgvThongKeThu);
            this.Controls.Add(this.btnLap);
            this.Name = "LapPhieuThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LapPhieuThu";
            this.Load += new System.EventHandler(this.LapPhieuThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeThu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLap;
        private System.Windows.Forms.DataGridView dtgvThongKeThu;
    }
}