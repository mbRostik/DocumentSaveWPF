   M S B A M L   `   `   `  ���� P  LDocumentSavingProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:DocumentSavingProject.ViewDocumentSavingProject.View  S.clr-namespace:DocumentSavingProject.Converters DocumentSavingProject.Converters  .    (DocumentSavingProject.View.MoveFilesView   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:DocumentSavingProject.View     E
converters.clr-namespace:DocumentSavingProject.Converters       � Title$  Files Saver��$	��600��$
��1000�� � Icon$2 ,pack://application:,,,/Images/WindowIcon.ico�� � WindowStartupLocation$ Manual=�
������� � 	Resources C   =DocumentSavingProject.Converters.BooleanToVisibilityConverter    BooleanToVisibilityConverterH   BDocumentSavingProject.Converters.StringToVisibilityConverterSecond % !StringToVisibilityConverterSecondJ   DDocumentSavingProject.Converters.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverter  ModernButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Padding
 �� Triggers P� Property P� Value��%�  &	        &	      &	 
     &	            �� " ��.���  � �� �#007ACC��  � ��
 �������  � ��$ Normal"���  � ��$ 14(���  � ��$
 10,5q���  � ��$ 0q���  � ��$ 10q���  � �� �� " ��.R��� #��z��$ 2��._��� #	 z��._��� $��Center=�$��Center=�
 P�  �@J�IsMouseOver$
 True��. ���  � �� �#005A9E��  �@�Cursor$
 Hand��P�  � ��$
 True��. ���  � �� �#003F73.��� .+��� -   $,��&pack://application:,,,/Images/back.png��$��30��$��30��$
��Left=�$	��Top=�$��10q� � Cursor$
 Hand����  �� Orientation$ 
Horizontal=�$	��Top=�$
��Left=�$��	90,10,0,0q�.+��� $��Center=�$��18(�$��SemiBold"����#005A9E$
��Wrap=�$��0,0,40,0q����� *DatabaseConfigSummary+�� $��FILE STRUCTURE:��$��Center=�$��18(�$
��Bold"����#007ACC$��0,0,10,0q��� $	��250��$��30��$��Center=�$
��Left=�
����������#007ACC$��1q����#333$��16(�$��SemiBold"�$��Center=����� *FileStructures+ �� SelectedItem �� *SelectedFileStructure+ �� Mode$ TwoWay=� ��%/  '��       �� " ��.���  � ��$ 16(���  � ��$ 5q���  � ��
 �   ���  � ��
 �����
 P�  �@J�IsMouseOver$
 True��. ���  � �� �#E3F2FD��  � �� �#007ACCP�  �@��
IsSelected$
 True��. ���  � �� �#007ACC��  � ��
 �   �� $��20,50,20,20q� � RowDefinitions �� $
��Auto ��� $��* �.+��� $��0�����#E3F2FD$ 5��$	 10q�._��  � ColumnDefinitions �� $��3* ��� $��1* ��� $��1* �.+��� $ 
Horizontal=�$��0��.+��� $"��Choose a path to move files:��$��Center=�$��16(�$��SemiBold"����#005A9E$��0,0,10,0q���  �� 
IsReadOnly$
 True��$	��400��$��0,0,10,0q����� *SelectedPath+ �� UpdateSourceTrigger$ PropertyChanged=��� $ 
Horizontal=�$
��Left=�$��1��$	��100��.+��� $��Browse��#��[ ���� *BrowseCommand+�� $ 
Horizontal=�$
��Left=�$��2��$	��220��$	��210��.+��� $��
Save Files������ *MoveFilesCommand+y��� *	IsLoading+ �� 	Converter# [ {���  �� Path$ SelectedPath�# [ ���� " �� �� BasedOn# [ .���  � �� �#007ACC��  � ��
 �����
 P�  � {�$ False��. ���  � �� �#D3D3D3��  � �� �#A9A9A9��  �@�Cursor$ Arrow���  � IsIndeterminate$
 True��$��20��$	��130��$
��0,10q�y��� *	IsLoading+# [  � $��1��$��0,20,0,0q� �� $��* ��� $��* ��� $��* �.+��� $��0��
����������#007ACC$��1q�$ 10��$��10q�._�� $��10q� �� $
��Auto ��� $��* �.+��� $��Invalid Files��$��16(�$
��Bold"����#005A9E$��0,0,0,10q��� $
��Auto=�$��1��.���� ���� *SkippedFiles+ �� AlternationCount �� *SkippedFiles.Count+���� .R��� $ 
Horizontal=�$��5,0,0,5q�.+��� $
��Bold"����#007ACC$��30������ *!(ItemsControl.AlternationIndex)+ �� RelativeSource ��  �� AncestorType ListBoxItem �� StringFormat$ [{0}]���� $��14(�$
��Bold"�$��10,0,0,0q����#333���� �� $��1��
����������#007ACC$��1q�$ 10��$��10q�._�� $��10q� �� $
��Auto ��� $��* �.+��� $��Files Not Added to DB��$��16(�$
��Bold"����#005A9E$��0,0,0,10q��� $
��Auto=�$��1��.���� ���� *NotAddedToDbFiles+ �� *NotAddedToDbFiles.Count+���� .R��� $ 
Horizontal=�$��5,0,0,5q�.+��� $
��Bold"����#007ACC$��30������ *!(ItemsControl.AlternationIndex)+ ��  ListBoxItem$ [{0}]���� $��14(�$
��Bold"�$��10,0,0,0q����#333���� �� $��2��
����������#007ACC$��1q�$ 10��$��10q�._�� $��10q� �� $
��Auto ��� $��* �.+��� $��Files Added to DB��$��16(�$
��Bold"����#005A9E$��0,0,0,10q��� $
��Auto=�$��1��.���� ���� *AddedToDbFiles+ �� *AddedToDbFiles.Count+���� .R��� $ 
Horizontal=�$��5,0,0,5q�.+��� $
��Bold"����#007ACC$��30������ *!(ItemsControl.AlternationIndex)+ ��  ListBoxItem$ [{0}]���� $��14(�$
��Bold"�$��10,0,0,0q����#333���� 