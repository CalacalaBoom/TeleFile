   M S B A M L   `   `   `  ����I  ETeleFileServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TeleFileServer.ViewsTeleFileServer.Views  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      (    "TeleFileServer.Views.BroadcastView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:TeleFileServer.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5	      .��5      � .+�5   
   �� 
������   � Cursor$
  Hand��6*   ._�5      ��  �� CornerRadius$ 20��6   $��0q�6'   ��5      �� 5       �� Color$ White��6&    �� Opacity$	 0.9Q�64   ._�5      � .+�5      ��   Caliburn.Micro.Message   Attach$. ([Event SelectionChanged]=[Action Select]��5      $	��600��5      $
��1300��6+   $	��Top=�68   $��0,50,0,0q�6P   
�������
���   � �� SelectedIndex 5      �� *selectedindex+��5      �� *BroadcastList+5   z   �� 5      $��广播标题��6    $��
Sitka Text)�6,   $��30(�6D   $
��Bold"�6R   $
��Left=�6d   $��Bottom=�6   $��
50,0,0,200q�6�   �� 5       !  MaterialDesignOutlinedTextBox#��[  5      $	��300��5      $��50��6*   $
��Left=�66   $��Bottom=�5      $��
50,0,0,120q�69   $
  Hand��6M   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 标题��5      $��15(�6B   ��5      �� *txtBroadTitle+5   B   �� 5      #��[  5      $	��700��5      $	��200��6*   $
��Left=�67   $��Bottom=�5       $��
400,0,0,50q�69   $
  Hand��6M   $ 广播内容��5!      $��15(�6D   ��5      �� *
txtBroad+5!   D   �� 5"      -   5         ��Name$ Broad��5#       ! MaterialDesignPaperDarkButton#��[ 5$      $	��200��5%       � ToolTip$2 ,Resource name: MaterialDesignPaperDarkButton��5&      $��发布广播��5'      $��Bottom=�6(   $��Right=�6C   $
  Hand��6_   $��
0,0,50,200q�6m   �� 5(      -   5        $ Delete��5)      #��[ 5*      $	��200��5+      $2 ,Resource name: MaterialDesignPaperDarkButton��5,      $��删除广播��5-      $
  Hand��5.      $��Right=�6'   $��Bottom=�6C   $��
0,0,50,100q�6^   50      52      53      54      55      