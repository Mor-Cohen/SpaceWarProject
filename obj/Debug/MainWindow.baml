   M S B A M L   `   `   `  ����C  ?SpaceWar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SpaceWarSpaceWar  5   	   /clr-namespace:SpaceWar.viewsSpaceWar.views  5	   	       SpaceWar.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SpaceWar     5   	   /myprojclr-namespace:SpaceWar.views     5	   	     � Title$  
MainWindow��5      $	��800��6   $
��1200��6(    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency . $��fonts/#Dosis)�5   	   -  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation$
 None=�6#   ��5      �� 5   
    �� ImageSource$ images/Background.png��6   .��5      ��  �� CornerRadius$ 10��6   ���#0a1744$��10q�65   ._�5   
   � $
 None=�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $	��180 �6#   .+�5      � -   5        $��2��5      .+�5      �� $��0,0,-8,0q�6   ���#0a1744$
 None=�6D   .+�5      �� $
��0,20q�6"   .+�5      �� $��SPACEWAR��6$   
�������$��25(�6G   $��	ExtraBold"�6U   $��Center=�6l   $��Center=�6�   �� 5       $��E  .  R  .  M��6$   
�������$��15(�5"      $��Medium"�5#      $��Center=�5$      $��Center=�5%      5&      �� 5'      -   5        $
��HOME��5'         btnMenu#��[  6,   $
 None=�6b   �� 5(      -   5        $
��PLAY��5(      #��[  6,   $
 None=�6b   �� 5)      -   5        $
��SHOP��5)      #��[  6,   $
 None=�6b   �� 5*      $��SETTINGS��6   #��[  60   $
 None=�6Q   5+      �� 5,      -   5        $
��Exit��5-        btnExit#��[ 5.      $��Bottom=�66   $��	0,0,-8,20q�6Q   $
 None=�5/      50      51         SpaceWar.views.Home  52      -   5          Name$
 home��52   0   $y�Visible=�6   60      SpaceWar.views.Play  53      -   5        	  Name$
	 play��53   /      SpaceWar.views.Play
   	LostFocus$
 play_LostFocus��6=   $y�Hidden=�6   6=      SpaceWar.views.Shop  54      -   5          Name$
 shop��54   /   $y�Hidden=�6   6/   56      57      58      