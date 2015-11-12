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
    public partial class PricePoolSelector : Form
    {
        public static PricePoolSelector instance;
        private EventsServices es = new EventsServices();
        private List<PricePoolControl> pricePoolControlList = new List<PricePoolControl>();

        public PricePoolSelector()
        {
            instance = this;
            InitializeComponent();

            es.GetPricePoolsCompleted += es_GetPricePoolsCompleted;
            es.DeletePricePoolCompleted += es_DeletePricePoolCompleted;
            es.GetPricePoolsAsync();
        }

        void es_GetPricePoolsCompleted(object sender, GetPricePoolsCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result.Length > 0)
                    for (int i = 0; i < e.Result.Length; i++)
                    {
                        PricePoolControl p = new PricePoolControl();
                        this.panel1.Controls.Add(p);
                        p.Location = new Point(0, 48 * i);
                        p.Display(e.Result[i]);
                        pricePoolControlList.Add(p);
                    }
                else
                    MessageBox.Show("price pool not found");
            }
            else
            {
                MessageBox.Show("Price pool " + e.Error.Message);
            }
        }

        void es_DeletePricePoolCompleted(object sender, DeletePricePoolCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void es_DeletePriceCompleted(object sender, DeletePriceCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result)
                {
                    MessageBox.Show("PricePool Deleted");
                }
                else
                {
                    MessageBox.Show("PricePool Delete Error");
                }
            }
            else
            {
                MessageBox.Show("PricePool Delete Error " + e.Error.Message);
            }
        }

        private void ReplaceElements()
        {
            for (int i = 0; i < pricePoolControlList.Count; i++)
            {
                pricePoolControlList[i].Location = new Point(0, 48 * i);
            }
            this.Refresh();
        }

        internal void DeletePrice(PriceS price)
        {
            var p = pricePoolControlList.SingleOrDefault(e => int.Parse(e.idLb.Text) == price.id);
            pricePoolControlList.Remove(p);
            this.panel1.Controls.Remove(p);
            ReplaceElements();
            es.DeletePriceAsync(price.id);
        }

        internal void DeletePricePool(PricePoolS pricePool)
        {
            throw new NotImplementedException();
        }
    }
}
