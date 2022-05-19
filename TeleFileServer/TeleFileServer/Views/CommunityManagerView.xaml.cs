using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeleFileServer.Models;
using TeleFileServer.Services;

namespace TeleFileServer.Views
{
    /// <summary>
    /// CommunityManagerView.xaml 的交互逻辑
    /// </summary>
    public partial class CommunityManagerView : UserControl
    {
        public CommunityManagerView()
        {
            InitializeComponent();
        }

        private void dtgdSO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = PublicStaticCode.pids.ElementAtOrDefault(dtgdSO.SelectedIndex);
                DB_TELEEntities db = new DB_TELEEntities();
                var query = db.TB_POST.SingleOrDefault(p => p.Postid == id);
                Stream s = new MemoryStream(query.Postcontent);
                FlowDocument doc = System.Windows.Markup.XamlReader.Load(s) as FlowDocument;
                s.Close();
                RichContent.Document = doc;

                string Path = "C:\\TeleFile\\cache\\" + doc.GetHashCode() + ".jpg";
                File.WriteAllBytes(Path, query.Cover);

                Image img = new Image();
                BitmapImage bImg = new BitmapImage();
                bImg.BeginInit();
                //bImg.UriSource = new Uri(@"C:\Users\admin\source\repos\WPFRichTextBox\WPFRichTextBox\ext_apk.png", UriKind.Relative);
                bImg.UriSource = new Uri(Path, UriKind.RelativeOrAbsolute);
                bImg.EndInit();
                img.Source = bImg;
                new InlineUIContainer(img, RichContent.Document.ContentStart); //插入图片到选定位置
                db.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
