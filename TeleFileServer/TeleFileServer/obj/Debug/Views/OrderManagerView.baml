   M S B A M L   `   `   `  ����I  ETeleFileServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TeleFileServer.ViewsTeleFileServer.Views  5      A%clr-namespace:TeleFileServer.ServicesTeleFileServer.Services  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      +    %TeleFileServer.Views.OrderManagerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:TeleFileServer.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      5	pwdHelper%clr-namespace:TeleFileServer.Services  5      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5	      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5
      .��5      � .+�5   
   �� 
������   � Cursor$
  Hand��6*   ._�5      ��  �� CornerRadius$ 20��6   $��0q�6'   ��5      �� 5       �� Color$ White��6&    �� Opacity$	 0.9Q�64   ._�5      �  � RowDefinitions 5      �� 5      $	��700 �6(   67   �� 5      $��* �6(   65   .+�5      �� $��0��6    $��用户账号：��6-   $��30(�6:   $��	50,50,0,0q�6H   $
��Left=�6[   $	��Top=�6v   �� 5       !  MaterialDesignOutlinedTextBox#��[  6   $��0��6m   $	��300��6z   $��50��6�   $
��Left=�6�   $	��Top=�6�   $��
230,44,0,0q�6�   $��30(�6�   $��0,0,0,0q�6�   $��Center=�6�   $  Arrow��6  ��6U   �� *UserId+6  (  "MaterialDesignThemes.Wpf.ColorZone  5      $��0��5         Mode$ Standard=�5         CornerRadius$ 2��5       K� ZIndex$ 1��5      $��
600,44,0,0q�5      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�5       $
��Left=�6J   $��50��6e   $	��250��6q   $��30(�6}   $��Center=�6�   .��5!      � 	 � ColumnDefinitions	 5"      �� 5#   "   $
��Auto �5$   %   �� 5%   "   $��* �5&   %   �� 5'   "   $
��Auto �5(   %   .+�5*      �� -   5        
 ��Name$
 	SerchGood��5+   !     MaterialDesignToolButton#���  5,   !   .��5-   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�5.   %    J� Opacity$	 .56Q�5/   %   $��30��63   $��30��6>   50      �� 51      $��1��53   !   $��8 0 0 0q�54   !   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 商品编号��55   !   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�56   !   $��0q�57   !   $	��200��58   !   $��Center=�59   !   $  Arrow��6<   ��52   !   �� *GoodID+59   <   5:      5;      &   System.Windows.Controls.DataGrid  5<      -   5          Name$ dtgdSO��5<   .   $��0��6      
IsReadOnly . $
��1300��5>      $	��450��6&   $��Center=�5?      $	��Top=�66      CanUserReorderColumns .     CanUserAddRows .     AutoGenerateColumns .     HeadersVisibility$	 All=�5C         GridLinesVisibility$	 All=�61     Caliburn.Micro.Message   Attach$2 ,[Event SelectionChanged]=[Action Slcchanged]��5E      $��	0,140,0,0q�6[   ��5@      �� *
ItemsGoods+ �� SelectedIndex 5D      �� *slcGD+   ColumnHeaderStyle 5F      �� 5G       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�5H   "   ��  �� Property � �� �� Value$ 20(�6=   �� 5I   "    � ��$ 黑体)�6?   �� 5J   "    � ��$ Center=�6O   5K         Columns 5M      0	  *System.Windows.Controls.DataGridTextColumn	  5N      ,
  &System.Windows.Controls.DataGridColumn 
  Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61    
  Header$ 商品编号��6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *gid+	  5O      $ * 61   $ 	商品名��6;    6H   �� *name+	  5P      $ * 61   $ 商品介绍��6;    6I   �� *intro+	  5Q      $ * 61   $ 商品类型��6;    6I   �� *nofk+	  5R      $ * 61   $ 	购买量��6;    6H   �� *cofb+	  5S      $ * 61   $ 价格��6;    6G   �� *pri+	  5T      $ * 61   $ 路径��6;    6G   �� *pa+5V      �� 5W      -   5        $
 AddOrder��5W       + 'MaterialDesignPaperSecondaryLightButton#��[ 6/   $	��300��6p   $��50��6|   $��添加订单��6�   $��0,0,0,0q�6�   $��30(�6�   $
��Left=�6�   $	��Top=�6�   $��
50,620,0,0q�6�   �� 5X      -   5          ��Name$  OrderId��5X   -   $��0��6    $��30(�6W   $��400,630,0,0q�6e   $
��Left=�6z   $	��Top=�6�   $
  Hand��6�   ��6>   �� *	OrderId+6�   �� 5Z      -   5        $
 AddGood��5Z   *   $��1��6   #��[ 6;   $	��300��6|   $��50��6�   $��添加商品��6�   $��0,0,0,0q�6�   $��30(�6�   $
��Left=�6�   $��Center=�6�   $��	200,0,0,0q�6�   $
  Hand��6  �� 5[      -   5        $
 
DeleteGood��5[   *   $��1��6   #��[ 6>   $	��300��6   $��50��6�   $��删除商品��6�   $��0,0,0,0q�6�   $��30(�6�   $��Center=�6�   $��Center=�6�   $
  Hand��6�   �� 5\      -   5        $
 
ChangeGood��5\   *   $��1��6   #��[ 6>   $	��300��6   $��50��6�   $��修改商品��6�   $��0,0,0,0q�6�   $��30(�6�   $
��Left=�6�   $��Center=�6�   $��	900,0,0,0q�6�   $
  Hand��6  5^      5a      5b      5c      5d      