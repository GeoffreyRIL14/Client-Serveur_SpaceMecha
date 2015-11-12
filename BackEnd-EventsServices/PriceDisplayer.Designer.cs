namespace BackEnd_EventsServices
{
    partial class PriceDisplayer
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
            this.imageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveBtn = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.imagePb = new System.Windows.Forms.PictureBox();
            this.descriptionTb = new System.Windows.Forms.TextBox();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.idLb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.assetBundleLb = new System.Windows.Forms.Label();
            this.assetBtn = new System.Windows.Forms.Button();
            this.assetOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.imagePb)).BeginInit();
            this.SuspendLayout();
            // 
            // imageOpenFileDialog
            // 
            this.imageOpenFileDialog.FileName = "openFileDialog1";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(159, 505);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(90, 33);
            this.saveBtn.TabIndex = 19;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(225, 368);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(24, 23);
            this.browseBtn.TabIndex = 16;
            this.browseBtn.Text = "...";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // imagePb
            // 
            this.imagePb.Location = new System.Drawing.Point(97, 248);
            this.imagePb.Name = "imagePb";
            this.imagePb.Size = new System.Drawing.Size(152, 114);
            this.imagePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePb.TabIndex = 15;
            this.imagePb.TabStop = false;
            // 
            // descriptionTb
            // 
            this.descriptionTb.Location = new System.Drawing.Point(97, 132);
            this.descriptionTb.Multiline = true;
            this.descriptionTb.Name = "descriptionTb";
            this.descriptionTb.Size = new System.Drawing.Size(167, 85);
            this.descriptionTb.TabIndex = 13;
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(97, 83);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(100, 20);
            this.nameTb.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "AssetBundle :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Image :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Description :";
            // 
            // idLb
            // 
            this.idLb.AutoSize = true;
            this.idLb.Location = new System.Drawing.Point(94, 38);
            this.idLb.Name = "idLb";
            this.idLb.Size = new System.Drawing.Size(13, 13);
            this.idLb.TabIndex = 10;
            this.idLb.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "ID :";
            // 
            // assetBundleLb
            // 
            this.assetBundleLb.AutoSize = true;
            this.assetBundleLb.Location = new System.Drawing.Point(97, 420);
            this.assetBundleLb.Name = "assetBundleLb";
            this.assetBundleLb.Size = new System.Drawing.Size(28, 13);
            this.assetBundleLb.TabIndex = 20;
            this.assetBundleLb.Text = "path";
            // 
            // assetBtn
            // 
            this.assetBtn.Location = new System.Drawing.Point(225, 446);
            this.assetBtn.Name = "assetBtn";
            this.assetBtn.Size = new System.Drawing.Size(24, 23);
            this.assetBtn.TabIndex = 16;
            this.assetBtn.Text = "...";
            this.assetBtn.UseVisualStyleBackColor = true;
            this.assetBtn.Click += new System.EventHandler(this.assetBtn_Click);
            // 
            // assetOpenFileDialog
            // 
            this.assetOpenFileDialog.FileName = "openFileDialog1";
            // 
            // PriceDisplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 566);
            this.Controls.Add(this.assetBundleLb);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.assetBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.imagePb);
            this.Controls.Add(this.descriptionTb);
            this.Controls.Add(this.nameTb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.idLb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "PriceDisplayer";
            this.Text = "PriceDisplayer";
            ((System.ComponentModel.ISupportInitialize)(this.imagePb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog imageOpenFileDialog;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.PictureBox imagePb;
        private System.Windows.Forms.TextBox descriptionTb;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label idLb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label assetBundleLb;
        private System.Windows.Forms.Button assetBtn;
        private System.Windows.Forms.OpenFileDialog assetOpenFileDialog;
    }
}