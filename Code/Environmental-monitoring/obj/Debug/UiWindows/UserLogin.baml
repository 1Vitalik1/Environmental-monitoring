   M S B A M L   `   `   `  ����S  OEnvironmental-monitoring, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Environmental_monitoring.UiWindows"Environmental_monitoring.UiWindows  5   	   2    ,Environmental_monitoring.UiWindows.UserLogin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:Environmental_monitoring.UiWindows     5   	     � Title$  	UserLogin��5   	   $	��450��6   $	��700��6(    � WindowStartupLocation$ CenterScreen=�64    � WindowStyle$
 None=�6Y    � 
ResizeMode$ NoResize=�6l   
������  � AllowsTransparency . .��5	      � .+�5
   
   �� $��2��6   ���#1D2028$��5q�6:   $��1q�6E    �� CornerRadius$ 5��6Y   ���#366EC0._�5      �  � ColumnDefinitions 5      �� 5      $��1* �6'   �� 5      $��1* �6'   .+�5      � $��0��6   .+�5      �� $��Center=�6!   .+�5      �� $	��200��6"   $	��200��6.   $ 30��6;   $��10q�6M    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   "   ��5      �� 5   "    �� ImageSource$ /res/avatar.jpg��6-   6M   5      �� 5      
�������$
��Bold"�63   $��Center=�6E   $��16(�6b    5        5   "   .��5   ,   SoftByVitaliyPerfilov6D   5      5      � 5       $��1��6   .+�5!      �� -   5        	 ��Name$	 labelSqlStatus��5!      $��Center=�64   $��Bottom=�6Q   
�������.��6   <:Подключение к БД не установлено6�   �� 5"      $��30 120q�6   ���#181A24$ 15��6B   ._�5#      �� $��Center=�6%   $��Center=�6B   .+�5$      �� $��Center=�6$   
�������$��15(�6T   $��Black"�6b   .��6u   Environmental-monitoring6�   �� 5%      
 �� Orientation$
 
Horizontal=�6)   $��10q�6B   .+�5&   "   �� $��55��6(   
�������.��6F   Логин:6N   �� 5'   "   $	��150��6)   $��0,0,0,1q�65   ���#366EC0$ 5��6e   ._�5(   &   �� -   5         ��Name$ TextBox_login��5(   .   
������ $��0q�6^   
������� �� 
CaretBrush
 �����6�   5)   #   5*      �� 5+      $
 
Horizontal=�6)   $��10q�6B   .+�5,   "   �� $��55��6(   
�������.��6F   Пароль:6O   �� 5-   "   $	��150��6)   $��0,0,0,1q�65   ���#366EC0$ 5��6e   ._�5.   &   �� -   5        $ TextBox_password��5.   .   
������ $��0q�6a   
�������
 �����6�   5/   #   50      �� 51      -   5         ��Name$ btn_sand��51   %   $	��100��67   $��25��6C   $��15q�6O   ���#366EC0$ 1��6p   ._�52   "   �� $��Center=�6(   $��Center=�6E   
�������.��6s   
Вход6y   53      54      55      56      57      58      59      5:      