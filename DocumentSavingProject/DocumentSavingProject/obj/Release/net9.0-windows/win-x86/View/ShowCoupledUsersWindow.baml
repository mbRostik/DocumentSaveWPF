   M S B A M L   `   `   `  ���� P  LDocumentSavingProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:DocumentSavingProject.ViewDocumentSavingProject.View  S.clr-namespace:DocumentSavingProject.Converters DocumentSavingProject.Converters  7    1DocumentSavingProject.View.ShowCoupledUsersWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:DocumentSavingProject.View     E
converters.clr-namespace:DocumentSavingProject.Converters       � Title$  Show Coupled Users��$	��600��$	��800�� � Icon$2 ,pack://application:,,,/Images/WindowIcon.ico�� � WindowStartupLocation$ CenterScreen=����#FFFFFF � 	Resources J   DDocumentSavingProject.Converters.FileUserSelectedVisibilityConverter '  #FileUserSelectedVisibilityConverter   BooleanToVisibilityConverterE   ?DocumentSavingProject.Converters.FileUserSelectedMultiConverter " FileUserSelectedMultiConverter��%-   &	        &	      &	 
       ��   .��� $��20q� � RowDefinitions �� $
��Auto ��� $��* �.+��� $��0�����#28A745 �� CornerRadius$ 5�� �� Padding$ 10q�$��0,0,0,10q�._��� $>��8These files have few possible users. Choose one for each��$��18(�$
��Bold"�
�������$��Center=�$��Center=� �� TextAlignment$ Center=�$
��Wrap=�� $��1�� � ColumnDefinitions �� $��2* ��� $��3* ��� $
��0.5* �.+��� $��0��$��Files��$��14(�$
��Bold"����#007ACC$��Center=�$��0,0,0,2q��� $��0�����#007ACC$��1q�$ 2��$��10,30,10,10q�._��� $��10q����� *FewUsersCollectionKeys+	 �� SelectedItem	 �� *SelectedFile+
 �� Mode$
 TwoWay=����� .R���  �� Orientation$ 
Horizontal=�$��5,0,0,5q�.+��� $
��Bold"����#007ACC$��30������ *!(ItemsControl.AlternationIndex)+ �� RelativeSource ��  �� AncestorType ListBoxItem �� StringFormat$ [{0}]���� $��14(�$
��Bold"�$��10,0,0,0q����#333���� *
FileName+�� $	��✔��$��14(�$
��Bold"�
��� � �$��10,0,0,0q�y��� *IsUserSelected+ �� 	Converter# [  �� AlternationCount$
 1000���� $��1��$��Users��$��14(�$
��Bold"����#007ACC$��Center=�$��0,0,0,2q��� $��1�����#007ACC$��1q�$ 2��$��10,30,10,10q�._��� $��10q����� *SelectedFileUsers+	 �� *SelectedFileUser+$
 TwoWay=�����  �� 
TargetType" ��.���  �� Property � �� �� Value
 �������  � ��$ 14(���  � ��$ 5q���  � ��$ 10q���  � �� ��  �� 
TargetType" ��.R��� #��z��$ 2��._��� $
��Left=�$��Center=� �� Triggers P�  P� Property �@��
IsSelected P� Value$
 True��. ���  � ��
 ������  � ��
 �   �]�  ]� 
Conditions ��  �� Property �@J�IsMouseOver �� Value$
 True����  �@��
IsSelected$ False��./���  � �� �#E0E0E0���� .R��� $ 
Horizontal=�$��Center=�.+��� $ Vertical=�$��Stretch=�.+��� $��10,0,0,0q����� *	SurName+$ {0} {1}��
��� $
��Bold"���� *	SurName+ �� $� �� �� $
��Bold"���� *Name+�� $��10,0,0,0q����� *	CODFISC+�� $��10,0,0,0q����� *PROGRESSIVO+�� $��20��$��20��$��10,0,0,0q� � Cursor$
 Hand��$��Center=�$��Right=����� *DataContext.RemoveUserCommand+ �� 
 Window���� ���� " ��.���  � y�$ 	Collapsed=���  � �� �� " ��.R�� .+��� $��5��$��22��
���  �� J� RenderTransformOrigin$ 0.1,0.5&�z���  �� Angle$ 45Q��� $��5��$��22��
���  ��$ 0.9,0.5&�z��� $	 -45Q� ��  �� Binding ��  ��  ListBoxItem �� Path$ 
IsSelected�  �� Value  True.a���  � y�$ Visible=�P�  �@J�IsMouseOver$
 True��. ���  �@J�Opacity$	 0.5Q�P�  � ��$
 True��. ���  �@J�Opacity$	 0.5Q��� $��2��$��0q�$ 2��._��� $
��Save��$��50�����#28A745
�������$	��200��$��16(�$
 Hand��$
��Bold"�$��Center=�$��Center=����� *ConfirmUserListCommand+���� " ��.���  � �� �� " ��.R�� .+��� ! ��Name$! ButtonBorder��#��z��$ 1��
���   �$��0q�._��� $��Center=�$��Center=�$
��Bold"�" �� Triggers" P�  �@J�IsMouseOver$
 True��# N� EnterActions# �� .���� .���� $ �� 
TargetName$$ ButtonBorder��% �� TargetProperty$1% +(Border.Background).(SolidColorBrush.Color)�	& �� To& #1E7D34' g� Duration$' 0:0:0.3D�( N� ExitActions( �� .���� .���� $$ ButtonBorder��$1% +(Border.Background).(SolidColorBrush.Color)�& #28A745$' 0:0:0.3D�