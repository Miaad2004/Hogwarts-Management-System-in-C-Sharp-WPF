   M S B A M L   `   `   `  ����I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Hogwarts.Views.StudentViews.Pages!Hogwarts.Views.StudentViews.Pages  5      ;    5Hogwarts.Views.StudentViews.Pages.HogwartsExpressView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      =local/clr-namespace:Hogwarts.Views.StudentViews.Pages   5        N� Title$  Students��5
      .��5      �  � Triggers 5   
   :� 5       :� RoutedEvent$ Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6*    W� From 0.35   *   	 W� To 165    g� Duration$ 0:0:0.3D�6<   5      5      5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5$   
   �� $��Trains��6   $��1��6"   $��32(�6/   $��SemiBold"�6=   $��0 20 0 0q�6S   ���#121518$
��Left=�6z   �� 5'   
   $��1��6   $��3��6   ���#DAE2EA$��	0 -1 0 10q�6A   �� 5*   
   $7��1Trains Are Sorted Based On Their Depaurture Time.��6   $��4��6M   $��18(�5+      $��SemiBold"�6"   ���#121518$
��Left=�5-      $��Center=�6/   &   System.Windows.Controls.DataGrid  50   
   -   5          Name$ trainsDataGrid��50         DataGridRowStyle1	   RowStyle#	 �   51        DataGridColumnHeaderStyle1
   ColumnHeaderStyle#
 �  52        DataGridCellStyle1   	CellStyle# �  53        DataGridStyle1#���  54      $
��True��55      $
��Auto=�56      $	��510��57         Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      
IsReadOnly$
 True��60      CanUserResize$ False��5<   %      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5=   %   �� *SequentialIndex+  5@      $ Origin��6%   $
 True��5A   @   $ * 6R    6%   �� *Origin+6R     5D      $ Destination��6%   $
 True��5E   E   $ * 6W    6%   �� *Destination+6W     5H      $ Departure Time��6%   $
 True��5I   G   $	 170 6Y    6%   �� *DepartureTime+6Y     5L      $ Occupied Seats��6%   $
 True��5M   H   $ * 6Z    6%   �� *NOccupiedSeats+6Z     5P      $ Total Capacity��6%   $
 True��5Q   G   $ * 6Y    6%   �� *TotalCapacity+6Y   4  .System.Windows.Controls.DataGridTemplateColumn  5T      $ 
Operations��6)   $
 True��6=   $
 auto 6O      CellTemplate 5U      �� 5V      .R�5W      ��  �� Orientation$ 
Horizontal=�6)   .+�5Y   "   ��  ��Name$ ReserveSeat��6)   -   5         � ToolTip$ Get a ticket��5Z   )   $��5 0 0 0q�5\   )     gridEditButton#��[ 5]   )   .��5^   &   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ CartPlus=�6<     gridButtonIcon#��[ 6L   5_   #   5a      5b      5d      5h      5i      5j      