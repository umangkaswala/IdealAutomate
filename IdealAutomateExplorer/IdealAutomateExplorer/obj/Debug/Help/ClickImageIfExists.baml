   M S B A M L   `   `   `  ����  IdealAutomateExplorer3    -Hardcodet.Wpf.Samples.Help.ClickImageIfExists   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  ClickImageIfExists��5      .��5      -�  -� ViewingMode$ Scroll=�6   .��5   
   /�  /� FontSize$ 20(�6   .T�5      J� .*�6   .*�5	      �� $��/Images/help1.png��6   $	��190��63   $	��190��6?   $��0,0,30,0q�6L    �� 5
      $��30(�6    �� BaselineAlignment$ Center=�6$   .�6?   ClickImageIfExists6S   5      J� 5      .*�6   .*�5      �� $��24(�6   .�6&   	Examples:61   5      �� 5      .<�5      �� .9�5      J� .*�6    .*�5      �� .�6   ClickImageIfExists63   5      �� 5       �� CellSpacing$ 0��6    �� BorderThickness$ 1q�6-    �� BorderBrush
 �   �.�5      �� .�5      �� 
�������$
��Bold"�6>   .�5   "   ��  �� BorderBrush
 �   � �� BorderThickness$ 1q�6@   .�5   &   J� 	 �� TextAlignment$	 Center=�60   .*�6G   Verb6M   5   #   �� 5   "   
 �   �$ 1q�6@   .�5   &   J� $	 Center=�60   .*�6G   	Entity16P   5   #   �� 5   "   
 �   �$ 1q�6A   .�5    &   J� $	 Center=�60   .*�6G   Relationship6U   5!   #   �� 5"   "   
 �   �$ 1q�6A   .�5#   &   J� $	 Center=�60   .*�6G   	Entity26P   5$   #   5(      5)      �� 5+      .�5,      �� .�5-   "   �� 
 �   �$ 1q�6@   .�5.   &   J� .*�60   ClickImageIfExists6D   5/   #   �� 50   "   
 �   �$ 1q�6@   .�51   &   J� .*�60   imgFindButton6?   52   #   �� 53   "   
 �   �$ 1q�6@   .�54   &   J� 62   55   #   �� 56   "   
 �   �$ 1q�6@   .�57   &   J� 62   58   #   5:      5;      5<      J� 5?      .*�6    .*�5@      �� .�6!   Explanation of example69   �� - This will do a left-click on the imgFindButton if it is found. imgFindButton is defined as an image in the images tab, and the Windows Snipping Tool was used to cut-n-paste a picture of the find button into that definition. If attempts, sleep, RelativeX, RelativeY, UseGrayScale, Tolerance, etc. were specified in the definition of the image, they will all be taken into account when looking for the image.�� 5A      5B      5C      5D      J� 5E      .*�6   .*�5F      �� 
 �� Stretch$

 Fill=�6   
���   �	 �� X2$ 1��65   5G      J� 5H      .*�6   .*�5I      �� $��24(�6   .�6%   
Columns:6/   5J      J� 5K      .*�6   .*�5L      �� .�6   ClickImageIfExists6+   YW - provides you with a quick and dirty way to do a left-click on an image if it exists.5M      J� 5N      $
��14pt(�6   .*�6)   .*�5O      �� .�6   .�5P      �� .�6   1. Sequence5R      5S      5T      J� 5U      .*�6   ��Sequence is a decimal number with 4 digits after the decimal. It can be modified to allow you to insert rows anywhere in your script. Rows are executed in sequence number order.5W      J� 5X      $
��14pt(�6   .*�6)   .*�5Y      �� .�6   .�5Z      �� .�6   	2. Verb5\      5]      5^      J� 5_      .*�6   !The verb is ClickImageIfExists.5a      J� 5d      $
��14pt(�6   .*�6)   .*�5e      �� .�6   .�5f      �� .�6   
3. Entity15h      5i      5j      J� 5k      .*�6   JHEntity1 is the name of an image that has been defined in the images tab.5m      J� 5n      $
��14pt(�6   .*�6)   .*�5o      �� .�6   .�5p      �� .�6   4. Relationship5r      5s      5t      J� 5u      .*�6   Relationship is not used.5w      J� 5x      $
��14pt(�6   .*�6)   .*�5y      �� .�6   .�5z      �� .�6   
5. Entity25|      5}      5~      J� 5      .*�6   Entity2 is not used.5�      5�      5�      5�      