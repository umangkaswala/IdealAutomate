   M S B A M L   `   `   `  ����  IdealAutomateExplorer.    (Hardcodet.Wpf.Samples.Help.IncludeScript   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Include Script��5      .��5      -�  -� ViewingMode$ Scroll=�6   .��5   
   /�  /� FontSize$ 20(�6   .T�5      J� .*�6   .*�5	      �� $��/Images/help1.png��6   $	��190��63   $	��190��6?   $��0,0,30,0q�6L    �� 5
      $��30(�6    �� BaselineAlignment$ Center=�6$   .�6?   IncludeScript6N   5      J� 5      .*�6   .*�5      �� $��24(�6   .�6&   	Examples:61   5      �� 5      .<�5      �� .9�5      J� .*�6    .*�5      �� .�6   IncludeScript6.   5      �� 5       �� CellSpacing$ 0��6    �� BorderThickness$ 1q�6-    �� BorderBrush
 �   �.�5      �� .�5      �� 
�������$
��Bold"�6>   .�5   "   ��  �� BorderBrush
 �   � �� BorderThickness$ 1q�6@   .�5   &   J� 	 �� TextAlignment$	 Center=�60   .*�6G   Verb6M   5   #   �� 5   "   
 �   �$ 1q�6@   .�5   &   J� $	 Center=�60   .*�6G   	Entity16P   5   #   �� 5   "   
 �   �$ 1q�6A   .�5   &   J� $	 Center=�60   .*�6G   Relationship6U   5    #   �� 5!   "   
 �   �$ 1q�6A   .�5"   &   J� $	 Center=�60   .*�6G   	Entity26P   5#   #   5'      5(      �� 5*      .�5+      �� .�5,   "   �� 
 �   �$ 1q�6@   .�5-   &   J� .*�60   
TypeText6:   5.   #   �� 5/   "   
 �   �$ 1q�6@   .�50   &   J� .*�60   txtAltSpaceN6>   51   #   �� 52   "   
 �   �$ 1q�6@   .�53   &   J� 62   54   #   �� 55   "   
 �   �$ 1q�6@   .�56   &   J� 62   57   #   59      5:      �� 5;      .�5<      �� .�5=   "   �� 
 �   �$ 1q�6@   .�5>   &   J� .*�60   IncludeScript6?   5?   #   �� 5@   "   
 �   �$ 1q�6@   .�5A   &   J� .*�60   txtLoginWebsite6A   5B   #   �� 5C   "   
 �   �$ 1q�6@   .�5D   &   J� 62   5E   #   �� 5F   "   
 �   �$ 1q�6@   .�5G   &   J� 62   5H   #   5J      5K      �� 5L      .�5M      �� .�5N   "   �� 
 �   �$ 1q�6@   .�5O   &   J� .*�60   
MessageBox6<   5P   #   �� 5Q   "   
 �   �$ 1q�6@   .�5R   &   J� .*�60   txtDoStuffOnWebSite6E   5S   #   �� 5T   "   
 �   �$ 1q�6@   .�5U   &   J� 62   5V   #   �� 5W   "   
 �   �$ 1q�6@   .�5X   &   J� 62   5Y   #   5[      5\      5]      J� 5^      .*�6    .*�5_      �� .�6!   Explanation of example69   �� - The first statement causes Ideal Automate to be minimized because txtAltSpaceN is defined as a primitive with a string value of %(" "n). The second statement includes the script that matches the string specified in the primitives tab for txtLoginWebsite. The statements in that included script are executed and that included script could even include other included scripts within it. After the included script is executed, the third statement involving the MessageBox is executed.�� 5`      5a      5b      5f      J� 5g      .*�6   .*�5h      �� 
 �� Stretch$

 Fill=�6   
���   �	 �� X2$ 1��65   5i      J� 5j      .*�6   .*�5k      �� $��24(�6   .�6%   
Columns:6/   5l      J� 5m      .*�6   .*�5n      �� .�6   IncludeScript6&   YW - IncludeScript allows you to execute one script inside another. Here are the columns:5o      J� 5p      $
��14pt(�6   .*�6)   .*�5q      �� .�6   .�5r      �� .�6   1. Sequence5t      5u      5v      J� 5w      .*�6   ��Sequence is a decimal number with 4 digits after the decimal. It can be modified to allow you to insert rows anywhere in your script. Rows are executed in sequence number order.5y      J� 5z      $
��14pt(�6   .*�6)   .*�5{      �� .�6   .�5|      �� .�6   	2. Verb5~      5      5�      J� 5�      .*�6   IncludeScript5�      J� 5�      $
��14pt(�6   .*�6)   .*�5�      �� .�6   .�5�      �� .�6   
3. Entity15�      5�      5�      J� 5�      .*�6   ��Entity1 is the name of a primitive that has been defined in the primitives tab. The value for the primitive needs to match the name of an existing local script.5�      J� 5�      $
��14pt(�6   .*�6)   .*�5�      �� .�6   .�5�      �� .�6   4. Relationship5�      5�      5�      J� 5�      .*�6   Relationship is not used.5�      J� 5�      $
��14pt(�6   .*�6)   .*�5�      �� .�6   .�5�      �� .�6   
5. Entity25�      5�      5�      J� 5�      .*�6   Entity2 is not used.5�      5�      5�      5�      