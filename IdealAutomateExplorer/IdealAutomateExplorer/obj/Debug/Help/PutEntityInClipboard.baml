   M S B A M L   `   `   `  ����  IdealAutomateExplorer5    /Hardcodet.Wpf.Samples.Help.PutEntityInClipboard   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  PutEntityInClipboard��5      .��5      -�  -� ViewingMode$ Scroll=�6   .��5   
   /�  /� FontSize$ 20(�6   .T�5      J� .*�6   .*�5	      �� $��/Images/help1.png��6   $	��190��63   $	��190��6?   $��0,0,30,0q�6L    �� 5
      $��30(�6    �� BaselineAlignment$ Center=�6$   .�6?   PutEntityInClipboard6U   5      J� 5      .*�6   .*�5      �� $��24(�6   .�6%   	Examples:60   5      �� 5      .<�5      �� .9�5      J� .*�6    .*�5      �� .�6   PutEntityInClipboard65   5      �� 5       �� CellSpacing$ 5��6    �� BorderThickness$ 1q�6,    �� BorderBrush
 �   �.�5      �� .�5      �� .�5   "   �� .�5   &   J� .*�60   .*�5   *   �� $%��/Images/PrimitivesPutEntity.PNG��60   $��5,5,5,5q�6Z   $��Center=�6l   5   '   5   #   5      5      5      �� 5       $ 0��6   $ 1q�6-   
 �   �.�5!      �� .�5"      �� 
�������$
��Bold"�6>   .�5#   "   ��  �� BorderBrush
 �   � �� BorderThickness$ 1q�6@   .�5$   &   J� 	 �� TextAlignment$	 Center=�60   .*�6G   Verb6M   5%   #   �� 5&   "   
 �   �$ 1q�6@   .�5'   &   J� $	 Center=�60   .*�6G   	Entity16P   5(   #   �� 5)   "   
 �   �$ 1q�6A   .�5*   &   J� $	 Center=�60   .*�6G   Relationship6U   5+   #   �� 5,   "   
 �   �$ 1q�6A   .�5-   &   J� $	 Center=�60   .*�6G   	Entity26P   5.   #   5/      50      �� 51      .�53      �� .�54   "   �� 
 �   �$ 1q�6@   .�55   &   J� .*�60   Run65   56   #   �� 57   "   
 �   �$ 1q�6@   .�58   &   J� .*�60   txtExe68   59   #   �� 5:   "   
 �   �$ 1q�6@   .�5;   &   J� 62   5<   #   �� 5=   "   
 �   �$ 1q�6@   .�5>   &   J� 62   5?   #   5@      5A      �� 5B      .�5C      �� .�5D   "   �� 
 �   �$ 1q�6@   .�5E   &   J� .*�60   PutEntityInClipboard6F   5F   #   �� 5G   "   
 �   �$ 1q�6@   .�5H   &   J� .*�60   txtWeirdChar6>   5I   #   �� 5J   "   
 �   �$ 1q�6@   .�5K   &   J� 62   5L   #   �� 5M   "   
 �   �$ 1q�6@   .�5N   &   J� 62   5O   #   5Q      �� 5R      .�5S   "   �� 
 �   �$ 1q�6@   .�5T   &   J� .*�60   
TypeText6:   5U   #   �� 5V   "   
 �   �$ 1q�6@   .�5W   &   J� .*�60   	Control-V6;   5X   #   �� 5Y   "   
 �   �$ 1q�6@   .�5Z   &   J� 62   5[   #   �� 5\   "   
 �   �$ 1q�6@   .�5]   &   J� .*�60   100066   5^   #   5_      5`      5b      J� 5d      .*�6    .*�5e      �� .�6!   Explanation of example69   �� - Run notepad. Put what is specified as the value of Entity1 into the clipboard. Paste the clipboard into notepad after waiting 1000 milliseconds for the application to load.5f      5g      5h      J� 5i      .*�6   .*�5j      �� 
 �� Stretch$

 Fill=�6   
���   �	 �� X2$ 1��65   5k      J� 5l      .*�6   .*�5m      �� $��24(�6   .�6%   
Columns:6/   5n      J� 5o      .*�6   .*�5p      �� .�6   PutEntityInClipboard6-   jh - PutEntityInClipboard allows you to put the value of Entity1 into the clipboard. Here are the columns:5q      J� 5r      $
��14pt(�6   .*�6)   .*�5s      �� .�6   .�5t      �� .�6   1. Sequence5v      5w      5x      J� 5y      .*�6   ��Sequence is a decimal number with 4 digits after the decimal. It can be modified to allow you to insert rows anywhere in your script. Rows are executed in sequence number order.5{      J� 5|      $
��14pt(�6   .*�6)   .*�5}      �� .�6   .�5~      �� .�6   	2. Verb5�      5�      5�      J� 5�      .*�6   PutEntityInClipboard5�      J� 5�      $
��14pt(�6   .*�6)   .*�5�      �� .�6   .�5�      �� .�6   
3. Entity15�      5�      5�      J� 5�      .*�6   IGEntity1 is the name of a string that was defined in the Primitives tab.5�      J� 5�      $
��14pt(�6   .*�6)   .*�5�      �� .�6   .�5�      �� .�6   4. Relationship5�      5�      5�      J� 5�      .*�6   Relationship is not used.5�      J� 5�      $
��14pt(�6   .*�6)   .*�5�      �� .�6   .�5�      �� .�6   
5. Entity25�      5�      5�      J� 5�      .*�6   Entity2 is not used.5�      5�      5�      5�      