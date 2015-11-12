using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BackEnd_EventsServices
{
    public partial class PricePoolControl : UserControl
    {
        private PricePoolS pricePool = null;

        public PricePoolControl()
        {
            InitializeComponent();
        }

        public void Display(PricePoolS pricePool)
        {
            this.pricePool = pricePool;
            idLb.Text = pricePool.id.ToString();
            labelEventName.Text = pricePool.eventId.ToString();
            labelPriceName.Text = pricePool.priceId.ToString();         
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            PricePoolSelector.instance.DeletePricePool(pricePool);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            PricepoolDisplayer ed = new PricepoolDisplayer();
            ed.Show();
            ed.Display(pricePool);
            PricePoolSelector.instance.Close();
        }
    }
}
