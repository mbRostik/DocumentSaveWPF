   M S B A M L   `   `   `  ���� P  LDocumentSavingProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:DocumentSavingProjectDocumentSavingProject  S.clr-namespace:DocumentSavingProject.Converters DocumentSavingProject.Converters  &     DocumentSavingProject.MainWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:DocumentSavingProject     E
converters.clr-namespace:DocumentSavingProject.Converters       � Title$  	Main Menu��$	��450��$	��800�� � Icon$2 ,pack://application:,,,/Images/WindowIcon.ico�� � WindowStartupLocation$ CenterScreen=����#E3F2FD � 	Resources B   <DocumentSavingProject.Converters.StringToVisibilityConverter   StringToVisibilityConverter  ModernButtonStyle �� 
TargetType �� Property �� Value �� 
StartPoint �� EndPoint	 � Color
 � Offset3  -System.Windows.Media.Effects.DropShadowEffect   Color   Opacity   ShadowDepth �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value��%�  &	        &	        �� " ��.���  � �� �� $	 0,0&�$	 1,1&�.��� $	 #007ACC��$
 0Q�� $	 #005A9E��$
 1Q���  � ��
 �������  � ��$ SemiBold"���  � ��$ 16(���  � ��$
 10,5q���  � ��$ 0q���  � ��$ 10q���  �@J�Effect   $ Black��$	 0.3Q�$ 3Q���  � �� �� " ��.R��� #��z��$ 2��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �� $	 0,0&�$	 1,1&�.��� $	 #005A9E��$
 0Q�� $	 #003F73��$
 1Q���  �@�Cursor$
 Hand��P�  � ��$
 True��. ���  � �� �#003F73.��� $��20q�.+��� 
�������$ 10�� �� Padding$ 30q����#007ACC$��2q� J� Effect   $ Black��$	 0.3Q�$ 5Q�   
BlurRadius$ 10Q�._��� $��Center=�$��Center=�.+��� $��	Main Menu��$��28(�$
��Bold"����#007ACC �� TextAlignment$ Center=�   $ Black��$	 0.5Q�$ 2Q�$ 5Q��� -   $ ��Make a Database Connection��$	��250��$��50��#��[ �� -   $��Save Files in the DB��$	��250��$��50��#��[ y��� *CurrentConnectionString+ �� 	Converter# [  �� -   $
��Exit��$	��250��$��50��#��[ 