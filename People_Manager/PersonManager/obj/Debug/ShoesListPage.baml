   M S B A M L   `   `   `  ????B  >Zadatak, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ZadatakZadatak  5          Zadatak.ShoesListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Zadatak     5        N? Title$  ShoesListPage??5	      .??5      ?    GradientBackground#??[  6   .+?5   
   ?? -   5         ??Name$ LvShoes??5   (   $??30,70,30,70q?6    ?? AlternationCount$ 2??69   ??5      ?? 5       ?? 
TargetType" ??6   .?5      -   5        ?? 5       ?? Property ? ?? ?? Value
 ??ح?63    ?? Triggers 5      P? 5       P? Property ?@??AlternationIndex P? Value$ 1??6G   . ?5      ??  ? ??
 ?????6;   5      ]? 5      	 ]? 
Conditions	 5      ?? 5   "   
 ?? Property
 ?@??
IsSelected ?? Value . 6B   ./?5      ??  ? ??
 ???_?6;   5      5       ?? View 5      ?? 5      .P?5       ??  ?? Width$	 400??6%   $??Brend??61    ?? CellTemplate 5!      ?? 5"      .R?5#   "   ?? $??	Underline{?6C   
???   ? ? Cursor$
 Hand??6r   ??6,   ?? *Brend+ ? ToolTip 5$   &   ?? 5%   *    ??Name$ ShoesPicture??60   $??60??6f   $??60??6q   $??0,0,5,0q?6}   ??6F   ?? *ShoesPicture+6}   5'   #   5(      5*      ?? 5+      $	 140??6%   $
??Size??61    ?? DisplayMemberBinding 6?   ?? *Size+5,      5.      ?? 50   
   -   5         ??Name$ BtnBack??51      
?????? 
?????? $
??Left=?54      $	??Top=?55      $??25??56      $??25??57      $??30q?58      .??5:      ?? $??/Assets/back.png??6   5;      ?? 5@   
   -   5        $ BtnAdd??5A      $	??Add??5B      $
??Left=?5C      $	??Top=?5D      $??75??5E      
??????????	#FF246844 J? RenderTransformOrigin$ 1.101,3.807&?5H   "   $??308,352,0,0q?6F   ?? 5J   
   -   5        $ BtnEdit??5K      $
??Edit??5L      $
??Left=?5M      $	??Top=?5N      $??75??5O      
??????????#13242C$ 1.101,3.807&?5R   #   $??396,352,0,0q?6G   ?? 5T   
   -   5        $ 	BtnDelete??5U      $??Delete??5V      $
??Left=?5W      $	??Top=?5X      $??75??5Y      
??????????	#FFD41B43$ 1.101,3.807&?5\   %   $??484,352,0,0q?6I   5]      5^      