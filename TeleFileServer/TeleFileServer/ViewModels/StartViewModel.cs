using Caliburn.Micro;
using TeleFileServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeleFileServer.Services;

namespace TeleFileServer.ViewModels
{
    public class StartViewModel:Screen,IShell
    {

        
        private string _txtUserID;
        //绑定的属性名是txtUserID
        public string txtUserID
        {
            get => _txtUserID;
            set
            {
                if (txtUserID == value) return;
                _txtUserID = value;
                NotifyOfPropertyChange(() => txtUserID);
            }
        }

        private string _Password;
        //绑定的属性名是Password
        public string Password
        {
            get => _Password;
            set
            {
                if (Password == value) return;
                _Password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }


        public void Login()
        {
            if (txtUserID==null)
            {
                MessageBox.Show("账号不可为空");
            }
            else if (Password==null)
            {
                MessageBox.Show("密码不可为空");
            }
            else
            {
                try
                {
                    using (DB_TELEEntities db=new DB_TELEEntities())
                    {
                        var query = db.TB_Admin.SingleOrDefault(s => s.Account == txtUserID);
                        if (query == null)
                        {
                            MessageBox.Show("没有该账户");
                        }
                        else
                        {
                            if (query.Password==Password)
                            {
                                PublicStaticCode.Jurisdiction=query.Jurisdiction;
                                new WindowManager().ShowWindow(new MainViewModel());
                                TryClose();
                            }
                            else
                            {
                                Plogs.Warn("StartViewModel", txtUserID + " 密码错误");
                                MessageBox.Show("密码错误");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Plogs.Error("StartViewModel", ex.Message);
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }


        public void Exit()
        {
            TryClose();
        }

        public StartViewModel()
        {
            txtUserID = "admin";
            Password = "123456";
        }
    }
}
