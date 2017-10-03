using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpLib;

namespace Client
{
    public class ListReceiver : TcpServiceProvider
    {
        private string _receivedStr;
        private static string _filelist;
        ClientForm clientform;

        public ListReceiver(ClientForm cf)
        {
            clientform = cf;
        }

        public override object Clone()
        {
            return new ListReceiver(clientform);
        }

        public override void OnAcceptConnection(ConnectionState state)
        {
            _receivedStr = "";
            if (!state.Write(Encoding.UTF8.GetBytes("Hello World!\r\n"), 0, 14))
                state.EndConnection(); //if write fails... then close connection
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
                        int headerStart = _receivedStr.IndexOf("<FILELIST>");
                        int filelistStart = headerStart + 10;
                        int filelistEnd = _receivedStr.IndexOf("</FILELIST>");
                        int headerEnd = filelistEnd + 11;
                        int filelistLength = filelistEnd - filelistStart;

                        _filelist = _receivedStr.Substring(filelistStart, filelistLength);
                        _receivedStr = _receivedStr.Remove(0, headerEnd);
                        Console.WriteLine("updateList.....");
                        clientform.updateList(_filelist);

                        int eofStart = _receivedStr.IndexOf("<EOF>");
                        _receivedStr = _receivedStr.Remove(eofStart, 4);
                    }
                }
                else state.EndConnection(); //If read fails then close connection
            }
        }

        public override void OnDropConnection(ConnectionState state)
        {
            //Nothing to clean here
        }
    }
}
