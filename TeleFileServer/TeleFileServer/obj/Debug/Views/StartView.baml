   M S B A M L   `   `   `  ����I  ETeleFileServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TeleFileServer.ViewsTeleFileServer.Views  5   	   A%clr-namespace:TeleFileServer.ServicesTeleFileServer.Services  5	   	   $    TeleFileServer.Views.StartView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:TeleFileServer.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   5	pwdHelper%clr-namespace:TeleFileServer.Services  5	   	     � Title$  	StartView��5
   	   $
��1920��6   $
��1080��6(    � WindowStartupLocation$ CenterScreen=�66    � WindowStyle$
 None=�6[    � AllowsTransparency . ��5      �� 5   
    �� ImageSource$ /Resources/bk.jpeg��6    j� Stretch$
 Fill=�66   .��5      � .+�5   
   �� -   5         ��Name$
 Exit��5      $��退出��6   $��Right=�6,   $��Bottom=�6H    � Cursor$
 Hand��6c   $��	0,0,50,50q�6q   ���	#FFFAFAFA���	#DD000000$	��100��6�   �� 5   
   $	��500��6   $	��810��6   
������ ._�5      ��  �� CornerRadius$ 20��6   $��0q�6'   ��5      �� 5      	 �� Color$	 White��6&   
 �� Opacity$	
 0.5Q�64   ._�5      �  � ColumnDefinitions 5      �� 5      $��* �6+   67   �� 5      $	��450 �6+   69   .+�5      � $��0��6   .+�5      �� $��TeleFile��6$   $
��Bold"�64   $��70(�6F   $��Center=�6T   $��	0,150,0,0q�6q   
���   �$
��Wrap=�6�   5      �� 5!      $��1��6   $	��400��6.   $	��380��6;   
������ $��0,0,50,0q�6`   ._�5"      �� $ 20��6!   $��0q�63   ��5#      �� 5$   "   $	 White��62   ._�5&      � $��Center=�6#   $��Center=�6@   $	��360��6[   $	��380��6g   .+�5'   "   �� $��登录��6,   $��Center=�66   $��40(�6S   $
��Bold"�6a   
���   �6s   �� 5(   "   $	��200��5)   %   $��40��61   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	用户名��5+   %      
Foreground �#0000FF.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �#0000FF %  !MaterialDesignFloatingHintTextBox#��[  5.   %   $	��Top=�5/   %   $��	0,100,0,0q�6=   ��5*   %   �� *	txtUserID+5/   =   G� 50   "   $	��200��51   %   $��40��61   8   2TeleFileServer.Services.PasswordBoxAssistantHelper   Attach . $ 密码��54   %    �#0000FF �#0000FF ) %MaterialDesignFloatingHintPasswordBox#��[ 57   %   $	��Top=�6d   $��	0,200,0,0q�6|   $ Arrow��6�      Password 53   %   �� *
Password+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�57   �   �� 59   "   -   5        $ Login��5:   %    " MaterialDesignPaperLightButton#��[ 5;   %   $��40��5<   %   $	��150��61   $��登  录��5=   %   $	��Top=�5>   %   $��	0,280,0,0q�6=   ���	#FFCCFFFF$
��Bold"�6h   $��20(�6z   $
 Hand��6�   5@      5A      5B      5G      5H      5I      5J      5K      