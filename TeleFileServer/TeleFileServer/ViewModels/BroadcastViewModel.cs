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
    internal class BroadcastViewModel:Screen,IShell
    {
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

        private List<string> _BroadcastList=new List<string>();
        //绑定的属性名是BroadcastList
        public List<string> BroadcastList
        {
            get => _BroadcastList;
            set
            {
                if (BroadcastList == value) return;
                _BroadcastList = value;
                NotifyOfPropertyChange(() => BroadcastList);
            }
        }

        private string _txtBroad;
        //绑定的属性名是txtBroad
        public string txtBroad
        {
            get => _txtBroad;
            set
            {
                if (txtBroad == value) return;
                _txtBroad = value;
                NotifyOfPropertyChange(() => txtBroad);
            }
        }

        private string _txtBroadTitle;
        //绑定的属性名是txtBroadTitle
        public string txtBroadTitle
        {
            get => _txtBroadTitle;
            set
            {
                if (txtBroadTitle == value) return;
                _txtBroadTitle = value;
                NotifyOfPropertyChange(() => txtBroadTitle);
            }
        }



        public void Select()
        {
            try
            {
                using (DB_TELEEntities db=new DB_TELEEntities())
                {
                    var query = db.TB_Broad.SingleOrDefault(s => s.ID == selectedindex + 1);
                    if (query == null)
                    {
                        MessageBox.Show("找不到该条记录");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("广播内容:\r\n" + query.BroadContent,query.BroadTitle);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        public void Broad()
        {
            if (txtBroadTitle==null)
            {
                MessageBox.Show("输入广播标题");
            }
            else
            {
                if (txtBroad==null)
                {
                    MessageBox.Show("输入广播内容");
                }
                else
                {
                    try
                    {
                        int id = 1;
                        using (DB_TELEEntities db=new DB_TELEEntities())
                        {
                            if (db.TB_Broad.ToList().Count!=0)
                            {
                                id = db.TB_Broad.Max(x => x.ID) + 1;
                            }
                            TB_Broad _Broad = new TB_Broad()
                            {
                                ID = id,
                                Date = DateTime.Now,
                                BroadTitle = txtBroadTitle,
                                BroadContent = txtBroad
                            };
                            db.TB_Broad.Add(_Broad);
                            db.SaveChangesAsync();
                            MessageBox.Show("成功发布");
                            father.ActivateItem(new BroadcastViewModel(father));
                            TryClose();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }


        public void Delete()
        {
            try
            {
                using (DB_TELEEntities db=new DB_TELEEntities())
                {
                    int id = selectedindex + 1;
                    var query = db.TB_Broad.SingleOrDefault(s => s.ID == id);
                    if (query == null)
                    {
                        MessageBox.Show("找不到该条记录");
                    }
                    else
                    {
                        var re = MessageBox.Show("确定删除吗？", "警告", MessageBoxButton.YesNo);
                        if (re==MessageBoxResult.Yes)
                        {
                            db.TB_Broad.Remove(query);
                            db.SaveChangesAsync();
                            MessageBox.Show("删除成功");
                            father.ActivateItem(new BroadcastViewModel(father));
                            TryClose();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        public MainViewModel father { get; set; } = new MainViewModel();

        public BroadcastViewModel(MainViewModel mvm)
        {
            selectedindex = -1;
            father = mvm;
            try
            {
                using (DB_TELEEntities db=new DB_TELEEntities())
                {
                    var query = db.TB_Broad.ToList();
                    if (query.Count==0)
                    {
                        return;
                    }
                    foreach (var item in query)
                    {
                        BroadcastList.Add("发布时间" + item.Date.ToString() + "\r\n标题：" + item.BroadTitle);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


    }
}
