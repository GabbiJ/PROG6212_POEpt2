   M S B A M L   `   `   `  ����R  NST10034968_PROG6212_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ST10034968_PROG6212_POE.Front_End!ST10034968_PROG6212_POE.Front_End  5   	   5    /ST10034968_PROG6212_POE.Front_End.AddModuleForm   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:ST10034968_PROG6212_POE.Front_End     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ 
Add Module��5   	   $	��400��6   $	��800��6)   .��5	      � ���#2E282A$	��390��6    $	��Top=�6-   $��0,0,0,0q�6E   .+�5
   
   �� -   5         ��Name$ lblTitle��5
      $��Add a Module��6"   $��Center=�69    	  title#��[  6V   $��0,45,0,0q�6u   $	��Top=�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ White��6#    � Offset$ 0.237Q�61   � 5      $ 	#FF9B7DBB��6#   $ 1Q�65   5      5      A� 5   
   $
��Left=�6   $	��225��6-   $��-51,-49,0,0q�6:   $	��Top=�6O   $	��225��6g   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67    �� RelativeTransform 5      V� 5      .~�5      ��  �� CenterY$	 0.5Q�6-   	 �� CenterX$		 0.5Q�6;   �� 5      
 �� CenterX$	
 0.5Q�6,    �� CenterY$	 0.5Q�6:   �� 5       �� Angle$	 135Q�6.    �� CenterX$	 0.5Q�6:    �� CenterY$	 0.5Q�6H   T� 5      5      .��5      � $ 	#FF84A9C0��6#   $ 1Q�65   � 5      $ 	#FF7D55A6��6#   $ 0Q�65   5      5!      �� 5"   
   -   5        $ label��5"      $��+��6   $
��Left=�6+   $��
51,-38,0,0q�6F   $	��Top=�6Z   ���	#FF2E282A$	��150(�6�   $��Comic Sans MS)�6�   $	��188��6�   $��98��6�   �� 5#   
   -   5        $ label1��5#      $��Module Name:��6    $
��Left=�67     
defaultLbl#��[ 6R   $��263,125,0,0q�6v   $	��Top=�6�   �� 5$   
   -   5        $ label2��5$      $��Module Code:��6    $
��Left=�67   #��[ 6R   $��268,161,0,0q�6v   $	��Top=�6�   �� 5%   
   -   5        $ label3��5%      $��Number of Credits:��6    $
��Left=�6=   #��[ 6X   $��233,197,0,0q�6|   $	��Top=�6�   �� 5&   
   -   5        $ label4��5&      $��Class Hours Per Week:��6    $
��Left=�6@   #��[ 6[   $��212,228,0,0q�6   $	��Top=�6�   �� 5'   
   -   5         ��Name$ 
txbModName��5'      $
��Left=�6&   $��434,127,0,0q�6A     
defaultTxb#��[ 6V    �� TextWrapping$
 Wrap=�6z   $	��Top=�6�   $	��170��6�   �� 5(   
   -   5        $ 
txbModCode��5(      $
��Left=�6&   $��434,164,0,0q�6A   #��[ 6V   $
 Wrap=�6z   $	��Top=�6�   $��85��6�   �� 5)   
   -	   5        $ txbNumOfCredits��5)      $
��Left=�6+   $��434,200,0,0q�6F   #��[ 6[   $
 Wrap=�6   $	��Top=�6�   $��85��6�   �� 5*   
   -
   5        $ txbClassHoursPerWeek��5*      $
��Left=�60   $��434,231,0,0q�6K   #��[ 6`   $
 Wrap=�6�   $	��Top=�6�   $��85��6�   �� 5+   
   -   5         ��Name$ btnAdd��5+      $	��Add��6!   $��Center=�6/     mostProminentBtn#��[ 6L   $��	0,284,0,0q�6v   $	��Top=�6�   6�   �� 5,   
   -   5        $ lblError��5,        errorLbl#��[ 6"   $��Center=�6D   $��	0,337,0,0q�6a   $	��Top=�6t   5-      5.      