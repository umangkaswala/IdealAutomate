   M S B A M L   `   `   `  ����  IdealAutomateExplorer&     Hardcodet.Wpf.Samples.Help.Label   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Label��5      .��5      -�  -� ViewingMode$ Scroll=�6   .��5   
   /�  /� FontSize$ 20(�6   .T�5      J� .*�6   .*�5	      �� $��/Images/help1.png��6   $	��190��63   $	��190��6?   $��0,0,30,0q�6L    �� 5
      $��30(�6    �� BaselineAlignment$ Center=�6$   .�6?   Label6F   5      J� 5      .*�6   .*�5      �� $��24(�6   .�6&   	Examples:61   5      �� 5      .<�5      �� .9�5      J� .*�6    .*�5      �� .�6   Label6&   5      �� 5       �� CellSpacing$ 0��6    �� BorderThickness$ 1q�6-    �� BorderBrush
 �   �.�5      �� .�5      �� 
�������$
��Bold"�6>   .�5   "   ��  �� BorderBrush
 �   � �� BorderThickness$ 1q�6@   .�5   &   J� 	 �� TextAlignment$	 Center=�60   .*�6G   Verb6M   5   #   �� 5   "   
 �   �$ 1q�6@   .�5   &   J� $	 Center=�60   .*�6G   	Entity16P   5   #   �� 5   "   
 �   �$ 1q�6A   .�5   &   J� $	 Center=�60   .*�6G   Relationship6U   5   #   �� 5    "   
 �   �$ 1q�6A   .�5!   &   J� $	 Center=�60   .*�6G   	Entity26P   5"   #   5&      5'      �� 5)      .�5*      �� .�5+   "   �� 
 �   �$ 1q�6@   .�5,   &   J� .*�60   	GoToLabel6;   5-   #   �� 5.   "   
 �   �$ 1q�6@   .�5/   &   J� .*�60   	txtExit69   50   #   �� 51   "   
 �   �$ 1q�6@   .�52   &   J� 62   53   #   �� 54   "   
 �   �$ 1q�6@   .�55   &   J� 62   56   #   58      59      �� 5:      .�5;      �� .�5<   "   �� 
 �   �$ 1q�6@   .�5=   &   J� .*�60   
MessageBox6<   5>   #   �� 5?   "   
 �   �$ 1q�6@   .�5@   &   J� .*�60   txtThisMessageWillNotShow6K   5A   #   �� 5B   "   
 �   �$ 1q�6@   .�5C   &   J� 62   5D   #   �� 5E   "   
 �   �$ 1q�6@   .�5F   &   J� 62   5G   #   5I      5J      �� 5K      .�5L      �� .�5M   "   �� 
 �   �$ 1q�6@   .�5N   &   J� .*�60   Label67   5O   #   �� 5P   "   
 �   �$ 1q�6@   .�5Q   &   J� .*�60   	txtExit69   5R   #   �� 5S   "   
 �   �$ 1q�6@   .�5T   &   J� 62   5U   #   �� 5V   "   
 �   �$ 1q�6@   .�5W   &   J� 62   5X   #   5Z      5[      5\      J� 5]      .*�6    .*�5^      �� .�6!   Explanation of example69   �� - This sequence of statements will cause the MessageBox to be skipped because the GoToLabel verb will cause the normal sequential execution to "jump over" the MessageBox statement and go directly to the Label line that has the entity1, txtExit, that matches what was specified in the GoToLabel statement. txtExit is string primitive that was defined in the primitives tab as the string Exit in this example, but it could have been defined as any primitive string as long as what is specified in the GoToLabel matches what is specified in the statement that contains the Label verb.�� 5_      5`      5a      5b      J� 5c      .*�6   .*�5d      �� 
 �� Stretch$

 Fill=�6   
���   �	 �� X2$ 1��65   5e      J� 5f      .*�6   .*�5g      �� $��24(�6   .�6%   
Columns:6/   5h      J� 5i      .*�6   .*�5j      �� .�6   Label6   ][ - Label is used as pointer for a place that GoToLabel can branch to. Here are the columns:5k      J� 5l      $
��14pt(�6   .*�6)   .*�5m      �� .�6   .�5n      �� .�6   1. Sequence5p      5q      5r      J� 5s      .*�6   ��Sequence is a decimal number with 4 digits after the decimal. It can be modified to allow you to insert rows anywhere in your script. Rows are executed in sequence number order.5u      J� 5v      $
��14pt(�6   .*�6)   .*�5w      �� .�6   .�5x      �� .�6   	2. Verb5z      5{      5|      J� 5}      .*�6   Label5      J� 5�      $
��14pt(�6   .*�6)   .*�5�      �� .�6   .�5�      �� .�6   
3. Entity15�      5�      5�      J� 5�      .*�6   ��Entity1 is the name of a primitive that has been defined in the primitives tab. Label is a string that the GoToLabel Entity1 must match in order for the jump to label to occur.5�      J� 5�      $
��14pt(�6   .*�6)   .*�5�      �� .�6   .�5�      �� .�6   4. Relationship5�      5�      5�      J� 5�      .*�6   Relationship is not used.5�      J� 5�      $
��14pt(�6   .*�6)   .*�5�      �� .�6   .�5�      �� .�6   
5. Entity25�      5�      5�      J� 5�      .*�6   Entity2 is not used.5�      5�      5�      5�      