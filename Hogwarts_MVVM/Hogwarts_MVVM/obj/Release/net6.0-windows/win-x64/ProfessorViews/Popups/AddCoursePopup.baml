   M S B A M L   `   `   `  ���� I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Hogwarts.Views.ProfessorViews.Popups$Hogwarts.Views.ProfessorViews.Popups  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 9    3Hogwarts.Views.ProfessorViews.Popups.AddCoursePopup   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Dlocal2clr-namespace:Hogwarts.Views.ProfessorViews.Popups     6sys&clr-namespace:System;assembly=mscorlib     -     � Title$  Add a Course��$	��450��$	��700�� � WindowStartupLocation$ CenterScreen=�   BorderTheme#��[  .����  �� CornerRadius$ 26������  �� ImageSource$@ :/StaticResources/MainPanel/Professor/AddCoursePopup/bg.jpg��._���  J� Opacity$	 0.6Q�$ 25�� � Triggers :�  :� RoutedEvent$ Loaded��.[��� .���� .��W�  �� TargetProperty$ Opacity� W� From 0.1		 W� To	 0.6
 g� Duration$
 0:0:0.5D�����  �� 
StartPoint$
 1, 1&� �� EndPoint$
 0, 0&�.���  � Color$ #060531�� � Offset$ 0Q�� $ #1B1448��$	 0.8Q�._��  � RowDefinitions �� $��30 ��� .+�� $��0�� � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��5 �.+��� -    ��Name$ Minimize��$��1��  MinimizeButtonStyle#��[ �� -   $ Close��$��2��  CloseButtonStyle#��[ � $��1��$��2��$��0, -30, 0, 0q� �� $
��0.6* ��� $��0 ��� $��* ��� $��0 �.+��� $��0�����	#FF318CBB$ 	25 0 0 25��$
}�True��._�� .+�A� $	��500��$	��500��$��Bottom=����	#FF645ECC$��50 0 0 -200q�$	 0.6Q�A� $	��300��$	��300��$��Bottom=����	#FFAA5BCB$��-450 0 0 30q�$	 0.3Q�A� $	��400��$	��400��$��Bottom=����	#FF9E5ECC$��-34,0,-133,-164q�$	 0.3Q�A� $	��280��$��Bottom=����	#FF367798$��83,0,-133,-165q�$	 0.5Q��� $	��Top=�.+��� $B��</StaticResources/MainPanel/Professor/AddCoursePopup/logo.png��$	��200��$	��200���� $��Course��$��46(�$��Light"����#ffffff �� TextAlignment$ Center=��� $��	Managemet��$��46(�$��Light"����#ffffff$ Center=��� $��Add a New Course!��$��Light"�$��16(����#D1F2EB$ Center=�$��0 15 0 3q��� $��2��._��� $��1��$
��auto�� �� Orientation$ Vertical=�$��Center=�.+��� $ 
Horizontal=�$��0, 25, 0, 0q�.+��� $��Title:��  SignupInputLabelTheme#��[ $��0, 25, 0, 0q��� -    ��Name$ txtTitle�� �� 	MaxLength$ 30��  LoginTextBoxTheme#��[ $��22,5,0,0q�
������ .���� $ 
Horizontal=�$��0, 25, 0, 0q�.+��� $��	End Date:��#��[ $��
0, 0, 5, 0q�(  "System.Windows.Controls.DatePicker  -   $��endDatePicker��
 �� Now   SelectedDate# Z    DisplayDateStart# Z $	��120��$
��Left=�$��5,0,0,0q��� $��	Schedule:��#��[ $��20, 0, 5, 0q��� -    ��Name$ scheduleComboBox��$��Visible=�$
��True�� �� MaxDropDownHeight$	 100��$��75��$��25�� �� SelectedIndex$ 0��$��
5, 0, 0, 0q�$��Center=�.@��� .��
Saturday�� .��Sunday�� .��Monday�� .��	Tuesday�� .��	Wednesday�� .��
Thursday�� .��Friday�� $ 
Horizontal=�$��0, 10, 0, 0q�.+��� $��	Capacity:��#��[ $��0, 25, 0, 0q��� -   $ txtCapacity��$��50��$ 3��#��[ $��10,5,0,0q�
������ .���� $��
Classroom:��#��[ $��90, 25, 10, 0q��� -   $ txtClassroom��$��50��$ 5��#��[ $��10,5,0,0q�
������ .���� $ 
Horizontal=�$��0, 25, 0, 0q�.+��� $��Class Start Time:��  LoginInputLabelTheme#��[ $��0, 0, 20, 0q��� -	   $ startHourComboBox��$��Visible=�$
��True��$	 150��$��50��$ 7��$��0, 0, 10, 0q�$��Center=�.@��� .��1�� .��2�� .��3�� .��4�� .��5�� .��6�� .��7�� .��8�� .��9�� .��10�� .��11�� .��12�� -
   $ startAmPmComboBox��$��50��$ 0��$��Center=�.@��� .��AM�� .��PM�� $ 
Horizontal=�$��0, 25, 0, 0q�.+��� $��Class End Time:��#��[ $��0, 0, 20, 0q��� -   $ endHourComboBox��$��Visible=�$
��True��$	 150��$��50��$ 9��$��6, 0, 10, 0q�$��Center=�.@��� .��1�� .��2�� .��3�� .��4�� .��5�� .��6�� .��7�� .��8�� .��9�� .��10�� .��11�� .��12�� -   $ endAmPmComboBox��$��50��$ 0��$��Center=�.@��� .��AM�� .��PM�� -   $ 	AddCourse��
�������$��0q�$��
Add Course��$��12(�$��
Montserrat)� � Cursor$
 Hand��$��2��$��	0,105,0,0q�����  �� 
TargetType" ��.���  �� Property � �� �� Value �	#FF135B80  �� Triggers  P� ! P� Property! �@J�IsMouseOver" P� Value$
" True��. ���  � �� �	#FF318CBB���� # �� 
TargetType"# ��.R��� $	��150��$��40��$ 20��#��z��._��� $��Center=�$��Center=�