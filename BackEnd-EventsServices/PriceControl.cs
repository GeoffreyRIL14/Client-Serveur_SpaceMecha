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
    public partial class PriceControl : UserControl
    {
        private PriceS price;
        private PricepoolDisplayer ppd;

        public PriceControl(PricepoolDisplayer ppd)
        {
            this.ppd = ppd;
            InitializeComponent();
            if (ppd == null)
                selectBtn.Enabled = false;
        }

        public void Display(PriceS price)
        {
            this.price = price;
            idLb.Text = price.id.ToString();
            nameLb.Text = price.name;

            
            if(price.image != null)
                imagePb.Image = Image.FromStream(new MemoryStream(price.image));
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            ppd.SetEvent(price);
            PriceSelector.instance.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            PriceSelector.instance.DeletePrice(price);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            PriceDisplayer ed = new PriceDisplayer();
            ed.Show();
            ed.Display(price);
            PriceSelector.instance.Close();
        }
    }
}
