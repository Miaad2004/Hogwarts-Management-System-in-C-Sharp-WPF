   M S B A M L   `   `   `  ���� I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Hogwarts.Views.AdminViews.PagesHogwarts.Views.AdminViews.Pages  .    (Hogwarts.Views.AdminViews.Pages.HomeView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ?local-clr-namespace:Hogwarts.Views.AdminViews.Pages       N� Title$
  Home��.����  �� CornerRadius$ 20�� � Triggers :�  :� RoutedEvent$ Loaded��.[��� .���� .��W�  �� TargetProperty$ Opacity� W� From 0.3	 W� To 1 g� Duration$ 0:0:0.3D�����  �� ImageSource$6 0/StaticResources/MainPanel/Admin/HomeView/bg.jpg��._��� 	 J� Opacity$
	 0.82Q�$ 25������ 
 �� 
StartPoint$

 1, 1&� �� EndPoint$
 0, 0&�.���  � Color$ #060531�� � Offset$ 0Q�� $ #1B1448��$	 0.8Q�._��  � RowDefinitions �� $��25 ��� $	��200 ��� $��* � � ColumnDefinitions �� $��25 ��� $��* ��� $��25 �.+�� $��1��$��1��.+�(� $
��1500��$
��1000��.���� $
��1200��$	��200��$ 30,30,30,30��$
��1300��$
��1000��._��� .+�A� $	��500��$	��500��$��Bottom=����	#FF4039B0$		 0.6Q� �� Left$
 -181��
 �� Top$
 -300��A� $	��400��$	��400��$��Bottom=����	#FF5856DD$		 0.5Q�$ 31��$
 -236��A� $	��400��$	��400��$��Bottom=����	#FF2A5A80$		 0.7Q�$
 -146��$
 -250��A� $	��400��$	��400�����	#FF362A80$		 0.7Q�$	 -55��$ 56��$
��Left=�$	��Top=�A� $	��400��$	��400�����	#FF4E419C$		 0.7Q�$	 105��$	 131��$
��Left=�$	��Top=����� $	
 0,0&�$	 1,1&�.��� $ 0Q�$ #162447��� $ 1Q�$ #1f4068���� $��Welcome Back!��$��36(�$��SemiBold"�$	��Top=�$��25,26,472,0q����	#FFE4E4FA J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 2Q��� -    ��Name$ txtFullName��$��	Full Name�����	#FF43F6AE$��48(�$��SemiBold"�$	��Top=�$��350,80,-1,0q�$	��136��   $ 2Q�� $��2��$��1��$	��350��$��0, 25, 0, 0q�.+��� $ 30 30 30 30������ $	
 0,0&�$	 1,1&�.��� $ 0Q�$ #162447��� $ 1Q�$ #1f4068���  �� $��15 ��� �� �� $��15 � �� $��40 ��� �� �� �� �� $��40 �.+���  �� Orientation$ 
Horizontal=�$��1��$��1��.+���    LoginInputLabelTheme#��[  $��	Username:��$��18(��� -   $ txtUsername��#��[   �� Padding$ 10, 0, 0, 0q�$��USERNAME��$��20(����	#FFF69C43�� $ 
Horizontal=�$��1��$��2��.+��� #��[  $
��Age:��$��18(��� -   $ txtAge��#��[  $ 10, 0, 0, 0q�$	��AGE��$��20(����	#FFF69C43�� $ 
Horizontal=�$��1��$��3��.+��� #��[  $��
BloodType:��$��18(��� -   $ txtBloodType��#��[  $ 10, 0, 0, 0q�$��
BLOOD TYPE��$��20(����	#FFF69C43�� $ 
Horizontal=�$��1��$��4��.+��� #��[  $��Email:��$��18(��� -   $ txtEmail��#��[  $ 10, 0, 0, 0q�$��EMAIL��$��18(����	#FFF69C43�� $ 
Horizontal=�$��2��$��1��.+��� #��[  $��Active Student Count:��$��18(��� -   $ txtStudentsCount��#��[  $ 10, 0, 0, 0q�$��COUNT��$��20(����	#FFF69C43�� $ 
Horizontal=�$��2��$��2��.+��� #��[  $��Active Train Count:��$��18(��� -   $ txtTrainsCount��#��[  $ 10, 0, 0, 0q�$��COUNT��$��20(����	#FFF69C43�� $ 
Horizontal=�$��2��$��3��.+��� #��[  $��Active Professor Count:��$��18(��� -   $ txtProfessorsCount��#��[  $ 10, 0, 0, 0q�$��COUNT��$��20(����	#FFF69C43�� $ 
Horizontal=�$��2��$��4��.+��� #��[  $%��Forest Collectable Plant Count:��$��18(��� -	   $ txtForestPlantsCount��#��[  $ 10, 0, 0, 0q�$��COUNT��$��20(����	#FFF69C43