   M S B A M L   `   `   `  ����F  BArion.Style, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulldAclr-namespace:Arion.Style.AttachedProperties;assembly=Arion.StyleArion.Style.AttachedProperties  5       HouseOfCulture4   .HouseOfCulture.Views.Tables.GroupsTableControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      QwpfAclr-namespace:Arion.Style.AttachedProperties;assembly=Arion.Style     5      -   5        .��5      �   � RowDefinitions  5   
   �� 5      $��60 �6   �� 5      $��* �6   �� 5      $��60 �6   .+�5   
   � $��0��6   $
��10,0q�6   .+�5      �� -   5        $��TbSearch��5      $	��250��5      $
��Left=�5      )   #Arion.Style.AttachedProperties.Hint   Placeholder$ Поиск...��5      ,   &Arion.Style.AttachedProperties.TextBox   	RightIcon$ Search=�5      5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��DgData��5      $��1��5      $
��10,5q�5         AutoGenerateColumns .     
IsReadOnly .    	RowHeight$ 40Q�5!         Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5$         FontSize$ 14Q�5&      	   Header$	 Название��5'      1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5%      �� *Name+5'        5(      $ * 5)      $ 14Q�5+      $	 Руководители��5,      
 5*      �� *
Leadership+5,        5-      $ * 5.      $ 14Q�50      $-	 'Количество студентов��51      
 5/      �� *CountStudents+51      4  .System.Windows.Controls.DataGridTemplateColumn  52      -   5        
ColumnEdit��   CanUserSort .     CellTemplate 53      �� 54      .R�55      �� -   5        +	   %Arion.Style.AttachedProperties.Button 	  Icon$
 Edit=�56   !      BtnText#��[  58   !   59      5;        5<      -   5        ColumnRequest�� 5=      �� 5>      .R�5?      �� -   5        $��Записаться��5A   !   #��[  5B   !   5C      5E      5G      � 5H   
   $��2��6   $	��5,0q�6    � ColumnDefinitions 5I      �� 5J      $
��Auto �6#   �� 5K      $
��Auto �6#   �� 5L      $��* �6#   �� 5M      $��* �6#   �� 5N      $
��Auto �6#   �� 5O      $
��Auto �6#   .+�5R      �� -   5        $��	BtnDelete��5S      $��4��5T      $	��5,0q�5U      $��Удалить��5W      �� 5X      -	   5        $��BtnAdd��5Y      $��5��5Z      $	��5,0q�5[      $��Добавить��5]        	BtnFilled#��[ 5^      5_      5`      5a      