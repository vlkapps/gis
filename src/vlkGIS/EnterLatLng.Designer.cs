namespace vlkGIS
{
    partial class EnterLatLng
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
            this.Lat_label = new System.Windows.Forms.Label();
            this.Lng_label = new System.Windows.Forms.Label();
            this.Lat_textBox = new System.Windows.Forms.TextBox();
            this.Lng_textBox = new System.Windows.Forms.TextBox();
            this.OK_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.Lat_comboBox = new System.Windows.Forms.ComboBox();
            this.Lng_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Lat_label
            // 
            this.Lat_label.AutoSize = true;
            this.Lat_label.Location = new System.Drawing.Point(14, 17);
            this.Lat_label.Name = "Lat_label";
            this.Lat_label.Size = new System.Drawing.Size(22, 16);
            this.Lat_label.TabIndex = 0;
            this.Lat_label.Text = "lat";
            // 
            // Lng_label
            // 
            this.Lng_label.AutoSize = true;
            this.Lng_label.Location = new System.Drawing.Point(14, 48);
            this.Lng_label.Name = "Lng_label";
            this.Lng_label.Size = new System.Drawing.Size(25, 16);
            this.Lng_label.TabIndex = 1;
            this.Lng_label.Text = "lng";
            // 
            // Lat_textBox
            // 
            this.Lat_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lat_textBox.Location = new System.Drawing.Point(79, 14);
            this.Lat_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Lat_textBox.Name = "Lat_textBox";
            this.Lat_textBox.Size = new System.Drawing.Size(169, 22);
            this.Lat_textBox.TabIndex = 2;
            // 
            // Lng_textBox
            // 
            this.Lng_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lng_textBox.Location = new System.Drawing.Point(79, 44);
            this.Lng_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Lng_textBox.Name = "Lng_textBox";
            this.Lng_textBox.Size = new System.Drawing.Size(169, 22);
            this.Lng_textBox.TabIndex = 3;
            // 
            // OK_button
            // 
            this.OK_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_button.ForeColor = System.Drawing.Color.Black;
            this.OK_button.Location = new System.Drawing.Point(255, 87);
            this.OK_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(87, 28);
            this.OK_button.TabIndex = 4;
            this.OK_button.Text = "ok";
            this.OK_button.UseVisualStyleBackColor = true;
            this.OK_button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_button.ForeColor = System.Drawing.Color.Black;
            this.Cancel_button.Location = new System.Drawing.Point(161, 87);
            this.Cancel_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(87, 28);
            this.Cancel_button.TabIndex = 5;
            this.Cancel_button.Text = "cancel";
            this.Cancel_button.UseVisualStyleBackColor = true;
            // 
            // Lat_comboBox
            // 
            this.Lat_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lat_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Lat_comboBox.FormattingEnabled = true;
            this.Lat_comboBox.Location = new System.Drawing.Point(254, 13);
            this.Lat_comboBox.Name = "Lat_comboBox";
            this.Lat_comboBox.Size = new System.Drawing.Size(88, 24);
            this.Lat_comboBox.TabIndex = 6;
            // 
            // Lng_comboBox
            // 
            this.Lng_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lng_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Lng_comboBox.FormattingEnabled = true;
            this.Lng_comboBox.Location = new System.Drawing.Point(254, 43);
            this.Lng_comboBox.Name = "Lng_comboBox";
            this.Lng_comboBox.Size = new System.Drawing.Size(88, 24);
            this.Lng_comboBox.TabIndex = 7;
            // 
            // EnterLatLng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 130);
            this.Controls.Add(this.Lng_comboBox);
            this.Controls.Add(this.Lat_comboBox);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.Lng_textBox);
            this.Controls.Add(this.Lat_textBox);
            this.Controls.Add(this.Lng_label);
            this.Controls.Add(this.Lat_label);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterLatLng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lat_label;
        private System.Windows.Forms.Label Lng_label;
        private System.Windows.Forms.TextBox Lat_textBox;
        private System.Windows.Forms.TextBox Lng_textBox;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.ComboBox Lat_comboBox;
        private System.Windows.Forms.ComboBox Lng_comboBox;
    }
}