namespace BackEnd_EventsServices
{
    partial class EventControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.idLb = new System.Windows.Forms.Label();
            this.nameLb = new System.Windows.Forms.Label();
            this.startDateLb = new System.Windows.Forms.Label();
            this.endDateLb = new System.Windows.Forms.Label();
            this.imagePb = new System.Windows.Forms.PictureBox();
            this.selectBtn = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagePb)).BeginInit();
            this.SuspendLayout();
            // 
            // idLb
            // 
            this.idLb.AutoSize = true;
            this.idLb.Location = new System.Drawing.Point(97, 15);
            this.idLb.Name = "idLb";
            this.idLb.Size = new System.Drawing.Size(13, 13);
            this.idLb.TabIndex = 0;
            this.idLb.Text = "0";
            // 
            // nameLb
            // 
            this.nameLb.AutoSize = true;
            this.nameLb.Location = new System.Drawing.Point(141, 15);
            this.nameLb.Name = "nameLb";
            this.nameLb.Size = new System.Drawing.Size(33, 13);
            this.nameLb.TabIndex = 1;
            this.nameLb.Text = "name";
            // 
            // startDateLb
            // 
            this.startDateLb.AutoSize = true;
            this.startDateLb.Location = new System.Drawing.Point(209, 15);
            this.startDateLb.Name = "startDateLb";
            this.startDateLb.Size = new System.Drawing.Size(53, 13);
            this.startDateLb.TabIndex = 2;
            this.startDateLb.Text = "01/01/15";
            // 
            // endDateLb
            // 
            this.endDateLb.AutoSize = true;
            this.endDateLb.Location = new System.Drawing.Point(296, 15);
            this.endDateLb.Name = "endDateLb";
            this.endDateLb.Size = new System.Drawing.Size(53, 13);
            this.endDateLb.TabIndex = 2;
            this.endDateLb.Text = "01/01/15";
            // 
            // imagePb
            // 
            this.imagePb.Location = new System.Drawing.Point(394, 2);
            this.imagePb.Name = "imagePb";
            this.imagePb.Size = new System.Drawing.Size(46, 44);
            this.imagePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePb.TabIndex = 3;
            this.imagePb.TabStop = false;
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(10, 9);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(56, 25);
            this.selectBtn.TabIndex = 5;
            this.selectBtn.Text = "Select";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(442, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(48, 48);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(493, 0);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(48, 48);
            this.buttonEdit.TabIndex = 7;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // EventControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.imagePb);
            this.Controls.Add(this.endDateLb);
            this.Controls.Add(this.startDateLb);
            this.Controls.Add(this.nameLb);
            this.Controls.Add(this.idLb);
            this.Name = "EventControl";
            this.Size = new System.Drawing.Size(544, 48);
            ((System.ComponentModel.ISupportInitialize)(this.imagePb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLb;
        private System.Windows.Forms.Label startDateLb;
        private System.Windows.Forms.Label endDateLb;
        private System.Windows.Forms.PictureBox imagePb;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        public System.Windows.Forms.Label idLb;
    }
}
