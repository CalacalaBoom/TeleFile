using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TeleFileServer.Models;
using TeleFileServer.Services;

namespace TeleFileServer.Views
{
    /// <summary>
    /// GoodsManagerView.xaml 的交互逻辑
    /// </summary>
    public partial class GoodsManagerView : Window
    {
        public GoodsManagerView()
        {
            InitializeComponent();
        }

        public byte[] img { get; set; }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openPhoto = new OpenFileDialog
                {
                    Title = "选择头像图片",
                    Filter = "所有文件|*.*"
                };
                openPhoto.InitialDirectory = @"C:\Users\Administrator\Desktop\封面";
                if ((bool)openPhoto.ShowDialog())
                {
                    img = PublicStaticCode.GetPictureData(openPhoto.FileName);
                    BitmapImage bitmapImage = new BitmapImage(new Uri(openPhoto.FileName));
                    photo.Source = bitmapImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Select_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog
            {
                Title = "选择上传文件",
                Filter = "所有文件|*.*"

            };
            dig.InitialDirectory = @"C:\TeleFile\Store";

            if ((bool)dig.ShowDialog())
            {
                Path.Text = dig.FileName;
            }
        }

        private void Change()
        {
            try
            {
                using (DB_TELEEntities db = new DB_TELEEntities())
                {
                    if (PublicStaticCode.father.slcGD != -1)
                    {
                        ItemsGoodsModel item = PublicStaticCode.father.ItemsGoods.ElementAtOrDefault(PublicStaticCode.father.slcGD);
                        try
                        {
                            var query = db.TB_Goods.SingleOrDefault(s => s.GoodsID == item.gid);
                            if (query != null)
                            {
                                query.Photo = img;
                                query.Name = GoodName.Text;
                                query.Introduce = Introduce.Text;
                                query.NumofKind = kofgComboBox.SelectedIndex + 1;
                                query.CountOfBuyed = Convert.ToInt32(CountOfBuyed.Text);
                                query.Price = Convert.ToDouble(Price.Text);
                                query.Path = Path.Text;
                                db.SaveChangesAsync();
                                MessageBox.Show("修改成功");
                                
                                PublicStaticCode.father.TryClose();

                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void Upload()
        {
            try
            {
                using (DB_TELEEntities db = new DB_TELEEntities())
                {
                    TB_Goods goods = new TB_Goods();
                    if (db.TB_Goods.Count() == 0)
                    {
                        goods.GoodsID = 1;
                    }
                    else
                    {
                        goods.GoodsID = db.TB_Goods.Max(m => m.GoodsID) + 1;
                    }
                    goods.Photo = img;
                    goods.Name = GoodName.Text;
                    goods.Introduce = Introduce.Text;
                    goods.NumofKind = kofgComboBox.SelectedIndex + 1;
                    goods.CountOfBuyed = Convert.ToInt32(CountOfBuyed.Text);
                    goods.Price = Convert.ToDouble(Price.Text);
                    goods.Path = Path.Text;
                    db.TB_Goods.Add(goods);
                    db.SaveChangesAsync();
                    MessageBox.Show("添加成功");
                    
                    PublicStaticCode.father.TryClose();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void OP_Click(object sender, RoutedEventArgs e)
        {
            if (PublicStaticCode.Iden == 1)             
            {
                Upload();
            }
            if (PublicStaticCode.Iden == 2)
            {
                Change();
            }
        }
    }
}
