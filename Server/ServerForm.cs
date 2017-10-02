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

namespace Server
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        private TcpServer Servidor;
        private FileServer Provider;

        private void ServerForm_Load(object sender, EventArgs e)
        {
            Provider = new FileServer();
            Servidor = new TcpServer(Provider, 7005);
            Servidor.Start();
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servidor.Stop();
        }
    }
}
