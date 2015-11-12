namespace BackEnd_EventsServices
{
    partial class PricepoolDisplayer
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.idLb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openPricesBtn = new System.Windows.Forms.Button();
            this.openEventsBtn = new System.Windows.Forms.Button();
            this.placeMinTb = new System.Windows.Forms.TextBox();
            this.placeMaxTb = new System.Windows.Forms.TextBox();
            this.placePercentTb = new System.Windows.Forms.TextBox();
            this.priceName = new System.Windows.Forms.Label();
            this.eventName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(118, 347);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 19;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Place % :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Place max :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Place min :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Event :";
            // 
            // idLb
            // 
            this.idLb.AutoSize = true;
            this.idLb.Location = new System.Drawing.Point(90, 44);
            this.idLb.Name = "idLb";
            this.idLb.Size = new System.Drawing.Size(13, 13);
            this.idLb.TabIndex = 10;
            this.idLb.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Price :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "ID :";
            // 
            // openPricesBtn
            // 
            this.openPricesBtn.Location = new System.Drawing.Point(24, 105);
            this.openPricesBtn.Name = "openPricesBtn";
            this.openPricesBtn.Size = new System.Drawing.Size(63, 23);
            this.openPricesBtn.TabIndex = 20;
            this.openPricesBtn.Text = "Search";
            this.openPricesBtn.UseVisualStyleBackColor = true;
            this.openPricesBtn.Click += new System.EventHandler(this.openPricesBtn_Click);
            // 
            // openEventsBtn
            // 
            this.openEventsBtn.Location = new System.Drawing.Point(24, 154);
            this.openEventsBtn.Name = "openEventsBtn";
            this.openEventsBtn.Size = new System.Drawing.Size(63, 23);
            this.openEventsBtn.TabIndex = 20;
            this.openEventsBtn.Text = "Search";
            this.openEventsBtn.UseVisualStyleBackColor = true;
            this.openEventsBtn.Click += new System.EventHandler(this.openEventsBtn_Click);
            // 
            // placeMinTb
            // 
            this.placeMinTb.Location = new System.Drawing.Point(93, 184);
            this.placeMinTb.Name = "placeMinTb";
            this.placeMinTb.Size = new System.Drawing.Size(100, 20);
            this.placeMinTb.TabIndex = 21;
            // 
            // placeMaxTb
            // 
            this.placeMaxTb.Location = new System.Drawing.Point(93, 235);
            this.placeMaxTb.Name = "placeMaxTb";
            this.placeMaxTb.Size = new System.Drawing.Size(100, 20);
            this.placeMaxTb.TabIndex = 21;
            // 
            // placePercentTb
            // 
            this.placePercentTb.Location = new System.Drawing.Point(93, 285);
            this.placePercentTb.Name = "placePercentTb";
            this.placePercentTb.Size = new System.Drawing.Size(100, 20);
            this.placePercentTb.TabIndex = 21;
            // 
            // priceName
            // 
            this.priceName.AutoSize = true;
            this.priceName.Location = new System.Drawing.Point(90, 89);
            this.priceName.Name = "priceName";
            this.priceName.Size = new System.Drawing.Size(16, 13);
            this.priceName.TabIndex = 11;
            this.priceName.Text = "...";
            // 
            // eventName
            // 
            this.eventName.AutoSize = true;
            this.eventName.Location = new System.Drawing.Point(90, 138);
            this.eventName.Name = "eventName";
            this.eventName.Size = new System.Drawing.Size(16, 13);
            this.eventName.TabIndex = 9;
            this.eventName.Text = "...";
            // 
            // PricepoolDisplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 382);
            this.Controls.Add(this.placePercentTb);
            this.Controls.Add(this.placeMaxTb);
            this.Controls.Add(this.placeMinTb);
            this.Controls.Add(this.openEventsBtn);
            this.Controls.Add(this.openPricesBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.eventName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.idLb);
            this.Controls.Add(this.priceName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "PricepoolDisplayer";
            this.Text = "PricepoolDisplayer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label idLb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openPricesBtn;
        private System.Windows.Forms.Button openEventsBtn;
        private System.Windows.Forms.TextBox placeMinTb;
        private System.Windows.Forms.TextBox placeMaxTb;
        private System.Windows.Forms.TextBox placePercentTb;
        private System.Windows.Forms.Label priceName;
        private System.Windows.Forms.Label eventName;
    }
}