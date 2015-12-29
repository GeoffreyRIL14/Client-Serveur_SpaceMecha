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
    public partial class PricepoolDisplayer : Form
    {
        private EventsServices es = new EventsServices();

        private EventS eventGame;
        private PriceS price;
        private PricePoolS pricepool;

        public PricepoolDisplayer()
        {
            InitializeComponent();
            es.CreateOrUpdatePricePoolCompleted += es_CreateOrUpdatePricePoolCompleted;
            es.GetEventCompleted += es_GetEventCompleted;
            es.GetPriceCompleted += es_GetPriceCompleted;
        }

        void es_GetPriceCompleted(object sender, GetPriceCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result != null)
                {
                    price = e.Result;
                    es.GetEventAsync(pricepool.eventId);
                }
                else
                {
                    MessageBox.Show("Price not exist");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("price ERROR : " + e.Error.Message);
                this.Close();
            }
        }

        void es_GetEventCompleted(object sender, GetEventCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result != null)
                {
                    eventGame = e.Result;
                    OnLoaded();
                }
                else
                {
                    MessageBox.Show("event not exist");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("event ERROR : " + e.Error.GetType().Name + e.Error.Message);
                this.Close();
            }
        }

        private void OnLoaded()
        {
            InitializeComponent();
            idLb.Text = pricepool.id.ToString();
            placeMinTb.Text = pricepool.placeRangeMin.ToString();
            placeMaxTb.Text = pricepool.placeRangeMax.ToString();
            placePercentTb.Text = pricepool.placePercent.ToString();
            priceName.Text = price.name;
            eventName.Text = eventGame.name;
        }

        internal void Display(PricePoolS pricepool)
        {
            this.pricepool = pricepool;
            es.GetPriceAsync(pricepool.priceId);
        }

        void es_CreateOrUpdatePricePoolCompleted(object sender, CreateOrUpdatePricePoolCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result == true)
                {
                    if (idLb.Text == "0")
                        MessageBox.Show("Price Pool Created");
                    else
                        MessageBox.Show("Price Pool Modified");

                    this.Close();
                }
                else
                    MessageBox.Show("Price Pool Error");
            }
            else
            {
                MessageBox.Show("Price Pool ERROR : " + e.Error.Message);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            int max = 0, min = 0;
            float percent = 0;

            if (placePercentTb.Text != "")
                percent = float.Parse(placePercentTb.Text);

            if (placeMinTb.Text != "")
                min = int.Parse(placeMinTb.Text);

            if (placeMaxTb.Text != "")
                max = int.Parse(placeMaxTb.Text);

            if (eventGame != null && price != null)
            {
                es.CreateOrUpdatePricePoolAsync(0, price.id, eventGame.id, max, min, percent);
                this.Close();
            }
            else
            {
                MessageBox.Show("ERROR Missing event or price");
            }           

        }

        private void openPricesBtn_Click(object sender, EventArgs e)
        {
            price = null;
            PriceSelector s = new PriceSelector(this);
            s.Show();
        }

        private void openEventsBtn_Click(object sender, EventArgs e)
        {
            eventGame = null;
            EventSelector es = new EventSelector(this);
            es.Show();
        }

        public void SetEvent(EventS eventGame)
        {
            this.eventGame = eventGame;
            eventName.Text = eventGame.name;
        }

        public void SetEvent(PriceS price)
        {
            this.price = price;
            priceName.Text = price.name;
        }

    }
}
