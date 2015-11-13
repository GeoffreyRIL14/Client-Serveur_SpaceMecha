using System;
using System.Collections;
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
    public partial class PriceDisplayer : Form
    {
        private EventsServices es = new EventsServices();

        public PriceDisplayer()
        {
            InitializeComponent();
            es.CreateOrUpdatePriceCompleted += es_CreatePriceCompleted;
        }

        public void Display(PriceS price)
        {
            idLb.Text = price.id.ToString();
            nameTb.Text = price.name;
            descriptionTb.Text = price.description;
            if (price.image != null) 
                imagePb.Image = Image.FromStream(new MemoryStream(price.image));
            assetBundleLb.Text = price.path != null? "ok" : "no asset";    

        }

        void es_CreatePriceCompleted(object sender, CreateOrUpdatePriceCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result > 0)
                {
                    if (idLb.Text == "0") 
                        MessageBox.Show("Price Created");
                    else
                        MessageBox.Show("Price Modified");

                    this.Close();
                }
                else
                    MessageBox.Show("Price Error");
            }
            else
            {
                MessageBox.Show("Price ERROR : " + e.Error.Message);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool validAssetPath = false;
            byte[] image = null, asset = null;

            try
            {
                Path.GetDirectoryName(assetBundleLb.Text);
                if (assetBundleLb.Text != "ok" && assetBundleLb.Text != "no asset")
                    validAssetPath = true;
                else
                    validAssetPath = false;
            }
            catch
            {
                validAssetPath = false;
            }

            if (!String.IsNullOrEmpty(assetBundleLb.Text) && validAssetPath)
                asset = ReadFile(assetBundleLb.Text);


            if (!String.IsNullOrEmpty(imagePb.ImageLocation))
                image = ReadFile(imagePb.ImageLocation);

            es.CreateOrUpdatePriceAsync(int.Parse(idLb.Text), nameTb.Text, image, asset, descriptionTb.Text);

        }


        public byte[] ReadFile(string path)
        {
            try
            {
                using (FileStream fsSource = new FileStream(path,
           FileMode.Open, FileAccess.Read))
                {

                    // Read the source file into a byte array.
                    byte[] bytes = new byte[fsSource.Length];
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

                    return bytes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            
        }

        private void assetBtn_Click(object sender, EventArgs e)
        {
            imageOpenFileDialog.FileName = null;
            imageOpenFileDialog.ShowDialog();
            if(!String.IsNullOrEmpty(imageOpenFileDialog.FileName))
                assetBundleLb.Text = imageOpenFileDialog.FileName;
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            imageOpenFileDialog.FileName = null;
            imageOpenFileDialog.ShowDialog();
            if (!String.IsNullOrEmpty(imageOpenFileDialog.FileName))
            {
                imagePb.Image = Image.FromFile(imageOpenFileDialog.FileName);
                imagePb.ImageLocation = imageOpenFileDialog.FileName;
            }
        }
    }
}
