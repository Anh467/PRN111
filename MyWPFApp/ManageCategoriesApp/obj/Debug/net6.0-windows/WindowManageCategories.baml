   M S B A M L   `   `   `  ����N  JManageCategoriesApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ManageCategoriesAppManageCategoriesApp  5   	   0    *ManageCategoriesApp.WindowManageCategories   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ManageCategoriesApp     5   	   ���#88b2db  � Title$  WindowManageCategories��5   	   $	��450��6(   $	��404��65   .��5	      � $	��434��6   $��Bottom=�6   .+�5
   
   �� $	��187��6   $	��Top=�6"   ���#88b2db.+�5      �� 
���  ��$��30(�6%   $
��Bold"�63   .��6F   Category Information6\   �� 5      .��6   Category ID6!   �� 5      -   5        $��txtCategoryID��5   =   $	��280��6   $
��Left=�6"   ��5      ��  �� Path$ 
CategoryID� �� Mode$ OneWay=� � DataContext 5      ��  �� ElementName$ 
dgCateList��$ SelectedItem�6Z   �� 5      .��6   Category Name6#   �� 5      -   5        $��txtCategoryName��5   =   $	��280��6   $
��Left=�6"   ��5      �� $ CategoryName�$ OneWay=� 5      �� $ 
dgCateList��$ SelectedItem�5      �� 5       �� Orientation$ 
Horizontal=�6   $
��Left=�63   .+�5      �� -   5         ��Name$ 	btnInsert��5      $��10q�6,   $��80��68   $��Insert��6C   5      �� 5      -   5        $ 	btnUpdate��5      $��10q�6-   $��80��69   $��Update��6E   5      �� 5      -   5        $ 	btnDelete��5      $��10q�6,   $��80��69   $��Delete��6D   5      5      5      � 5   
   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��
dgCateList��5         AutoGenerateColumns$ False��6)   $��	0,185,0,0q�6E      Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6)   
   Header$
 Category ID��63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *
CategoryID+  5"      $	 * 6)   $
 Category Name��63    6J   �� *CategoryName+5$      5%      5&      5'      