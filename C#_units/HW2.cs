using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_units
{
    public class HttpServer
    {
        private readonly TcpListener _listener;
        private readonly bool _useThreadPool;
        public HttpServer(int port, bool useThreadPool)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _useThreadPool = useThreadPool;
        }
        public void Start()
        {
            _listener.Start();

            Console.WriteLine("Server started");
            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                if (_useThreadPool)
                {
                    ThreadPool.QueueUserWorkItem(ProcessClient, client);
                }
                else
                {
                    ProcessClient(client);
                }
            }
        }
        private void ProcessClient(object obj)
        {
            TcpClient client = obj as TcpClient;
            if (client == null)
                return;
            using (NetworkStream stream = client.GetStream())
            {
                byte[] request = new byte[1024];
                int bytesRead = stream.Read(request, 0, request.Length);
                string message = Encoding.ASCII.GetString(request, 0, bytesRead);
                var arrMsg = message.Split(' ');
                Console.WriteLine("________");
                List<string> listMsg = new List<string>();
                string response = "";
                foreach (var msg in arrMsg) { listMsg.Add(msg); }
                listMsg.RemoveAt(listMsg.Count - 1);
                switch(listMsg[0])
                {
                    case "GET":
                        if(listMsg[1] == "/")
                        {
                            response = "HTTP/1.1 200 OK\r\n" +
                            "Content-Type: text/html; charset=UTF-8\r\n" +
                            "Connection: close\r\n\r\n" +
                            "<html><body><h1>hello world!</h1></body></html>";
                        } 
                        if (listMsg[1] == "/testMSG") 
                        {
                            response = "HTTP/1.1 200 OK\r\n" +
                            "Content-Type: text/html; charset=UTF-8\r\n" +
                            "Connection: close\r\n\r\n" +
                            "<html><body><h1>jopa!</h1></body></html>";
                        }
                        break;
                    case "POST":
                        break;
                }
                
                byte[] buffer = Encoding.ASCII.GetBytes(response);
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
            client.Close();
        }

        ~HttpServer()
        {
            _listener.Stop();
        }

    }
}
