   M S B A M L   `   `   `  ���� I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Hogwarts.Views.AdminViews.Popups Hogwarts.Views.AdminViews.Popups  9    3Hogwarts.Views.AdminViews.Popups.InviteStudentPopup   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @local.clr-namespace:Hogwarts.Views.AdminViews.Popups     -     � Title$  InviteStudent��$	��450��$	��700�� � WindowStartupLocation$ CenterScreen=�   BorderTheme#��[  .����  �� CornerRadius$ 26������  �� ImageSource$@ :/StaticResources/MainPanel/Admin/InviteStudentPopup/bg.jpg��._���  J� Opacity$
 0.75Q�$ 25�� � Triggers :�  :� RoutedEvent$ Loaded��.[��� .���� .��W�  �� TargetProperty$ Opacity� W� From 0.1		 W� To	 0.75
 g� Duration$
 0:0:0.5D�����  �� 
StartPoint$
 1, 1&� �� EndPoint$
 0, 0&�.���  � Color$ #060531�� � Offset$ 0Q�� $ #1B1448��$	 0.8Q�._��  � RowDefinitions �� $��30 ��� .+�� $��0�� � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��5 �.+��� -    ��Name$ Minimize��$��1��  MinimizeButtonStyle#��[ �� -   $ Close��$��2��  CloseButtonStyle#��[ � $��1��$��2��$��0, -30, 0, 0q� �� $
��0.5* ��� $��0 ��� $��* ��� $��0 �.+��� $��0�����	#FF318CBB$ 	25 0 0 25��$
}�True��._�� .+�A� $	��500��$	��500��$��Bottom=����	#FF645ECC$��50 0 0 -200q�$	 0.6Q�A� $	��300��$	��300��$��Bottom=����	#FFAA5BCB$��-450 0 0 30q�$	 0.3Q�A� $	��400��$	��400��$��Bottom=����	#FF9E5ECC$��-34,0,-133,-164q�$	 0.3Q�A� $	��280��$��Bottom=����	#FF367798$��83,0,-133,-165q�$	 0.5Q��� $��0 30 0 0q�$	��Top=�.+��� $B��</StaticResources/MainPanel/Admin/InviteStudentPopup/logo.png��$	��200��$	��200���� $��Owlery��$��46(�$��Light"����#ffffff �� TextAlignment$ Center=��� $ ��Send an Acceptance Letter!��$��Light"�$��16(����#D1F2EB$ Center=�$��0 15 0 3q��� $��2��._��� $��1��$
��auto�� �� Orientation$ Vertical=�$��Center=�.+��� $��	Username:��  LoginInputLabelTheme#��[ $��0, 45, 0, 0q��� -    ��Name$ txtUsername��$��15, 0, 0, 0q�  LoginTextBoxTheme#��[ $��0,5,0,0q�.������ $G A/StaticResources/MainPanel/Admin/InviteStudentPopup/user-icon.png�� j� Stretch$
 None=� j� 
AlignmentX$
 Left=�.���� $��First Name:��#��[ $��0, 25, 0, 0q��� -   $ txtFirstName��#��[ $��0,5,0,0q�
������ .���� $��
Last Name:��#��[ $��0, 25, 0, 0q��� -   $ txtLastName��#��[ $��0,5,0,0q�
������ .���� $��Email��#��[ $��0, 25, 0, 0q��� -   $ txtEmail��#��[ $��0,5,0,0q�
������ .���� -   $ InviteStudent��
�������$��0q�$��Invite��$��12(�$��
Montserrat)� � Cursor$
 Hand��$��2��$��0,55,0,0q�����  �� 
TargetType" ��.���  �� Property � �� �� Value �	#FF135B80 �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �	#FF318CBB����  �� 
TargetType" ��.R��� $	��150��$��40��$ 20��#��z��._��� $��Center=�$��Center=�