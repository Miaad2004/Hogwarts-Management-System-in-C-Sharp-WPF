   M S B A M L   `   `   `  ����I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Hogwarts.Views.AdminViews.PagesHogwarts.Views.AdminViews.Pages  5      0    *Hogwarts.Views.AdminViews.Pages.ForestView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      ;local-clr-namespace:Hogwarts.Views.AdminViews.Pages   5        N� Title$  Students��5
      .��5      �  � Triggers 5   
   :� 5       :� RoutedEvent$ Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6*    W� From 0.35   *   	 W� To 165    g� Duration$ 0:0:0.3D�6<   5      5      5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5$   
   �� $��Plants��6   $��1��6"   $��32(�6/   $��SemiBold"�6=   $��0 20 0 0q�5%      ���#121518$
��Left=�6;   �� 5(   
   $��1��6   $��3��6   ���#DAE2EA$��	0 -1 0 10q�6A   �� 5+   
   -   5           	addButton#��[  5+      $��4��5,      $��Center=�5-      .��50      ��  �� Orientation$ 
Horizontal=�6   .+�51      .  (MahApps.Metro.IconPacks.PackIconMaterial  	   Kind$
	 Plus=�6(   $��Center=�64   $��0 1 8 0q�52   (   $��11��69   $��11��6D   �� 53      $��Add a New Plant��6   54      56      �� 59   
   $4��.Plants Are Sorted Based On Their Harvest Time.��6   $��4��6J   $��18(�5:      $��SemiBold"�6"   ���#121518$
��Left=�5<      $��Center=�6/   &   System.Windows.Controls.DataGrid  5?   
   -   5        
  Name$
 plantsDataGrid��5?        DataGridRowStyle1   RowStyle# �  5@        DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  5A        DataGridCellStyle1   	CellStyle# �  5B        DataGridStyle1#���  5C      $
��True��5D      $
��Auto=�5E      $	��510��5F         Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      
IsReadOnly$
 True��60      CanUserResize$ False��5K   %      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5L   %   �� *SequentialIndex+4  .System.Windows.Controls.DataGridTemplateColumn  5O      $
 Name��6)   $
 True��67   $	 225 6I      CellTemplate 5P      �� 5Q      .R�5S      �� $ 
Horizontal=�6)   .+�5T   "   �� $��65��6)   $��65��64   
������� �� CornerRadius$	 100��5U   )   $��Center=�6<   $��Center=�5V   )   $��5 0 10 0q�6F   ._�5X   &   A� ��5Y   *   �� 5Z   .    �� ImageSource 69   �� *FullProfileImagePath+5\   '   5^   #   �� 5`   "   $��Center=�6B   ��6,   �� *Name+ � ToolTip 6]   �� *Description+5b      5d      5f        5i      $ Planting Time��6%   $
 True��5j   F   $ * 6X    6%   �� *PlantingTime+6X     5m      $ Harvest Time��6%   $
 True��5n   %   $ * 67    5m   ;   �� *HarvestTime+5n   7     5q      $ Is Collectable��6%   $
 True��5r   %   $ * 67    5q   =   �� *IsCollectable+5r   7     5u      $ Quantity��6%   $
 True��5v   %   $ * 67    5u   7   �� *
Quantity+5v   7   5z      5{      5|      