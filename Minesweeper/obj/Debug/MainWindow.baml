   M S B A M L   `   `   `  ����F  BMinesweeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Minesweeper.ViewModelMinesweeper.ViewModel  5   	   )clr-namespace:MinesweeperMinesweeper  5   	   3clr-namespace:Minesweeper.ViewMinesweeper.View  5   	       Minesweeper.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9	viewModel#clr-namespace:Minesweeper.ViewModel     5   	   +localclr-namespace:Minesweeper     5   	   /viewclr-namespace:Minesweeper.View     5   	     � Title$  
MainWindow��5
   	   $	��800��6   $	��800��6)    � DataContext 5      ,   &Minesweeper.ViewModel.ViewModelLocator  5   
    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $Z TC:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Resource.xaml?�6%   %    5      .��5      �  6   �� *	Main.Game+ � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      �� 5       .+�5"   
   >� -   5         >�Name$ SettingsControl��5)       K� ZIndex$ 1��5"      $��1��5#      $	��300��5&      $
��Left=�5'      $	��Top=�5(       5$      �� *viewModel.Settings+y�5%      �� *	Visible+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�.��5+      "   Minesweeper.View.SettingView  5-      � 5/   
   $��0��6   $��2��6     50      �� 51      $
��0.3* �6#   �� 52      �� 53      $
��0.3* �6#   .+�55      �� $��Center=�56      $��Center=�57      $��Center=�58      $��Center=�59      
���   �
���  ��$��25(�5<      $	��100��5=      $	��100��5>      {�. ��55      �� *BombCounter+$	 OneWay=�$
 PropertyChanged=�5?      �� 5A      $��1��6    �� Orientation$ 
Horizontal=�5B      $��Center=�5C      .+�5D      �� $	��100��6   $	��100��5E      $��Center=�5F      $��Center=�5G      ��5H      �� *ShowSettings+��5J      �� 5K      $[��UC:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\gear.png��6    5M      �� 5O      $	��100��6   $	��100��5P      $��Center=�5Q      ��5R      �� *viewModel.NewGame+$	 OneWay=�$
 PropertyChanged=���5S      �� 5T      $^��XC:\Users\zavia\Desktop\MoneySaver\Wpf\Minesweeper\Minesweeper\Resource\Image\restart.png��6   5V      5W      �� 5X      $��2��6   $��Center=�5Z      $��Center=�5[      $��Center=�5\      $��Center=�5]      
���   �
���  ��$��25(�5`      $	��100��5a      $	��100��5b      {�. ��5Y      �� *time+$	 OneWay=�$
 PropertyChanged=�5c      5f      �� 5g   
   $��1��6   $��0��6%   $��2��65   ��6I   �� *cells+$	 OneWay=�$
 PropertyChanged=���5h      �� 5i      .R�5j      A�  A� Rows 6"   �� *GlobalCount+$	 OneWay=�$
 PropertyChanged=� A� Columns 5k   "   �� *GlobalCount+$	 OneWay=�$
 PropertyChanged=�5l      5m      ��5o      �� 5p      .R�5q      �� {�6   �� *
IsEnable+$	 OneWay=�$
 PropertyChanged=���5r      �� 5s      ��6$   �� *
imageUri+$	 OneWay=�$
 PropertyChanged=� J� InputBindings 5u      d� 5v       d� Gesture$ 	LeftClicka�6+    �� Command 6?   �� *	LeftClick+$	 OneWay=�$
 PropertyChanged=�d� 5w      $ 
RightClicka�6+    6@   �� *
RightClick+$	 OneWay=�$
 PropertyChanged=�5z      5{      5}      5�      5�      