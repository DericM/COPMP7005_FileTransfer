using System;
using System.IO;
using System.Text;

namespace TcpLib

{
    public class FileReceiver : TcpServiceProvider
    {
        private string _receivedStr;
        private string _filename;

        public override object Clone()
        {
            return new FileReceiver();
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
                        int headerStart = _receivedStr.IndexOf("<FILENAME>");
                        int filenameStart = headerStart + 10;
                        int filenameEnd = _receivedStr.IndexOf("</FILENAME>");
                        int headerEnd = filenameEnd + 11;
                        int filenameLength = filenameEnd - filenameStart;

                        _filename = _receivedStr.Substring(filenameStart, filenameLength);
                        _receivedStr = _receivedStr.Remove(0, headerEnd);


                        int eofStart = _receivedStr.IndexOf("<EOF>");
                        _receivedStr = _receivedStr.Remove(eofStart, 4);
                        saveFile();
                    }
                }
                else state.EndConnection(); //If read fails then close connection
            }
        }

        private void saveFile()
        {
            String path = "Files\\";
            String filePath = path + _filename;
            makedir(path);
            Console.WriteLine("Server saving file from client: " + filePath);
            File.WriteAllText(filePath, _receivedStr);
        }

        private void makedir(String path)
        {
            DirectoryInfo di = Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully at {0}.",
                Directory.GetCreationTime(path));
        }

        public override void OnDropConnection(ConnectionState state)
        {
            //Nothing to clean here
        }
    }
}
