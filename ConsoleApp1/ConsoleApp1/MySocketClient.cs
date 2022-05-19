using RRQMCore;
using RRQMCore.ByteManager;
using RRQMCore.Serialization;
using RRQMCore.XREF.Newtonsoft.Json;
using RRQMSocket;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MySocketClient : SocketClient
    {

        public RecModel obj_send { get; set; } = new RecModel();

        protected override void HandleReceivedData(ByteBlock Block, IRequestInfo requestInfo)
        {
            //此处逻辑单线程处理。

            //此处处理数据，功能相当于Received事件。


            string rec = Encoding.UTF8.GetString(Block.Buffer, 0, Block.Len);

            RecModel obj_rec = JsonConvert.DeserializeObject<RecModel>(rec);


            switch (obj_rec.Iden)
            {
                case 1:
                    {
                        SignUpModel obj_login = JsonConvert.DeserializeObject<SignUpModel>(obj_rec.obj);
                        Login(obj_login);
                        break;
                    }
                case 2:
                    {
                        SignUpModel obj_forget = JsonConvert.DeserializeObject<SignUpModel>(obj_rec.obj);
                        Forget(obj_forget);
                        break;
                    }
                case 3:
                    {
                        SignUpModel obj_signUp = JsonConvert.DeserializeObject<SignUpModel>(obj_rec.obj);
                        SignUp(obj_signUp);
                        break;
                    }
                case 4:
                    {
                        PostModel obj_post = JsonConvert.DeserializeObject<PostModel>(obj_rec.obj);
                        Post(obj_post);
                        break;
                    }
                case 5:
                    {
                        Recommendation();
                        break;
                    }
                case 6:
                    {
                        GetArticleRequestModel _articlerequest = JsonConvert.DeserializeObject<GetArticleRequestModel>(obj_rec.obj);
                        PushRecommendationArticle(_articlerequest);
                        break;
                    }
                case 7:
                    {
                        AddToMyCollectionModel obj_add = JsonConvert.DeserializeObject<AddToMyCollectionModel>(obj_rec.obj);
                        AddToMyCollectionModel(obj_add);
                        break;
                    }
                case 8:
                    {
                        ShowMyCollection(obj_rec.obj);
                        break;
                    }
                case 9:
                    {
                        SaveDiscussModel obj_savedis = JsonConvert.DeserializeObject<SaveDiscussModel>(obj_rec.obj);
                        SaveDis(obj_savedis);
                        break;
                    }
                case 10:
                    {
                        string Account = obj_rec.obj;
                        Followed(Account);
                        break;
                    }
                case 11:
                    {
                        string Account = obj_rec.obj;
                        MySaying(Account);
                        break;
                    }
                case 12:
                    {
                        KindPush();
                        break;
                    }
                case 13:
                    {
                        ShowGoods();
                        break;
                    }
                case 14:
                    {
                        SignUpModel obj_change=JsonConvert.DeserializeObject<SignUpModel>(obj_rec.obj);
                        Change(obj_change);
                        break;
                    }
                case 15:
                    {
                        ChangeTwoModel obj_add=JsonConvert.DeserializeObject<ChangeTwoModel>(obj_rec.obj);
                        Address(obj_add);
                        break;
                    }
                case 16:
                    { 
                        AddressModel obj_add=JsonConvert.DeserializeObject<AddressModel>(obj_rec.obj);
                        ChangeAddress(obj_add);
                        break;
                    }
                case 17:
                    {
                        ComModel obj_com=JsonConvert.DeserializeObject<ComModel>(obj_rec.obj);
                        ChangeCom(obj_com);
                        break;
                    }
                case 18:
                    { 
                        OLModel ol=JsonConvert.DeserializeObject<OLModel>(obj_rec.obj);
                        GetOnline(ol);
                        break;
                    }
                case 19:
                    {
                        ReqModel obj_req=JsonConvert.DeserializeObject<ReqModel>(obj_rec.obj);
                        ReqFriend(obj_req);
                        break;
                    }
                case 20:
                    {
                        string Account = obj_rec.obj;
                        PushReqList(Account);
                        break;
                    }
                case 21:
                    {
                        ReqModel agree=JsonConvert.DeserializeObject<ReqModel>(obj_rec.obj);
                        Agree(agree);
                        break;
                    }
                case 22:
                    {
                        ReqModel refuse = JsonConvert.DeserializeObject<ReqModel>(obj_rec.obj);
                        Refuse(refuse);
                        break;
                    }
                case 23:
                    {
                        PushBroad();
                        break;
                    }
                case 24:
                    {
                        string Account=obj_rec.obj;
                        PushBuyed(Account);
                        break;
                    }
                case 25:
                    {
                        string Account = obj_rec.obj;
                        PushOrder(Account);
                        break;
                    }
                default:
                    break;
            }
            #region 弃用算法
            //string rec = Encoding.UTF8.GetString(Block.Buffer, 0, Block.Len);
            //string[] recs = rec.Split('~');
            //switch (recs[0])
            //{
            //    case "01":
            //        {
            //            using (ByteBlock byteBlock = new ByteBlock())
            //            {

            //                byteBlock.SetHolding(true);
            //                string account = recs[2];
            //                try
            //                {
            //                    using (DBContent db = new DBContent())
            //                    {
            //                        TB_USER _USER = db.TB_USER.Single(s => s.Account == account);
            //                        if (_USER == null)
            //                        {
            //                            byteBlock.Write("11").Write("2").Write("2");
            //                        }
            //                        else if (_USER.Password.Trim() == recs[3])
            //                        {
            //                            USERModel userModel = new USERModel();
            //                            userModel.Account = db.TB_USER.Single(s => s.Account == account).Account.Trim();
            //                            userModel.Nickname = db.TB_USER.Single(s => s.Account == account).Nickname.Trim();
            //                            userModel.Region = db.TB_USER.Single(s => s.Account == account).Region.Trim();
            //                            userModel.Sex = db.TB_USER.Single(s => s.Account == account).Sex.Trim();
            //                            //userModel.Signature = db.TB_USER.Single(s => s.Account == account).Signature.Trim();
            //                            userModel.Photo = db.TB_USER.Single(s => s.Account == account).Photo;
            //                            byteBlock.Write("11").Write("8").Write("1").WriteObject(userModel,SerializationType.Json);
            //                                //.Write(userModel.Account)
            //                                //.Write(userModel.Nickname)
            //                                //.Write(userModel.Region)
            //                                //.Write(userModel.Sex)
            //                                //.Write(userModel.Signature)
            //                                //.Write(userModel.Photo);

            //                            //byteBlock.Write("11~8~1~" +
            //                            //    db.TB_USER.Single(s => s.Account == account).Account.Trim() + "~" +
            //                            //    db.TB_USER.Single(s => s.Account == account).Nickname.Trim() + "~" +
            //                            //    db.TB_USER.Single(s => s.Account == account).Region.Trim() + "~" +
            //                            //    db.TB_USER.Single(s => s.Account == account).Sex.Trim() + "~" +
            //                            //    db.TB_USER.Single(s => s.Account == account).Signature.Trim() + "~");
            //                            //byteBlock.Write(db.TB_USER.Single(s => s.Account == account).Photo);
            //                        }
            //                        else
            //                        {
            //                            byteBlock.Write("11").Write("2").Write("0");
            //                        }
            //                    }
            //                }
            //                catch (Exception)
            //                {
            //                    byteBlock.Write("11").Write("2").Write("3");
            //                }
            //                SendAsync(byteBlock);
            //                byteBlock.SetHolding(false);
            //            }
            //            break;
            //        }
            //    case "02":
            //        {
            //            using (ByteBlock byteBlock = new ByteBlock())
            //            {
            //                byteBlock.SetHolding(true);
            //                string account = recs[2];
            //                try
            //                {
            //                    using (DBContent db = new DBContent())
            //                    {
            //                        TB_USER _USER = db.TB_USER.Single(s => s.Account == account);
            //                        if (_USER==null)
            //                        {
            //                            byteBlock.Write("12").Write("2").Write("2");
            //                        }
            //                        else
            //                        {
            //                            _USER.Password = recs[3];
            //                            db.SaveChanges();
            //                            byteBlock.Write("12").Write("2").Write("1");
            //                        }
            //                    }
            //                }
            //                catch (Exception)
            //                {
            //                    byteBlock.Write("12").Write("2").Write("3");
            //                }
            //                SendAsync(byteBlock);
            //                byteBlock.SetHolding(false);
            //            }
            //            break;
            //        }
            //    case "03":
            //        {
            //            using (ByteBlock byteBlock = new ByteBlock())
            //            {
            //                byteBlock.SetHolding(true);
            //                string Recstr = recs[2];
            //                try
            //                {
            //                    //SignUpModel sm=new SignUpModel();
            //                    //sm = JsonConvert.DeserializeObject<SignUpModel>(Recstr);
            //                    //using (DBContent db = new DBContent())
            //                    //{
            //                    //    TB_USER _USER = new TB_USER()
            //                    //    {
            //                    //        Account = sm.Account,
            //                    //        Password = sm.Password,
            //                    //        Nickname = sm.Nickname,
            //                    //        Sex = sm.Sex,
            //                    //        Region=sm.Region,
            //                    //        Signature = sm.Signature,
            //                    //        Photo = sm.Photo
            //                    //    };
            //                    //    db.TB_USER.Add(_USER);
            //                    //    db.SaveChanges();
            //                    SignUpModel sm = new SignUpModel()
            //                    {
            //                        Account = recs[2],
            //                        Password = recs[3],
            //                        Nickname = recs[4],
            //                        Sex = recs[5],
            //                        Region = recs[6],
            //                        Photo = Encoding.UTF8.GetBytes(recs[7])
            //                    };
            //                    using (DBContent db = new DBContent())
            //                    {
            //                        TB_USER _USER = new TB_USER()
            //                        {
            //                            Account = sm.Account,
            //                            Password = sm.Password,
            //                            Nickname = sm.Nickname,
            //                            Sex = sm.Sex,
            //                            Region = sm.Region,
            //                            Signature = sm.Signature,
            //                            Photo = sm.Photo
            //                        };
            //                        db.TB_USER.Add(_USER);
            //                        db.SaveChanges();
            //                        byteBlock.Write("13").Write("2").Write("1");
            //                    }
            //                }
            //                catch (Exception)
            //                {
            //                    byteBlock.Write("13").Write("2").Write("2");
            //                }
            //                SendAsync(byteBlock);
            //                byteBlock.SetHolding(false);
            //            }
            //            break;
            //        }
            //    default:
            //        break;
            //}
            #endregion
        }

        private void PushOrder(string account)
        {
            try
            {
                List<ItemsOrderModel> OrdersList = new List<ItemsOrderModel>();
                using (DBContent db = new DBContent())
                {
                    var query = db.TB_Order.Where(w => w.Userid.Trim() == account.Trim()).ToList();
                    if (query.Count!=0)
                    {
                        foreach (var item in query)
                        {
                            var good = db.TB_Goods.SingleOrDefault(s => s.GoodsID == item.GoodsID);
                            if (good != null)
                            {
                                OrdersList.Add(new ItemsOrderModel()
                                {
                                    gid = item.GoodsID,
                                    date = item.Date,
                                    oid = item.OrderID,
                                    nok = good.NumofKind,
                                    nob = good.CountOfBuyed,
                                    pri = good.Price
                                });
                            }
                        }
                        obj_send.Iden = 251;
                        obj_send.obj =JsonConvert.SerializeObject(OrdersList);
                    }
                    else
                    {
                        obj_send.Iden = 252;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 252;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return;
        }

        private void PushBuyed(string account)
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    var query=db.TB_Order.Where(w=>w.Userid.Trim()==account.Trim()).ToList();
                    if (query.Count==0)
                    {
                        obj_send.Iden = 242;
                    }
                    else
                    {
                        List<PushGoodsModel> BuyedList=new List<PushGoodsModel>();
                        foreach (var item in query)
                        {
                            var good = db.TB_Goods.SingleOrDefault(s => s.GoodsID == item.GoodsID);
                            if (good!=null)
                            {
                                BuyedList.Add(new PushGoodsModel()
                                {
                                    Name = good.Name,
                                    Photo = good.Photo,
                                    Introduce = good.Introduce,
                                    Path = good.Path
                                });
                            }
                        }
                        obj_send.Iden = 241;
                        obj_send.obj=JsonConvert.SerializeObject(BuyedList);
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 242;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return;
        }

        private void PushBroad()
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    var query = db.TB_Broad.ToList().OrderByDescending(o => o.Date);
                    List<BroadModel> broads = new List<BroadModel>();
                    foreach (var item in query)
                    {
                        broads.Add(new BroadModel()
                        {
                            Title = item.BroadTitle,
                            Content = item.BroadContent,
                            Date=item.Date
                        });
                    }
                    obj_send.Iden = 231;
                    obj_send.obj=JsonConvert.SerializeObject(broads);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 232;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return;
        }

        private void Refuse(ReqModel refuse)
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    var query = db.TB_Req.Where(s => s.Account == refuse.ReqAccount).SingleOrDefault(s => s.ReqAccount == refuse.Account);
                    if (query != null)
                    {
                        db.TB_Req.Remove(query);
                    }
                    db.SaveChanges();
                    obj_send.Iden = 221;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 222;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return;
        }

        private void Agree(ReqModel agree)
        {
            try
            {
                using (DBContent db=new DBContent())
                {
                    TB_Friends _Friend1 = new TB_Friends()
                    {
                        ID = db.TB_Friends.Max(x => x.ID) + 1,
                        Account = agree.Account,
                        FriendAccount = agree.ReqAccount
                    };
                    db.TB_Friends.Add(_Friend1);
                    db.SaveChanges();
                    TB_Friends _Friend2 = new TB_Friends()
                    {
                        ID = db.TB_Friends.Max(x => x.ID) + 1,
                        Account = agree.ReqAccount,
                        FriendAccount = agree.Account
                    };
                    db.TB_Friends.Add(_Friend2);
                    var query = db.TB_Req.Where(s => s.Account == agree.ReqAccount).SingleOrDefault(s => s.ReqAccount == agree.Account);
                    if (query!=null)
                    {
                        db.TB_Req.Remove(query);
                    }
                    db.SaveChanges();
                    obj_send.Iden = 211;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 212;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return;
        }

        private void PushReqList(string account)
        {
            try
            {
                List<SignUpModel> userlist=new List<SignUpModel>();
                using (DBContent db = new DBContent())
                {
                    var query=db.TB_Req.Where(w=>w.ReqAccount.Trim()==account.Trim()).ToList();
                    if (query.Count == 0)
                    {
                        obj_send.Iden = 202;
                    }
                    else
                    { 
                        foreach (var item in query)
                        {
                            var userquery = db.TB_USER.SingleOrDefault(s => s.Account.Trim() == item.Account.Trim());
                            if (userquery != null)
                            {
                                SignUpModel user = new SignUpModel()
                                {
                                    Photo = userquery.Photo,
                                    Account = userquery.Account
                                };
                                obj_send.Iden = 201;
                                userlist.Add(user);
                            }
                            else
                            {
                                obj_send.Iden = 202;
                            }
                        }
                        obj_send.obj = JsonConvert.SerializeObject(userlist);
                    }
                        

                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 202;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return;
        }

        private void ReqFriend(ReqModel obj_req)
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    var query = db.TB_USER.SingleOrDefault(s => s.Account.Trim() == obj_req.ReqAccount.Trim());
                    if (query != null)
                    {
                        var req = db.TB_Req.FirstOrDefault();
                        if (req == null)
                        {
                            TB_Req _Req = new TB_Req()
                            {
                                ID = 1,
                                Account = obj_req.Account.Trim(),
                                ReqAccount = obj_req.ReqAccount.Trim()
                            };
                            obj_send.Iden = 191;
                            db.TB_Req.Add(_Req);
                        }
                        else
                        {
                            TB_Req _Req = new TB_Req()
                            {
                                ID = db.TB_Req.Max(x => x.ID) + 1,
                                Account = obj_req.Account.Trim(),
                                ReqAccount = obj_req.ReqAccount.Trim()
                            };
                            obj_send.Iden = 191;
                            db.TB_Req.Add(_Req);
                        }
                        db.SaveChanges();
                    }
                    else
                    {
                        obj_send.Iden = 192;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 192;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return;
        }

        private void GetOnline(OLModel ol)
        {
            bool alr=false;
            foreach (var item in StaticClass.OLUser)
            {
                if (item.Account==ol.Account)
                {
                    alr=true;
                }
            }
            if (alr)
            {
                try
                {
                    using (DBContent db = new DBContent())
                    {
                        var query = db.TB_Friends.Where(w => w.Account.Trim() == ol.Account.Trim()).ToList();
                        List<FriendModel> frList = new List<FriendModel>();
                        if (query.Count == 0)
                        {
                            obj_send.Iden = 182;
                        }
                        foreach (var item in query)
                        {
                            string frAccount = item.FriendAccount;
                            var OLModelquery = StaticClass.OLUser.SingleOrDefault(s => s.Account.Trim() == frAccount.Trim());
                            if (OLModelquery != null)
                            {
                                var Frquery = db.TB_USER.SingleOrDefault(s => s.Account.Trim() == frAccount.Trim());
                                if (Frquery != null)
                                {
                                    frList.Add(new FriendModel()
                                    {
                                        Account = frAccount,
                                        IP = OLModelquery.ip,
                                        Port = OLModelquery.port,
                                        NickName = Frquery.Nickname,
                                        Signature = Frquery.Signature,
                                        Region = Frquery.Region,
                                        Photo = Frquery.Photo,
                                        Sex = Frquery.Sex
                                    });
                                    obj_send.Iden = 181;
                                }
                            }
                        }
                        if (frList.Count == 0)
                        {
                            obj_send.Iden = 182;
                        }
                        else
                        {
                            obj_send.obj = JsonConvert.SerializeObject(frList);
                        }

                    }
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException)
                {
                    obj_send.Iden = 182;
                }

                try
                {
                    Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return;
            }
            else
            { 
                StaticClass.OLUser.Add(ol);
            }
            
            try
            {
                using (DBContent db = new DBContent())
                {
                    var query=db.TB_Friends.Where(w=>w.Account.Trim()==ol.Account.Trim()).ToList();
                    List<FriendModel> frList = new List<FriendModel>();
                    if (query.Count==0)
                    {
                        obj_send.Iden = 182;
                    }
                    foreach (var item in query)
                    { 
                        string frAccount=item.FriendAccount;
                        var OLModelquery = StaticClass.OLUser.SingleOrDefault(s => s.Account.Trim() == frAccount.Trim());
                        if (OLModelquery != null)
                        {
                            var Frquery = db.TB_USER.SingleOrDefault(s => s.Account.Trim() == frAccount.Trim());
                            if (Frquery!=null)
                            {
                                frList.Add(new FriendModel()
                                {
                                    Account = frAccount,
                                    IP=OLModelquery.ip,
                                    Port=OLModelquery.port,
                                    NickName=Frquery.Nickname,
                                    Signature=Frquery.Signature,
                                    Region=Frquery.Region,
                                    Photo=Frquery.Photo
                                });
                                obj_send.Iden = 181;
                            }
                        }
                    }
                    if (frList.Count==0)
                    {
                        obj_send.Iden = 182;
                    }
                    else
                    {
                        obj_send.obj = JsonConvert.SerializeObject(frList);
                    }
                    
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 182;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ChangeCom(ComModel obj_com)
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    var com = db.TB_Com.SingleOrDefault(s => s.Account.Trim() == obj_com.Account.Trim());
                    if (com == null)
                    {
                        var Com = new TB_Com()
                        {
                            Account=obj_com.Account,
                            ComAddress=obj_com.ComAddress,
                            ComName=obj_com.ComName,
                            ComTele=obj_com.ComTele
                        };
                        db.TB_Com.Add(Com);
                        obj_send.Iden = 170;
                    }
                    else
                    {
                        com.ComAddress = obj_com.ComAddress;
                        com.ComName = obj_com.ComName;
                        com.ComTele = obj_com.ComTele;

                        obj_send.Iden = 171;
                    }
                    db.SaveChanges();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 172;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ChangeAddress(AddressModel obj_add)
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    var add = db.TB_Address.SingleOrDefault(s => s.Account.Trim() == obj_add.Account.Trim());
                    if (add == null)
                    {
                        var addAddress = new TB_Address()
                        {
                            Account = obj_add.Account,
                            Address1 = obj_add.Address1,
                            Address2 = obj_add.Address2,
                            City = obj_add.City,
                            Country = obj_add.Country,
                            Address = obj_add.Address
                        };
                        db.TB_Address.Add(addAddress);
                        obj_send.Iden = 160;
                    }
                    else
                    {
                        add.Address = obj_add.Address;
                        add.Address1 = obj_add.Address1;
                        add.Address2 = obj_add.Address2;
                        add.City = obj_add.City;
                        add.Country = obj_add.Country;
                        add.Address = obj_add.Address;

                        obj_send.Iden = 161;
                    }
                    db.SaveChanges();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 162;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Address(ChangeTwoModel obj_add)
        {
            try
            {
                SignUpModel obj_user = obj_add.obj_changeUser;
                AddressModel obj_address = obj_add.obj_changeAddress;
                using (DBContent db = new DBContent())
                {
                    var user = db.TB_USER.Single(s => s.Account.Trim() == obj_user.Account.Trim());
                    user.Nickname = obj_user.Nickname;
                    user.Sex = obj_user.Sex;
                    user.Region = obj_user.Region;
                    user.Signature = obj_user.Signature;
                    user.Photo = obj_user.Photo;

                    var add = db.TB_Address.SingleOrDefault(s => s.Account.Trim() == obj_address.Account.Trim());
                    if (add == null)
                    {
                        var addAddress = new TB_Address()
                        {
                            Account = obj_address.Account,
                            Address1 = obj_address.Address1,
                            Address2 = obj_address.Address2,
                            City = obj_address.City,
                            Country = obj_address.Country,
                            Address = obj_address.Address
                        };
                        db.TB_Address.Add(addAddress);
                        obj_send.Iden = 150;
                    }
                    else
                    {
                        add.Address= obj_address.Address;
                        add.Address1= obj_address.Address1;
                        add.Address2= obj_address.Address2;
                        add.City= obj_address.City;
                        add.Country= obj_address.Country;
                        add.Address= obj_address.Address;
                        
                        obj_send.Iden = 151;
                    }
                    db.SaveChanges();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 152;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Change(SignUpModel obj_change)
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    var user=db.TB_USER.Single(s=>s.Account.Trim()==obj_change.Account.Trim());
                    user.Nickname = obj_change.Nickname;
                    user.Sex = obj_change.Sex;
                    user.Region = obj_change.Region;
                    user.Signature = obj_change.Signature;
                    user.Photo = obj_change.Photo;
                    db.SaveChanges();
                    obj_send.Iden = 141;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 142;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ShowGoods()
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    List<TB_Goods> _GoodsList = db.TB_Goods.ToList();
                    List<PushGoodsModel> pushGoodsList = new List<PushGoodsModel>();
                    foreach (TB_Goods item in _GoodsList)
                    {
                        pushGoodsList.Add(new PushGoodsModel()
                        {
                            Num = item.GoodsID,
                            Photo = item.Photo,
                            Name = item.Name,
                            Introduce = item.Introduce,
                            NumOfKind = item.NumofKind,
                            CountOfBuyed = item.CountOfBuyed,
                            Price = (float)item.Price,
                            Path = item.Path
                        });
                    }

                    obj_send.Iden = 131;
                    obj_send.obj = JsonConvert.SerializeObject(pushGoodsList);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 132;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void KindPush()
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    List<TB_POST> _POSTList = db.TB_POST.ToList();
                    KindListModel obj_kindList = new KindListModel();
                    foreach (var item in _POSTList)
                    {
                        switch (item.Blockid)
                        {
                            case 1:
                                {
                                    obj_kindList.ZList.Add(new RecdaModel()
                                    {
                                        Postid = item.Postid,
                                        Title = item.Title,
                                        Date = item.Date,
                                        Cover = item.Cover
                                    });
                                    break;
                                }
                            case 2:
                                {
                                    obj_kindList.XList.Add(new RecdaModel()
                                    {
                                        Postid = item.Postid,
                                        Title = item.Title,
                                        Date = item.Date,
                                        Cover = item.Cover
                                    });
                                    break;
                                }
                            case 3:
                                {
                                    obj_kindList.SList.Add(new RecdaModel()
                                    {
                                        Postid = item.Postid,
                                        Title = item.Title,
                                        Date = item.Date,
                                        Cover = item.Cover
                                    });
                                    break;
                                }
                            case 4:
                                {
                                    obj_kindList.FList.Add(new RecdaModel()
                                    {
                                        Postid = item.Postid,
                                        Title = item.Title,
                                        Date = item.Date,
                                        Cover = item.Cover
                                    });
                                    break;
                                }
                            case 5:
                                {
                                    obj_kindList.TList.Add(new RecdaModel()
                                    {
                                        Postid = item.Postid,
                                        Title = item.Title,
                                        Date = item.Date,
                                        Cover = item.Cover
                                    });
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                    obj_send.Iden = 121;
                    obj_send.obj = JsonConvert.SerializeObject(obj_kindList);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 122;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void MySaying(string account)
        {
            try
            {
                List<RecdaModel> MySayingList = new List<RecdaModel>();
                using (DBContent db = new DBContent())
                {
                    var _SayingList = db.TB_POST.Where(w => w.Userid.Trim() == account.Trim()).ToList();
                    foreach (var item in _SayingList)
                    {
                        TB_POST _POST = db.TB_POST.Single(s => s.Postid == item.Postid);
                        MySayingList.Add(new RecdaModel()
                        {
                            Postid = item.Postid,
                            Title = _POST.Title,
                            Date = _POST.Date,
                            Cover = _POST.Cover
                        });
                    }
                    obj_send.Iden = 111;
                    obj_send.obj = JsonConvert.SerializeObject(MySayingList);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 112;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Followed(string account)
        {
            try
            {
                List<RecdaModel> objList = new List<RecdaModel>();
                using (DBContent db = new DBContent())
                {
                    var list = db.TB_Followed.Where(w => w.Account.Trim() == account.Trim()).ToList();
                    foreach (var obj in list)
                    {
                        List<TB_POST> _POSTList = db.TB_POST.Where(s => s.Userid.Trim() == obj.FollowedAccount.Trim()).ToList();
                        foreach (var _POST in _POSTList)
                        {
                            objList.Add(new RecdaModel()
                            {
                                Postid = _POST.Postid,
                                Title = _POST.Title,
                                Date = _POST.Date,
                                Cover = _POST.Cover
                            });
                        }
                    }
                    obj_send.Iden = 101;
                    obj_send.obj = JsonConvert.SerializeObject(objList);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 102;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void SaveDis(SaveDiscussModel obj_savedis)
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    int disid;
                    if (db.TB_DISCUSS.Count() == 0)
                    {
                        disid = 1;
                    }
                    else
                    {
                        disid = db.TB_DISCUSS.Max(m => m.Discussid) + 1;
                    }
                    TB_DISCUSS _DISCUSS = new TB_DISCUSS()
                    {
                        Postid = obj_savedis.Postid,
                        Account = obj_savedis.Account,
                        Date = obj_savedis.Date,
                        Dicscuss = obj_savedis.Disscuss,
                        Discussid = disid
                    };
                    db.TB_DISCUSS.Add(_DISCUSS);
                    db.SaveChanges();
                    obj_send.Iden = 91;

                }
            }
            catch (Exception)
            {
                obj_send.Iden = 92;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ShowMyCollection(string Account)
        {
            try
            {
                List<RecdaModel> MyCollectionList = new List<RecdaModel>();
                using (DBContent db = new DBContent())
                {
                    var _CollectionList = db.TB_Collection.Where(w => w.Userid.Trim() == Account.Trim()).ToList();
                    foreach (var item in _CollectionList)
                    {
                        TB_POST _POST = db.TB_POST.Single(s => s.Postid == item.Postid);
                        MyCollectionList.Add(new RecdaModel()
                        {
                            Postid = item.Postid,
                            Title = _POST.Title,
                            Date = _POST.Date,
                            Cover = _POST.Cover
                        });
                    }
                    obj_send.Iden = 81;
                    obj_send.obj = JsonConvert.SerializeObject(MyCollectionList);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 82;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void AddToMyCollectionModel(AddToMyCollectionModel obj_add)
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    TB_Collection _Collection = new TB_Collection()
                    {
                        Userid = obj_add.Userid,
                        Postid = obj_add.Postid
                    };
                    db.TB_Collection.Add(_Collection);
                    db.SaveChanges();
                    obj_send.Iden = 71;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 72;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void PushRecommendationArticle(GetArticleRequestModel _articlerequest)
        {
            try
            {
                List<DisModel> disList = new List<DisModel>();
                using (DBContent db = new DBContent())
                {
                    TB_POST _POST = db.TB_POST.SingleOrDefault(s => s.Postid == _articlerequest.SlectPostid);
                    if (_POST==null)
                    {
                        obj_send.Iden = 62;
                    }
                    else
                    {
                        PostModel obj_article = new PostModel()
                        {
                            Postid = _POST.Postid,
                            Author = db.TB_USER.Single(w => w.Account == _POST.Userid).Nickname.Trim(),
                            Title = _POST.Title,
                            Date = _POST.Date,
                            Cover = _POST.Cover,
                            Lable = _POST.Lable,
                            Postcontent = _POST.Postcontent,
                            isFollowed = false
                        };

                        List<TB_Followed> _followedList = db.TB_Followed.Where(w => w.Account.Trim() == _articlerequest.MyAccount).ToList();
                        foreach (TB_Followed _followed in _followedList)
                        {
                            if (_followed.FollowedAccount.Trim() == _POST.Userid.Trim())
                            {
                                obj_article.isFollowed = true;
                            }
                        };

                        List<TB_DISCUSS> _DiscussList = db.TB_DISCUSS.Where(w => w.Postid == _POST.Postid).ToList();
                        foreach (var item in _DiscussList)
                        {
                            disList.Add(new DisModel()
                            {
                                PhotoBytes = db.TB_USER.Single(s => s.Account == item.Account).Photo,
                                NickName = db.TB_USER.Single(s => s.Account == item.Account).Nickname,
                                Date = item.Date,
                                Discuss = item.Dicscuss
                            });
                        }
                        PushArticleModel obj_PushArticle = new PushArticleModel()
                        {
                            obj_post = obj_article,
                            disList = disList
                        };
                        obj_send.Iden = 61;
                        obj_send.obj = JsonConvert.SerializeObject(obj_PushArticle);
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 62;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Recommendation()
        {
            try
            {
                List<RecdaModel> objList = new List<RecdaModel>();
                using (DBContent db = new DBContent())
                {
                    var list = db.TB_RECOMMEND.ToList();
                    foreach (TB_RECOMMEND obj in list)
                    {
                        TB_POST _POST = db.TB_POST.Single(s => s.Postid == obj.Postid);
                        objList.Add(new RecdaModel()
                        {
                            Postid = _POST.Postid,
                            Title = _POST.Title,
                            Date = obj.Date,
                            Cover = _POST.Cover
                        });
                    }
                    obj_send.Iden = 51;
                    obj_send.obj = JsonConvert.SerializeObject(objList);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 52;
            }

            try
            {
                Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj_send)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Post(PostModel obj_post)
        {
            int postid, examineid;
            try
            {
                using (DBContent db = new DBContent())
                {

                    if (db.TB_POST.Any())
                    {
                        int max = db.TB_POST.Max(m => m.Postid);
                        postid = max + 1;
                    }
                    else
                    {
                        postid = 1;
                    }

                    TB_POST _POST = new TB_POST()
                    {
                        Postid = postid,
                        Blockid = obj_post.Blockid,
                        Title = obj_post.Title,
                        Date = obj_post.Date,
                        Postcontent = obj_post.Postcontent,
                        Cover = obj_post.Cover,
                        Userid = obj_post.Userid,
                        Recommendid = -1,
                        Lable = obj_post.Lable
                    };

                    if (obj_post.IsContribute)
                    {

                        if (db.TB_EXAMINE.Any())
                        {
                            int max = db.TB_EXAMINE.Max(m => m.Examineid);
                            examineid = max + 1;
                        }
                        else
                        {
                            examineid = 1;
                        }

                        TB_EXAMINE _EXAMINE = new TB_EXAMINE()
                        {
                            Examineid = examineid,
                            Postid = postid
                        };

                        db.TB_EXAMINE.Add(_EXAMINE);
                        _POST.Examineid = examineid;
                    }
                    else
                    {
                        _POST.Examineid = -1;
                    }
                    db.TB_POST.Add(_POST);
                    db.SaveChanges();
                    obj_send.Iden = 41;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 42;
            }

            try
            {
                string json = JsonConvert.SerializeObject(obj_send);
                Send(Encoding.UTF8.GetBytes(json));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void SignUp(SignUpModel obj_signUp)
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    TB_USER _USER = new TB_USER()
                    {
                        Account = obj_signUp.Account,
                        Password = obj_signUp.Password,
                        Nickname = obj_signUp.Nickname,
                        Region = obj_signUp.Region,
                        Sex = obj_signUp.Sex,
                        Signature = obj_signUp.Signature,
                        Photo = obj_signUp.Photo
                    };
                    db.TB_USER.Add(_USER);
                    db.SaveChanges();
                    obj_send.Iden = 31;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                obj_send.Iden = 32;
            }
            try
            {
                string json = JsonConvert.SerializeObject(obj_send);
                Send(Encoding.UTF8.GetBytes(json));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Forget(SignUpModel obj_forget)
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    TB_USER _USER = db.TB_USER.Single(s => s.Account == obj_forget.Account);
                    _USER.Password = obj_forget.Password;
                    db.SaveChanges();
                    obj_send.Iden = 21;
                }
            }
            catch (Exception)
            {
                obj_send.Iden = 22;
            }
            try
            {
                string json = JsonConvert.SerializeObject(obj_send);
                Send(Encoding.UTF8.GetBytes(json));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Login(SignUpModel obj_login)
        {
            try
            {
                using (DBContent db = new DBContent())
                {
                    TB_USER _USER = db.TB_USER.Single(s => s.Account.Trim() == obj_login.Account);
                    if (_USER.Password.Trim() == obj_login.Password)
                    {
                        obj_send.Iden = 11;
                        USERModel obj_relogin = new USERModel()
                        {
                            Account = _USER.Account.Trim(),
                            Nickname = _USER.Nickname.Trim(),
                            Region = _USER.Region.Trim(),
                            Sex = _USER.Sex.Trim(),
                            Signature = _USER.Signature.Trim(),
                            Photo = _USER.Photo
                        };
                        obj_send.obj = JsonConvert.SerializeObject(obj_relogin);
                    }
                }
            }
            catch (Exception)
            {
                obj_send.Iden = 12;
            }
            string jsons = JsonConvert.SerializeObject(obj_send);
            try
            {
                Send(Encoding.UTF8.GetBytes(jsons));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
