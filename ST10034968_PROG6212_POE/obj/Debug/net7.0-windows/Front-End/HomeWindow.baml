   M S B A M L   `   `   `  ����R  NST10034968_PROG6212_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ST10034968_PROG6212_POE.Front_End!ST10034968_PROG6212_POE.Front_End  5   	   2    ,ST10034968_PROG6212_POE.Front_End.HomeWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:ST10034968_PROG6212_POE.Front_End     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$! Lerato's Studying Organiser��5   	   $	��633��6-   $	��900��6:   .��5	      � ���#2E282A$��0,0,0,0q�6    .+�5
   
   �� $
��Left=�6   $��81��6/   $��177,144,0,0q�6;   
���   �$	��Top=�6_   $	��539��6w    �� RadiusX$ 15��6�    �� RadiusY$ 15��6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF84A9C0��6#   � 5      $ 	#FFB3CBB9��6#    � Offset$ 1Q�65   5      5      A� 5   
   $��Center=�6   $	��246��6/   
���   �$	��Top=�6K   $	��446��6c   $��
0,-129,0,0q�6o   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67    �� RelativeTransform 5      V� 5      .~�5      �� 	 �� CenterY$		 0.5Q�6-   
 �� CenterX$	
 0.5Q�6;   �� 5       �� CenterX$	 0.5Q�6,    �� CenterY$	 0.5Q�6:   �� 5       �� Angle$ 90Q�6.    �� CenterX$	 0.5Q�69    �� CenterY$	 0.5Q�6G   T� 5      5      .��5      � $ 	#FFD7999E��6#   � 5      $ 	#FFB3CBB9��6#   $ 1Q�65   � 5      $ 	#FF7D55A6��6#   $
 0.33Q�65   � 5       $ 	#FF84A9C0��6#   $
 0.66Q�65   5!      5#      �� 5$   
   -   5         ��Name$ lblTitle��5$      $#��(Username)'s Current Semester��6"    	  title#��[  6J   $��Center=�6k   $��0,24,0,0q�6�   $	��Top=�6�   ���	#FF282224$��22(�6�   �� 5%   
   -   5        $ lblDuration��5%      $��Click the Edit button ��6%     
defaultLbl#��[ 6F   $
��Left=�6l   $��209,153,0,0q�6�   $	��Top=�6�   ���	#FF2E282A$��Medium"�6�   �� 5&   
   -   5        $ lblStartDate��5&      $0��*to enter your current semester information��6&   #��[ 6[   $
��Left=�6�   $��209,179,0,0q�6�   $	��Top=�6�   ���	#FF2E282A$��Medium"�6�   �� 5'   
   -   5        $ lblModulesTitle��5'      $��Modules��6)   #��[  6;   $
��Left=�6\   $��
84,227,0,0q�6w   $	��Top=�6�   $��28(�6�   �� 5(   
   -   5         ��Name$ 	lvModules��5(      $��84,272,84,179q�6Q   
����������	#FF2E282A$��1.5,1.5,1.5,1.5q�6�   $��14(�6�   ��5)      �� 5*      $ 0.5,1&�6&   $ 0.5,0&�67    5+      V� 5,      .~�5-      �� $		 0.5Q�6-   $	
 0.5Q�6;   �� 5.      $	 0.5Q�6,   $	 0.5Q�6:   �� 5/      $ 90Q�6.   $	 0.5Q�69   $	 0.5Q�6G   T� 50      51      .��53      � $ 	#FFD7999E��6#   � 54      $ 	#FFB3CBB9��6#   $ 1Q�65   � 55      $ 	#FF7D55A6��6#   $
 0.33Q�65   � 56      $ 	#FF84A9C0��6#   $
 0.66Q�65   57       �� View 59      �� 5:      .P�5;      �� $��Module Code��6%    �� Width$
 auto��6:    �� DisplayMemberBinding 6G   �� *Code+�� 5<      $��Module Name��6%   $
 auto��6:    6G   �� *Name+�� 5=      $��Number of Credits��6%   $
 auto��6@    6M   �� *NumOfCredits+�� 5>      $��Class Hours per Week��6%   $
 auto��6C    6P   �� *ClassHoursPerWeek+�� 5?      $ ��Total Study Hours Per Week��6%   $
 auto��6I    6V   �� *TotalStudyHrsPerWeek+�� 5@      $%��Remaining study hours this week��6%   $
 auto��6N    6[   �� *selfStudyPerWeek+5A      5C      �� 5D   
   -   5         ��Name$ btnAdd��5D      $��+��6!     
defaultBtn#��[ 6-   $��Center=�6R   $��	0,443,0,0q�6o   $	��Top=�6�   $
��Bold"�6�   $��30(�6�   $��
20,-6,20,3q�6�   $��39��6�   ���	#FFD7999E$��2,2,2,2q�6�    J� RenderTransformOrigin$ 0.531,0.501&�6  $��Center=�61  ���	#FF3831336j  �� 5E   
   -   5        $ btnEdit��5E      $
��Edit��6"   #��[ 61   $
��Left=�6V   $��627,170,0,0q�6q   $	��Top=�6�   $��	10,2,10,2q�6�    � UseLayoutRounding$
 True��6�   ���	#FF383133���	#FF3831336�   �� 5F   
   -   5        $ btnAddStudyTime��5F      $��Add Study Time��6*     mostProminentBtn#��[ 6C   $��Center=�6n   $��	0,529,0,0q�6�   $	��Top=�6�   $��24(�6�   6�   �� 5G   
   -	   5        $ btnExit��5G      $
��Exit��6"   #��[ 61   $
��Left=�6U   $��768,538,0,0q�6p   $	��Top=�6�   $��	10,2,10,2q�6�   6�   �� 5H   
   -
   5        $ 
btnRefresh��5H      $��Refresh��6%   #��[ 67   ���	#FF383133$��2,2,2,2q�6r   $
��Left=�6�   $��740,443,0,0q�6�   $	��Top=�6�   $��	10,2,10,5q�6�   ���	#FF7D55A66   5K      5L      