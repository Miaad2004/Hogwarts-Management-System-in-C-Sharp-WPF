   M S B A M L   `   `   `  ���� I  EHogwarts.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Hogwarts.Views.StudentViewsHogwarts.Views.StudentViews  *    $Hogwarts.Views.StudentViews.MainView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;local)clr-namespace:Hogwarts.Views.StudentViews     c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks     N� Title$  Admin's Panel��.��� .+���  �� CornerRadius$ 26�����#EFF2F7 � Triggers :�  :� RoutedEvent$ Loaded��.[��� .���� .��W�  �� TargetProperty$ Opacity� W� From 0.4	 W� To 1 g� Duration$ 0:0:0.4D�._��  � ColumnDefinitions �� $	��200 ��� $��* �	 � RowDefinitions	 �� $��0 ��� $��* �.+��� $��1�����#623ED0$ 
25 50 0 25��._�]� .+��� $	��160��$	��160��
 �� Padding$
 3q�$	 100��$	��Top=�$
��Left=�$��	20 30 0 0q�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�-   BorderBrush��.���  � Color$ #462AD8�� � Offset$ 0Q�� $ #DA34AE��$	 0.5Q�� $ #8A16C1��$ 1Q�._�A� ���� -   brushProfileImage�� :� $ Loaded��.[��� .����  g� RepeatBehavior$ Forever��.����  �� 
TargetName$ BorderBrush�� g� AutoReverse$
 True��$ GradientStops[0].Color� �� From #462AD8	 �� To #39e3d8$ 0:0:11D��� $ BorderBrush��$
 True��$ GradientStops[1].Color� #DA34AE #c1f551$ 0:0:11D��� $ BorderBrush��$
 True��$ GradientStops[2].Color� #8A16C1 #e38039$ 0:0:11D�W� $ BorderBrush��$
 True��$ GradientStops[0].Offset� 0 1$ 0:0:7.5D�W� $ BorderBrush��$
 True��$ GradientStops[1].Offset� 0.1 1$ 0:0:7.5D��� $��Hogwarts��
�������$��22(�$��SemiBold"�$	��Top=�$��	5 25 0 10q� �� TextAlignment$ Center=��� $��Management System�����#D0BFFF$��14(�$��SemiBold"�$	��Top=�$ Center=��� $��25q����#7E5FDC$	��Top=�$	��0.8���� $	��Top=�.+��� -      PanelNavButton#��[  
 � Tag$' !/StudentViews/Pages/HomeView.xaml��.����  �� Orientation$ 
Horizontal=�.+�.  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ HomeVariant=�  PanelNavButtonIcon#��[ �� $��	Dashboard���� -   #��[  $, &/StudentViews/Pages/MyCoursesView.xaml��.���� $ 
Horizontal=�.+�  $ GoogleClassroom=�#��[ �� $��
My Courses���� -   #��[  $. (/StudentViews/Pages/AssignmentsView.xaml��.���� $ 
Horizontal=�.+�  $ ClipboardText=�#��[ �� $��Assignments���� -   #��[  $0 */StudentViews/Pages/CourseCatalogView.xaml��.���� $ 
Horizontal=�.+�  $ ClipboardList=�#��[ �� $��Course Catalog���� -   #��[  $2 ,/StudentViews/Pages/HogwartsExpressView.xaml��.���� $ 
Horizontal=�.+�  $ Train=�#��[ �� $��Hogwarts Express���� -   #��[  $) #/StudentViews/Pages/ForestView.xaml��.���� $ 
Horizontal=�.+�  $ Forest=�#��[ �� $��Forest���� -	    ��Name$ Logout��#��[  $��Bottom=�$��Bottom=�$��
15 0 15 20q�.���� $ 
Horizontal=�.+�  $ Logout=�#��[ �� $��Logout��� $��1��$��2��	 �� $��30 ��� $��* �.+�� $��1��.+� � -
     �Name$ 	pageFrame��  � NavigationUIVisibility$ Hidden=�$��15,10,33,10q�  � Source$' !/StudentViews/Pages/HomeView.xaml?�