#pragma checksum "..\..\..\Views\GoodsManagerView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A9D07CB1D99EE8BDBB22C38FA7E84305DCC18BD9BDC88B42CC00BD4FC6B855E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TeleFileServer.Views;


namespace TeleFileServer.Views {
    
    
    /// <summary>
    /// GoodsManagerView
    /// </summary>
    public partial class GoodsManagerView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Views\GoodsManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image photo;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Views\GoodsManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button select;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Views\GoodsManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GoodName;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\GoodsManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Introduce;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views\GoodsManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox kofgComboBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views\GoodsManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CountOfBuyed;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\GoodsManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Price;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\GoodsManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Path;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Views\GoodsManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Select;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Views\GoodsManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OP;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TeleFileServer;component/views/goodsmanagerview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\GoodsManagerView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.photo = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.select = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Views\GoodsManagerView.xaml"
            this.select.Click += new System.Windows.RoutedEventHandler(this.select_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GoodName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Introduce = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.kofgComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.CountOfBuyed = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Path = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Select = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\Views\GoodsManagerView.xaml"
            this.Select.Click += new System.Windows.RoutedEventHandler(this.Select_Click_1);
            
            #line default
            #line hidden
            return;
            case 10:
            this.OP = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\Views\GoodsManagerView.xaml"
            this.OP.Click += new System.Windows.RoutedEventHandler(this.OP_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

