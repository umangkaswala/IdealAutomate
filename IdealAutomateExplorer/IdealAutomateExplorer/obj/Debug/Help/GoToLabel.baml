   M S B A M L   `   `   `  ����  IdealAutomateExplorer*    $Hardcodet.Wpf.Samples.Help.GoToLabel   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Logic��5      .��5      -�  -� ViewingMode$ Scroll=�6   .��5   
   /�  /� FontSize$ 20(�6   .T�5      J� .*�6   .*�5	      �� $��/Images/help1.png��6   $	��190��63   $	��190��6?   $��0,0,30,0q�6L    �� 5
      $��30(�6    �� BaselineAlignment$ Center=�6$   .�6?   	GoToLabel6J   5      J� 5      .*�6   .*�5      �� $��24(�6   .�6&   	Examples:61   5      �� 5      .<�5      �� .9�5      J� .*�6    .*�5      �� .�6   	GoToLabel6*   5      �� 5       �� CellSpacing$ 0��6    �� BorderThickness$ 1q�6-    �� BorderBrush
 �   �.�5      �� .�5      �� 
�������$
��Bold"�6>   .�5   "   ��  �� BorderBrush
 �   � �� BorderThickness$ 1q�6@   .�5   &   J� 	 �� TextAlignment$	 Center=�60   .*�6G   Verb6M   5   #   �� 5   "   
 �   �$ 1q�6@   .�5   &   J� $	 Center=�60   .*�6G   	Entity16P   5   #   �� 5   "   
 �   �$ 1q�6A   .�5   &   J� $	 Center=�60   .*�6G   Relationship6U   5    #   �� 5!   "   
 �   �$ 1q�6A   .�5"   &   J� $	 Center=�60   .*�6G   	Entity26P   5#   #   5'      5(      �� 5*      .�5+      �� .�5,   "   �� 
 �   �$ 1q�6@   .�5-   &   J� .*�60   	GoToLabel6;   5.   #   �� 5/   "   
 �   �$ 1q�6@   .�50   &   J� .*�60   	txtExit69   51   #   �� 52   "   
 �   �$ 1q�6@   .�53   &   J� 62   54   #   �� 55   "   
 �   �$ 1q�6@   .�56   &   J� 62   57   #   59      5:      �� 5;      .�5<      �� .�5=   "   �� 
 �   �$ 1q�6@   .�5>   &   J� .*�60   
MessageBox6<   5?   #   �� 5@   "   
 �   �$ 1q�6@   .�5A   &   J� .*�60   txtThisMessageWillNotShow6K   5B   #   �� 5C   "   
 �   �$ 1q�6@   .�5D   &   J� 62   5E   #   �� 5F   "   
 �   �$ 1q�6@   .�5G   &   J� 62   5H   #   5J      5K      �� 5L      .�5M      �� .�5N   "   �� 
 �   �$ 1q�6@   .�5O   &   J� .*�60   Label67   5P   #   �� 5Q   "   
 �   �$ 1q�6@   .�5R   &   J� .*�60   	txtExit69   5S   #   �� 5T   "   
 �   �$ 1q�6@   .�5U   &   J� 62   5V   #   �� 5W   "   
 �   �$ 1q�6@   .�5X   &   J� 62   5Y   #   5[      5\      5]      J� 5^      .*�6    .*�5_      �� .�6!   Explanation of example69   �� - This sequence of statements will cause the MessageBox to be skipped because the GoToLabel verb will cause the normal sequential execution to "jump over" the MessageBox statement and go directly to the Label line that has the entity1, txtExit, that matches what was specified in the GoToLabel statement. txtExit is string primitive that was defined in the primitives tab as the string Exit in this example, but it could have been defined as any primitive string as long as what is specified in the GoToLabel matches what is specified in the statement that contains the Label verb.�� 5`      5a      5b      5c      J� 5d      .*�6   .*�5e      �� 
 �� Stretch$

 Fill=�6   
���   �	 �� X2$ 1��65   5f      J� 5g      .*�6   .*�5h      �� $��24(�6   .�6%   
Columns:6/   5i      J� 5j      .*�6   .*�5k      �� .�6   	GoToLabel6"   �� - Used to break out of the sequential execution of statements in order to go directly to the Label statement that contains the matching Entity1. Here are the columns:5l      J� 5m      $
��14pt(�6   .*�6)   .*�5n      �� .�6   .�5o      �� .�6   1. Sequence5q      5r      5s      J� 5t      .*�6   ��Sequence is a decimal number with 4 digits after the decimal. It can be modified to allow you to insert rows anywhere in your script. Rows are executed in sequence number order.5v      J� 5w      $
��14pt(�6   .*�6)   .*�5x      �� .�6   .�5y      �� .�6   	2. Verb5{      5|      5}      J� 5~      .*�6   	GoToLabel5�      J� 5�      $
��14pt(�6   .*�6)   .*�5�      �� .�6   .�5�      �� .�6   
3. Entity15�      5�      5�      J� 5�      .*�6   QOEntity1 is the name of a primitive that has been defined in the primitives tab.5�      J� 5�      $
��14pt(�6   .*�6)   .*�5�      �� .�6   .�5�      �� .�6   4. Relationship5�      5�      5�      J� 5�      .*�6   Relationship is not used.5�      J� 5�      $
��14pt(�6   .*�6)   .*�5�      �� .�6   .�5�      �� .�6   
5. Entity25�      5�      5�      J� 5�      .*�6   Entity2 is not used.5�      5�      5�      5�      