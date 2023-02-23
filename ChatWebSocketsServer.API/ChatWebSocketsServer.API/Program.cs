using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebSocketSharp;
using WebSocketSharp.Server;

namespace ChatWebSocketsServer.API
{
    public class Program
    {
        public class SendMessage : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                Console.WriteLine("Mensagem Recebida: " + e.Data);
                Sessions.Broadcast(e.Data);
            }
        }
        static void Main(string[] args)
        {
            WebSocketServer ws = new WebSocketServer("ws://127.0.0.1:7890");

            ws.AddWebSocketService<SendMessage>("/SendMessage");
            
            ws.Start();
            Console.WriteLine("Servidor Iniciado");

            Console.ReadKey();
            ws.Stop();
        }
    }
}
