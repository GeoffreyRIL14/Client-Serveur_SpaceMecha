namespace BackEnd_EventsServices
{
    partial class CreateForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.createEventBtn = new System.Windows.Forms.Button();
            this.createPriceBtn = new System.Windows.Forms.Button();
            this.createPricepoolBtn = new System.Windows.Forms.Button();
            this.buttonEditEvent = new System.Windows.Forms.Button();
            this.buttonEditPrice = new System.Windows.Forms.Button();
            this.buttonEditPricePool = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createEventBtn
            // 
            this.createEventBtn.Location = new System.Drawing.Point(179, 62);
            this.createEventBtn.Name = "createEventBtn";
            this.createEventBtn.Size = new System.Drawing.Size(108, 41);
            this.createEventBtn.TabIndex = 0;
            this.createEventBtn.Text = "Create event";
            this.createEventBtn.UseVisualStyleBackColor = true;
            this.createEventBtn.Click += new System.EventHandler(this.createEventBtn_Click);
            // 
            // createPriceBtn
            // 
            this.createPriceBtn.Location = new System.Drawing.Point(179, 120);
            this.createPriceBtn.Name = "createPriceBtn";
            this.createPriceBtn.Size = new System.Drawing.Size(108, 41);
            this.createPriceBtn.TabIndex = 0;
            this.createPriceBtn.Text = "Create Price";
            this.createPriceBtn.UseVisualStyleBackColor = true;
            this.createPriceBtn.Click += new System.EventHandler(this.createPriceBtn_Click);
            // 
            // createPricepoolBtn
            // 
            this.createPricepoolBtn.Location = new System.Drawing.Point(179, 178);
            this.createPricepoolBtn.Name = "createPricepoolBtn";
            this.createPricepoolBtn.Size = new System.Drawing.Size(108, 41);
            this.createPricepoolBtn.TabIndex = 0;
            this.createPricepoolBtn.Text = "Create Pricepool";
            this.createPricepoolBtn.UseVisualStyleBackColor = true;
            this.createPricepoolBtn.Click += new System.EventHandler(this.createPricepoolBtn_Click);
            // 
            // buttonEditEvent
            // 
            this.buttonEditEvent.Location = new System.Drawing.Point(24, 63);
            this.buttonEditEvent.Name = "buttonEditEvent";
            this.buttonEditEvent.Size = new System.Drawing.Size(108, 40);
            this.buttonEditEvent.TabIndex = 1;
            this.buttonEditEvent.Text = "Edit Event";
            this.buttonEditEvent.UseVisualStyleBackColor = true;
            this.buttonEditEvent.Click += new System.EventHandler(this.buttonEditEvent_Click);
            // 
            // buttonEditPrice
            // 
            this.buttonEditPrice.Location = new System.Drawing.Point(24, 120);
            this.buttonEditPrice.Name = "buttonEditPrice";
            this.buttonEditPrice.Size = new System.Drawing.Size(108, 40);
            this.buttonEditPrice.TabIndex = 2;
            this.buttonEditPrice.Text = "Edit Price";
            this.buttonEditPrice.UseVisualStyleBackColor = true;
            this.buttonEditPrice.Click += new System.EventHandler(this.buttonEditPrice_Click);
            // 
            // buttonEditPricePool
            // 
            this.buttonEditPricePool.Location = new System.Drawing.Point(24, 179);
            this.buttonEditPricePool.Name = "buttonEditPricePool";
            this.buttonEditPricePool.Size = new System.Drawing.Size(108, 40);
            this.buttonEditPricePool.TabIndex = 3;
            this.buttonEditPricePool.Text = "Edit Price Pool";
            this.buttonEditPricePool.UseVisualStyleBackColor = true;
            this.buttonEditPricePool.Click += new System.EventHandler(this.buttonEditPricePool_Click);
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 300);
            this.Controls.Add(this.buttonEditPricePool);
            this.Controls.Add(this.buttonEditPrice);
            this.Controls.Add(this.buttonEditEvent);
            this.Controls.Add(this.createPricepoolBtn);
            this.Controls.Add(this.createPriceBtn);
            this.Controls.Add(this.createEventBtn);
            this.Name = "CreateForm";
            this.Text = "Create Item";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createEventBtn;
        private System.Windows.Forms.Button createPriceBtn;
        private System.Windows.Forms.Button createPricepoolBtn;
        private System.Windows.Forms.Button buttonEditEvent;
        private System.Windows.Forms.Button buttonEditPrice;
        private System.Windows.Forms.Button buttonEditPricePool;
    }
}

