   M S B A M L   `   `   `  ����I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Hogwarts.Views.AdminViews.PagesHogwarts.Views.AdminViews.Pages  5      3    -Hogwarts.Views.AdminViews.Pages.DormitoryView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      ;local-clr-namespace:Hogwarts.Views.AdminViews.Pages   5        N� Title$  Dormitories��5
      .��5      �  � Triggers 5   
   :� 5       :� RoutedEvent$ Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6*    W� From 0.35   *   	 W� To 165    g� Duration$ 0:0:0.3D�6<   5      5      5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5$   
   �� $��Trains��6   $��1��5%      $��32(�6!   $��SemiBold"�6/   $��0 20 0 0q�5&      ���#121518$
��Left=�6;   �� 5)   
   $��1��6   $��3��6   ���#DAE2EA$��	0 -1 0 10q�6A   �� 5,   
   -   5         ��Name$ AddDormitory��5,         	addButton#��[  5-      $��4��5.      $��Center=�5/      .��52      �� 	 �� Orientation$	 
Horizontal=�6   .+�53      .  (MahApps.Metro.IconPacks.PackIconMaterial  
   Kind$

 Plus=�6(   $��Center=�64   $��0 1 8 0q�54   (   $��13��69   $��11��6D   �� 55      $��Add a Dormitory��6   56      58      �� 5;   
   $2��,Dormitories Are Sorted Based On Their House.��6   $��4��6H   $��18(�5<      $��SemiBold"�6"   ���#121518$
��Left=�5>      $��Center=�6/   &   System.Windows.Controls.DataGrid  5A   
   -   5          Name$ dormitoriesDataGrid��5A        DataGridRowStyle1   RowStyle# �  5B        DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  5C        DataGridCellStyle1   	CellStyle# �  5D        DataGridStyle1#���  5E      $
��True��5F      $
��Auto=�5G      $	��510��5H         Columns 5J      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      
IsReadOnly$
 True��60      CanUserResize$ False��5M   %      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5N   %   �� *SequentialIndex+  5Q      $ Title��6%   $
 True��5R   ?   $ * 6Q    6%   �� *Title+6Q     5U      $ House��6%   $
 True��5V   ?   $ * 6Q    6%   �� *House+6Q     5Y      $ Floor Count��6%   $
 True��5Z   D   $ * 6V    6%   �� *
FloorCount+6V     5]      $ 
Room Count��6%   $
 True��5^   C   $ * 6U    6%   �� *	RoomCount+6U     5a      $ Remainig Capacity��6%   $
 True��5b   K   $ * 6]    6%   �� *RemainingCapacity+6]     5e      $ Total Capacity��6%   $
 True��5f   G   $ * 6Y    6%   �� *TotalCapacity+6Y   5j      5k      5l      