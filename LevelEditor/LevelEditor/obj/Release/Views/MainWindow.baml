   M S B A M L   `   `   `  ���� F  BLevelEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LevelEditorLevelEditor  ?$clr-namespace:LevelEditor.ViewModelsLevelEditor.ViewModels      LevelEditor.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:LevelEditor     ;
Viewmodels$clr-namespace:LevelEditor.ViewModels     $	��768��$
��1024��   MainWindowTitle  � Title#  �     	MainImage � Icon# �   � DataContext ��  �� Path$ MainViewModel�  Locator �� Source# [  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$	 New��  -   $
 Open��  -   $
 Save��  -   $
 Help�� � 	Resources  �� MergedDictionaries	 �� Source��  �� $#	 /Data/ResourceDictionary.xaml?�%    .��]� .+�o� $	��Top=�.@�m� $
��File��.@�m� $
��_New��
 m� Command$	
 New�� m� Icon ��   NewImage#���  {�.  m� $��_Open...��$

 Open���� m� $��_Save��$

 Save���� m� -   $��E_xit�� m� InputGestureText$ Alt+F4��m� $
��Edit��.@�m� -   $��Project Settings��m� $��_Help��.@�m� $��_Help��$

 Help�� ��   	HelpImage#���  �   BackgroundColor1#���   � ColumnDefinitions �� $
��Auto ��� $��* � � RowDefinitions �� $
��Auto ��� $��* �.+��� $��3��  BackgroundColor2#���  .+���  � ToolTip ��  �� Orientation$ 
Horizontal=�.+���   TooltipImage#���  �� $4��.Click with LeftMouseButton to select this tile��$��Center=�$��10 0 0 0q�.���� -   $��/Icons/water.png��$��10q���  �� $ 
Horizontal=�.+��� #���  �� $4��.Click with LeftMouseButton to select this tile��$��Center=�$��10 0 0 0q�.���� -   $��/Icons/grass.png��$��10q���  �� $ 
Horizontal=�.+��� #���  �� $4��.Click with LeftMouseButton to select this tile��$��Center=�$��10 0 0 0q�.���� -	   $��/Icons/ground.png��$��10q��� $��1��$��1��$��2��$
��Left=�
�������$��2q�� -
   $��
EditorGrid��$	��600��$	��600��$��1��$��0��$��3��#���  .+��� 
�������$��3q�