   M S B A M L   `   `   `  ����R  NSkillProfiDesctopClient, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SkillProfiDesctopClientSkillProfiDesctopClient  5   	   1    +SkillProfiDesctopClient.CreateServiceWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:SkillProfiDesctopClient     5   	     � Title$  CreateServiceWindow��5   	   $	��450��6%   $	��800��62   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��11* �6   �� 5      $
��233* �6   �� 5      $
��307* �6   �� 5      $
��235* �6   �� 5      $	��14* �6    � RowDefinitions 5   
   �� 5      $��9* �6   �� 5      $	��59* �6   �� 5      $	��49* �6   �� 5      $	��49* �6   �� 5      $
��202* �6   �� 5      $	��50* �6   �� 5      $	��16* �6   .+�5   
   �� $��1��6   $��1��5      $��Новый контакт��5      $��24(�5      $��Center=�5      $��Center=�5       $��2��6/   $��31��6C   $	��166��6O   �� 5"   
   $��1��6   $��2��5#      $��16(�5$      $��Название:��5%      $��	149,0,0,0q�5&      $��Center=�5'      $
��Left=�5(      $��21��6/   $��74��6;   �� 5*   
   -   5         ��Name$ NameBox��5*      $��2��5+      $��2��5,      $��10,10,10,10q�5-      $��18(�5.      �� 50   
   $��1��6   $��3��51      $��16(�52      $$��Описание услуги:��53      $��Center=�54      $��Right=�55      $��10q�56      �� 58   
   -   5        $ DescriptionBox��58      $��2��59      $��3��5:      $��2��5;      $��2��5<      $��10q�5=      $��16(�5>       �� TextWrapping$
 Wrap=�5?      �� 5A   
   -   5         ��Name$ 	CreateBut��5A      $��3��5B      $��5��5C      $��10,10,10,10q�5D      $��18(�5E      $��Создать��5F      5G      5H      5I      