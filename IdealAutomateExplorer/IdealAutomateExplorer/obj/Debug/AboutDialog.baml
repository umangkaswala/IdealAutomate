   M S B A M L   `   `   `  ����  IdealAutomateExplorer'    !Hardcodet.Wpf.Samples.AboutDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  About��5   	   $	��391��5   	   $	��487��5   	    � WindowStartupLocation$ CenterOwner=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency .  � ShowInTaskbar .  ���	#00000000 � 	Resources 5      ��%    5      .��5      �� -   5         ��Name$ 
MainBorder��5      $	��450��5      $	��300��5      $��0q�5       �� CornerRadius$ 12,12,12,12��5      ��5      �� 5       �� 
StartPoint$ 0.126,-0.197&�6   	 �� EndPoint$	 0.874,1.197&�5      .��5   
   � 
 � Offset$
 0Q�6    � Color$ 	#FF615E5A��5      � 5   
   $
 1Q�6   $ 	#FF535353��5      � 5   
   $
 0.284Q�6   $ 	#FFE0E0E0��5       � 5!   
   $
 0.365Q�6   $ 	#FFFFFFFF��5"      5#   	   ._�5%      �  � RowDefinitions 5&      �� 5'   
   $��50 �6   �� 5(   
   $��* �6   �� 5)   
   $��80 �6   .+�5+      �� -   5        $ HeaderBorder��5+      $��0��5,      ���	#384F4F4F$��0q�5.      $ 	12,12,0,0��5/      �� 50      $��0��6    �� Orientation$ 
Horizontal=�51      .+�52      �� $��/Images/FolderLogo.png��6   $��48��53      $��48��54      $��20,0,0,0q�55      �� 56   
   -   5         ��Name$ 
HeaderText��56      $��8,0,0,0q�57      $��Center=�58      $��30(�59      ���	#FF434343$��Ideal Automate��5;       J� Effect 5<      3  -System.Windows.Media.Effects.DropShadowEffect  5=         
BlurRadius$ 15Q�6+      Color$ 	#FFFFFFFF��6;      ShadowDepth$ 0Q�6N      Opacity$	 .24Q�6^   5?      5@   	   �� 5D      $��1��6   $��10,10,10,47q�5E      $��2��6(   .+�5F      �� $	��390��6   $
��Wrap=�6)   ��Ideal Automate allows one to automate almost any task. It does this by allowing you to write scripts that can find images on the screen to locate where you want to read or write something. The Windows Snipping Tool can be very useful in allowing you to cut-n-paste images into your scripts. The fact that you can read and write to virtually any location makes it possible to create a degree of artificial intelligence where the script is able to perform real problem-solving activities. For example, the script can read a piece of information, interpret what it has read, and then make decisions in real time about what to do based on that interpretation.6�  �� 5H   
   5J      5K   	   �� 5P      -   5        $ FooterBorder��5P      $��2��5Q      ���	#384F4F4F$��0q�5S      $ 	0,0,12,12��5T      $��0,6,0,0q�6(   6;   �� 5V      -   5         ��Name$ btnOk��5V      $��80��5X      $��24��5Y      $��2��5Z      $��	0,0,10,10q�5[      $��Right=�5\      $��Bottom=�5]       �� 	IsDefault . $��OK��5_      �� 5`      $
��Wrap=�6   $��
30,15,90,7q�6,   $��3��6@   :8I grant you permission to freely share this application.�� 5a   D   6P   �� 5e      $��Version ��6   �� 6)   -   5        $ 
txtVersion��5e   3   �� 6J   6V   �� 6a   $	��© ��6k   �� 6w   -   5        $ txtYear��5e   �   �� 6�   $�� Wade Harvey  ��6�    �� 5g      $"��http://www.idealautomate.com?�6   .�6A   http://www.idealautomate.com/6`   5h      5i      5j      5k      