   M S B A M L   `   `   `  ����P  LDocumentSavingProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:DocumentSavingProjectDocumentSavingProject  5   	   S.clr-namespace:DocumentSavingProject.Converters DocumentSavingProject.Converters  5   	   &     DocumentSavingProject.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:DocumentSavingProject     5   	   E
converters.clr-namespace:DocumentSavingProject.Converters     5   	     � Title$  	Main Menu��5	   	   $	��450��6   $	��800��6(    � Icon$2 ,pack://application:,,,/Images/WindowIcon.ico��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#E3F2FD � 	Resources 5      B   <DocumentSavingProject.Converters.StringToVisibilityConverter   StringToVisibilityConverter  ModernButtonStyle �� 
TargetType �� Property �� Value �� 
StartPoint �� EndPoint	 � Color
 � Offset3  -System.Windows.Media.Effects.DropShadowEffect   Color   Opacity   ShadowDepth �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value��%�  &	        &	        5   
   61   �� 5   
   " ��6*   .�5      ��  � �� 5      �� 5      $	 0,0&�6*   $	 1,1&�6;   .��5      � $	 #007ACC��6'   $
 0Q�67   � 5      $	 #005A9E��6'   $
 1Q�67   5      5      �� 5       � ��
 �����6+   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 0q�60   �� 5       � ��$ 10q�6'   �� 5       �@J�Effect 5        5       $ Black��6'   $	 0.3Q�65   $ 3Q�6C   5"      �� 5#       � �� 5$      �� 5%      " ��6&   .R�5&      �� #��z��6!   $ 2��5'   !   ._�5(      �� $��Center=�6/   $��Center=�5)   /   5*      5+      5-       5.      P� 5/       �@J�IsMouseOver$
 True��61   . �50      ��  � �� 51      �� 52      $	 0,0&�62   $	 1,1&�6C   .��53   "   � $	 #005A9E��6/   $
 0Q�6?   � 54   "   $	 #003F73��6/   $
 1Q�6?   55      57      �� 58       �@�Cursor$
 Hand��6/   59      P� 5:       � ��$
 True��6/   . �5;      ��  � �� �#003F7363   5<      5>      5?      .��5A      � $��20q�6   .+�5B   
   �� 
�������$ 10��6$    �� Padding$ 30q�66   ���#007ACC$��2q�6Y    J� Effect 5C        5D      $ Black��6#   $	 0.3Q�61   $ 5Q�6?      
BlurRadius$ 10Q�6O   ._�5F      �� $��Center=�6   $��Center=�64   .+�5H      �� $��	Main Menu��6   $��28(�5I      $
��Bold"�5J      ���#007ACC �� TextAlignment$ Center=�5L       5M        5N      $ Black��6+   $	 0.5Q�69   $ 2Q�6G   $ 5Q�6W   5P      �� 5T      -   5        $ ��Make a Database Connection��5T      $	��250��5U      $��50��5V      #��[ 5X      �� 5[      -   5        $��Save Files in the DB��5[      $	��250��5\      $��50��5]      #��[ 5`      y�5_      �� *CurrentConnectionString+ �� 	Converter# [  5`      �� 5c      -   5        $
��Exit��5c      $	��250��5d      $��50��5e      #��[ 5g      5h      5i      5j      5k      