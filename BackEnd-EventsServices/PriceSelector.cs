using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackEnd_EventsServices
{
    public partial class PriceSelector : Form
    {
        public static PriceSelector instance;
        private EventsServices es = new EventsServices();
        private PricepoolDisplayer ppd;
        private List<PriceControl> priceControlList = new List<PriceControl>();

        public PriceSelector(PricepoolDisplayer ppd)
        {
            instance = this;
            this.ppd = ppd;
            InitializeComponent();

            es.GetPricesCompleted += es_GetPricesCompleted;
            es.DeletePriceCompleted += es_DeletePriceCompleted;
            es.GetPricesAsync();
        }

        void es_DeletePriceCompleted(object sender, DeletePriceCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result)
                {
                    MessageBox.Show("Price Deleted");
                }
                else
                {
                    MessageBox.Show("Price Delete Error");
                }
            }
            else
            {
                MessageBox.Show("Price Delete Error " + e.Error.Message);
            }
        }

        void es_GetPricesCompleted(object sender, GetPricesCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                for (int i = 0; i < e.Result.Length; i++)
                {
                    PriceControl ev = new PriceControl(ppd);
                    this.panel1.Controls.Add(ev);
                    ev.Location = new Point(0, 48 * i);
                    ev.Display(e.Result[i]);
                    priceControlList.Add(ev);
                }
            }
        }

        private void ReplaceElements()
        {
            for (int i = 0; i < priceControlList.Count; i++)
            {
                priceControlList[i].Location = new Point(0, 48 * i);
            }
            this.Refresh();
        }

        internal void DeletePrice(PriceS price)
        {
            var p = priceControlList.SingleOrDefault(e => int.Parse(e.idLb.Text) == price.id);
            priceControlList.Remove(p);
            this.panel1.Controls.Remove(p);
            ReplaceElements();
            es.DeletePriceAsync(price.id);
        }
    }
}
