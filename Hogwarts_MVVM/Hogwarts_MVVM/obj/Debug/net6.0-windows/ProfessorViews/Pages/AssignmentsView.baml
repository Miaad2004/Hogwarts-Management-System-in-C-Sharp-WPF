   M S B A M L   `   `   `  ����I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Hogwarts.Views.ProfessorViews.Pages#Hogwarts.Views.ProfessorViews.Pages  5      9    3Hogwarts.Views.ProfessorViews.Pages.AssignmentsView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      ?local1clr-namespace:Hogwarts.Views.ProfessorViews.Pages   5        N� Title$  Students��5
      .��5      �  � Triggers 5   
   :� 5       :� RoutedEvent$ Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6*    W� From 0.35   *   	 W� To 165    g� Duration$ 0:0:0.3D�6<   5      5      5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5$   
   �� $��Students' Assignments��6   $��1��61   $��32(�6>   $��SemiBold"�6L   $��0 20 0 0q�6b   ���#121518$
��Left=�6�   �� 5'   
   $��1��6   $��3��6   ���#DAE2EA$��	0 -1 0 10q�6A   �� 5*   
   $5��/Assignments Are Sorted Based On Their Due Date.��6   $��4��6K   $��18(�5+      $��SemiBold"�6"   ���#121518$
��Left=�5-      $��Center=�6/   &   System.Windows.Controls.DataGrid  50   
   -   5          Name$ assignmentsDataGrid��50         DataGridRowStyle1	   RowStyle#	 �   51        DataGridColumnHeaderStyle1
   ColumnHeaderStyle#
 �  52        DataGridCellStyle1   	CellStyle# �  53        DataGridStyle1#���  54      $
��True��55      $
��Auto=�56      $	��510��57         Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      
IsReadOnly$
 True��60      CanUserResize$ False��5<   %      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5=   %   �� *SequentialIndex+  5@      $ Title��6%   $
 True��5A   ?   $ * 6Q    6%   �� *Title+6Q     5D      $ 	Prfoessor��6%   $
 True��5E   L   $ * 6^    6%   �� *Professor.FullName+6^     5H      $ Course��6%   $
 True��5I   F   $ * 6X    6%   �� *Course.Title+6X     5L      $ 
Start Date��6%   $
 True��5M   C   $ * 6U    6%   �� *	StartDate+6U     5P      $ Due Date��6%   $
 True��5Q   %   $ * 67    5P   7   �� *	DueDate+5Q   7   4  .System.Windows.Controls.DataGridTemplateColumn  5T      $ 
Operations��6)   $
 True��6=   $
 auto 6O      CellTemplate 5U      �� 5V      .R�5X      ��  �� Orientation$ 
Horizontal=�6)   .+�5Z   "   ��  ��Name$ SubmitScores��6)   -   5         � ToolTip$ Submit the scores��5[   )   $��5 0 0 0q�5]   )     gridRemoveButton#��[ 5^   )   .��5_   &   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Counter=�6<     gridButtonIcon#��[ 6K   5`   #   �� 5c   "   $ ViewDescription��6)   -   5        $# View Assingment's Description��5d   )   $��5 0 0 0q�5f   )     gridEditButton#��[ 5g   )   .��5h   &     $ 	ImageText=�6<   #��[ 6M   5i   #   5j      5l      5n      5r      5s      5t      