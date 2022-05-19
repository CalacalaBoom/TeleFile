using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRQMSocket;
using RRQMSocket.FileTransfer;
using RRQMSocket.RPC.RRQMRPC;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyService service = new MyService();
            service.Connecting += (client, e) => {
                e.DataHandlingAdapter = new FixedHeaderPackageAdapter() { FixedHeaderType = FixedHeaderType.Int,MaxPackageSize=1024*1024* 30 };
                Console.WriteLine(client.IP+":"+client.Port+"正在连接"); };//有客户端正在连接
            service.Connected += (client, e) => { Console.WriteLine(client.IP + ":" + client.Port + "已连接"); };//有客户端连接
            service.Disconnected += (client, e) => { Console.WriteLine(client.IP + ":" + client.Port + "断开连接"); };//有客户端断开连接

            service.Setup(new RRQMConfig()//载入配置     
                .SetListenIPHosts(new IPHost[] { new IPHost("192.168.179.1:7789") })//同时监听两个地址
                .SetMaxCount(10000)
                .SetBufferLength(1024*1024* 30)
                .SetThreadCount(100))
                .Start();//启动

            FileService parser = new FileService();
            parser.Connecting += (client, e) => { Console.WriteLine(client.Port + "FileClient正在连接"); };//有客户端正在连接
            parser.Connected += (client, e) => { Console.WriteLine(client.Port + "FileClient已连接"); };//有客户端连接
            parser.Disconnected += (client, e) => { Console.WriteLine(client.Port + "FileClient断开连接"); };//有客户端断开连接
            parser.Received += (client, protocol, byteBlock) =>
            {
                //从客户端收到信息
                //因为TcpRpcParser继承自ProtocolService，所以也支持“协议+数据”的数据格式。
                //但是一般这里不使用。
            };

            parser.Setup(new RRQMConfig()//载入配置     
                .SetListenIPHosts(new IPHost[] { new IPHost(7790) })//同时监听两个地址
                .SetMaxCount(10000)
                .SetThreadCount(100)
                .SetVerifyToken("Download")
                .SetProxyToken("RPC"))
                .Start();//启动


            Console.ReadLine();
        }
    }
}
