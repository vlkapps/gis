namespace vlkGIS
{
    partial class AboutBox
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OK_Button = new System.Windows.Forms.Button();
            this.CompanyName_Label = new System.Windows.Forms.Label();
            this.Copyright_Label = new System.Windows.Forms.Label();
            this.Version_Label = new System.Windows.Forms.Label();
            this.ProductName_Label = new System.Windows.Forms.Label();
            this.Web_linkLabel = new System.Windows.Forms.LinkLabel();
            this.Mail1_linkLabel = new System.Windows.Forms.LinkLabel();
            this.Mail2_linkLabel = new System.Windows.Forms.LinkLabel();
            this.Logo_Company_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_Company_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OK_Button.ForeColor = System.Drawing.Color.Black;
            this.OK_Button.Location = new System.Drawing.Point(173, 301);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 24;
            this.OK_Button.Text = "&ОК";
            // 
            // CompanyName_Label
            // 
            this.CompanyName_Label.AutoSize = true;
            this.CompanyName_Label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CompanyName_Label.Location = new System.Drawing.Point(155, 147);
            this.CompanyName_Label.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.CompanyName_Label.Name = "CompanyName_Label";
            this.CompanyName_Label.Size = new System.Drawing.Size(198, 19);
            this.CompanyName_Label.TabIndex = 22;
            this.CompanyName_Label.Text = "Denis Volkov - VLK Apps";
            this.CompanyName_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Copyright_Label
            // 
            this.Copyright_Label.Location = new System.Drawing.Point(53, 89);
            this.Copyright_Label.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.Copyright_Label.Name = "Copyright_Label";
            this.Copyright_Label.Size = new System.Drawing.Size(315, 16);
            this.Copyright_Label.TabIndex = 21;
            this.Copyright_Label.Text = "author";
            this.Copyright_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Version_Label
            // 
            this.Version_Label.Location = new System.Drawing.Point(51, 59);
            this.Version_Label.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.Version_Label.Name = "Version_Label";
            this.Version_Label.Size = new System.Drawing.Size(318, 16);
            this.Version_Label.TabIndex = 0;
            this.Version_Label.Text = "ver";
            this.Version_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductName_Label
            // 
            this.ProductName_Label.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductName_Label.Location = new System.Drawing.Point(136, 12);
            this.ProductName_Label.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.ProductName_Label.Name = "ProductName_Label";
            this.ProductName_Label.Size = new System.Drawing.Size(148, 37);
            this.ProductName_Label.TabIndex = 19;
            this.ProductName_Label.Text = "vlkGIS";
            this.ProductName_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Web_linkLabel
            // 
            this.Web_linkLabel.AutoSize = true;
            this.Web_linkLabel.Location = new System.Drawing.Point(156, 174);
            this.Web_linkLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.Web_linkLabel.Name = "Web_linkLabel";
            this.Web_linkLabel.Size = new System.Drawing.Size(66, 16);
            this.Web_linkLabel.TabIndex = 26;
            this.Web_linkLabel.TabStop = true;
            this.Web_linkLabel.Text = "vlkapps.ru";
            this.Web_linkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Web_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Web_LinkLabel_LinkClicked);
            // 
            // Mail1_linkLabel
            // 
            this.Mail1_linkLabel.AutoSize = true;
            this.Mail1_linkLabel.Location = new System.Drawing.Point(156, 195);
            this.Mail1_linkLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.Mail1_linkLabel.Name = "Mail1_linkLabel";
            this.Mail1_linkLabel.Size = new System.Drawing.Size(114, 16);
            this.Mail1_linkLabel.TabIndex = 27;
            this.Mail1_linkLabel.TabStop = true;
            this.Mail1_linkLabel.Text = "vlkden@yandex.ru";
            this.Mail1_linkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mail1_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Mail1_LinkLabel_LinkClicked);
            // 
            // Mail2_linkLabel
            // 
            this.Mail2_linkLabel.AutoSize = true;
            this.Mail2_linkLabel.Location = new System.Drawing.Point(156, 216);
            this.Mail2_linkLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.Mail2_linkLabel.Name = "Mail2_linkLabel";
            this.Mail2_linkLabel.Size = new System.Drawing.Size(122, 16);
            this.Mail2_linkLabel.TabIndex = 28;
            this.Mail2_linkLabel.TabStop = true;
            this.Mail2_linkLabel.Text = "support@vlkapps.ru";
            this.Mail2_linkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mail2_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Mail2_LinkLabel_LinkClicked);
            // 
            // Logo_Company_pictureBox
            // 
            this.Logo_Company_pictureBox.Image = global::vlkGIS.Properties.Resources.logo_vlk;
            this.Logo_Company_pictureBox.Location = new System.Drawing.Point(12, 147);
            this.Logo_Company_pictureBox.Name = "Logo_Company_pictureBox";
            this.Logo_Company_pictureBox.Size = new System.Drawing.Size(131, 131);
            this.Logo_Company_pictureBox.TabIndex = 30;
            this.Logo_Company_pictureBox.TabStop = false;
            // 
            // AboutBox
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(420, 336);
            this.Controls.Add(this.Logo_Company_pictureBox);
            this.Controls.Add(this.ProductName_Label);
            this.Controls.Add(this.Version_Label);
            this.Controls.Add(this.Mail2_linkLabel);
            this.Controls.Add(this.Web_linkLabel);
            this.Controls.Add(this.Copyright_Label);
            this.Controls.Add(this.Mail1_linkLabel);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.CompanyName_Label);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.Logo_Company_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Label CompanyName_Label;
        private System.Windows.Forms.Label Copyright_Label;
        private System.Windows.Forms.Label Version_Label;
        private System.Windows.Forms.Label ProductName_Label;
        private System.Windows.Forms.LinkLabel Web_linkLabel;
        private System.Windows.Forms.LinkLabel Mail1_linkLabel;
        private System.Windows.Forms.LinkLabel Mail2_linkLabel;
        private System.Windows.Forms.PictureBox Logo_Company_pictureBox;
    }
}
