using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using TeleFileServer.Models;
using TeleFileServer.Services;

namespace TeleFileServer.ViewModels
{
    internal class GoodsIntroViewModel:Screen,IShell
    {
        private BitmapImage _goodsimg;
        //绑定的属性名是GoodsIMG
        public BitmapImage GoodsIMG
        {
            get => _goodsimg;
            set
            {
                if (GoodsIMG == value) return;
                _goodsimg = value;
                NotifyOfPropertyChange(() => GoodsIMG);
            }
        }

        private string _name;
        //绑定的属性名是Name
        public string Name
        {
            get => _name;
            set
            {
                if (Name == value) return;
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        private string _kind;
        //绑定的属性名是Kind
        public string Kind
        {
            get => _kind;
            set
            {
                if (Kind == value) return;
                _kind = value;
                NotifyOfPropertyChange(() => Kind);
            }
        }

        private string _count;
        //绑定的属性名是MyProperty
        public string Count
        {
            get => _count;
            set
            {
                if (Count == value) return;
                _count = value;
                NotifyOfPropertyChange(() => Count);
            }
        }

        private string _introduce;
        //绑定的属性名是Introduce
        public string Introduce
        {
            get => _introduce;
            set
            {
                if (Introduce == value) return;
                _introduce = value;
                NotifyOfPropertyChange(() => Introduce);
            }
        }



        public TB_Goods  Goods { get; set; }

        public GoodsIntroViewModel(TB_Goods goods)
        {
            Goods = goods;

            GoodsIMG = PublicStaticCode.ByteArrayToBitmapImage(Goods.Photo);

            Name = Goods.Name;

            Kind = "售价（元）：" + Goods.Price.ToString() + "\r\n \r\n" + PublicStaticCode.GetKind(Goods.NumofKind);

            Count = Goods.CountOfBuyed.ToString();

            Introduce = Goods.Introduce;
        }
    }
}
