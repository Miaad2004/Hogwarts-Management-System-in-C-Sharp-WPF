   M S B A M L   `   `   `  ����I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Hogwarts.Views.StudentViews.Pages!Hogwarts.Views.StudentViews.Pages  5      2    ,Hogwarts.Views.StudentViews.Pages.ForestView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      =local/clr-namespace:Hogwarts.Views.StudentViews.Pages   5        N� Title$  Students��5
      .��5      �  � Triggers 5   
   :� 5       :� RoutedEvent$ Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6*    W� From 0.35   *   	 W� To 165    g� Duration$ 0:0:0.3D�6<   5      5      5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5$   
   �� $��Plants��6   $��1��6"   $��32(�6/   $��SemiBold"�6=   $��0 20 0 0q�6S   ���#121518$
��Left=�6z   �� 5'   
   $��1��6   $��3��6   ���#DAE2EA$��	0 -1 0 10q�6A   �� 5*   
   $4��.Plants Are Sorted Based On Their Harvest Time.��6   $��4��6J   $��18(�5+      $��SemiBold"�6"   ���#121518$
��Left=�5-      $��Center=�6/   &   System.Windows.Controls.DataGrid  50   
   -   5          Name$ plantsDataGrid��50         DataGridRowStyle1	   RowStyle#	 �   51        DataGridColumnHeaderStyle1
   ColumnHeaderStyle#
 �  52        DataGridCellStyle1   	CellStyle# �  53        DataGridStyle1#���  54      $
��True��55      $
��Auto=�56      $	��510��57         Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      
IsReadOnly$
 True��60      CanUserResize$ False��5<   %      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5=   %   �� *SequentialIndex+4  .System.Windows.Controls.DataGridTemplateColumn  5@      $
 Name��6)   $
 True��67   $	 225 6I      CellTemplate 5A      �� 5B      .R�5D      ��  �� Orientation$ 
Horizontal=�6)   .+�5E   "   �� $��65��6)   $��65��64   
������� �� CornerRadius$	 100��5F   )   $��Center=�6<   $��Center=�5G   )   $��5 0 10 0q�6F   ._�5I   &   A� ��5J   *   �� 5K   .    �� ImageSource 69   �� *FullProfileImagePath+5M   '   5O   #   �� 5Q   "   $��Center=�6B   ��6,   �� *Name+ � ToolTip 6]   �� *Description+5S      5U      5W        5Z      $ Planting Time��6%   $
 True��5[   F   $ * 6X    6%   �� *PlantingTime+6X     5^      $ Harvest Time��6%   $
 True��5_   %   $ * 67    5^   ;   �� *HarvestTime+5_   7     5b      $ Is Collectable��6%   $
 True��5c   %   $ * 67    5b   =   �� *IsCollectable+5c   7     5f      $ Quantity��6%   $
 True��5g   %   $ * 67    5f   7   �� *
Quantity+5g   7     5j      $ 
Operations��6)   $
 True��6=   $ * 6O    5k      �� 5l      .R�5n      �� $ 
Horizontal=�6)   .+�5p   "   ��  ��Name$ CollectPlant��6)   -   5        $ Collect this plant��5q   )   $��5 0 0 0q�5s   )     gridEditButton#��[ 5t   )   .��5u   &   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ HandSaw=�6<     gridButtonIcon#��[ 6K   5v   #   �� 5y   "   $ GetQuantity��6)   -   5        $4 .See how many of this plant you have collected.��5z   )   $��5 0 0 0q�5|   )   #��[ 5}   )   .��5~   &     $ Counter=�6<   #��[ 6K   5   #   5�      5�      5�      5�      5�      5�      