using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeleFileServer.Models;

namespace TeleFileServer.ViewModels
{
    internal class UserManagerViewModel:Screen,IShell
    {
        private ObservableCollection<userModel> _UserItems = new ObservableCollection<userModel>();
        //绑定的属性名是ItemsGoods
        public ObservableCollection<userModel> UserItems
        {
            get => _UserItems;
            set
            {
                if (UserItems == value) return;
                _UserItems = value;
                NotifyOfPropertyChange(() => UserItems);
            }
        }

        private int _selectedindex;
        //绑定的属性名是selectedindex
        public int selectedindex
        {
            get => _selectedindex;
            set
            {
                if (selectedindex == value) return;
                _selectedindex = value;
                NotifyOfPropertyChange(() => selectedindex);
            }
        }

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

        private userModel _item;
        //绑定的属性名是item
        public userModel item
        {
            get => _item;
            set
            {
                if (item == value) return;
                _item = value;
                NotifyOfPropertyChange(() => item);
            }
        }


        public MainViewModel father { get; set; } = new MainViewModel();


        public void SearchUser()
        {
            UserItems.Clear();
            try
            {
                using (DB_TELEEntities db=new DB_TELEEntities())
                {
                    var query = db.TB_USER.SingleOrDefault(s => s.Account.Trim() == Account.Trim());
                    if (query != null)
                    {
                        UserItems.Add(new userModel()
                        {
                            aco = query.Account,
                            nic = query.Nickname,
                            reg = query.Region,
                            sex = query.Sex,
                            sig = query.Signature
                        });
                    }
                    else
                    {
                        MessageBox.Show("没有此用户");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        public void Delete()
        {
            if (selectedindex==-1)
            {
                MessageBox.Show("请选择封禁的用户");
            }
            string ac = item.aco;
            if (ac==null)
            {
                MessageBox.Show("获取用户账号失败");
            }
            else
            {
                try
                {
                    using (DB_TELEEntities db=new DB_TELEEntities())
                    {
                        var query = db.TB_USER.SingleOrDefault(s => s.Account.Trim() == ac.Trim());
                        if (query!=null)
                        {
                            db.TB_USER.Remove(query);
                            db.SaveChangesAsync();
                            MessageBox.Show("此用户删除成功");
                            TryClose();
                            father.ActivateItem(new UserManagerViewModel(father));
                        }
                        else
                        {
                            MessageBox.Show("没有查到此用户");
                            return ;
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public UserManagerViewModel(MainViewModel mainViewModel)
        {
            selectedindex = -1;
            father = mainViewModel;
            try
            {
                using (DB_TELEEntities db=new DB_TELEEntities())
                {
                    var query=db.TB_USER.ToList();
                    foreach (var item in query)
                    {
                        UserItems.Add(new userModel()
                        {
                            aco = item.Account,
                            nic = item.Nickname,
                            reg = item.Region,
                            sex = item.Sex,
                            sig = item.Signature
                        });
                    }   
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
    class userModel
    {
        public string aco { get; set; }

        public string nic { get; set; }

        public string reg { get; set; }

        public string sex { get; set; }

        public string sig { get; set; }
    }
}
