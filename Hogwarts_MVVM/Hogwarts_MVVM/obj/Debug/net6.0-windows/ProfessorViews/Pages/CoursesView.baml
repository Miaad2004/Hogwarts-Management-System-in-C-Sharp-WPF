   M S B A M L   `   `   `  ����I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Hogwarts.Views.ProfessorViews.Pages#Hogwarts.Views.ProfessorViews.Pages  5      5    /Hogwarts.Views.ProfessorViews.Pages.CoursesView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      ?local1clr-namespace:Hogwarts.Views.ProfessorViews.Pages   5        N� Title$  Students��5
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
   -   5         ��Name$ 	AddCourse��5*         	addButton#��[  5+      $��4��5,      $��Center=�5-      .��50      �� 	 �� Orientation$	 
Horizontal=�6   .+�51      .  (MahApps.Metro.IconPacks.PackIconMaterial  
   Kind$

 Plus=�6(   $��Center=�64   $��0 1 8 0q�52   (   $��11��69   $��11��6D   �� 53      $��Add a New Course��6   54      56      �� 59   
   $.��(Courses Are Sorted Based On Their Title.��6   $��4��6D   $��18(�5:      $��SemiBold"�6"   ���#121518$
��Left=�5<      $��Center=�6/   &   System.Windows.Controls.DataGrid  5?   
   -   5          Name$ coursessDataGrid��5?        DataGridRowStyle1   RowStyle# �  5@        DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  5A        DataGridCellStyle1   	CellStyle# �  5B        DataGridStyle1#���  5C      $
��True��5D      $
��Auto=�5E      $	��510��5F      $��0,10,0,0q�6#   $��5��65      Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      
IsReadOnly$
 True��60      CanUserResize$ False��5K   %      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5L   %   �� *SequentialIndex+  5O      $ Title��6%   $
 True��5P   ?   $	 100 6Q    6%   �� *Title+6Q     5S      $ 	Professor��6%   $
 True��5T   L   $	 150 6^    6%   �� *Professor.FullName+6^     5W      $ 	Classroom��6%   $
 True��5X   C   $	 105 6U    6%   �� *	Classroom+6U     5[      $ 
Start Time��6%   $
 True��5\   H   $	 100 6Z    6%   �� *ClassStartTime+6Z     5_      $ End Time��6%   $
 True��5`   F   $ 95 6X    6%   �� *ClassEndTime+6X     5c      $ End Date��6%   $
 True��5d   %   $ * 67    5c   7   �� *	EndDate+5d   7     5g      $ Course Schedule��6%   $
 True��5h   %   $	 150 67    5g   >   �� *
Schedule+5h   7     5k      $ Capacity��6%   $
 True��5l   %   $ 79 67    5k   7   �� *
Capacity+5l   7   4  .System.Windows.Controls.DataGridTemplateColumn  5o      $ 
Operations��6)   $
 True��6=   $ 98 6O      CellTemplate 5p      �� 5q      .R�5s      �� $	 
Horizontal=�6)   .+�5u   "   �� $ SubmitScores��6)   -   5         � ToolTip$ Submit the scores��5v   )   $��5 0 0 0q�5x   )     gridRemoveButton#��[ 5y   )   .��5z   &     $
 Counter=�6<     gridButtonIcon#��[ 6K   5{   #   �� 5~   "   $ AddAssignment��6)   -   5        $ Add an assignment��5   )   $��5 0 0 0q�5�   )     gridEditButton#��[ 5�   )   .��5�   &     $
 HeadQuestion=�6<   #��[ 6P   5�   #   5�      5�      5�      5�      5�      5�      