   M S B A M L   `   `   `  ����I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Hogwarts.Views.AdminViews.PagesHogwarts.Views.AdminViews.Pages  5      9    3Hogwarts.Views.AdminViews.Pages.HogwartsExpressView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      ;local-clr-namespace:Hogwarts.Views.AdminViews.Pages   5        N� Title$  Students��5
      .��5      �  � Triggers 5   
   :� 5       :� RoutedEvent$ Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6*    W� From 0.35   *   	 W� To 165    g� Duration$ 0:0:0.3D�6<   5      5      5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5$   
   �� $��Trains��6   $��1��6"   $��32(�6/   $��SemiBold"�6=   $��0 20 0 0q�5%      ���#121518$
��Left=�6;   �� 5(   
   $��1��6   $��3��6   ���#DAE2EA$��	0 -1 0 10q�6A   �� 5+   
   -   5           	addButton#��[  5+      $��4��5,      $��Center=�5-      .��50      ��  �� Orientation$ 
Horizontal=�6   .+�51      .  (MahApps.Metro.IconPacks.PackIconMaterial  	   Kind$
	 Plus=�6(   $��Center=�64   $��0 1 8 0q�52   (   $��11��69   $��11��6D   �� 53      $��Add a New Train��6   54      56      �� 59   
   $7��1Trains Are Sorted Based On Their Depaurture Time.��6   $��4��6M   $��18(�5:      $��SemiBold"�6"   ���#121518$
��Left=�5<      $��Center=�6/   &   System.Windows.Controls.DataGrid  5?   
   -   5        
  Name$
 trainsDataGrid��5?        DataGridRowStyle1   RowStyle# �  5@        DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  5A        DataGridCellStyle1   	CellStyle# �  5B        DataGridStyle1#���  5C      $
��True��5D      $
��Auto=�5E      $	��510��5F         Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      
IsReadOnly$
 True��60      CanUserResize$ False��5K   %      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5L   %   �� *SequentialIndex+  5O      $ Title��6%   $
 True��5P   ?   $ * 6Q    6%   �� *Title+6Q     5S      $ Origin��6%   $
 True��5T   @   $ * 6R    6%   �� *Origin+6R     5W      $ Destination��6%   $
 True��5X   E   $ * 6W    6%   �� *Destination+6W     5[      $ Departure Time��6%   $
 True��5\   G   $ * 6Y    6%   �� *DepartureTime+6Y     5_      $ Occupied Seats��6%   $
 True��5`   H   $ * 6Z    6%   �� *NOccupiedSeats+6Z     5c      $ Total Capacity��6%   $
 True��5d   G   $ * 6Y    6%   �� *TotalCapacity+6Y   5h      5i      5j      