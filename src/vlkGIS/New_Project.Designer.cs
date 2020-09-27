namespace vlkGIS
{
    partial class New_Project
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
            this.Name_label = new System.Windows.Forms.Label();
            this.Name_textBox = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Uri_label = new System.Windows.Forms.Label();
            this.Uri_textBox = new System.Windows.Forms.TextBox();
            this.Browse_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Name_label
            // 
            this.Name_label.AutoSize = true;
            this.Name_label.Location = new System.Drawing.Point(14, 11);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(40, 16);
            this.Name_label.TabIndex = 0;
            this.Name_label.Text = "name";
            // 
            // Name_textBox
            // 
            this.Name_textBox.Location = new System.Drawing.Point(17, 31);
            this.Name_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(327, 22);
            this.Name_textBox.TabIndex = 1;
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CreateButton.ForeColor = System.Drawing.Color.Black;
            this.CreateButton.Location = new System.Drawing.Point(138, 122);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(87, 28);
            this.CreateButton.TabIndex = 2;
            this.CreateButton.Text = "create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // Uri_label
            // 
            this.Uri_label.AutoSize = true;
            this.Uri_label.Location = new System.Drawing.Point(14, 59);
            this.Uri_label.Name = "Uri_label";
            this.Uri_label.Size = new System.Drawing.Size(22, 16);
            this.Uri_label.TabIndex = 3;
            this.Uri_label.Text = "uri";
            // 
            // Uri_textBox
            // 
            this.Uri_textBox.Location = new System.Drawing.Point(17, 79);
            this.Uri_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Uri_textBox.Name = "Uri_textBox";
            this.Uri_textBox.Size = new System.Drawing.Size(233, 22);
            this.Uri_textBox.TabIndex = 4;
            // 
            // Browse_button
            // 
            this.Browse_button.ForeColor = System.Drawing.Color.Black;
            this.Browse_button.Location = new System.Drawing.Point(258, 76);
            this.Browse_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Browse_button.Name = "Browse_button";
            this.Browse_button.Size = new System.Drawing.Size(87, 28);
            this.Browse_button.TabIndex = 5;
            this.Browse_button.Text = "browse";
            this.Browse_button.UseVisualStyleBackColor = true;
            this.Browse_button.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // New_Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 165);
            this.Controls.Add(this.Browse_button);
            this.Controls.Add(this.Uri_textBox);
            this.Controls.Add(this.Uri_label);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.Name_textBox);
            this.Controls.Add(this.Name_label);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "New_Project";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New project";
            this.Load += new System.EventHandler(this.New_Project_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Name_label;
        private System.Windows.Forms.TextBox Name_textBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label Uri_label;
        private System.Windows.Forms.TextBox Uri_textBox;
        private System.Windows.Forms.Button Browse_button;
    }
}