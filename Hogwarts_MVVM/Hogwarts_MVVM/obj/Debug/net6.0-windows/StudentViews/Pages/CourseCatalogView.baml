   M S B A M L   `   `   `  ����I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Hogwarts.Views.StudentViews.Pages!Hogwarts.Views.StudentViews.Pages  5      9    3Hogwarts.Views.StudentViews.Pages.CourseCatalogView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      =local/clr-namespace:Hogwarts.Views.StudentViews.Pages   5        N� Title$  Students��5
      .��5      �  � Triggers 5   
   :� 5       :� RoutedEvent$ Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6*    W� From 0.35   *   	 W� To 165    g� Duration$ 0:0:0.3D�6<   5      5      5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5$   
   �� $��Courses��6   $��1��6#   $��32(�60   $��SemiBold"�6>   $��0 20 0 0q�6T   ���#121518$
��Left=�6{   �� 5'   
   $��1��6   $��3��6   ���#DAE2EA$��	0 -1 0 10q�6A   �� 5*   
   $.��(Courses Are Sorted Based On Their Title.��6   $��4��6D   $��18(�5+      $��SemiBold"�6"   ���#121518$
��Left=�5-      $��Center=�6/   &   System.Windows.Controls.DataGrid  50   
   -   5          Name$ coursessDataGrid��50         DataGridRowStyle1	   RowStyle#	 �   51        DataGridColumnHeaderStyle1
   ColumnHeaderStyle#
 �  52        DataGridCellStyle1   	CellStyle# �  53        DataGridStyle1#���  54      $
��True��55      $
��Auto=�56      $	��510��57         Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      
IsReadOnly$
 True��60      CanUserResize$ False��5<   %      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5=   %   �� *SequentialIndex+  5@      $ Title��6%   $
 True��5A   ?   $	 100 6Q    6%   �� *Title+6Q     5D      $ 	Professor��6%   $
 True��5E   L   $	 150 6^    6%   �� *Professor.FullName+6^     5H      $ 	Classroom��6%   $
 True��5I   C   $	 105 6U    6%   �� *	Classroom+6U     5L      $ 
Start Time��6%   $
 True��5M   H   $	 100 6Z    6%   �� *ClassStartTime+6Z     5P      $ End Time��6%   $
 True��5Q   F   $ 95 6X    6%   �� *ClassEndTime+6X     5T      $ End Date��6%   $
 True��5U   %   $ * 67    5T   7   �� *	EndDate+5U   7     5X      $ Course Schedule��6%   $
 True��5Y   %   $	 150 67    5X   >   �� *
Schedule+5Y   7     5\      $ 
Seats Left��6%   $
 True��5]   %   $ 87 67    5\   9   �� *	SeatsLeft+5]   7   4  .System.Windows.Controls.DataGridTemplateColumn  5`      $ 
Operations��6)   $
 True��6=   $	 100 6O      CellTemplate 5a      �� 5b      .R�5d      ��  �� Orientation$ 
Horizontal=�6)   .+�5f   "   ��  ��Name$ 	AddCourse��6)   -   5         � ToolTip$ Enroll��5g   )   $��5 0 0 0q�5i   )     gridEditButton#��[ 5j   )   .��5k   &   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ 	TablePlus=�6<     gridButtonIcon#��[ 6M   5l   #   5n      5p      5r      5v      5w      5x      