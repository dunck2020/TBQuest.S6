   M S B A M L   `   `   `  ����L  HWpfTBQuestGame.S6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:TBQuestGame.PresentationLayerTBQuestGame.PresentationLayer  5   	   ;    5TBQuestGame.PresentationLayer.PlayerEntryAndSetupView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:TBQuestGame.PresentationLayer     5   	     � Title$  Player Entry��5   	   $	��230��5	   	   $	��200��5
   	   
���-R�� � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         SetupButtonStyle �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6*   .�5      ��  � ��$ 70��6&   �� 5       � ��$ 30��6'   �� 5       � ��$ 5q�6'   �� 5       � ��
 �-R��6+   �� 5       � ��
 �����6+   5      5      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�5      .+�5      �� $��Center=�5      $��Enter username:��5      
�������5      �� 5      -   5         ��Name$ UserName��5      $	��100��5      $��30��5       
�������5!      �� 5"      -   5         ��Name$ 
loadPlayer��5$      #��[  5#      $��	Load Game��5%      5&      �� 5'      -   5        $ 	newPlayer��5)      #��[  5(      $��
New Player��5*      5+      5.      50      51      