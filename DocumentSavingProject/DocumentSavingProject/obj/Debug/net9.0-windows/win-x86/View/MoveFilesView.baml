   M S B A M L   `   `   `  ����P  LDocumentSavingProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:DocumentSavingProject.ViewDocumentSavingProject.View  5   	   S.clr-namespace:DocumentSavingProject.Converters DocumentSavingProject.Converters  5   	   .    (DocumentSavingProject.View.MoveFilesView   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:DocumentSavingProject.View     5   	   E
converters.clr-namespace:DocumentSavingProject.Converters     5   	     � Title$  Files Saver��5	   	   $	��600��6   $
��1000��6*    � Icon$, &pack://application:,,,/Images/icon.ico��5
   	    � WindowStartupLocation$ Manual=�5   	   
������� � 	Resources 5      C   =DocumentSavingProject.Converters.BooleanToVisibilityConverter    BooleanToVisibilityConverterH   BDocumentSavingProject.Converters.StringToVisibilityConverterSecond % !StringToVisibilityConverterSecondJ   DDocumentSavingProject.Converters.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverter  ModernButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Padding
 �� Triggers P� Property P� Value��%o  &	        &	      &	 &     &	 9       5   
   62     5   
   67     5   
   69   �� 5   
   " ��6*   .�5      ��  � �� �#007ACC6+   �� 5       � ��
 �����6+   �� 5       � ��$ Normal"�6+   �� 5       � ��$ 14(�6)   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 0q�60   �� 5       � ��$ 10q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 2��5   !   ._�5      �� #	 z��6%   ._�5    "   �� $��Center=�63   $��Center=�5!   3   5"      5#      5$      5&      
 5'      P� 5(       �@J�IsMouseOver$
 True��61   . �5)      ��  � �� �#005A9E63   �� 5*       �@�Cursor$
 Hand��6/   5+      P� 5,       � ��$
 True��6/   . �5-      ��  � �� �#003F7363   5.      50      51      .��54      � .+�56   
   �� -   5        $,��&pack://application:,,,/Images/back.png��56      $��30��57      $��30��6   $
��Left=�58      $	��Top=�6+   $��10q�59       � Cursor$
 Hand��5:      5;      �� 5<   
   $	��Top=�5=      $
��Left=�5>      $��	90,10,0,0q�5?      $��18(�5@      $��SemiBold"�5A      ���#005A9E$
��Wrap=�5C      ��5<      �� *DatabaseConfigSummary+5C      � 5E   
   $��20,50,20,20q�6    � RowDefinitions 5F      �� 5G      $
��Auto �6    �� 5H      $��* �6    .+�5L      �� $��0��6   ���#E3F2FD$ 5��67   $	 10q�6H   ._�5M      �  � ColumnDefinitions 5N      �� 5O      $��3* �6+   �� 5P      $��1* �6+   �� 5Q      $��1* �6+   .+�5U      ��  �� Orientation$ 
Horizontal=�6!   $��0��6:   .+�5V      �� $"��Choose a path to move files:��6$   $��Center=�5W      $��16(�5X      $��SemiBold"�5Y      ���#005A9E$��0,0,10,0q�5\      �� 5]       �� 
IsReadOnly$
 True��6e   $	��400��6w   $��0,0,10,0q�6�   ��6"   �� *SelectedPath+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5_      �� 5a      $ 
Horizontal=�6!   $
��Left=�6:   $��1��6U   $	��100��6e   .+�5b      �� $��Browse��6!   #��[ 6T   ��62   �� *BrowseCommand+6T   5c      �� 5d      $ 
Horizontal=�6!   $
��Left=�6:   $��2��6U   $	��220��6e   $	��210��6t   .+�5e      �� $��
Save Files��6!   ��66   �� *MoveFilesCommand+y�5f   !   �� *	IsLoading+ �� 	Converter# [ {�5g   "   ��  �� Path$ SelectedPath�# [ ��5h      �� 5i   "   " ��6(    �� BasedOn# [ 6<   .�5j   &   ��  � �� �#007ACC6C   �� 5k   &    � ��
 �����6C   
 5l   &   P� 5m   *    � {�$ False��6G   . �5n   .   ��  � �� �#D3D3D36K   �� 5o   .    � �� �#A9A9A96K   �� 5p   .    �@�Cursor$ Arrow��6G   5q   +   5s   #   5u      � 5w       � IsIndeterminate$
 True��6&   $��20��5y   &   $	��200��62   $
��0,10q�6>   y�5x   &   �� *	IsLoading+# [  5y   >   5z      5{      5|      � 5      $��1��6   $��0,20,0,0q�6     5�      �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   .+�5�      �� $��0��6   
����������#007ACC$��1q�6R   $ 10��6f   $��10q�6x   ._�5�      � $��10q�6    5�      �� 5�      $
��Auto �6,   �� 5�      $��* �6,   .+�5�      �� $��Invalid Files��6$   $��16(�69   $
��Bold"�6G   ���#005A9E$��0,0,0,10q�6n   �� 5�      $
��Auto=�6'   $��1��6J   .��5�      �� ��6&   �� *SkippedFiles+ �� AlternationCount 6K   �� *SkippedFiles.Count+��5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   $��5,0,0,5q�6N   .+�5�   .   �� $
��Bold"�5�   (   ���#007ACC$��30��6O   ��5�   8   �� *!(ItemsControl.AlternationIndex)+ �� RelativeSource ��  �� AncestorType ListBoxItem �� StringFormat$ [{0}]��5�   O   �� 5�   .   $��14(�6I   $
��Bold"�6W   $��10,0,0,0q�6i   ���#333��68   �� 6{   5�   +   5�   '   5�      5�      5�      5�      �� 5�      $��1��6   
����������#007ACC$��1q�6R   $ 10��6f   $��10q�6x   ._�5�      � $��10q�6    5�      �� 5�      $
��Auto �6,   �� 5�      $��* �6,   .+�5�      �� $��Files Not Added to DB��6$   $��16(�6A   $
��Bold"�6O   ���#005A9E$��0,0,0,10q�6v   �� 5�      $
��Auto=�6'   $��1��6J   .��5�      �� ��6&   �� *NotAddedToDbFiles+ 6P   �� *NotAddedToDbFiles.Count+��5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   $��5,0,0,5q�6N   .+�5�   .   �� $
��Bold"�5�   (   ���#007ACC$��30��6O   ��5�   8   �� *!(ItemsControl.AlternationIndex)+ ��  ListBoxItem$ [{0}]��5�   O   �� 5�   .   $��14(�6I   $
��Bold"�6W   $��10,0,0,0q�6i   ���#333��68   �� 6{   5�   +   5�   '   5�      5�      5�      5�      �� 5�      $��2��6   
����������#007ACC$��1q�6R   $ 10��6f   $��10q�6x   ._�5�      � $��10q�6    5�      �� 5�      $
��Auto �6,   �� 5�      $��* �6,   .+�5�      �� $��Files Added to DB��6$   $��16(�6=   $
��Bold"�6K   ���#005A9E$��0,0,0,10q�6r   �� 5�      $
��Auto=�6'   $��1��6J   .��5�      �� ��6&   �� *AddedToDbFiles+ 6M   �� *AddedToDbFiles.Count+��5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   $��5,0,0,5q�6N   .+�5�   .   �� $
��Bold"�5�   (   ���#007ACC$��30��6O   ��5�   8   �� *!(ItemsControl.AlternationIndex)+ ��  ListBoxItem$ [{0}]��5�   O   �� 5�   .   $��14(�6I   $
��Bold"�6W   $��10,0,0,0q�6i   ���#333��68   �� 6{   5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      