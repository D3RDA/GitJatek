   M S B A M L   `   `   `  ����K  GCharacterManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CharacterManagerCharacterManager  5   	   !    CharacterManager.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CharacterManager     5   	     � Title$  Character Manager��5   	   $	��600��6#   $	��900��60   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ CharactersDataGrid��5      $��0��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5         SelectionMode$ Single=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *Id+6H     5      $
 Name��6%   $ * 6L   	 63   �� *Name+6L     5      $ Class��6%   $ 2* 6N   	 64   �� *Class+6N     5      $	 Dmg��6%   $	 100 6J   	 62   �� *Dmg+6J     5      $ Hp��6%   $	 100 6H   	 61   �� *Hp+6H     5      $ 
Created At��6%   $	 150 6m   	 69   �� *	CreatedAt+
 �� StringFormat$
 {0:g}��6m   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�5      $��Center=�5       $��0,10,0,0q�5!      .+�5#      �� -   5        $��Refresh��5#      $	��5,0q�5%      $
��10,5q�5&      �� 5(      -   5        $	��Add��5(      $	��5,0q�5*      $
��10,5q�5+      �� 5-      -   5        $
��Edit��5-      $	��5,0q�5/      $
��10,5q�50      �� 52      -   5        $��Delete��52      $	��5,0q�54      $
��10,5q�55      58      5:      5;      