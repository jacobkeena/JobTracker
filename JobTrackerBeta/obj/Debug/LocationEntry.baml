   M S B A M L   `   `   `  ����I  EJobTrackerBeta, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:JobTrackerBetaJobTrackerBeta  5      "    JobTrackerBeta.LocationEntry   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:JobTrackerBeta     5        N� Title$  LocationEntry��5	      $	��400��5
      $	��700��6   .��5      �� 
���   �
�������$��2q�62   ._�5      � $��10q�6    � RowDefinitions 5      �� 5   
   $��* �6   �� 5   
   $��* �6   �� 5   
   $��* �6   �� 5   
   $��* �6   �� 5   
   $��* �6    � ColumnDefinitions 5      �� 5   
   $��* �6   �� 5   
   $��* �6   .+�5      �� $��New Location��6   $��15(�6'   $
��Bold"�5   
   $��0��6   $��0��60   �� 5      $��0��6   $��1��6%    �� Orientation$ 
Horizontal=�64   .+�5   
   �� $
��City��6   $��Center=�6"   $��70��6?   �� 5    
   -   5        $��txtCity��5       $��Center=�6#   $	��200��5!      .��6   5"      5#   	   �� 5%      $��0��6   $��2��6%   $ 
Horizontal=�64   .+�5&   
   �� $��State��6   $��Center=�6"   $��70��6?   �� 5'   
   -   5        $��boxState��5'   .   $��Center=�6   $	��130��6>   $��18��6J   $��9(�6V    �� 
IsEditable . 5(      5)   	   ]� 5+      $��0��6   $��3��6$   .+�5,   
   � $��0q�6    5-      �� 5.      $��* �6    51      �� 52      $��* �6   �� 53      $��* �6   .+�55      �� $��0��6   $��0��6'   $ 
Horizontal=�64   .+�56      �� $��Rating��6   $��Center=�6'   $��70��6D   �� 57      -   5        $��	txtRating��57      $��Center=�6)   $��50��58      6J   59      �� 5:      $��1��6   $��0��6'   $ Vertical=�64   .+�5;      �� $��Last resort: 0-2��6   �� 5<      $��Ehh there's better: 3-5��6   �� 5=      $'��!Pretty nice, could do better: 6-8��6   �� 5>      $#��Doesn't get much better: 9-10��6   5?      �� 5@      -   5        $��canvasPanel��5@   C   $��1��6   $��0��6#   
�������6C   5A      5B   	   �� 5D      $��0��6   $��4��6%   $ 
Horizontal=�64   .+�5E   
   �� $��Notes��6   $��Center=�6"   $��70��6?   �� 5F   
   -   5        $��txtNotes��5F      $��Center=�6$      WrappedTextBox#���   5G      $	��200��66   5H   	   �� 5I      $��1��6   $��1��6   .+�5J   
   �� -   5        $��canceledMessage��5J   r   $*��$Canceled: New location was not saved��6   $
��Bold"�6@   
���  ��$��90,40q�6c   6r   5K   	   ]� 5L      $��1��6   $��2��6"   .+�5M   
   �� -   5          MyButtonStyle#���  5M      $��Submit��69   6J   5N   	   5O      5P      5Q      