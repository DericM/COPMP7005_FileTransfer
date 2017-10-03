using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using TcpLib;

namespace Client
{
    public partial class ClientForm : Form
    {

        private TcpServer FRServidor;
        private FileReceiver FRProvider;

        private TcpServer LRServidor;
        private ListReceiver LRProvider;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            Thread FRThread = new Thread(FileReceiverThread);
            FRThread.Start();
            Thread LRThread = new Thread(ListReceiverThread);
            LRThread.Start();
        }

        private void FileReceiverThread()
        {
            FRProvider = new FileReceiver();
            FRServidor = new TcpServer(FRProvider, 7006);
            FRServidor.Start();
        }

        private void ListReceiverThread()
        {
            LRProvider = new ListReceiver(this);
            LRServidor = new TcpServer(LRProvider, 7007);
            LRServidor.Start();
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

            if (client.connect(ip, port))
            {
                buttonBrowse.Enabled = true;
                listBoxServerFiles.Enabled = true;
                listBoxServerFiles.Items.Clear();
            }
            
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
            client.requestFileFromServer(listBoxServerFiles.SelectedItem.ToString());
        }

        private void listBoxServerFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDownload.Enabled = true;
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FRServidor.Stop();
            LRServidor.Stop();
            client.disconnect();
        }

        public void updateList(String files)
        {
            Console.WriteLine(files);
            List<String> listfiles = files.Split(',').ToList();
            this.Invoke((MethodInvoker)(() => listBoxServerFiles.Items.Clear()));
            foreach (String element in listfiles)
            {
                this.Invoke((MethodInvoker)(() => listBoxServerFiles.Items.Add(element)));
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            client.requestListFromServer();
        }
    }
}
