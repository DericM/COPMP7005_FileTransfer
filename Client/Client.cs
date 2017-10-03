using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        TcpClient commandClnt;
        TcpClient transferClnt;
        Stream commandStream;
        Stream transferStream;
        


        public bool connect(String ip, int port)
        {
            try
            {
                commandClnt = new TcpClient();
                transferClnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                commandClnt.Connect(ip, 7005);
                transferClnt.Connect(ip, 7004);

                commandStream = commandClnt.GetStream();
                transferStream = transferClnt.GetStream();

                Console.WriteLine("Connected");

                requestListFromServer();
                
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                return false;
            }
        }

        public bool sendFileToServer(String filepath)
        {
            byte[] buffer = new byte[1024];

            Console.WriteLine("Client sending server file: " + filepath);

            try
            {
                String header = "<FILENAME>" + Path.GetFileName(filepath) + "</FILENAME>";
                transferStream.Write(Encoding.UTF8.GetBytes(header), 0, header.Length);

                using (Stream source = File.OpenRead(filepath))
                {
                    buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        transferStream.Write(buffer, 0, bytesRead);
                    }
                }

                transferStream.Write(Encoding.UTF8.GetBytes("<EOF>"), 0, 5);

                requestListFromServer();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                return false;
            }
        }



        public void requestListFromServer()
        {
            String header = "<FILELIST><EOF>";
            commandStream.Write(Encoding.UTF8.GetBytes(header), 0, header.Length);
        }

        public void requestFileFromServer(String filename)
        {
            String header = "<FILENAME>" + filename + "</FILENAME><EOF>";
            commandStream.Write(Encoding.UTF8.GetBytes(header), 0, header.Length);
        }

        public bool disconnect()
        {
            try
            {

                commandStream.Close();
                transferStream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                return false;
            }
        }

    }
}
