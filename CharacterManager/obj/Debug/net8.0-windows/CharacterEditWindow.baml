   M S B A M L   `   `   `  ����K  GCharacterManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CharacterManagerCharacterManager  5   	   *    $CharacterManager.CharacterEditWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CharacterManager     5   	     � Title$  Edit Character��5   	   $	��450��6    $	��400��6-   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $	��ID:��6   $��0��6   $��0��6,   $��0,0,10,5q�6<   $��Center=�6N   �� 5   
   -   5         ��Name$ 	IdTextBox��5      $��0��5      $��1��5      $��0,0,0,5q�5       �� 
IsReadOnly$
 True��5      �� 5!   
   $��Name:��6   $��1��6!   $��0��6.   $��0,0,10,5q�6>   $��Center=�6P   �� 5"   
   -   5        $ NameTextBox��5"      $��1��5#      $��1��5$      $��0,0,0,5q�5%      �� 5'   
   $��Class:��6   $��2��6"   $��0��6/   $��0,0,10,5q�6?   $	��Top=�6Q   �� 5(   
   -   5         ��Name$ ClassComboBox��5(      $��2��5)      $��1��5*      $��0,0,0,5q�5+      ��5,      �� *AvailableClasses+ �� SelectedItem 5-      �� *Character.Class+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 50   
   $
��Dmg:��6   $��3��6    $��0��6-   $��0,0,10,5q�6=   $��Center=�6O   �� 51   
   -   5        $ 
DmgTextBox��51      $��3��52      $��1��53      $��0,0,0,5q�54      �� 56   
   $	��Hp:��6   $��4��6   $��0��6,   $��0,0,10,5q�6<   $��Center=�6N   �� 57   
   -   5        $ 	HpTextBox��57      $��4��58      $��1��59      $��0,0,0,5q�5:      �� 5<   
   $��Created At:��6   $��5��6'   $��0��64   $��0,0,10,5q�6D   $��Center=�6V   �� 5=   
   -   5        $ CreatedAtTextBox��5=      $��5��5>      $��1��5?      $��0,0,0,5q�5@      $
 True��5A      �� 5C   
   $��7��6   $��0��6"   $��2��62   	 �� Orientation$	 
Horizontal=�6F   $��Right=�6_   .+�5D      �� -   5        $
��Save��5D      $	��5,0q�5F      $
��10,5q�5G      �� 5H      -   5        $��Cancel��5H      $	��5,0q�5J      $
��10,5q�5K      5L      5N      5O      