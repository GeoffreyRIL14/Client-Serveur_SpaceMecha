using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackEnd_EventsServices
{
    public partial class EventDisplayer : Form
    {
        private EventsServices es = new EventsServices();
        

        public EventDisplayer()
        {
            InitializeComponent();
            es.CreateOrUpdateEventCompleted += es_CreateOrUpdateEventCompleted;
        }

        void es_CreateOrUpdateEventCompleted(object sender, CreateOrUpdateEventCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result > 0)
                {
                    MessageBox.Show("Event Created");
                    this.Close();
                }
                else
                    MessageBox.Show("Event Error");
            }
            else
            {
                MessageBox.Show("Event ERROR : " + e.Error.Message);
            }
        }

        public void Display(EventS eventGame)
        {
            idLb.Text = eventGame.id.ToString();
            nameTb.Text = eventGame.name;
            descriptionTb.Text = eventGame.description;
            startDateDTP.Value = eventGame.startDate;
            endDateDTP.Value = eventGame.endDate;
            if (eventGame.image != null)
                imagePb.Image = Image.FromStream(new MemoryStream(eventGame.image));
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] bytes;    

                using (FileStream fsSource = new FileStream(imagePb.ImageLocation,
            FileMode.Open, FileAccess.Read))
                {

                    // Read the source file into a byte array.
                    bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                }

                es.CreateOrUpdateEventAsync(int.Parse(idLb.Text), nameTb.Text, startDateDTP.Value, endDateDTP.Value, bytes, descriptionTb.Text);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void browseBtn_Click(object sender, EventArgs e)
        {      
            openFileDialog.ShowDialog();
            imagePb.Image = Image.FromFile(openFileDialog.FileName);
            imagePb.ImageLocation = openFileDialog.FileName;
        }


       
    }
}
