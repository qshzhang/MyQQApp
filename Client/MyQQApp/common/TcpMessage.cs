using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    class TcpServerThreadPara
    {
        private string fileName;
        private long fileLen;
        private Socket serverSocket;

        public TcpServerThreadPara(string path, long len, Socket server)
        {
            fileName = path;
            fileLen = len;
            serverSocket = server;
        }

        public void ReceiveAndSendMsgToClient()
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            Byte[] readbyte = new Byte[8 * 1024];
            int readcount = 0;

            Byte[] received = new Byte[1];

            long HaveRead = 0;
            Socket ClientSocket = serverSocket.Accept();
            while (true)
            {
                if (ClientSocket != null)
                {
                    try
                    {
                        ClientSocket.Receive(received);
                    }
                    catch(Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                    }
                    
                    if(received[0] == (Byte)GlobalValue.ResponseType.DownOver)
                    {
                        fs.Close();
                        System.Windows.Forms.MessageBox.Show("send success");
                        break;
                    }
                    else if(received[0] == (Byte)GlobalValue.ResponseType.CancelRecv)
                    {
                        fs.Close();
                        System.Windows.Forms.MessageBox.Show("friend cancel recv");
                        break;
                    }
                    else if (received[0] == (Byte)GlobalValue.ResponseType.NoResponse)
                    {
                        fs.Close();
                        System.Windows.Forms.MessageBox.Show("friend no response");
                        break;
                    }
                    //读文件
                    readcount = fs.Read(readbyte, 0, readbyte.Length);
                    HaveRead += (long)readcount;
                    if (readcount != readbyte.Length)
                    {
                        Byte[] msgByte = new Byte[readcount];
                        Array.Copy(readbyte, msgByte, readcount);
                        try
                        {
                            ClientSocket.Send(msgByte);
                        }
                        catch(Exception)
                        {

                        }
                        
                        //Thread.Sleep(100);
                        //break;
                    }
                    else
                    {
                        try
                        {
                            ClientSocket.Send(readbyte);
                        }
                        catch (Exception)
                        {

                        }
                        
                    }
                }
            }
        }

    }

    class TcpClientThreadPara
    {
        private string fileName;
        private long fileLen;
        private Socket clientSocket;

        public TcpClientThreadPara(string ip, int port, string path, long len, Socket socket)
        {
            fileName = path;
            fileLen = len;
            clientSocket = socket;
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
        }

        public void ReceiveMsgFromServer()
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            Byte[] msgbyte = new Byte[8 * 1024];
            Byte[] response = new Byte[1];
            long HaveWrited = 0;

            clientSocket.Send(response);

            while (true)
            {
                int count = clientSocket.Receive(msgbyte);
                if (count > 0)
                {
                    //写文件
                    fs.Write(msgbyte, 0, count);

                    HaveWrited += (long)count;

                    if(HaveWrited == fileLen)
                    {
                        response[0] = (Byte)GlobalValue.ResponseType.DownOver;
                        try
                        {
                            clientSocket.Send(response);
                        }
                        catch(Exception)
                        {

                        }
                        Thread.Sleep(100);
                        fs.Close();
                        break;
                    }
                    else
                    {
                        response[0] = (Byte)GlobalValue.ResponseType.RequestDownload;
                        try
                        {
                            clientSocket.Send(response);
                        }
                        catch (Exception)
                        {

                        }
                        
                    }
                }
                else
                {
                    fs.Close();
                    break;
                }
            }
        }
    }

    class TcpMessage
    {
        private Socket serverSocket;
        private Socket clientSocket;

        public TcpMessage(int port)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            serverSocket.Listen(10);

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void ServerStartMonitor(string filename, long fileLen)
        {
            TcpServerThreadPara tcpServerThreadPara = new TcpServerThreadPara(filename, fileLen, serverSocket);
            Thread thread = new Thread(new ThreadStart(tcpServerThreadPara.ReceiveAndSendMsgToClient));
            thread.IsBackground = true;
            thread.Start();
        }

        public void ClientStartMonitor(string ip, int port, string filename, long filelen)
        {
            TcpClientThreadPara tcpClientThreadPara = new TcpClientThreadPara(ip, port, filename, filelen, clientSocket);
            Thread thread = new Thread(new ThreadStart(tcpClientThreadPara.ReceiveMsgFromServer));
            thread.IsBackground = true;
            thread.Start();
        }

        public void ClientSendMsgRecvFile(string ip, int port, GlobalValue.ResponseType type)
        {
            try
            {
                clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
            }
            catch(Exception)
            {

            }
            
            Byte[] response = new Byte[1];
            response[0] = (Byte)type;
            try
            {
                clientSocket.Send(response);
            }
            catch (Exception)
            {

            }
        }

    }

    public class ServerTcp
    {
        private Socket serverSocket;

        private FileStream fs;
        private long fileLen;


        public ServerTcp(int port, string filepath, long filesize)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            serverSocket.Listen(1);

            fs = new FileStream(filepath, FileMode.Open);
            fileLen = filesize;
        }

        public void StartMonitor()
        {
            Thread t = new Thread(ReceiveAndSendMsgToClient);
            t.IsBackground = true;
            t.Start();
        }

        private void ReceiveAndSendMsgToClient()
        {
            Byte[] readbyte = new Byte[8 * 1024];
            int readcount = 0;
            while(true)
            {
                Socket ClientSocket = serverSocket.Accept();
                if (ClientSocket != null)
                {
                    //读文件
                    readcount = fs.Read(readbyte, 0, readbyte.Length);

                    Byte[] msgByte = new Byte[readcount];
                    Array.Copy(readbyte, msgByte, readcount);

                    ClientSocket.Send(msgByte);
                }
            }
        }
    }


    public class ClientTcp
    {
        private Socket clientSocket;
        private IPAddress iPAddress;
        private int port;

        private FileStream fs;

        private long fileLen;

        

        public ClientTcp(string ip, int port, string filepath, long filesize)
        {
            fs = new FileStream(filepath, FileMode.OpenOrCreate);
            fileLen = filesize;


            this.iPAddress = IPAddress.Parse(ip);
            this.port = port;

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void StartConnectServer()
        {
            clientSocket.Connect(new IPEndPoint(iPAddress, port));
        }

        public void StartMonitor()
        {
            Thread t = new Thread(ReceiveMsgFromServer);
            t.IsBackground = true;
            t.Start();
        }

        public void ReceiveMsgFromServer()
        {
            Byte[] msgbyte = new Byte[8 * 1024];
            Byte[] response = new Byte[1];
            UInt32 HaveWrited = 0;
            clientSocket.Send(response);
            while (true)
            {
                int count = clientSocket.Receive(msgbyte);
                if (count > 0)
                {
                    //写文件
                    fs.Write(msgbyte, 0, count);

                    clientSocket.Send(response);
                }
            }
        }
    }
}
