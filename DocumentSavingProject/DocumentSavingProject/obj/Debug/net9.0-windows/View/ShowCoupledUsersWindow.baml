   M S B A M L   `   `   `  ����P  LDocumentSavingProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:DocumentSavingProject.ViewDocumentSavingProject.View  5      S.clr-namespace:DocumentSavingProject.Converters DocumentSavingProject.Converters  5      7    1DocumentSavingProject.View.ShowCoupledUsersWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      :local(clr-namespace:DocumentSavingProject.View     5      E
converters.clr-namespace:DocumentSavingProject.Converters     5        � Title$  Show Coupled Users��5	   	   $	��600��6$   $	��800��61    � Icon$2 ,pack://application:,,,/Images/WindowIcon.ico��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#FFFFFF � 	Resources 5      J   DDocumentSavingProject.Converters.FileUserSelectedVisibilityConverter '  #FileUserSelectedVisibilityConverter   BooleanToVisibilityConverterE   ?DocumentSavingProject.Converters.FileUserSelectedMultiConverter " FileUserSelectedMultiConverter��%W   &	        &	      &	 &       5   
   69   �� 5   
   6'     5   
   64   5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ���#28A745 �� CornerRadius$ 5��63    �� Padding$ 10q�6D   $��0,0,0,10q�6Q   ._�5      �� $>��8These files have few possible users. Choose one for each��6   $��18(�5      $
��Bold"�5      
�������$��Center=�5       $��Center=�5!       �� TextAlignment$ Center=�5"      $
��Wrap=�5#      5$      � 5'   
   $��1��6    � ColumnDefinitions 5(      �� 5)      $��2* �6#   �� 5*      $��3* �6#   �� 5+      $
��0.5* �6#   .+�5/      �� $��0��6   $��Files��6(   $��14(�50      $
��Bold"�6&   ���#007ACC$��Center=�51      $��0,0,0,2q�65   �� 54      $��0��6   ���#007ACC$��1q�6;   $ 2��6O   $��10,30,10,10q�6`   ._�55      �� $��10q�57   
   ��55      �� *FewUsersCollectionKeys+	 �� SelectedItem	 56   
   �� *SelectedFile+
 �� Mode$
 TwoWay=���58      �� 59      .R�5:      ��  �� Orientation$ 
Horizontal=�6)   $��5,0,0,5q�6B   .+�5;   "   �� $
��Bold"�5>      ���#007ACC$��30��5@      ��5;   ,   �� *!(ItemsControl.AlternationIndex)+ �� RelativeSource ��  �� AncestorType ListBoxItem �� StringFormat$ [{0}]��5@      �� 5A   "   $��14(�5B      $
��Bold"�5C      $��10,0,0,0q�5D      ���#333��5A   ,   �� *
FileName+5E      �� 5F   "   $	��✔��6,   $��14(�5G   $   $
��Bold"�5H   $   
��� � �$��10,0,0,0q�5J   $   y�5K   $   �� *IsUserSelected+ �� 	Converter# [ 5L      5M       �� AlternationCount$
 1000��5O   N   5P      5Q      �� 5T      $��1��6   $��Users��6(   $��14(�5U      $
��Bold"�6&   ���#007ACC$��Center=�5V      $��0,0,0,2q�65   �� 5Y      $��1��6   ���#007ACC$��1q�6;   $ 2��6O   $��10,30,10,10q�6`   ._�5Z      �� $��10q�5\      ��5Z      �� *SelectedFileUsers+	 5[      �� *SelectedFileUser+$
 TwoWay=���5]      �� 5^       �� 
TargetType" ��6    .�5_      ��  �� Property � �� �� Value
 �����6;   �� 5`       � ��$ 14(�69   �� 5a       � ��$ 5q�67   �� 5b       � ��$ 10q�68   �� 5c       � �� 5d   "   �� 5e   &    �� 
TargetType" ��66   .R�5f   *   �� #��z��61   $ 2��6[   ._�5g   .   �� $
��Left=�6?   $��Center=�6Z   5h   +   5i   '   5k       �� Triggers 5l      P� 5m   "    P� Property �@��
IsSelected P� Value$
 True��6@   . �5n   &   ��  � ��
 ����6C   �� 5o   &    � ��
 �   �6C   5p   #   ]� 5q   "    ]� 
Conditions 5r   &   �� 5s   *    �� Property �@J�IsMouseOver �� Value$
 True��6K   �� 5t   *    �@��
IsSelected$ False��6J   ./�5v   &   ��  � �� �#E0E0E06C   5w   #   5y      ��5{      �� 5|      .R�5}      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5~   "   �� $ Vertical=�6-   $��Stretch=�6D   .+�5   &   �� $
��Bold"�6F   $��10,0,0,0q�6X   ��60   �� *Name+6X   �� 5�   &   $��10,0,0,0q�6I   ��60   �� *	SurName+6I   �� 5�   &   $��10,0,0,0q�6M   ��60   �� *PROGRESSIVO+6M   5�   #   �� 5�   "   $��20��6)   $��20��5�   )   $��10,0,0,0q�5�   )    � Cursor$
 Hand��5�   )   $��Center=�5�   )   $��Right=�5�   )   ��5�   )   �� *DataContext.RemoveUserCommand+ �� 
 Window��5�   )   �� ��5�   &   �� 5�   *   " ��60   .�5�   .   ��  � y�$ 	Collapsed=�6K   �� 5�   .    � �� 5�   2   �� 5�   6   " ��6F   .R�5�   :   � .+�5�   >   �� $��5��6H   $��22��6R   
���  �� J� RenderTransformOrigin$ 0.1,0.5&�6i   z�5�   B   �� 5�   F    �� Angle$ 45Q�6V   5�   ?   �� 5�   >   $��5��6H   $��22��6R   
���  ��$ 0.9,0.5&�6i   z�5�   B   �� 5�   F   $	 -45Q�6V   5�   ?   5�   ;   5�   7   5�   /    5�   .   �� 5�   2    �� Binding 6>   ��  ��  ListBoxItem �� Path$ 
IsSelected�  �� Value  True6�   .a�5�   6   ��  � y�$ Visible=�6S   5�   3   P� 5�   2    �@J�IsMouseOver$
 True��6Q   . �5�   6   ��  �@J�Opacity$	 0.5Q�6P   5�   3   P� 5�   2    � ��$
 True��6O   . �5�   6   ��  �@J�Opacity$	 0.5Q�6P   5�   3   5�   +   5�   #   5�      5�      5�      5�      �� 5�      $��2��6   $��0q�6%   $ 2��69   ._�5�      �� $
��Save��6   $��50��5�      ���#28A745
�������$	��200��5�      $��16(�5�      $
 Hand��5�      $
��Bold"�5�      $��Center=�5�      $��Center=�5�      ��5�   (   �� *ConfirmUserListCommand+��5�      �� 5�      " ��6    .�5�      ��  � �� 5�   "   �� 5�   &   " ��66   .R�5�   *   � .+�5�   .   �� ! ��Name$! ButtonBorder��65   #��z��5�   5   $ 1��5�   5   
���   �$��0q�5�   5   ._�5�   2   �� $��Center=�6C   $��Center=�5�   C   $
��Bold"�5�   C   5�   /   5�   +   " �� Triggers" 5�   *   P� 5�   .    �@J�IsMouseOver$
 True��6M   # N� EnterActions# 5�   2   �� 5�   6   .��5�   :   �� .��5�   >   �� $ �� 
TargetName$$ ButtonBorder��6M   % �� TargetProperty$1% +(Border.Background).(SolidColorBrush.Color)�5�   M   	& �� To& #1E7D345�   M   ' g� Duration$' 0:0:0.3D�6Z   5�   ;   5�   7   ( N� ExitActions( 5�   2   �� 5�   6   .��5�   :   �� .��5�   >   �� $$ ButtonBorder��6M   $1% +(Border.Background).(SolidColorBrush.Color)�5�   M   & #28A7455�   M   $' 0:0:0.3D�6Z   5�   ;   5�   7   5�   /   5�   '   5�      5�      5�      5�      5�      5�      5�      