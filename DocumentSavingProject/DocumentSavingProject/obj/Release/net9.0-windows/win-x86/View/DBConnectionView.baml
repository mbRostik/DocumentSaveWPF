   M S B A M L   `   `   `  ���� P  LDocumentSavingProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:DocumentSavingProject.ViewDocumentSavingProject.View  S.clr-namespace:DocumentSavingProject.Converters DocumentSavingProject.Converters  1    +DocumentSavingProject.View.DBConnectionView   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:DocumentSavingProject.View     E
converters.clr-namespace:DocumentSavingProject.Converters       � Title$  Database Connection��$	��500��$	��800�� � Icon$2 ,pack://application:,,,/Images/WindowIcon.ico�� � WindowStartupLocation$ Manual=����#E3F2FD � 	Resources     BooleanToVisibilityConverterJ   DDocumentSavingProject.Converters.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverterG   ADocumentSavingProject.Converters.NullOrEmptyToVisibilityConverter $  NullOrEmptyToVisibilityConverter  ModernButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Padding
 �� Triggers P� Property P� Value��%�  &	        &	      &	 
     &	      ��     �� " ��.���  � �� �#007ACC��  � ��
 �������  � ��$ Normal"���  � ��$ 14(���  � ��$
 10,5q���  � ��$ 0q���  � ��$ 10q���  � �� �� " ��.R��� #��z��$ 2��._��� #	 z��._��� $��Center=�$��Center=�
 P�  �@J�IsMouseOver$
 True��. ���  � �� �#005A9E��  �@�Cursor$
 Hand��P�  � ��$
 True��. ���  � �� �#003F73.��� $��20q� � RowDefinitions �� $
��Auto ��� $��* �.+��� -   $,��&pack://application:,,,/Images/back.png��$��30��$��30��$
��Left=�$	��Top=�$��10q� � Cursor$
 Hand��$��0�� K� ZIndex$	 100���� 
�������$ 5��$	 20q����#007ACC$��2q�$ 0��._��  �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��Database Connection��$��24(�$
��Bold"����#007ACC$��0,0,0,20q�$��Center=�$��0���� $��1��$��Center=�$	��Top=�$	��400��.+��� .+��� $��Server Name:��$��SemiBold"�$��14(�$��0,0,0,5q�
���   ��� 
����������#007ACC$��1q�$ 3��$	 5q�._��� -   $��0q�$��0q����� *
ServerName+ �� UpdateSourceTrigger$ PropertyChanged=��� .+��� $��Database Name:��$��SemiBold"�$��14(�$��0,0,0,5q�
���   ��� 
����������#007ACC$��1q�$ 3��$	 5q�._��� -   $��0q�$��0q����� *DatabaseName+$ PropertyChanged=��� .+��� $��	Username:��$��SemiBold"�$��14(�$��0,0,0,5q�
���   ��� 
����������#007ACC$��1q�$ 3��$	 5q�._��� -   $��0q�$��0q����� *
Username+$ PropertyChanged=��� .+��� $��	Password:��$��SemiBold"�$��14(�$��0,0,0,5q�
���   ��� 
����������#007ACC$��1q�$ 3��$	 5q�._�G� -   $��0q�$��0q���  �� Orientation$ 
Horizontal=�$��Center=�$��0,0,0,15q�.+��� $��Trust Server Certificate:��$��SemiBold"�$��14(�
���   �$��Center=�$��0,0,10,0q��� $��Center=� d� 	IsChecked �� *TrustServerCertificate+�� $��2��$ Vertical=�$��Center=�$��Bottom=�.+��� $��Connect��$	��200��$��50�����#28A745
�������$��16(�$
��Bold"�$��Center=�$��Center=����� *TestConnectionCommand+y��� *	IsLoading+ �� 	Converter# [ ���� " �� �� BasedOn# [ .���  � �� �� " ��.R�� .+���  ��Name$ ButtonBorder��#��z��$ 1��
���   �$��0q�._��� $��Center=�$��Center=�$
��Bold"� �� Triggers P�  �@J�IsMouseOver$
 True�� N� EnterActions �� .���� .����  �� 
TargetName$ ButtonBorder�� �� TargetProperty$1 +(Border.Background).(SolidColorBrush.Color)�	 �� To #1E7D34 g� Duration$ 0:0:0.3D� N� ExitActions �� .���� .���� $ ButtonBorder��$1 +(Border.Background).(SolidColorBrush.Color)� #28A745$ 0:0:0.3D��  � IsIndeterminate$
 True��$��20��$	��200��$��0,10,0,0q�y��� *	IsLoading+# [  �� $
��Wrap=� �� TextAlignment$ Center=�$��Center=�$	��Top=�$��0,10,0,0q�$��16(�$
��Bold"�
���  ��$	��600�� J� Opacity$ 0Q����� *StatusMessage+���� " ��.���  �@J�Opacity$ 0Q�
 ��   �� Binding  �� *StatusMessage+# [ ! �� Value! Visible �� .���� .��W� $ Opacity�" W� From" 0	# W� To# 1$ 0:0:0.5D� �� .���� .��W� $ Opacity�" 1# 0$ 0:0:0.5D�