namespace BackEnd_EventsServices
{
    partial class PricePoolControl
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
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.labelPriceName = new System.Windows.Forms.Label();
            this.labelEventName = new System.Windows.Forms.Label();
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
            this.nameLb.Location = new System.Drawing.Point(152, 15);
            this.nameLb.Name = "nameLb";
            this.nameLb.Size = new System.Drawing.Size(33, 13);
            this.nameLb.TabIndex = 1;
            this.nameLb.Text = "name";
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
            // labelPriceName
            // 
            this.labelPriceName.AutoSize = true;
            this.labelPriceName.Location = new System.Drawing.Point(228, 15);
            this.labelPriceName.Name = "labelPriceName";
            this.labelPriceName.Size = new System.Drawing.Size(59, 13);
            this.labelPriceName.TabIndex = 8;
            this.labelPriceName.Text = "price name";
            // 
            // labelEventName
            // 
            this.labelEventName.AutoSize = true;
            this.labelEventName.Location = new System.Drawing.Point(329, 15);
            this.labelEventName.Name = "labelEventName";
            this.labelEventName.Size = new System.Drawing.Size(63, 13);
            this.labelEventName.TabIndex = 9;
            this.labelEventName.Text = "event name";
            // 
            // PricePoolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelEventName);
            this.Controls.Add(this.labelPriceName);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.nameLb);
            this.Controls.Add(this.idLb);
            this.Name = "PricePoolControl";
            this.Size = new System.Drawing.Size(544, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLb;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        public System.Windows.Forms.Label idLb;
        private System.Windows.Forms.Label labelPriceName;
        private System.Windows.Forms.Label labelEventName;
    }
}
