   M S B A M L   `   `   `  ���� H  DCentricaShops, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CentricaShops.ViewsCentricaShops.Views  C&clr-namespace:CentricaShops.ViewModelsCentricaShops.ViewModels  +    %CentricaShops.Views.ShowDistrictsView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:CentricaShops.Views     =
viewmodels&clr-namespace:CentricaShops.ViewModels     .���   � ColumnDefinitions  �� $
��221* ��� $��2* ��� $
��577* �.+��� -    ��Name$ DistrictsListView��4  .System.Windows.Automation.AutomationProperties   AutomationId$ DistrictsListView��$
��Left=�$	��186��$��	72,39,0,0q�$	��Top=�$	��132������ *	Districts+ �� SelectedItem �� *SelectedDistrictTest+����  �� 
TargetType" ��.���  �� Property � �� �� Value$ Stretch=� �� View �� .P��� $��District�� �� CellTemplate �� .R��� $��Center=����� �� -   	 ��Name$	 bRefresh��$ bRefresh��$��Refresh Districts��$
��Left=�$��
79,241,0,0q�$	��Top=�$��28��$	��125��
 J� RenderTransformOrigin$
 4.833,-1.357&����� *RefreshCommand+z�V� .~��� �� ��  �� Angle$ 0.077Q�T� �� -   $ SalePersonsLV��$
��Left=�$	��186��$	��Top=�$	��252��$��2��$��
315,39,0,0q����� *SalePersons+���� " ��.���  � ��$ Stretch=� �� .P��� $��Sale Person�� �� .R��� $��Center=����� *
SalePerson+�� $��
Is Primary�� �� .R��� $��Center=����� *	IsPrimary+�� -   $ lvStores��$��2��$
��Left=�$	��186��$��	70,39,0,0q�$	��Top=�$	��184������ *Stores+ �� .P��� $��Stores�� �� .R��� $��Center=����� �� -    ��Name$ 	bDistrict��$��2��$
��Left=�$��25��$��217,255,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��94������ *TestMessage+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -   $ bSaleperson��$��2��$
��Left=�$��25��$��358,255,0,0q�$
 Wrap=�$	��Top=�$��83��$
 
0.614,-0.4&����� *SalepersonToAdd+�� -    ��Name$ chIsPrimary��$��2��$��CheckBox��$
��Left=�$��13��$��489,261,0,0q�$	��Top=�$��26�� d� 	IsChecked �� *	IsPrimary+�� -   $	 Remove��$��2��$��Remove��$
��Left=�$��28��$��217,377,0,0q�$	��Top=�$	��117��$
 1.722,-0.214&����� *RemoveCommand+�� -	    ��Name$ DistrictLabel��
�������$��2��$
��Left=�$��50��$��
83,255,0,0q�$	��Top=�$��94������ *SelectedDistrictTest+�� -
   $		 Add��$��2��$��Add Or Update��$
��Left=�$��217,315,0,0q�$	��Top=�$	��117������ *RemoveCommand+