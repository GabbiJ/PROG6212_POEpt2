   M S B A M L   `   `   `  ����R  NST10034968_PROG6212_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ST10034968_PROG6212_POE.Front_End!ST10034968_PROG6212_POE.Front_End  5   	   8    2ST10034968_PROG6212_POE.Front_End.SemesterInfoForm   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:ST10034968_PROG6212_POE.Front_End     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$( "Enter Current Semester Information��5   	   $	��369��64   $	��737��6A   .��5	      � ���#2E282A$��0,0,0,0q�6    .+�5
   
   �� -   5         ��Name$ label��5
      $(��"Enter Current Semester Information��6    	  title#��[  6L   $��Center=�6n   $��0,10,0,0q�6�   $	��Top=�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFAAD0B3��6#    � Offset$ 1Q�65   � 5      $ White��6#   $ 0Q�61   5      5      �� 5   
   -   5        $ label1��5      $!��This semester's start date:��6      
defaultLbl#��[ 6F   $
��Left=�6j   $��143,127,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $ label2��5      $$��Number of weeks this semester:��6    #��[ 6I   $
��Left=�6m   $��
99,186,0,0q�6�   $	��Top=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpStartDate��5      $
��Left=�6*   $��400,134,0,0q�6E   $	��Top=�6Z   ���	#FF2E282A��6�   Z� �� 5   
   -   5         ��Name$ txbWeeks��5      $
��Left=�6$     
defaultTxb#��[ 6?   $��400,193,0,0q�6c   	 �� TextWrapping$
	 Wrap=�6x   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        
 ��Name$
 btnEnter��5        mostProminentBtn#��[ 6#   $��Enter��6M   $��Center=�6]   $��	0,236,0,0q�6z   $	��Top=�6�   6�   �� 5   
   -   5        $ lblError��5      $��Center=�6"   $��	0,284,0,0q�6?   $	��Top=�6R   ���	#FFF56B6B$	��554��6�   $��Center=�6�   5      5      