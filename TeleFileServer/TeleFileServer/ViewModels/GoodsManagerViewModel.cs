using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleFileServer.Models;
using TeleFileServer.Services;
using TeleFileServer.ViewModels;

namespace TeleFileServer.ViewModels
{
    internal class GoodsManagerViewModel:Screen,IShell
    {
        

        public GoodsManagerViewModel(OrderManagerViewModel Pre,int Iden)
        {
            PublicStaticCode.father = Pre;
            PublicStaticCode.Iden = Iden;
            kind = new List<string>() { "视频", "音乐", "图片", "其他" };
            if (PublicStaticCode.Iden == 1)
            {
                GoodOp = "上传";
            }
            else
            {
                GoodOp = "修改";
            }
        }

        private string _GoodOp;
        //绑定的属性名是GoodOp
        public string GoodOp
        {
            get => _GoodOp;
            set
            {
                if (GoodOp == value) return;
                _GoodOp = value;
                NotifyOfPropertyChange(() => GoodOp);
            }
        }

        private List<string> _kind;
        //绑定的属性名是kind   
        public List<string> kind
        {
            get => _kind;
            set
            {
                if (kind == value) return;
                _kind = value;
                NotifyOfPropertyChange(() => kind);
            }
        }


    }
}
