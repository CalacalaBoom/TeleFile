using Caliburn.Micro;
using TeleFileServer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TeleFileServer.ViewModels
{
    public class OrderManagerViewModel : Screen, IShell
    {
        #region Binding
        private string _UserId;
        //绑定的属性名是UserId
        public string UserId
        {
            get => _UserId;
            set
            {
                if (UserId == value) return;
                _UserId = value;
                NotifyOfPropertyChange(() => UserId);
            }
        }

        private string _GoodID;
        //绑定的属性名是GoodID
        public string GoodID
        {
            get => _GoodID;
            set
            {
                if (GoodID == value) return;
                _GoodID = value;
                NotifyOfPropertyChange(() => GoodID);
            }
        }

        private ObservableCollection<ItemsGoodsModel> _ItemsGoods = new ObservableCollection<ItemsGoodsModel>();
        //绑定的属性名是ItemsGoods
        public ObservableCollection<ItemsGoodsModel> ItemsGoods
        {
            get => _ItemsGoods;
            set
            {
                if (ItemsGoods == value) return;
                _ItemsGoods = value;
                NotifyOfPropertyChange(() => ItemsGoods);
            }
        }

        private string _OrderId;
        //绑定的属性名是OrderId
        public string OrderId
        {
            get => _OrderId;
            set
            {
                if (OrderId == value) return;
                _OrderId = value;
                NotifyOfPropertyChange(() => OrderId);
            }
        }

        private int _slcGD;
        //绑定的属性名是slcGD
        public int slcGD
        {
            get => _slcGD;
            set
            {
                if (slcGD == value) return;
                _slcGD = value;
                NotifyOfPropertyChange(() => slcGD);
            }
        }

        #endregion

        #region Command


        public void AddGood()
        {
            new WindowManager().ShowWindow(new GoodsManagerViewModel(this, 1));
        }


        public void DeleteGood()
        {
            if (slcGD != -1)
            {
                ItemsGoodsModel item = ItemsGoods.ElementAtOrDefault(slcGD);
                var re = MessageBox.Show("确定要删除该条商品？", "提示", MessageBoxButton.YesNo);
                if (re == MessageBoxResult.Yes)
                {
                    using (DB_TELEEntities db = new DB_TELEEntities())
                    {
                        var query = db.TB_Goods.SingleOrDefault(s => s.GoodsID==item.gid);
                        if (query != null)
                        { 
                            db.TB_Goods.Remove(query);
                            db.SaveChangesAsync();
                            MessageBox.Show("删除成功");
                            TryClose();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }


        public void ChangeGood()
        {
            new WindowManager().ShowWindow(new GoodsManagerViewModel(this, 2));
        }

        public void AddOrder()
        {
            if (UserId == null)
            {
                MessageBox.Show("请输入用户账号");
            }
            else
            {
                if (slcGD == -1)
                {
                    MessageBox.Show("请选择商品");
                }
                else
                {
                    try
                    {
                        int id = 1;
                        using (DB_TELEEntities db = new DB_TELEEntities())
                        {
                            if (db.TB_Order.ToList().Count != 0)
                            {
                                id = db.TB_Order.Max(x => x.OrderID);
                                id++;
                            }
                            TB_Order _Order = new TB_Order()
                            {
                                OrderID = id,
                                Userid = UserId,
                                GoodsID = Convert.ToInt32(GoodID),
                                Date = DateTime.Now
                            };
                            db.TB_Order.Add(_Order);
                            db.SaveChanges();
                            OrderId = "订单编号： " + id;
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        public void Slcchanged()
        {
            if (slcGD != -1)
            {
                ItemsGoodsModel item = ItemsGoods.ElementAtOrDefault(slcGD);
                GoodID = item.gid.ToString();
                try
                {
                    using (DB_TELEEntities db = new DB_TELEEntities())
                    {
                        new WindowManager().ShowWindow(new GoodsIntroViewModel(db.TB_Goods.Single(s => s.GoodsID == item.gid)));
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public void SerchGood()
        {
            if (GoodID == null)
            {
                MessageBox.Show("请输入商品ID");
            }
            else
            {
                ItemsGoods.Clear();
                try
                {
                    using (DB_TELEEntities db = new DB_TELEEntities())
                    {
                        int id = Convert.ToInt32(GoodID);
                        var query = db.TB_Goods.SingleOrDefault(w => w.GoodsID == id);
                        if (query == null)
                        {
                            MessageBox.Show("不存在此商品");
                        }
                        else
                        {
                            ItemsGoods.Add(new ItemsGoodsModel()
                            {
                                gid = query.GoodsID,
                                name = query.Name,
                                intro = query.Introduce,
                                nofk = query.NumofKind,
                                cofb = query.CountOfBuyed,
                                pri = (float)query.Price,
                                pa = query.Path
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
        #endregion

        public OrderManagerViewModel()
        {
            try
            {
                using (DB_TELEEntities db = new DB_TELEEntities())
                {
                    var query = db.TB_Goods.ToList();
                    foreach (var item in query)
                    {
                        ItemsGoods.Add(new ItemsGoodsModel()
                        {
                            gid = item.GoodsID,
                            name = item.Name,
                            intro = item.Introduce,
                            nofk = item.NumofKind,
                            cofb = item.CountOfBuyed,
                            pri = (float)item.Price,
                            pa = item.Path
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
}
