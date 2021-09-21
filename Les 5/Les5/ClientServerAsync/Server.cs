﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncEchoServer
{
    public class AsyncEchoServer
    {
        private int _listeningPort;
        public AsyncEchoServer( int port) {
            _listeningPort = port;
        }

         // Start listening for connection:
         public async void Start() {
            IPAddress ipAddres = IPAddress.Loopback;
            TcpListener listener = new TcpListener(ipAddres, _listeningPort);
            listener.Start();
            LogMessage("Server is running");
            LogMessage("Listening on port " + _listeningPort);
 
            while (true) {
                LogMessage("Waiting for connections...");
                try { 
                var tcpClient = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                    await HandleClientAsync(tcpClient);
                } catch (Exception exp) {
                    LogMessage(exp.ToString());
                }
            }
         }
         /// Process Individual client
 
        private async Task HandleClientAsync(TcpClient tcpClient)  {
            string clientInfo = tcpClient.Client.RemoteEndPoint.ToString();
            LogMessage(string.Format("Got connection request from {0}", clientInfo));
            try {
                using (var networkStream = tcpClient.GetStream()) {
                    using (var reader = new StreamReader(networkStream)) {
                        using (var writer = new StreamWriter(networkStream)) {
                            writer.AutoFlush = true;
                            while (true) {
                                var dataFromServer = await reader.ReadLineAsync();
                                if (string.IsNullOrEmpty(dataFromServer)) {
                                    break;
                                }

                                LogMessage(dataFromServer);
                                await writer.WriteLineAsync("FromServer-" + dataFromServer);
                            }
                        }
                    }
                }
            } catch (Exception exp) {
                LogMessage(exp.Message);
            } finally {
                LogMessage($"Closing the client connection - {clientInfo}");
                tcpClient.Close();
            }
        }

        private void LogMessage(string message, [CallerMemberName]string callername = "") {
            Console.WriteLine("[{0}] - Thread-{1}- {2}",
                    callername, Thread.CurrentThread.ManagedThreadId, message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AsyncEchoServer asyncServer = new AsyncEchoServer(51510);
            asyncServer.Start();
            Console.ReadLine();
        }
    }
}
