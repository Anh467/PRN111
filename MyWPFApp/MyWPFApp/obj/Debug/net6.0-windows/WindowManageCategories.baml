   M S B A M L   `   `   `  ����C  ?MyWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ManageCategoriesAppManageCategoriesApp  5   	   0    *ManageCategoriesApp.WindowManageCategories   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ManageCategoriesApp     5   	   -   5        ���#88b2db  � Title$  WindowManageCategories��5   	   $	��450��6(   $	��404��65    � WindowStartupLocation$ CenterScreen=�5	        � 
ResizeMode$ NoResize=�6E   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� 
����ح� �� Orientation$ Vertical=�6-   $
��Left=�5      $	��400��64   .+�5      �� -   5        $��lblInstruction��5      
���  ��$��DemiBold"�6;   $��20(�5      $��Category Information��6"   �� 5      -   5        $��lblCategoryID��5      $��
CategoryID��6)   �� 5      -   5        $��txtCategoryID��5      $
��Left=�6+    �� 
IsReadOnly$
 True��5      $��25��6   $	��300��6+   ��5      ��  �� Path$ 
CategoryID� �� Mode$ OneWay=� � DataContext 5      �� 	 �� ElementName$	 lvCategories��$ SelectedItem��� 5      -   5        $��lbCategoryName��5      $��Category Name��6*   �� 5      -   5        $��txtCategoryName��5      $
��Left=�6-   $��25��5      $	��300��6"   ��5      �� $ CategoryName�$ OneWay=� 5       �� $	 lvCategories��$ SelectedItem��� 5"      $ 
Horizontal=�6   $
��Left=�63   .+�5#      �� -   5        
 ��Name$
 	btnInsert��5#      $��10q�6,   $��80��68   $��Insert��6C   6T   �� 5%      -   5        $
 	btnUpdate��5%      $��10q�6-   $��80��69   $��Update��6E   6V   �� 5'      -	   5        $
 	btnDelete��5'      $��10q�6,   $��80��69   $��Delete��6D   6U   5)      5*      �� 5+   
   -
   5        $��lvCategories��5+       $��1��6   $	��400��64    �� View 5,      �� 5-      .P�5.      �� $��Category ID��6%    �� Width$	 100��6;    �� DisplayMemberBinding 5/   %   �� $ 
CategoryID��� 50      $��Category Name��6%   $	 200��6<    51   %   �� $ CategoryName�52      54      55      57      