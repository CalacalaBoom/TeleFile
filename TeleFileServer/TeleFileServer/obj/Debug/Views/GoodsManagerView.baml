   M S B A M L   `   `   `  ����I  ETeleFileServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TeleFileServer.ViewsTeleFileServer.Views  5   	   +    %TeleFileServer.Views.GoodsManagerView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:TeleFileServer.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  GoodsManagerView��5	   	   $	��500��6"   $	��800��6/   .��5
      � .+�5   
   �� -   5         ��Name$ photo��5      $
��Left=�6   $	��Top=�6:   $	��150��6R   $	��150��6^   $��	50,50,0,0q�6k   �� 5   
   -   5         ��Name$ select��5       &  "MaterialDesignPaperSecondaryButton#��[  6!   $	��100��6]   $��30��6i   $
��Left=�6u   $	��Top=�6�   $��
75,228,0,0q�6�   $��选择图片��6�    � Cursor$
 Hand��6�   6�   �� 5   
   $��	商品名��6   $
��Left=�6   $	��Top=�6:   $��
238,22,0,0q�6R   �� 5   
   $��介绍��6   $
��Left=�6   $	��Top=�69   $��
250,69,0,0q�6Q   �� 5   
   $��商品类别��6   $
��Left=�6    $	��Top=�6;   $��226,182,0,0q�6S   �� 5   
   $��	购买量��6   $
��Left=�6   $	��Top=�6:   $��238,232,0,0q�6R   �� 5   
   $��价格��6   $
��Left=�6   $	��Top=�69   $��250,282,0,0q�6Q   �� 5   
   $��路径��6   $
��Left=�6   $	��Top=�69   $��250,328,0,0q�6Q   �� 5   
   -   5        $��GoodName��5      $	��200��6"   $��40��6.    ! MaterialDesignOutlinedTextBox#��[ 6:   $	��Top=�6q   $��0,10,0,0q�6�   $��30(�6�   $��0,0,0,0q�6�   �� 5   
   -   5        $��	Introduce��5      $	��200��6#   $	��100��6/   #��[ 6<   $	��Top=�6s   $��0,60,0,0q�6�   $��30(�6�   $��0,0,0,0q�6�   �� 5   
   -   5         ��Name$ kofgComboBox��5      $��40��5       " MaterialDesignOutlinedComboBox#��[ 5       )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 商品类别��5!      $	��150��5#      $	��Top=�6   $��300,170,0,0q�61   $��Center=�5$      $��0,0,0,0q�6/   $��30(�6A   $
��Left=�5%      ��5"      �� *kind+5%      �� 5'   
   -   5        $��CountOfBuyed��5'      $	��200��6&   $��40��62   #��[ 6>   $	��Top=�6u   $��	0,220,0,0q�6�   $��30(�6�   $��0,0,0,0q�6�   �� 5(   
   -   5        $��Price��5(      $	��100��6   $��40��6+   #��[ 67   $	��Top=�6n   $��0,270,100,0q�6�   $��30(�6�   $��0,0,0,0q�6�   �� 5)   
   -   5        $
��Path��5)      $	��200��6   $��40��6*   #��[ 66   $	��Top=�6m   $��	0,320,0,0q�6�   $��30(�6�   $��0,0,0,0q�6�   $ Arrow��6�   �� 5-   
   -	   5        $��Select��5-      #��[  6   $��选择文件��6\   $��80��6k   $��30��6v   $��300,376,400,0q�6�   $	��Top=�6�   $��0,0,0,0q�6�   $
 Hand��6�   �� 5/   
   -
   5        $ OP��5/      #��[  6   $��80��6Y   $��30��6d   $
��Left=�6p   $	��Top=�6�   $��669,396,0,0q�6�   $
 Hand��6�   ��6�   �� *GoodOp+6�   �� 50   
   $	��元��6   $
��Left=�6   $	��Top=�68   $��415,282,0,0q�6P   51      52      