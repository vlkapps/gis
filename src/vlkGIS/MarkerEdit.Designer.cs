namespace vlkGIS
{
    partial class MarkerEdit
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
            this.Location_groupBox = new System.Windows.Forms.GroupBox();
            this.Lng_comboBox = new System.Windows.Forms.ComboBox();
            this.Lat_comboBox = new System.Windows.Forms.ComboBox();
            this.Lng_textBox = new System.Windows.Forms.TextBox();
            this.Lat_textBox = new System.Windows.Forms.TextBox();
            this.Lng_label = new System.Windows.Forms.Label();
            this.Lat_label = new System.Windows.Forms.Label();
            this.Name_label = new System.Windows.Forms.Label();
            this.Name_textBox = new System.Windows.Forms.TextBox();
            this.Desc_label = new System.Windows.Forms.Label();
            this.Desc_textBox = new System.Windows.Forms.TextBox();
            this.Images_label = new System.Windows.Forms.Label();
            this.Color_label = new System.Windows.Forms.Label();
            this.Color_comboBox = new System.Windows.Forms.ComboBox();
            this.OK_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.Add_Images_button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Images_listView = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Location_groupBox.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Location_groupBox
            // 
            this.Location_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Location_groupBox.Controls.Add(this.Lng_comboBox);
            this.Location_groupBox.Controls.Add(this.Lat_comboBox);
            this.Location_groupBox.Controls.Add(this.Lng_textBox);
            this.Location_groupBox.Controls.Add(this.Lat_textBox);
            this.Location_groupBox.Controls.Add(this.Lng_label);
            this.Location_groupBox.Controls.Add(this.Lat_label);
            this.Location_groupBox.Location = new System.Drawing.Point(14, 13);
            this.Location_groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Location_groupBox.Name = "Location_groupBox";
            this.Location_groupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Location_groupBox.Size = new System.Drawing.Size(358, 91);
            this.Location_groupBox.TabIndex = 0;
            this.Location_groupBox.TabStop = false;
            this.Location_groupBox.Text = "location";
            // 
            // Lng_comboBox
            // 
            this.Lng_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lng_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Lng_comboBox.FormattingEnabled = true;
            this.Lng_comboBox.Location = new System.Drawing.Point(256, 55);
            this.Lng_comboBox.Name = "Lng_comboBox";
            this.Lng_comboBox.Size = new System.Drawing.Size(88, 24);
            this.Lng_comboBox.TabIndex = 13;
            // 
            // Lat_comboBox
            // 
            this.Lat_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lat_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Lat_comboBox.FormattingEnabled = true;
            this.Lat_comboBox.Location = new System.Drawing.Point(256, 25);
            this.Lat_comboBox.Name = "Lat_comboBox";
            this.Lat_comboBox.Size = new System.Drawing.Size(88, 24);
            this.Lat_comboBox.TabIndex = 12;
            // 
            // Lng_textBox
            // 
            this.Lng_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lng_textBox.Location = new System.Drawing.Point(71, 56);
            this.Lng_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Lng_textBox.Name = "Lng_textBox";
            this.Lng_textBox.Size = new System.Drawing.Size(179, 22);
            this.Lng_textBox.TabIndex = 11;
            // 
            // Lat_textBox
            // 
            this.Lat_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lat_textBox.Location = new System.Drawing.Point(71, 26);
            this.Lat_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Lat_textBox.Name = "Lat_textBox";
            this.Lat_textBox.Size = new System.Drawing.Size(179, 22);
            this.Lat_textBox.TabIndex = 10;
            // 
            // Lng_label
            // 
            this.Lng_label.AutoSize = true;
            this.Lng_label.Location = new System.Drawing.Point(6, 60);
            this.Lng_label.Name = "Lng_label";
            this.Lng_label.Size = new System.Drawing.Size(25, 16);
            this.Lng_label.TabIndex = 9;
            this.Lng_label.Text = "lng";
            // 
            // Lat_label
            // 
            this.Lat_label.AutoSize = true;
            this.Lat_label.Location = new System.Drawing.Point(6, 29);
            this.Lat_label.Name = "Lat_label";
            this.Lat_label.Size = new System.Drawing.Size(22, 16);
            this.Lat_label.TabIndex = 8;
            this.Lat_label.Text = "lat";
            // 
            // Name_label
            // 
            this.Name_label.AutoSize = true;
            this.Name_label.Location = new System.Drawing.Point(20, 117);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(40, 16);
            this.Name_label.TabIndex = 1;
            this.Name_label.Text = "name";
            // 
            // Name_textBox
            // 
            this.Name_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Name_textBox.Location = new System.Drawing.Point(91, 114);
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(267, 22);
            this.Name_textBox.TabIndex = 2;
            // 
            // Desc_label
            // 
            this.Desc_label.AutoSize = true;
            this.Desc_label.Location = new System.Drawing.Point(20, 148);
            this.Desc_label.Name = "Desc_label";
            this.Desc_label.Size = new System.Drawing.Size(36, 16);
            this.Desc_label.TabIndex = 3;
            this.Desc_label.Text = "desc";
            // 
            // Desc_textBox
            // 
            this.Desc_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Desc_textBox.Location = new System.Drawing.Point(23, 167);
            this.Desc_textBox.Multiline = true;
            this.Desc_textBox.Name = "Desc_textBox";
            this.Desc_textBox.Size = new System.Drawing.Size(335, 146);
            this.Desc_textBox.TabIndex = 4;
            // 
            // Images_label
            // 
            this.Images_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Images_label.AutoSize = true;
            this.Images_label.Location = new System.Drawing.Point(20, 326);
            this.Images_label.Name = "Images_label";
            this.Images_label.Size = new System.Drawing.Size(50, 16);
            this.Images_label.TabIndex = 5;
            this.Images_label.Text = "images";
            // 
            // Color_label
            // 
            this.Color_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Color_label.AutoSize = true;
            this.Color_label.Location = new System.Drawing.Point(20, 460);
            this.Color_label.Name = "Color_label";
            this.Color_label.Size = new System.Drawing.Size(36, 16);
            this.Color_label.TabIndex = 7;
            this.Color_label.Text = "color";
            // 
            // Color_comboBox
            // 
            this.Color_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Color_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Color_comboBox.FormattingEnabled = true;
            this.Color_comboBox.Location = new System.Drawing.Point(63, 457);
            this.Color_comboBox.Name = "Color_comboBox";
            this.Color_comboBox.Size = new System.Drawing.Size(162, 24);
            this.Color_comboBox.TabIndex = 8;
            // 
            // OK_button
            // 
            this.OK_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_button.ForeColor = System.Drawing.Color.Black;
            this.OK_button.Location = new System.Drawing.Point(297, 508);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(75, 23);
            this.OK_button.TabIndex = 9;
            this.OK_button.Text = "ok";
            this.OK_button.UseVisualStyleBackColor = true;
            // 
            // Cancel_button
            // 
            this.Cancel_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_button.ForeColor = System.Drawing.Color.Black;
            this.Cancel_button.Location = new System.Drawing.Point(216, 508);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.TabIndex = 10;
            this.Cancel_button.Text = "cancel";
            this.Cancel_button.UseVisualStyleBackColor = true;
            // 
            // Add_Images_button
            // 
            this.Add_Images_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_Images_button.ForeColor = System.Drawing.Color.Black;
            this.Add_Images_button.Location = new System.Drawing.Point(236, 319);
            this.Add_Images_button.Name = "Add_Images_button";
            this.Add_Images_button.Size = new System.Drawing.Size(122, 23);
            this.Add_Images_button.TabIndex = 11;
            this.Add_Images_button.Text = "add";
            this.Add_Images_button.UseVisualStyleBackColor = true;
            this.Add_Images_button.Click += new System.EventHandler(this.Add_Images_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Изображения (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
            this.openFileDialog1.Multiselect = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(94, 74);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Images_listView
            // 
            this.Images_listView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.Images_listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Images_listView.BackColor = System.Drawing.Color.Gray;
            this.Images_listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Images_listView.ContextMenuStrip = this.contextMenuStrip1;
            this.Images_listView.Font = new System.Drawing.Font("Arial", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Images_listView.HideSelection = false;
            this.Images_listView.LabelWrap = false;
            this.Images_listView.LargeImageList = this.imageList1;
            this.Images_listView.Location = new System.Drawing.Point(23, 345);
            this.Images_listView.MultiSelect = false;
            this.Images_listView.Name = "Images_listView";
            this.Images_listView.Size = new System.Drawing.Size(335, 100);
            this.Images_listView.TabIndex = 12;
            this.Images_listView.UseCompatibleStateImageBehavior = false;
            this.Images_listView.DoubleClick += new System.EventHandler(this.Images_listView_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.DeleteToolStripMenuItem.Text = "Удалить";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // MarkerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 543);
            this.Controls.Add(this.Images_listView);
            this.Controls.Add(this.Add_Images_button);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.Color_comboBox);
            this.Controls.Add(this.Color_label);
            this.Controls.Add(this.Images_label);
            this.Controls.Add(this.Desc_textBox);
            this.Controls.Add(this.Desc_label);
            this.Controls.Add(this.Name_textBox);
            this.Controls.Add(this.Name_label);
            this.Controls.Add(this.Location_groupBox);
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MarkerEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Marker";
            this.Load += new System.EventHandler(this.MarkerEdit_Load);
            this.Location_groupBox.ResumeLayout(false);
            this.Location_groupBox.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Location_groupBox;
        private System.Windows.Forms.ComboBox Lng_comboBox;
        private System.Windows.Forms.ComboBox Lat_comboBox;
        private System.Windows.Forms.TextBox Lng_textBox;
        private System.Windows.Forms.TextBox Lat_textBox;
        private System.Windows.Forms.Label Lng_label;
        private System.Windows.Forms.Label Lat_label;
        private System.Windows.Forms.Label Name_label;
        private System.Windows.Forms.TextBox Name_textBox;
        private System.Windows.Forms.Label Desc_label;
        private System.Windows.Forms.TextBox Desc_textBox;
        private System.Windows.Forms.Label Images_label;
        private System.Windows.Forms.Label Color_label;
        private System.Windows.Forms.ComboBox Color_comboBox;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Button Add_Images_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView Images_listView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
    }
}