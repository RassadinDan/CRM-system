   M S B A M L   `   `   `  ����R  NSkillProfiDesctopClient, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:SkillProfiDesctopClient.PagesSkillProfiDesctopClient.Pages  5      -    'SkillProfiDesctopClient.Pages.BlogsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:SkillProfiDesctopClient.Pages     5        N� Title$  	BlogsPage��5	       � 	Resources 5
         defaultImage �� 	UriSource��%C   &	        �� 5   
   $! ../Images/default_image.jpg?�5   
   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��10* �6   �� 5      $
��151* �6   �� 5      $
��110* �6   �� 5      $
��119* �6   �� 5      $	��10* �6    � RowDefinitions 5   
   �� 5      $	��20* �6   �� 5      $	��31* �6   �� 5      $
��324* �6   �� 5      $	��39* �6   �� 5      $	��20* �6   .+�5   
   �� $��1��6   $��1��5      $��Center=�5       $��24(�5!      $��Блог��5"      �� 5$   
   -   5         ��Name$ BlogsListBox��5$      $��1��5%   
   $��2��5&   
   $��3��5'   
   $��10q�5(   
   $��Disabled=�5)   
   ��5+      �� 5,      .R�5-      � $��Center=�6     � 	ItemWidth$	 400��5.      5/      ��51      �� 52       �� 
TargetType" ��6   .�53      ��  �� Property � ��	 �� Value$	 Stretch=�54      55      ��57      �� 58      .R�59      �� $��1q�6   
���   �._�5<      � $��10q�6   $��Stretch=�5=       5>      �� 5?   "   $	��100 �60   �� 5@   "   $��* �60   .+�5C      �� $��0��6$   $	��100��5D   !   ��5E   !   �� *	ImageData+
 �� TargetNullValue#
 [  �� 5G      $��1��6)   $��5q�5H   !   .+�5I   "   �� ��6,   �� *	Preview+5J      5K      5L      5M      5O      5P      5Q      