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
        TcpClient tcpclnt;
        Stream stream;


        public bool connect(String ip, int port)
        {
            try
            {
                tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");
                
                tcpclnt.Connect(ip, port);
                // use the ipaddress as in the server program

                stream = tcpclnt.GetStream();

                Console.WriteLine("Connected");


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
                using (Stream source = File.OpenRead(filepath))
                {
                    buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, 1024);
                    }
                }

                String header = "[SEND]" + Path.GetFileName(filepath);
                buffer = new byte[1024];
                Array.Copy(Encoding.UTF8.GetBytes(header), buffer, header.Length);
                Console.WriteLine("Client SEND header: " + Encoding.Default.GetString(buffer));
                stream.Write(buffer, 0, 1024);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                return false;
            }
        }

        public bool write(String data)
        {
            try
            {
                String str = "[GET]00_ship_sizes.txt<EOF>";// Console.ReadLine();
                

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                Console.WriteLine("Transmitting.....");

                stream.Write(ba, 0, ba.Length);

                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                return false;
            }
        }

        public bool getFileFromServer(String filename)
        {
            try
            {
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                return false;
            }
        }

        public bool read()
        {
            try
            {
                byte[] bb = new byte[100];
                int k = stream.Read(bb, 0, 100);

                Console.WriteLine("Bytes read:" + k);

                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(bb[i]));

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                return false;
            }
        }


        public bool disconnect()
        {
            try
            {

                tcpclnt.Close();
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
