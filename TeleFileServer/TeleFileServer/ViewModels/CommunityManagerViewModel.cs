using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeleFileServer.Models;
using TeleFileServer.Services;

namespace TeleFileServer.ViewModels
{
    internal class CommunityManagerViewModel : Screen, IShell
    {
        private ObservableCollection<PManagerModel> _ItemsPost = new ObservableCollection<PManagerModel>();
        //绑定的属性名是ItemsPost
        public ObservableCollection<PManagerModel> ItemsPost
        {
            get => _ItemsPost;
            set
            {
                if (ItemsPost == value) return;
                _ItemsPost = value;
                NotifyOfPropertyChange(() => ItemsPost);
            }
        }

        private int _slc;
        //绑定的属性名是slc
        public int slc
        {
            get => _slc;
            set
            {
                if (slc == value) return;
                _slc = value;
                NotifyOfPropertyChange(() => slc);
            }
        }

        public string name = "operator";

        public void AddRec()
        {
            try
            {
                using (DB_TELEEntities db = new DB_TELEEntities())
                {
                    int i = db.TB_POST.Max(x => x.Recommendid);
                    var query = db.TB_POST.SingleOrDefault(s => s.Postid == slc + 1);
                    if (query != null)
                    {
                        query.Recommendid = i + 1;
                        if (PublicStaticCode.Jurisdiction == 1)
                        {
                            name = "Admin";
                        }
                        TB_RECOMMEND _Re = new TB_RECOMMEND()
                        {
                            Recommendid = i + 1,
                            Date = DateTime.Now,
                            Recommender = name,
                            Postid = query.Postid,
                            Userid = query.Userid
                        };
                        db.TB_RECOMMEND.Add(_Re);
                        db.SaveChanges();
                        MessageBox.Show("添加成功");
                        TryClose();
                        father.ActivateItem(new CommunityManagerViewModel(father));
                    }
                    else
                    {
                        MessageBox.Show("数据库错误");
                    }
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        public void DeleteRec()
        {
            try
            {
                using (DB_TELEEntities db = new DB_TELEEntities())
                {
                    var query = db.TB_RECOMMEND.SingleOrDefault(s => s.Postid == slc + 1);
                    if (query != null)
                    {
                        var post = db.TB_POST.SingleOrDefault(s => s.Postid == query.Postid);
                        if (post != null)
                        {
                            db.TB_RECOMMEND.Remove(query);
                            post.Recommendid = -1;
                            db.SaveChanges();
                            MessageBox.Show("取消推荐成功");
                            TryClose();
                            father.ActivateItem(new CommunityManagerViewModel(father));
                        }
                        else
                        {
                            MessageBox.Show("数据库错误");
                        }
                    }
                    else
                    {
                        MessageBox.Show("数据库错误");
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
            try
            {
                using (DB_TELEEntities db = new DB_TELEEntities())
                {
                    var query = db.TB_POST.SingleOrDefault(s => s.Postid == slc + 1);
                    if (query != null)
                    {
                        if (query.Recommendid != -1)
                        {
                            var re = db.TB_RECOMMEND.SingleOrDefault(s => s.Postid == query.Postid);
                            if (re!=null)
                            {
                                db.TB_RECOMMEND.Remove(re);
                            }
                            else
                            {
                                MessageBox.Show("数据库错误");
                                return;
                            }
                        }
                        db.TB_POST.Remove(query);
                        db.SaveChangesAsync();
                        MessageBox.Show("删除成功");
                        TryClose();
                        father.ActivateItem(new CommunityManagerViewModel(father));
                    }
                    else
                    {
                        MessageBox.Show("数据库错误");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        public MainViewModel father { get; set; } = new MainViewModel();

        public CommunityManagerViewModel(MainViewModel mvm)
        {
            PublicStaticCode.pids.Clear();
            father = mvm;
            try
            {
                using (DB_TELEEntities db = new DB_TELEEntities())
                {
                    var query = db.TB_POST.ToList();
                    foreach (var item in query)
                    {
                        ItemsPost.Add(new PManagerModel()
                        {
                            pid = item.Postid,
                            bid = item.Blockid,
                            ti = item.Title,
                            date = item.Date,
                            uid = item.Userid,
                            rid = item.Recommendid,
                            la = item.Lable
                        });
                        PublicStaticCode.pids.Add(item.Postid);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
    class PManagerModel
    {
        public int pid { get; set; }

        public int bid { get; set; }

        public string ti { get; set; }

        public DateTime date { get; set; }

        public string uid { get; set; }

        public int rid { get; set; }

        public string la { get; set; }
    }
}
