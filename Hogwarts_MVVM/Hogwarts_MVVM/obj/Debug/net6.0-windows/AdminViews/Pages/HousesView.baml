   M S B A M L   `   `   `  ����I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Hogwarts.Views.AdminViews.PagesHogwarts.Views.AdminViews.Pages  5      0    *Hogwarts.Views.AdminViews.Pages.HousesView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      ;local-clr-namespace:Hogwarts.Views.AdminViews.Pages   5        N� Title$  Students��5
      .��5      �  � Triggers 5   
   :� 5       :� RoutedEvent$ Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6*    W� From 0.35   *   	 W� To 165    g� Duration$ 0:0:0.3D�6<   5      5      5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5$   
   �� $��Houses��6   $��1��6"   $��32(�6/   $��SemiBold"�6=   $��0 20 0 0q�5%      ���#121518$
��Left=�6;   �� 5(   
   $��1��6   $��3��6   ���#DAE2EA$��	0 -1 0 10q�6A   �� 5+   
   -   5        $��AddHouse��5,         	addButton#��[  5+      $��4��5-      $��Center=�5.      .��51      ��  �� Orientation$ 
Horizontal=�6   .+�52      .  (MahApps.Metro.IconPacks.PackIconMaterial  	   Kind$
	 Plus=�6(   $��Center=�64   $��0 1 8 0q�53   (   $��11��69   $��11��6D   �� 54      $��Add a New House��6   55      57      �� 5:   
   $.��(Houses Are Sorted Based On Their Points.��6   $��4��6D   $��18(�5;      $��SemiBold"�6"   ���#121518$
��Left=�5=      $��Center=�6/   &   System.Windows.Controls.DataGrid  5@   
   -   5        
  Name$
 housesDataGrid��5@        DataGridRowStyle1   RowStyle# �  5A        DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  5B        DataGridCellStyle1   	CellStyle# �  5C        DataGridStyle1#���  5D      $
��True��5E      $
��Auto=�5F      $	��510��5G         Columns 5I      0  *System.Windows.Controls.DataGridTextColumn  5K      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      
IsReadOnly$
 True��60      CanUserResize$ False��5L   %      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5M   %   �� *SequentialIndex+4  .System.Windows.Controls.DataGridTemplateColumn  5P      $
 Name��6)   $
 True��67   $	 250 6I      CellTemplate 5Q      �� 5R      .R�5T      �� $ 
Horizontal=�6)   .+�5U   "   �� $��65��6)   $��65��64   
������� �� CornerRadius$	 100��5V   )   $��Center=�6<   $��Center=�5W   )   $��5 0 10 0q�6F   ._�5Y   &   A� ��5Z   *   �� 5[   .    �� ImageSource 69   �� *FullProfileImagePath+5]   '   5_   #   �� 5a   "   $��Center=�6G   ��6,   �� *	HouseType+6G   5c      5e      5g        5j      $ Points��6%   $
 True��5k   @   $ * 6R    6%   �� *Points+6R     5n      $ Students Count��6%   $
 True��5o   G   $ * 6Y    6%   �� *StudentsCount+6Y     5r      $ 
Operations��6)   $
 True��6=   $ * 6O    5s      �� 5t      .R�5v      �� $ 
Horizontal=�6)   .+�5x   "   ��  ��Name$ AddPoint��6)   -   5         � ToolTip$ Give 5 points!��5y   )   $��5 0 0 0q�5{   )     gridEditButton#��[ 5|   )   .��5}   &     $	 StarPlus=�6<     gridButtonIcon#��[ 6L   5~   #   �� 5�   "   $ DeductPoint��6)   -   5        $ Deduct 5 points!��5�   )   $��5 0 0 0q�5�   )     gridRemoveButton#��[ 5�   )   .��5�   &     $	 	StarMinus=�6<   #��[ 6M   5�   #   5�      5�      5�      5�      5�      5�      