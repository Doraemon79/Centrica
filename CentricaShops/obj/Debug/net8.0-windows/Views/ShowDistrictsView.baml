   M S B A M L   `   `   `  ����H  DCentricaShops, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CentricaShops.ViewsCentricaShops.Views  5      C&clr-namespace:CentricaShops.ViewModelsCentricaShops.ViewModels  6>   +    %CentricaShops.Views.ShowDistrictsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CentricaShops.Views     5      =
viewmodels&clr-namespace:CentricaShops.ViewModels     6>   $	��488��5      $	��801��6,   .��5      �   � ColumnDefinitions  5	   
   �� 5
      $
��221* �6   �� 5      $��2* �6   �� 5      $
��577* �6   .+�5   
   �� -   5         ��Name$ DistrictsListView��5      4  .System.Windows.Automation.AutomationProperties   AutomationId$ DistrictsListView��6/   $
��Left=�6e   $	��186��6�   $��	72,39,0,0q�6�   $	��Top=�6�   $	��132��6�   ��5      �� *	Districts+ �� SelectedItem 65   �� *SelectedDistrictTest+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ Stretch=�6C   5       �� View 5      �� 5      .P�5      �� $��District��6%    �� CellTemplate 5      �� 5      .R�5   "   �� $��Center=�6,   ��6I   �� 5      5      5       5"      �� 5#   
   -   5        	 ��Name$	 bRefresh��5#      $ bRefresh��6#   $��Refresh Districts��6s   $
��Left=�6�   $��
79,241,0,0q�6�   $	��Top=�6�   $��28��6�   $	��125��6�   
 J� RenderTransformOrigin$
 4.833,-1.357&�6�   ��6P   �� *RefreshCommand+z�5$      V� 5%      .~�5&      �� �� 5'      �� 5(       �� Angle$ 0.077Q�6&   T� 5)      5*      5,      �� 5.   
   -   5        $ SalePersonsLV��5.      $
��Left=�6*   $	��186��6E   $	��Top=�6R   $	��479��6j   $��2��6w   $��	10,39,0,0q�6�   ��5/      �� *StoreSalePersons+��50      �� 51      " ��6   .�52      ��  � ��$ Stretch=�6C   53       55      �� 56      .P�58      �� $��Sale Person��6%    59      �� 5:      .R�5;   "   �� $��Center=�6,   ��6I   �� *
SalePerson+5<      5>      �� 5@      $��Store��6%    5A      �� 5B      .R�5C   "   �� $��Center=�6,   ��6I   �� *	StoreName+5D      5F      �� 5H      $��
Is Primary��6%    5I      �� 5J      .R�5K   "   �� $��Center=�6,   ��6I   �� *	IsPrimary+5L      5N      5P      5R      �� 5S   
   -   5         ��Name$ UserMessage��5S      $��2��6'   $
��Left=�67   $��44��6R   $��
41,396,0,0q�6^    �� TextWrapping$
 Wrap=�6r   $	��Top=�6�   $	��362��6�   ��6�   �� *UserMessage+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5T   
   -   5        $ bSaleperson��5T      $��2��6'   $
��Left=�67   $��25��6R   $��191,298,0,0q�6^   $
 Wrap=�6s   $	��Top=�6�   $	��117��6�   $
 
0.614,-0.4&�6�   ��6�   �� *SalepersonToAdd+$ PropertyChanged=�6�   �� 5U   
   -   5         ��Name$ chIsPrimary��5U      $��2��6(   $��Primary?��68   $
��Left=�6K   $��19��6f   $��322,304,0,0q�6r   $	��Top=�6�   $��87��6�    d� 	IsChecked 6�   �� *	IsPrimary+�� 5V   
   -   5        $	 Remove��5V      $��2��6C   $��Remove��6S   $
��Left=�6d   $��28��6   $��
41,344,0,0q�6�   $	��Top=�6�   $	��117��6�   $
 1.722,-0.214&�6�   ��6!   �� *RemoveCommand+6�   �� 5W   
   -   5         ��Name$ DistrictLabel��5W      
�������$��2��6A   $
��Left=�6z   $��25��6�   $��
41,255,0,0q�6�   $	��Top=�6�   $��94��6�   ��6Q   �� *SelectedDistrictTest+6�   �� 5X   
   -	   5        $	 bnAdd��5X      $��2��6    $	��Add��6Q   $
��Left=�6_   $��
41,295,0,0q�6z   $	��Top=�6�   $	��117��6�   ��62   �� *
AddCommand+6�   �� 5Y   
   -
   5        $	 bnGetDetails��5Y      $��2��6'   $��Get Details��6]   $
��Left=�6s   $��191,252,0,0q�6�   $	��Top=�6�   $	��117��6�   ��67   �� *GetDetailsCommand+6�   �� 5Z   
   -   5        $	 bnUpdate��5Z      $��2��6#   $��Update��6W   $
��Left=�6h   $��436,295,0,0q�6�   $	��Top=�6�   $	��117��6�   $��28��6�   ��65   �� *UpdateCommand+6�   5\      5]      