
namespace GUI
{
    partial class frmQuenMatKhau
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
            this.btnQuenPass = new System.Windows.Forms.Button();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.lblTenTaiKhoan = new System.Windows.Forms.Label();
            this.txtEmailDK = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuenPass
            // 
            this.btnQuenPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuenPass.Location = new System.Drawing.Point(150, 299);
            this.btnQuenPass.Name = "btnQuenPass";
            this.btnQuenPass.Size = new System.Drawing.Size(153, 38);
            this.btnQuenPass.TabIndex = 25;
            this.btnQuenPass.Text = "Lấy lại mật khẩu";
            this.btnQuenPass.UseVisualStyleBackColor = true;
            this.btnQuenPass.Click += new System.EventHandler(this.btnQuenPass_Click);
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetQua.ForeColor = System.Drawing.Color.Blue;
            this.lblKetQua.Location = new System.Drawing.Point(50, 238);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(58, 18);
            this.lblKetQua.TabIndex = 19;
            this.lblKetQua.Text = "Kết quả";
            // 
            // lblTenTaiKhoan
            // 
            this.lblTenTaiKhoan.AutoSize = true;
            this.lblTenTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTaiKhoan.ForeColor = System.Drawing.Color.Blue;
            this.lblTenTaiKhoan.Location = new System.Drawing.Point(50, 201);
            this.lblTenTaiKhoan.Name = "lblTenTaiKhoan";
            this.lblTenTaiKhoan.Size = new System.Drawing.Size(100, 18);
            this.lblTenTaiKhoan.TabIndex = 20;
            this.lblTenTaiKhoan.Text = "Email đăng ký";
            // 
            // txtEmailDK
            // 
            this.txtEmailDK.Location = new System.Drawing.Point(194, 202);
            this.txtEmailDK.Name = "txtEmailDK";
            this.txtEmailDK.Size = new System.Drawing.Size(205, 20);
            this.txtEmailDK.TabIndex = 24;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.login;
            this.pictureBox1.Location = new System.Drawing.Point(76, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // frmQuenMatKhau
            // 
            this.AcceptButton = this.btnQuenPass;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 393);
            this.Controls.Add(this.btnQuenPass);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.lblTenTaiKhoan);
            this.Controls.Add(this.txtEmailDK);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmQuenMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuenMatKhau";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuenPass;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Label lblTenTaiKhoan;
        private System.Windows.Forms.TextBox txtEmailDK;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}