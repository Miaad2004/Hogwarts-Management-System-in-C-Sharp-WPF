   M S B A M L   `   `   `  ���� I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Hogwarts.Views.AdminViews.PagesHogwarts.Views.AdminViews.Pages  3    -Hogwarts.Views.AdminViews.Pages.DormitoryView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   ;local-clr-namespace:Hogwarts.Views.AdminViews.Pages     N� Title$  Dormitories��.���  � Triggers :�  :� RoutedEvent$ Loaded��.[��� .���� .��W�  �� TargetProperty$ Opacity� W� From 0.3	 W� To 1 g� Duration$ 0:0:0.3D� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* �.+��� $��Trains��$��1��$��32(�$��SemiBold"�$��0 20 0 0q����#121518$
��Left=��� $��1��$��3�����#DAE2EA$��	0 -1 0 10q��� -    ��Name$ AddDormitory��   	addButton#��[  $��4��$��Center=�.���� 	 �� Orientation$	 
Horizontal=�.+�.  (MahApps.Metro.IconPacks.PackIconMaterial  
   Kind$

 Plus=�$��Center=�$��0 1 8 0q�$��13��$��11���� $��Add a Dormitory���� $2��,Dormitories Are Sorted Based On Their House.��$��4��$��18(�$��SemiBold"����#121518$
��Left=�$��Center=�&   System.Windows.Controls.DataGrid  -     Name$ dormitoriesDataGrid��  DataGridRowStyle1   RowStyle# �    DataGridColumnHeaderStyle1   ColumnHeaderStyle# �    DataGridCellStyle1   	CellStyle# �    DataGridStyle1#���  $
��True��$
��Auto=�$	��510��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ #��   
IsReadOnly$
 True��   CanUserResize$ False��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *SequentialIndex+  $ Title��$
 True��$ *  �� *Title+  $ House��$
 True��$ *  �� *House+  $ Floor Count��$
 True��$ *  �� *
FloorCount+  $ 
Room Count��$
 True��$ *  �� *	RoomCount+  $ Remainig Capacity��$
 True��$ *  �� *RemainingCapacity+  $ Total Capacity��$
 True��$ *  �� *TotalCapacity+