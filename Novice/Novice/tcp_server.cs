using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server 
{
	class ClientOb 
	{
		public TcpClient client;
		public ClientOb (TcpClient tcpClient)
		{
			client=tcpClient;
		}
		
		public void Method () 
		{
			NetworkStream stream=client.GetStream();
			byte [] data =new byte[256];
			while (true)
			{
				
				//получаем данные
				StringBuilder builder =new StringBuilder();
				int bytes=0;
				do 
				{
					bytes =stream.Read(data,0,data.Length);
					builder.Append(Encoding.Unicode.GetString(data,0,bytes));
				}
				while(stream.DataAvailable);
				string message =builder.ToString();
				
				Console.WriteLine(message);
				
				//отправка данных
				
				message =message.ToUpper();
				data=Encoding.Unicode.GetBytes(message);
				stream.Write(data,0,data.Length);
			}   
			
		}
	}
	class Program 
	{
		static int port =10000;
		static void Main()
		{
			IPAddress myip=IPAddress.Parse("127.0.0.1");
			TcpListener listener=new TcpListener(myip,port);
			listener.Start();
			
			Console.WriteLine("подключения ...");
			
			//while(true)
			//{
				TcpClient client =listener.AcceptTcpClient();
				ClientOb clientob=new ClientOb(client);
				
				clientob.Method();
				
				//Thread clientThread=new Thread(new ThreadStart(clientob.Method));
				//clientThread.Start();
			//}
		if(listener != null)
			listener.Stop();
		}
	}
}