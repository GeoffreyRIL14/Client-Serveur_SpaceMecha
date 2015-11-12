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
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        private void createEventBtn_Click(object sender, EventArgs e)
        {
            EventDisplayer ed = new EventDisplayer();
            ed.Show();
        }

        private void createPriceBtn_Click(object sender, EventArgs e)
        {
            PriceDisplayer pd = new PriceDisplayer();
            pd.Show();
        }

        private void createPricepoolBtn_Click(object sender, EventArgs e)
        {
            PricepoolDisplayer ppd = new PricepoolDisplayer();
            ppd.Show();
        }

        private void buttonEditEvent_Click(object sender, EventArgs e)
        {
            EventSelector ee = new EventSelector(null);
            ee.Show();
        }

        private void buttonEditPrice_Click(object sender, EventArgs e)
        {
            PriceSelector ps = new PriceSelector(null);
            ps.Show();
        }

        private void buttonEditPricePool_Click(object sender, EventArgs e)
        {
            PricePoolSelector pps = new PricePoolSelector();
            pps.Show();
        }
    }
}
