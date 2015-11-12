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
    public partial class EventControl : UserControl
    {
        private EventS eventGame;
        private PricepoolDisplayer ppd;

        public EventControl(PricepoolDisplayer ppd)
        {
            InitializeComponent();
            if (ppd == null)
                selectBtn.Enabled = false;
            this.ppd = ppd;            
        }

        public void Display(EventS eventGame)
        {
            this.eventGame = eventGame;
            idLb.Text = eventGame.id.ToString();
            nameLb.Text = eventGame.name;
            startDateLb.Text = eventGame.startDate.ToShortDateString();
            endDateLb.Text = eventGame.endDate.ToShortDateString();
            
            if(eventGame.image != null)
                imagePb.Image = Image.FromStream(new MemoryStream(eventGame.image));
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            ppd.SetEvent(eventGame);
            EventSelector.instance.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            EventSelector.instance.DeleteEvent(eventGame);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EventDisplayer ed = new EventDisplayer();
            ed.Show();
            ed.Display(eventGame);
            EventSelector.instance.Close();
        }

    }
}
