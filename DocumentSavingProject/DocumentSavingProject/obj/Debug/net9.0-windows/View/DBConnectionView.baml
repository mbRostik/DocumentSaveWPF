   M S B A M L   `   `   `  ����P  LDocumentSavingProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:DocumentSavingProject.ViewDocumentSavingProject.View  5   	   S.clr-namespace:DocumentSavingProject.Converters DocumentSavingProject.Converters  5   	   1    +DocumentSavingProject.View.DBConnectionView   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:DocumentSavingProject.View     5   	   E
converters.clr-namespace:DocumentSavingProject.Converters     5   	     � Title$  Database Connection��5	   	   $	��500��6%   $	��800��62    � Icon$2 ,pack://application:,,,/Images/WindowIcon.ico��5
   	    � WindowStartupLocation$ Manual=�5   	   ���#E3F2FD � 	Resources 5          BooleanToVisibilityConverterJ   DDocumentSavingProject.Converters.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverterG   ADocumentSavingProject.Converters.NullOrEmptyToVisibilityConverter $  NullOrEmptyToVisibilityConverter  ModernButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Padding
 �� Triggers P� Property P� Value��%o  &	        &	      &	 &     &	 9     �� 5   
   6'     5   
   69     5   
   66   �� 5   
   " ��6*   .�5      ��  � �� �#007ACC6+   �� 5       � ��
 �����6+   �� 5       � ��$ Normal"�6+   �� 5       � ��$ 14(�6)   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 0q�60   �� 5       � ��$ 10q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 2��5   !   ._�5      �� #	 z��6%   ._�5    "   �� $��Center=�63   $��Center=�5!   3   5"      5#      5$      5&      
 5'      P� 5(       �@J�IsMouseOver$
 True��61   . �5)      ��  � �� �#005A9E63   �� 5*       �@�Cursor$
 Hand��6/   5,      P� 5-       � ��$
 True��6/   . �5.      ��  � �� �#003F7363   5/      51      52      .��54      � $��20q�6    � RowDefinitions 55   
   �� 56      $
��Auto �6   �� 57      $��* �6   .+�5:   
   �� -   5        $,��&pack://application:,,,/Images/back.png��5:      $��30��5;      $��30��6   $
��Left=�5<      $	��Top=�6'   $��10q�5=       � Cursor$
 Hand��5>      $��0��5@       K� ZIndex$	 100��5A      �� 5B   
   
�������$ 5��6$   $	 20q�65   ���#007ACC$��2q�6X   $ 0��6l   ._�5C      �  5D      �� 5E      $
��Auto �6$   �� 5F      $��* �6$   �� 5G      $
��Auto �6$   .+�5K      �� $��Database Connection��6   $��24(�5L      $
��Bold"�5M      ���#007ACC$��0,0,0,20q�5O      $��Center=�5P      $��0��5Q      �� 5T      $��1��6   $��Center=�6*   $	��Top=�6G   $	��400��6_   .+�5V      �� .+�5W      �� $��Server Name:��6$   $��SemiBold"�68   $��14(�6N   $��0,0,0,5q�6\   
���   �6m   �� 5X      
����������#007ACC$��1q�6J   $ 3��6^   $	 5q�6o   ._�5Y      �� -   5        $��0q�5Z      $��0q�5[      ��5Y   &   �� *
ServerName+ �� UpdateSourceTrigger$ PropertyChanged=�5\      5]      5^      �� 5a      .+�5b      �� $��Database Name:��6$   $��SemiBold"�6:   $��14(�6P   $��0,0,0,5q�6^   
���   �6o   �� 5c      
����������#007ACC$��1q�6J   $ 3��6^   $	 5q�6o   ._�5d      �� -   5        $��0q�5e      $��0q�5f      ��5d   &   �� *DatabaseName+$ PropertyChanged=�5g      5h      5i      �� 5l      .+�5m      �� $��	Username:��6$   $��SemiBold"�65   $��14(�6K   $��0,0,0,5q�6Y   
���   �6j   �� 5n      
����������#007ACC$��1q�6J   $ 3��6^   $	 5q�6o   ._�5o      �� -   5        $��0q�5p      $��0q�5q      ��5o   &   �� *
Username+$ PropertyChanged=�5r      5s      5t      �� 5w      .+�5x      �� $��	Password:��6$   $��SemiBold"�65   $��14(�6K   $��0,0,0,5q�6Y   
���   �6j   �� 5y      
����������#007ACC$��1q�6J   $ 3��6^   $	 5q�6o   ._�5z      G� -   5        $��0q�5{      $��0q�5|      5}      5~      �� 5�       �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��0,0,0,15q�6U   .+�5�      �� $��Trust Server Certificate:��6$   $��SemiBold"�6E   $��14(�6[   
���   �$��Center=�6|   $��0,0,10,0q�6�   �� 5�      $��Center=�6P    d� 	IsChecked 6#   �� *TrustServerCertificate+6P   5�      5�      �� 5�      $��2��6   $ Vertical=�6*   $��Center=�6A   $��Bottom=�6^   .+�5�      �� $��Connect��6   $	��200��5�      $��50��5�   	   ���#28A745
�������$��16(�5�   	   $
��Bold"�5�   	   $��Center=�5�   	   $��Center=�5�   	   ��5�      �� *TestConnectionCommand+y�5�      �� *	IsLoading+ �� 	Converter# [ ��5�      �� 5�      " ��6$    �� BasedOn# [ 68   .�5�   "   ��  � �� 5�   &   �� 5�   *   " ��6:   .R�5�   .   � .+�5�   2   ��  ��Name$ ButtonBorder��69   #��z��5�   %   $ 1��5�   %   
���   �$��0q�5�   %   ._�5�   6   �� $��Center=�6G   $��Center=�5�   3   $
��Bold"�5�   3   5�   3   5�   /    �� Triggers 5�   .   P� 5�   2    �@J�IsMouseOver$
 True��6Q    N� EnterActions 5�   6   �� 5�   :   .��5�   >   �� .��5�   B   ��  �� 
TargetName$ ButtonBorder��6Q    �� TargetProperty$1 +(Border.Background).(SolidColorBrush.Color)�5�   =   	 �� To #1E7D345�   =    g� Duration$ 0:0:0.3D�6J   5�   ?   5�   ;    N� ExitActions 5�   6   �� 5�   :   .��5�   >   �� .��5�   B   �� $ ButtonBorder��6Q   $1 +(Border.Background).(SolidColorBrush.Color)�5�   =    #28A7455�   =   $ 0:0:0.3D�6J   5�   ?   5�   ;   5�   3   5�   +   5�   #   5�      5�      � 5�       � IsIndeterminate$
 True��6"   $��20��5�      $	��200��6   $��0,10,0,0q�6*   y�5�      �� *	IsLoading+# [  5�   *   �� 5�      $
��Wrap=�5�       �� TextAlignment$ Center=�5�      $��Center=�5�      $	��Top=�5�      $��0,10,0,0q�5�      $��16(�5�      $
��Bold"�5�      
���  ��$	��600��5�       J� Opacity$ 0Q�5�      ��5�       �� *StatusMessage+��5�      �� 5�      " ��6$   .�5�   "   ��  �@J�Opacity$ 0Q�6<   
 5�   "   �� 5�   &     �� Binding  62   �� *StatusMessage+# [ ! �� Value! Visible6�    5�   *   �� 5�   .   .��5�   2   �� .��5�   6   W� $ Opacity�6F   " W� From" 05�   2   	# W� To# 16;   $ 0:0:0.5D�5�   2   5�   3   5�   /    5�   *   �� 5�   .   .��5�   2   �� .��5�   6   W� $ Opacity�6F   " 15�   2   # 06;   $ 0:0:0.5D�5�   2   5�   3   5�   /   5�   '   5�      5�      5�      5�      5�      5�      5�      