   M S B A M L   `   `   `  ����I  ETeleFileServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TeleFileServer.ViewsTeleFileServer.Views  5      A%clr-namespace:TeleFileServer.ServicesTeleFileServer.Services  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      -    'TeleFileServer.Views.AccountManagerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:TeleFileServer.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      5	pwdHelper%clr-namespace:TeleFileServer.Services  5      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5	      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5
      .��5      � .+�5   
   �� 
������   � Cursor$
  Hand��6*   ._�5      ��  �� CornerRadius$ 20��6   $��0q�6'   ��5      �� 5       �� Color$ White��6&    �� Opacity$	 0.9Q�64   ._�5      � .+�5      �� 
������ $  Arrow��66   $	��400��6E   $	��600��6Q   ._�5      �� $ 20��6!   $��0q�63   
�������$
  Hand��6_   ._�5      � $
  Hand��6#   .+�5   "   ��   Caliburn.Micro.Message   Attach$. ([Event SelectionChanged]=[Action Select]��6v   $	��200��6�   $	��Top=�6�    �� SelectedIndex 6*   �� *selectedindex+��6R   �� *AccountList+6�   �� 5   "    !  MaterialDesignOutlinedTextBox#��[  5   %   $	��Top=�5   %   $��50��5   %    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5   %   " �� VerticalScrollBarVisibility$
 Auto=�5   %   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 账号��5    %   $��	0,250,0,0q�6I   $  Arrow��6\   ��5   %   �� *	Account+5    \   G� 5!   "    % !MaterialDesignOutlinedPasswordBox#��[ 5"   %   $	��Top=�5#   %   8   2TeleFileServer.Services.PasswordBoxAssistantHelper
   Attach
 . $	 密码��5&   %   $��	0,350,0,0q�6I      Password 5%   %   �� *
Password+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5&   I   �� 5(   "   $/��)1为管理员权限，2为操作员权限��6,   $
��Left=�6C   $	��Top=�6^   $��15(�6v   $��	0,430,0,0q�6�   $
��Bold"�6�   � 5)   "   $
��Left=�6'   $	��Top=�6B   $��	0,450,0,0q�6Z   $	��400��6m   .+�5*   &   (� $��40��6.   .��5+   *   	�  	� 	GroupName$
 Date��66   
���   �
���   �$
��Left=�6�   $��	0,0,200,0q�6�    d� 	IsChecked 6G   �� *IsOne+6�   5,   '   (� 5-   &   $��40��6.   .��5.   *   	� $
 Date��66   
���   �
���   �$
��Left=�6�   $��0,0,80,0q�6�    6G   �� *IsTwo+6�   5/   '   �� 50   &   $��1��60   $��30(�69   $��40,0,0,0q�6G   $
��Left=�6Y   $��Center=�6t   �� 51   &   $��2��60   $��30(�69   $��	140,0,0,0q�6G   $
��Left=�6Z   $��Center=�6u   52   #   �� 53   "   -   5         ��Name$	 Add��53   )   $��添加/修改��66   $	��200��6F   ���	#FFE2E2E2
���   ����	#DD000000$��	0,450,0,0q�6�   $
  Hand��6�   �� 54   "   -   5        $
 Dele��54   )   $��删除��67   $	��200��6D   ���	#FFE2E2E2
���   ����	#DD000000$��	0,550,0,0q�6�   $
  Hand��6�   56      57      58      59      5;      5<      5=      5>      