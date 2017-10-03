using TcpLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Server
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        private static TcpServer FSServidor;
        private FileServer FSProvider;

        private static TcpServer FRServidor;
        private FileReceiver FRProvider;

        private void ServerForm_Load(object sender, EventArgs e)
        {
            Thread FSThread = new Thread(FileServerThread);
            Thread FRThread = new Thread(FileReceiverThread);
            FSThread.Start();
            FRThread.Start();
        }

        private void FileServerThread()
        {
            FSProvider = new FileServer();
            FSServidor = new TcpServer(FSProvider, 7005);
            FSServidor.Start();
        }

        private void FileReceiverThread()
        {
            FRProvider = new FileReceiver();
            FRServidor = new TcpServer(FRProvider, 7004);
            FRServidor.Start();
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FSServidor.Stop();
            FRServidor.Stop();
        }
    }
}
