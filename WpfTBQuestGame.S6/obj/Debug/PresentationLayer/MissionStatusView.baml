   M S B A M L   `   `   `  ����L  HWpfTBQuestGame.S6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:TBQuestGame.PresentationLayerTBQuestGame.PresentationLayer  5   	   5    /TBQuestGame.PresentationLayer.MissionStatusView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:TBQuestGame.PresentationLayer     5   	   
���-R��$	��600��5	   	   $	��600��5
   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$ SingleBorderWindow=�5   	    � 	Resources 5   
      SetupButtonStyle �� 
TargetType �� Property �� Value��%�   &	        �� 5      " ��6.   .�5      ��  � ��$ 70��6*   �� 5       � ��$ 30��6+   �� 5       � ��$ 5q�6+   �� 5       � ��
 �-R��6/   �� 5       � ��
 �����6/   5      5      .��5      � .+�5   
   �� $��10q�5      ._�5      � $��10q�5       � RowDefinitions 5      �� 5      $��1* �6$   �� 5      $��2* �6$   .+�5      �� $��0��5       $��0q�5!      $��2��5"      ._�5#      � .+�5$      ��  �� Orientation$ Vertical=�5%      .+�5&      �� $ Vertical=�5'   !   $��Center=�5(   !   $��0q�5)   !   .+�5*   "   �� -   5        $��0,10,0,0q�5+   %   $	��150��5,   %   $��Return to Main Screen��5-   %   #��[  5/   %   �� 50   "   $��10q�51   %   $��Current Quest Information��52   %   $��Center=�53   %   
�������$��15(�55   %   �� 57   "   $��1��58   %   $��0,0,0,5q�59   %    �� Padding$ 0q�5:   %   
�������._�5<   &   �� $��60��5=   )   $	��500��5>   )   $��10q�5?   )   
�������$��0q�5A   )   	 �� TextWrapping$
	 Wrap=�5B   )   "
 �� VerticalScrollBarVisibility$

 Auto=�5D   )   $	��top=�5E   )   ��5C   )   �� *MissionInformation+ �� Mode$ OneWay=�5E   )   5F   #   5H      5I      5J      5K      �� 5L      $��0,10,0,0q�5M      $��1��5N      ._�5O      �� .+�5P      &   System.Windows.Controls.DataGrid  -   5          Name$ LocationItemsDataGrid��5Q      $	��300��5R      $��10q�5S         AutoGenerateColumns .     HeadersVisibility$ Column=�5V      ��5T      �� *
Missions+   Columns 5W      0  *System.Windows.Controls.DataGridTextColumn  5X   "   ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��5Y   )      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 5\   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5[   )   �� *Name+$ OneWay=�   ElementStyle 5]   &   �� 5^   *   .�5_   .   ��  � ��$
 Wrap=�6W   5`   +   5b   #     5c   "   $ Status��5d   )    . $	 100 5f   )    5g   )   �� *Status+$ OneWay=�  5h   "   $ Details��5i   )    . $ * 5l   )    5k   )   �� *StatusDetail+$ OneWay=� 5m   &   �� 5n   *   .�5o   .   ��  � ��$
 Wrap=�6W   5p   +   5r   #   5u      5v      5w      5x      5y      5z      5{      