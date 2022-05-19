using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using TeleFileServer.Services;

namespace TeleFileServer.ViewModels
{
    public class MainViewModel : Conductor<object>, IShell
    {

        private string _Account;
        //绑定的属性名是Account
        public string Account
        {
            get => _Account;
            set
            {
                if (Account == value) return;
                _Account = value;
                NotifyOfPropertyChange(() => Account);
            }
        }

        private string _IPHost;
        //绑定的属性名是IPHost
        public string IPHost
        {
            get => _IPHost;
            set
            {
                if (IPHost == value) return;
                _IPHost = value;
                NotifyOfPropertyChange(() => IPHost);
            }
        }


        public MainViewModel()
        {
            if (PublicStaticCode.Jurisdiction == 1)
            {
                Account = "账号:Admin\r\n权限等级：1";
            }
            else
            {
                Account = "账号:Operator\r\n权限等级：2";
            }
        }


        public void btnCom()
        {
            ActivateItem(new CommunityManagerViewModel(this));
        }

        public void btnBroadcast()
        {
            ActivateItem(new BroadcastViewModel(this));
        }


        public void btnAccount()
        {
            ActivateItem(new AccountManagerViewModel(this));
        }


        public void btnOrder()
        {
            ActivateItem(new OrderManagerViewModel());
        }


        public void btnUser()
        {
            ActivateItem(new UserManagerViewModel(this));
        }


        public void Stop()
        {
            try
            {
                System.Collections.ArrayList procList = new System.Collections.ArrayList();
                string tempName = "";
                int begpos;
                int endpos;
                foreach (System.Diagnostics.Process thisProc in System.Diagnostics.Process.GetProcesses())
                {
                    tempName = thisProc.ToString();
                    begpos = tempName.IndexOf("(") + 1;
                    endpos = tempName.IndexOf(")");
                    tempName = tempName.Substring(begpos, endpos - begpos);
                    procList.Add(tempName);
                    if (tempName == "ConsoleApp1")
                    {
                        if (!thisProc.CloseMainWindow())
                            thisProc.Kill();//当发送关闭窗口命令无效时强行结束进程
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            IPHost = null;
        }


        public void Start()
        {
            Process pc = new Process();
            pc.StartInfo.FileName = "C:\\Users\\Administrator\\source\\repos\\ConsoleApp1\\ConsoleApp1\\bin\\Debug\\ConsoleApp1.exe";
            pc.Start();

            IPHost = "服务器IP：192.168.179.1\r\n监听端口：7789（TCP）\r\n7790（FileTransfer）";
        }

        public void Exit()
        {
            TryClose();
        }
    }
}
