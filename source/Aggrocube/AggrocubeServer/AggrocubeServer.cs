using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace AggrocubeServer
{
	public class AggrocubeServer
	{
		private TcpListener tcpListener;
		private Thread listenThread;

		public AggrocubeServer(int listenPort)
		{
			this.tcpListener = new TcpListener(IPAddress.Any, listenPort);
			this.listenThread = new Thread(new ThreadStart(ListenForClients));
			this.listenThread.Start();
		}

		private void ListenForClients()
		{
			this.tcpListener.Start();
			while(true) {
				TcpClient tcpClient = this.tcpListener.AcceptTcpClient();
				Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
				clientThread.Start(tcpClient);
			}
		}

		private void HandleClientComm (object client)
		{
			TcpClient tcpClient = (TcpClient)client;
			NetworkStream clientStream = tcpClient.GetStream ();
			
			byte[] message = new byte[4096];
			int bytesRead;
			
			while (true) {
				bytesRead = 0;
				try {
					bytesRead = clientStream.Read (message, 0, 4096);
				} catch {
					break;
				}
				
				if (bytesRead == 0) {
					break;
				}
				
				UTF8Encoding encoder = new UTF8Encoding();
				System.Diagnostics.Debug.WriteLine (encoder.GetString (message, 0, bytesRead));
			}
			
			tcpClient.Close ();
		}

		public static void Main (string[] args)
		{
			new AggrocubeServer (9001);
		}
	}
}

