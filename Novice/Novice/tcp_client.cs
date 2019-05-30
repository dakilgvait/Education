using System;
using System.Text;
using System.Net.Sockets;

namespace tcpclient_lib 
{
	class Program_c 
	{
		const int port=10000;
		const string server_ip="127.0.0.1";
		
		static void Main() 
		{
			Console.WriteLine("Введите текст");
			string message=Console.ReadLine();
			
			TcpClient client =new TcpClient(server_ip, port);
			NetworkStream stream =client.GetStream();
			
			while (true)
			{
				//отправка данных
				byte [] data =Encoding.Unicode.GetBytes(message);
				stream.Write(data,0,data.Length);
				
				//получаем ответ
				data=new byte[256];
				StringBuilder builder =new StringBuilder();
				int bytes =0;

				do 
				{
					bytes=stream.Read(data,0,data.Length);
					builder.Append(Encoding.Unicode.GetString(data,0,bytes));
				}	
				while(stream.DataAvailable);
				
				message=builder.ToString();
				Console.WriteLine("Сервер " + message);
				Console.ReadLine();
			}
			
			
		}
	}
}