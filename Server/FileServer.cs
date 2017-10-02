using TcpLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server
{

    /// <SUMMARY>
    /// EchoServiceProvider. Just replies messages
    /// received from the clients.
    /// </SUMMARY>
    public class FileServer : TcpServiceProvider
    {
        private string _receivedStr;
        private string _receiveFile;
        private string _getfileName;
        private string _sendfileName;

        public override object Clone()
        {
            return new FileServer();
        }

        public override void OnAcceptConnection(ConnectionState state)
        {
            _receivedStr = "";
            if (!state.Write(Encoding.UTF8.GetBytes("Hello World!\r\n"), 0, 14))
                state.EndConnection();
            //if write fails... then close connection
        }


        public override void OnReceiveData(ConnectionState state)
        {
            byte[] buffer = new byte[1024];
            int readBytes = 0;
            while (state.AvailableData > 0)
            {
                Console.WriteLine("Server Read.");
                readBytes += state.Read(buffer, 0, 1024);

                if (readBytes != 1024)
                {
                    Console.WriteLine("Server readBytes: " + readBytes);
                }

                if (readBytes >= 1024)
                {
                    _receivedStr += Encoding.UTF8.GetString(buffer, 0, readBytes);
                    //Console.WriteLine("Server received: " + _receivedStr);
                    if (_receivedStr.IndexOf("[GET]") >= 0)
                    {
                        _getfileName = _receivedStr.Substring(5, _receivedStr.Length - 10);
                        _getfileName = _getfileName.TrimEnd('\0');
                        Console.WriteLine("Server received [GET] request for file: " + _getfileName);
                        getFileForSendingToClient(state);
                    }
                    else if (_receivedStr.IndexOf("[SEND]") >= 0)
                    {
                        Console.WriteLine("_receivedStr.IndexOf([SEND])." + _receivedStr.IndexOf("[SEND]"));
                        _sendfileName = _receivedStr.Substring(6, _receivedStr.Length - 11);
                        _sendfileName = _sendfileName.TrimEnd('\0');
                        Console.WriteLine("Server received [SEND] request for file: " + _sendfileName);
                        saveFileSentFromClient();
                    }
                    else if (_receivedStr.IndexOf("[LIST]") >= 0)
                    {
                        Console.WriteLine("Server received [LIST] request for all file names.");
                    }
                    else
                    {
                        Console.WriteLine("Server received Data from client.");
                        _receiveFile += _receivedStr;
                    }

                    //Console.WriteLine("Server write: " + _receivedStr);
                    //state.Write(Encoding.UTF8.GetBytes(_receivedStr), 0, _receivedStr.Length);
                    _receivedStr = "";
                    readBytes = 0;
                }
                else
                {
                    Console.WriteLine("Server EndConnection.");
                    state.EndConnection();
                }
                //If read fails then close connection
            }
        }

        public void getFileForSendingToClient(ConnectionState state)
        {
            String filePath = "Files\\" + _getfileName;
            Console.WriteLine("Server sending client file: " + filePath);
            using (Stream source = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    state.Write(buffer, 0, bytesRead);
                }
            }
        }

        public void saveFileSentFromClient()
        {
            String filePath = "Files\\" + _sendfileName;
            Console.WriteLine("Server saving file from client: " + filePath);

            File.WriteAllText(filePath, _receiveFile);
        }




        public override void OnDropConnection(ConnectionState state)
        {
            //Nothing to clean here
        }
    }
}
