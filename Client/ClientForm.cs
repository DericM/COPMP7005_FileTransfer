using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {


        public ClientForm()
        {
            InitializeComponent();
        }

        private void maskedTextBoxIPAddress_Validating(object sender, CancelEventArgs e)
        {
            IPAddress ipAddress;
            if (IPAddress.TryParse(maskedTextBoxIPAddress.Text, out ipAddress))
            {
                //valid ip
            }
            else
            {
                //is not valid ip
            }
        }

        Client client;
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            String ip = maskedTextBoxIPAddress.Text;
            int port = Convert.ToInt32(maskedTextBoxPort.Text);
            client = new Client();

            client.connect(ip, port);

            buttonBrowse.Enabled = true;
            listBoxServerFiles.Enabled = true;


            //client.write();
            //client.read();
            //client.disconnect();
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            client.sendFileToServer(openFileDialog.FileName);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                labelUploadPath.Text = openFileDialog.FileName;
                buttonUpload.Enabled = true;
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            //client.getFileFromServer(listBoxServerFiles.SelectedItem.ToString);
        }

        private void listBoxServerFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDownload.Enabled = true;
        }


        
        


    }
}
