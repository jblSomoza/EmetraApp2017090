   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GEmetraApp2017090, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EmetraApp2017090EmetraApp2017090 5   	   '   !EmetraApp2017090.SanctionTypeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:EmetraApp2017090     5   	      AccentColorBrush#���   5	   	   $��3q�5
   	     � 
ResizeMode$  CanResizeWithGrip=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ SanctionTypeView��5   	   $	��500��6"   $	��750��6/   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF2EC52E��6    � Offset$ 0.988Q�61   5      .+�5   
   �� -   5         ��Name$ lbRemissionID��5      $��RemissionID��6'   $
��Left=�6=   $��	10,27,0,0q�6X   $	��Top=�6k   $
��auto��6�   $
��auto��6�   $��20(�6�   $��	UltraBold"�6�   �� 5   
   -   5        $ lbDescription��5      $��Description��6'   $
��Left=�6=   $��	13,84,0,0q�6X   $	��Top=�6k   $
��auto��6�   $
��auto��6�   $��20(�6�   $��	UltraBold"�6�   �� 5   
   -   5        $ lbImport��5      $��Import��6"   $
��Left=�63   $��
411,27,0,0q�6N   $	��Top=�6b   $
��auto��6z   $
��auto��6�   $��20(�6�   $��	UltraBold"�6�   �� 5   
   -   5        $ lbRecurrent��5      $��	Recurrent��6%   $
��Left=�69   $��
401,84,0,0q�6T   $	��Top=�6h   $
��auto��6�   $
��auto��6�   $��20(�6�   $��	UltraBold"�6�   �� 5   
   -   5         ��Name$ txtRemissionID��5      {�.  *   $MahApps.Metro.Controls.TextBoxHelper	   ClearTextButton	 . 
   	Watermark$
 Enter Remission ID��6�   $
��Left=�6�   $��34��6�   $��
171,27,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6  $	��197��6$  ��6<   �� *RemissionID+6$  �� 5   
   -   5        $ txtDescription��5      	 . $
 Enter Description��6u   $
��Left=�6�   $��34��6�   $��
171,87,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��197��6  ��6*   �� *Description+6  �� 5   
   -   5        $ 	txtImport��5      	 . $
 Enter Import��6k   $
��Left=�6�   $��34��6�   $��
535,27,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��197��6  ��6%   �� *Import+6  �� 5   
   -   5        $ txtRecurrent��5      	 . $
 Enter Recurrent��6q   $
��Left=�6�   $��34��6�   $��
535,84,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��197��6  ��6(   �� *	Recurrent+6  �� 5    
   $
��Left=�6   $	��190��60   $��
13,206,0,0q�6=   $	��Top=�6Q   $	��719��6i   .+�5!      &   System.Windows.Controls.DataGrid  -	   5          Name$ dataGrid��5!         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      
IsReadOnly .    AutoGenerateColumns .  "   VerticalScrollBarVisibility$ Visible=�6�   $   HorizontalScrollBarVisibility$ Visible=�6�   $	��189��6    AzureDataGrid#��[ 6  ��6K   �� *ListSanctionType+ �� SelectedItem 6t   �� *	Element+   Columns 5"      4  .System.Windows.Controls.DataGridCheckBoxColumn  5$        MetroDataGridCheckBox1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# �  6-      EditingElementStyle# �  5%   )   ,  &System.Windows.Controls.DataGridColumn   Header$ Selected��5&   )      Binding 5'   )   ��  �� RelativeSource ��  �� AncestorType$ DataGridRowL� �� Path$ 
IsSelected� �� Mode$ OneWay=�0  *System.Windows.Controls.DataGridTextColumn  5*      $ remission ID��6*    6A   �� *RemissionID+  5+      $ Description��6)    6?   �� *Description+  5,      $ Import��6*    6:   �� *Import+  5-      $ 	Recurrent��6*    6=   �� *	Recurrent+5/      50      �� 52   
   -
   5         ��Name$ btnNew��52      $	��new��6>     AccentedSquareButtonStyle#��[ 6p   $	��New��6�   $
��Left=�6�   $��
13,413,0,0q�6�   $	��Top=�6�   $��75��6�   {�6!   �� *BtnNew+��6V   �� *Model+6�   �� 53   
   -   5        $ btnSave��53      $
��save��6@   #��[ 6r   $
��Save��6�   $
��Left=�6�   $��154,413,0,0q�6�   $	��Top=�6�   $��75��6�   {�6"   �� *	BtnSave+��6X   �� *Model+6�   �� 54   
   -   5        $ 	btnUpdate��54      $��update��6D   #��[ 6x   $��Update��6�   $
��Left=�6�   $��303,413,0,0q�6�   $	��Top=�6�   $��75��6  {�6$   �� *	BtnUpdate+��6^   �� *Model+6  �� 55   
   -   5        $ 	btnDelete��55      $��delete��6E   #��[ 6y   $��Delete��6�   $
��Left=�6�   $��473,413,0,0q�6�   $	��Top=�6�   $��75��6  {�6%   �� *	BtnDelete+��6_   �� *Model+6  �� 56   
   -   5        $ 	btnCancel��56      $��cancel��6D   #��[ 6x   $��Cancel��6�   $
��Left=�6�   $��625,413,0,0q�6�   $	��Top=�6�   $��75��6  {�6$   �� *	BtnCancel+��6^   �� *Model+6  57      58      