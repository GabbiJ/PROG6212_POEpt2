   M S B A M L   `   `   `  ����R  NST10034968_PROG6212_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ST10034968_PROG6212_POE.Front_End!ST10034968_PROG6212_POE.Front_End  5   	   8    2ST10034968_PROG6212_POE.Front_End.AddStudyTimeForm   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:ST10034968_PROG6212_POE.Front_End     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ Add Study Time��5   	   $	��407��6    $	��800��6-   .��5	      � ���#2E282A$��0,0,0,0q�6    .+�5
   
   �� -   5         ��Name$ btnAdd��5
      $	��Add��6!   $��Center=�6/      mostProminentBtn#��[  6L   $��	0,280,0,0q�6v   $	��Top=�6�   6�   �� 5   
   -   5         ��Name$ lblTitle��5      $��Add Study Time��6"   $��Center=�6;    	 title#��[ 6X   $��0,51,0,0q�6w   $	��Top=�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ White��6#   � 5      $ 	#FF84A9C0��6#    � Offset$ 1Q�65   5      5      A� 5   
   $
��Left=�6   $	��225��6-   $��-51,-49,0,0q�6:   $	��Top=�6O   $	��225��6g   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67    �� RelativeTransform 5      V� 5      .~�5      �� 	 �� CenterY$		 0.5Q�6-   
 �� CenterX$	
 0.5Q�6;   �� 5       �� CenterX$	 0.5Q�6,    �� CenterY$	 0.5Q�6:   �� 5       �� Angle$	 135Q�6.    �� CenterX$	 0.5Q�6:    �� CenterY$	 0.5Q�6H   T� 5      5      .��5      � $ 	#FF84A9C0��6#   � 5      $ 	#FFB3CBB9��6#   $ 1Q�65   5       5"      �� 5#   
   -   5        $ label��5#      $��+��6   $
��Left=�6+   $��
51,-38,0,0q�6F   $	��Top=�6Z   ���	#FF2E282A$	��150(�6�   $��Comic Sans MS)�6�   $	��188��6�   $��98��6�   �� 5$   
   -   5        $ label1��5$      $��Date completed:��6    $
��Left=�6:     
defaultLbl#��[ 6U   $��233,154,0,0q�6y   $	��Top=�6�   �� 5%   
   -   5        $ label2��5%      $��Hours studied:��6    $
��Left=�69   #��[ 6T   $��247,194,0,0q�6x   $	��Top=�6�   �� 5&   
   -   5        $ label3��5&      $��Module:��6    $
��Left=�62   #��[ 6M   $��291,234,0,0q�6q   $	��Top=�6�   �� 5'   
   -   5         ��Name$ txbHours��5'      $
��Left=�6$   $��400,194,0,0q�6?     
defaultTxb#��[ 6T    �� TextWrapping$
 Wrap=�6x   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5(   
   -   5        $ lblError��5(        errorLbl#��[ 6"   $��Center=�6D   $��	0,332,0,0q�6a   $	��Top=�6t   (  "System.Windows.Controls.DatePicker  5)   
   -	   5          Name$ dpDateCompleted��5)      $
��Left=�6.   $��400,152,0,0q�6I   $	��Top=�6^   $	��120��6v   �� 5*   
   -
   5         ��Name$ 
cmbModules��5*      $
��Left=�6'   $��400,240,0,0q�6B   $	��Top=�6W   $	��120��6o   ���	#FF2E282A���	#FF2E282A6�   5,      5-      