   M S B A M L   `   `   `  ���� I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Hogwarts.Views.ProfessorViews.Popups$Hogwarts.Views.ProfessorViews.Popups  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem C    =Hogwarts.Views.ProfessorViews.Popups.AddAssignmentScoresPopup   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Dlocal2clr-namespace:Hogwarts.Views.ProfessorViews.Popups     6sys&clr-namespace:System;assembly=mscorlib     c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   -     � Title$  Add a Course��$	��600��$
��1000�� � WindowStartupLocation$ CenterScreen=�   BorderTheme#��[  .����  �� CornerRadius$ 26�� J� Opacity$
 0.92Q� � Triggers :�  :� RoutedEvent$ Loaded��.[��� .���� .��W�  �� TargetProperty$ Opacity� W� From 0.1	 W� To 0.92	 g� Duration$	 0:0:0.5D����� 
 �� 
StartPoint$

 1, 1&� �� EndPoint$
 0, 0&�.���  � Color$ #060531�� � Offset$ 0Q�� $ #1B1448��$	 0.8Q�._��  � RowDefinitions �� $��30 ��� �� $	��100 �.+�� $��0�� � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��5 �.+��� -    ��Name$ Minimize��$��1��  MinimizeButtonStyle#��[ �� -   $ Close��$��2��  CloseButtonStyle#��[ &   System.Windows.Controls.DataGrid  -     Name$ gradesDataGrid��$��1��  DataGridRowStyle1   RowStyle# �    DataGridColumnHeaderStyle1   ColumnHeaderStyle# �    DataGridCellStyle1   	CellStyle# �    DataGridStyle1#���  $
��True��$
��Auto=�$	��510��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ #��   
IsReadOnly$
 True��   CanUserResize$ False��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *SequentialIndex+4  .System.Windows.Controls.DataGridTemplateColumn  $
 Name��$
 True��$ *    CellTemplate �� .R���  �� Orientation$ 
Horizontal=�.+��� $��65��$��65��
�������$	 100��$��Center=�$��Center=�$��5 0 10 0q�._�A� ����  �� ImageSource �� *Student.FullProfileImagePath+�� $��Center=����� *Student.FullName+  $ Username��$
 True��$ *  �� *Student.Username+  $ Email Address��$
 True��$ *  �� *Student.Email+  $ House��$
 True��$ *  �� *Student.HouseType+  $ Score�� �� .R��� :   4Hogwarts.Views.ProfessorViews.Popups.GradeTypeValues   Values#��Z {��� *HasBeenAnswered+ �� SelectedItem �� *Score+  �� Mode$  TwoWay=�! �� UpdateSourceTrigger$! PropertyChanged=�  $ 
Operations��$
 True��$ *  �� .R��� $ 
Horizontal=�.+��� $ 
ViewAnswer��-   " � ToolTip$" View Student's Answer��$��5 0 0 0q�  gridEditButton#��[ {��� *HasBeenAnswered+.��.  (MahApps.Metro.IconPacks.PackIconMaterial  #   Kind$# 
CardSearch=�  gridButtonIcon#��[ �� -   $ SubmitScores��
�������$��0q�$��Submit��$��12(�$��
Montserrat)�$ � Cursor$
$ Hand��$��2������ % �� 
TargetType"% ��.��� & �� Property& � ��' �� Value' �	#FF135B80( �� Triggers( P� ) P� Property) �@J�IsMouseOver* P� Value$
* True��. ��� & � ��' �	#FF318CBB���� + �� 
TargetType"+ ��.R��� $	��150��$��40��$ 20��#��z��._��� $��Center=�$��Center=�