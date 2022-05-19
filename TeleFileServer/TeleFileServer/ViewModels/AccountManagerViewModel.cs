using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeleFileServer.Models;

namespace TeleFileServer.ViewModels
{
    internal class AccountManagerViewModel : Screen, IShell
    {
        private List<string> _AccountList = new List<string>();
        //绑定的属性名是AccountList
        public List<string> AccountList
        {
            get => _AccountList;
            set
            {
                if (AccountList == value) return;
                _AccountList = value;
                NotifyOfPropertyChange(() => AccountList);
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

        private bool _IsOne;
        //绑定的属性名是IsOne
        public bool IsOne
        {
            get => _IsOne;
            set
            {
                if (IsOne == value) return;
                _IsOne = value;
                NotifyOfPropertyChange(() => IsOne);
            }
        }

        private bool _IsTwo;
        //绑定的属性名是IsTwo
        public bool IsTwo
        {
            get => _IsTwo;
            set
            {
                if (IsTwo == value) return;
                _IsTwo = value;
                NotifyOfPropertyChange(() => IsTwo);
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


        public void Add()
        {
            try
            {
                using (DB_TELEEntities db = new DB_TELEEntities())
                {
                    if (Account == null || Password == null)
                    {
                        MessageBox.Show("请先输入账户信息");
                    }
                    else
                    {
                        var query = db.TB_Admin.SingleOrDefault(s => s.Account == Account);
                        if (query == null)
                        {
                            int ju = 2;
                            if (IsOne)
                            {
                                ju = 1;
                            }
                            TB_Admin _Admin = new TB_Admin()
                            {
                                Account = Account,
                                Password = Password,
                                Jurisdiction = ju
                            };
                            db.TB_Admin.Add(_Admin);
                            db.SaveChangesAsync();
                            MessageBox.Show("账户添加成功");
                            mainviewmodel.ActivateItem(new AccountManagerViewModel(mainviewmodel));
                            TryClose();
                        }
                        else
                        {
                            int ju = 2;
                            if (IsOne)
                            {
                                ju = 1;
                            }
                            query.Password = Password;
                            query.Jurisdiction = ju;
                            db.SaveChangesAsync();
                            MessageBox.Show("账户修改成功");
                            mainviewmodel.ActivateItem(new AccountManagerViewModel(mainviewmodel));
                            TryClose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        public void Dele()
        {
            try
            {
                using (DB_TELEEntities db = new DB_TELEEntities())
                {
                    string tempstr = AccountList.ElementAt(selectedindex);
                    var query = db.TB_Admin.SingleOrDefault(s => s.Account == tempstr);
                    if (query != null)
                    {
                        db.TB_Admin.Remove(query);
                        db.SaveChangesAsync();
                        MessageBox.Show("账户删除成功");
                        mainviewmodel.ActivateItem(new AccountManagerViewModel(mainviewmodel));
                        TryClose();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        public void Select()
        {
            try
            {
                using (DB_TELEEntities db = new DB_TELEEntities())
                {
                    string tempstr = AccountList.ElementAt(selectedindex);
                    var query = db.TB_Admin.SingleOrDefault(s => s.Account == tempstr);
                    if (query != null)
                    {
                        Account = query.Account;
                        Password = query.Password;
                        if (query.Jurisdiction == 1)
                        {
                            IsOne = true;
                        }
                        else
                        {
                            IsTwo = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public AccountManagerViewModel(MainViewModel mainViewModel)
        {
            mainviewmodel=mainViewModel;
            try
            {
                IsTwo = true;
                selectedindex = -1;
                using (DB_TELEEntities db = new DB_TELEEntities())
                {
                    var query = db.TB_Admin.ToList();
                    foreach (var item in query)
                    {
                        AccountList.Add(item.Account);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        public MainViewModel mainviewmodel { get; set; }




    }
}
