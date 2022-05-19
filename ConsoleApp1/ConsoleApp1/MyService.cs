using RRQMSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyService : TcpService<MySocketClient>
    {
        protected override void LoadConfig(RRQMConfig config)
        {
            //此处加载配置，用户可以从配置中获取配置项。
            base.LoadConfig(config);
        }

        protected override void OnConnecting(MySocketClient socketClient, ClientOperationEventArgs e)
        {
            //此处逻辑会多线程处理。

            //e.DataHandlingAdapter:数据处理适配器赋值
            //e.ID:对新连接的客户端进行ID初始化，例如可以设置为其IP地址。
            //e.IsPermitOperation:指示是否运行该链接。

            //对即将连接的客户端做初始化配置
            socketClient.Protocol = new Protocol("MyProtocol");
            base.OnConnecting(socketClient, e);
        }
    }
}
