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
    public partial class EventSelector : Form
    {
        public static EventSelector instance;
        private EventsServices es = new EventsServices();
        private PricepoolDisplayer ppd;
        private List<EventControl> eventControlList = new List<EventControl>();

        public EventSelector(PricepoolDisplayer ppd)
        {
            instance = this;
            this.ppd = ppd;
            InitializeComponent();

            es.GetEventsCompleted += es_GetEventsCompleted;
            es.DeleteEventCompleted += es_DeleteEventCompleted;
            es.GetEventsAsync();
        }

        private void es_DeleteEventCompleted(object sender, DeleteEventCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result)
                {
                    MessageBox.Show("Event Deleted");
                }
                else
                {
                    MessageBox.Show("Event Delete Error");
                }
            }
            else
            {
                MessageBox.Show("Event Delete Error " + e.Error.Message);
            }
        }

        void es_GetEventsCompleted(object sender, GetEventsCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                for (int i = 0; i < e.Result.Length; i++)
                {
                    EventControl ev = new EventControl(ppd);
                    this.panel1.Controls.Add(ev);
                    ev.Location = new Point(0, 48 * i);
                    ev.Display(e.Result[i]);
                    eventControlList.Add(ev);
                }
            }
        }

        private void ReplaceElements()
        {
            for (int i = 0; i < eventControlList.Count; i++)
            {
                eventControlList[i].Location = new Point(0, 48 * i);
            }
            this.Refresh();
        }

        internal void DeleteEvent(EventS eventGame)
        {
            var ev = eventControlList.SingleOrDefault(e => int.Parse(e.idLb.Text) == eventGame.id);
            eventControlList.Remove(ev);
            this.panel1.Controls.Remove(ev);
            ReplaceElements();
            es.DeleteEventAsync(eventGame.id);
        }
    }
}
