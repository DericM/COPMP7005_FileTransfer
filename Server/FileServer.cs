using TcpLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace Server
{

    /// <SUMMARY>
    /// EchoServiceProvider. Just replies messages
    /// received from the clients.
    /// </SUMMARY>
    public class FileServer : TcpServiceProvider
    {
        private string _receivedStr;

        TcpClient filelistclnt;
        TcpClient fileTransferClnt;

        public override object Clone()
        {
            return new FileServer();
        }

        public override void OnAcceptConnection(ConnectionState state)
        {
            _receivedStr = "";
            if (!state.Write(Encoding.UTF8.GetBytes("Hello World!\r\n"), 0, 14))
                state.EndConnection();

            String ip = ((IPEndPoint)state.RemoteEndPoint).Address.ToString();

            filelistclnt = new TcpClient();
            filelistclnt.Connect(ip, 7007);

            fileTransferClnt = new TcpClient();
            fileTransferClnt.Connect(ip, 7006);

            //if write fails... then close connection
        }
        

        public override void OnReceiveData(ConnectionState state)
        {
            
            byte[] buffer = new byte[1024];
            while (state.AvailableData > 0)
            {
                int readBytes = state.Read(buffer, 0, 1024);
                if (readBytes > 0)
                {
                    _receivedStr += Encoding.UTF8.GetString(buffer, 0, readBytes);
                    if (_receivedStr.IndexOf("<EOF>") >= 0)
                    {
                        if (_receivedStr.IndexOf("<FILENAME>") >= 0)
                        {
                            int headerStart = _receivedStr.IndexOf("<FILENAME>");
                            int filenameStart = headerStart + 10;
                            int filenameEnd = _receivedStr.IndexOf("</FILENAME>");
                            int headerEnd = filenameEnd + 11;
                            int filenameLength = filenameEnd - filenameStart;

                            String filename = _receivedStr.Substring(filenameStart, filenameLength);
                            getFileForSendingToClient(filename);

                            int eofEnd = _receivedStr.IndexOf("<EOF>") + 4;
                            _receivedStr = _receivedStr.Remove(0, eofEnd);
                        }

                        if (_receivedStr.IndexOf("<FILELIST>") >= 0)
                        {
                            sendFileList(state);
                            int eofEnd = _receivedStr.IndexOf("<EOF>") + 4;
                            _receivedStr = _receivedStr.Remove(0, eofEnd);
                        }




                    }
                }
                else state.EndConnection(); //If read fails then close connection
            }
        }

        private void getFileForSendingToClient(String filename)
        {
            Stream stream = fileTransferClnt.GetStream();
            byte[] buffer = new byte[1024];

            String filePath = "Files\\" + filename;
            Console.WriteLine("Server sending client file: " + filePath);
            
            String header = "<FILENAME>" + filename + "</FILENAME>";
            stream.Write(Encoding.UTF8.GetBytes(header), 0, header.Length);

            using (Stream source = File.OpenRead(filePath))
            {
                buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                }
            }

            stream.Write(Encoding.UTF8.GetBytes("<EOF>"), 0, 5);
        }

        

        private void sendFileList(ConnectionState state)
        {
            
            Stream stream = filelistclnt.GetStream();

            DirectoryInfo d = new DirectoryInfo("Files");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*"); //Getting Text files
            string str = "";
            foreach (FileInfo file in Files)
            {
                str = str + "," + file.Name;
            }
            str = str.Remove(0, 1);
            try
            {
                String header = "<FILELIST>" + str + "</FILELIST>";
                stream.Write(Encoding.UTF8.GetBytes(header), 0, header.Length);
                stream.Write(Encoding.UTF8.GetBytes("<EOF>"), 0, 5);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }

            //tcpclnt.Close();
        }


        public override void OnDropConnection(ConnectionState state)
        {
            //Nothing to clean here
        }
    }
}
