   M S B A M L   `   `   `  ????B  >Zadatak, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ZadatakZadatak  5          Zadatak.EditPersonPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Zadatak     5        N? Title$  EditPage??5	      .??5      ? -   5         ?Name$ GridContainter??5   <      GradientBackground#??[  6   .+?5   
   ?? -   5         ??Name$ LvShoes??5   *   $??465,79,30,118q?6    ?? AlternationCount$ 2??6;   ??5      ?? 5       ?? 
TargetType" ??6   .?5      -   5        ?? 5       ?? Property ? ?? ?? Value
 ??ح?63    ?? Triggers 5      P? 5       P? Property ?@??AlternationIndex	 P? Value$	 1??6G   . ?5      ??  ? ??
 ?????6;   5      ]? 5      
 ]? 
Conditions
 5      ?? 5   "    ?? Property ?@??
IsSelected ?? Value . 6B   ./?5      ??  ? ??
 ???_?6;   5      5       ?? View 5       ?? 5!      .P?5"      ??  ?? Width$	 160??6%   $??Brend??61    ?? CellTemplate 5#      ?? 5$      .R?5%   "   ?? $??	Underline{?6C   
???   ? ? Cursor$
 Hand??6r   ??6,   ?? *Brand+ ? ToolTip 5&   &   ?? 5'   *    ??Name$ ShoesPicture??60   $??60??6f   $??60??6q   $??0,0,5,0q?6}   ??6F   ?? *ShoesPicture+6}   5)   #   5*      5,      ?? 5-      $	 140??6%   $
??Size??61    ?? DisplayMemberBinding 6?   ?? *Size+5.      50      ?? 52   
   -   5         ??Name$ BtnAddShoes??53      $??	Add Shoes??54      $
??Left=?55      $	??Top=?56      $??75??57      
??????????	#FF246844 J? RenderTransformOrigin$ 1.101,3.807&?5:   "   $??497,337,0,0q?6F   ?? 5<   
   -   5        $ BtnEditShoes??5=      $??
Edit Shoes??5>      $
??Left=?5?      $	??Top=?5@      $??75??5A      
??????????#13242C$ 1.101,3.807&?5D   #   $??585,337,0,0q?6G   ?? 5F   
   -   5        $ BtnDeleteShoes??5G      $??Delete Shoes??5H      $
??Left=?5I      $	??Top=?5J      $??75??5K      
??????????	#FFD41B43$ 1.101,3.807&?5N   %   $??673,337,0,0q?6I   ?? 5R   
   -   5        $ BtnBack??5S      
?????? 
?????? $
??Left=?5V      $	??Top=?5W      $??25??5X      $??25??5Y      $??30q?5Z      .??5\      ?? $??/Assets/back.png??6   5]      ?? 5_   
   $??First name:??5`      $
??Left=?5a      $??	32,81,0,0q?5b      $	??Top=?5c      ???	#FFF6F9FE5d      ?? 5f   
   -   5         ??Name$ TbFirstName??5g      $
??Left=?5h      $??23??5i      $??
109,80,0,0q?5j       ?? TextWrapping$
 Wrap=?5k      $	??Top=?5m      $	??107??6%   ??5l      ?? *	FirstName+5m   %   ?? 5o   
   $??
Last Name:??5p      $
??Left=?5q      $??
32,125,0,0q?5r      $	??Top=?5s      ???	#FFF6F9FE5t      ?? 5v   
   -	   5        $ 
TbLastName??5w      $
??Left=?5x      $??23??5y      $??109,126,0,0q?5z      $
 Wrap=?5{      $	??Top=?5}      $	??107??6%   ??5|      ?? *
LastName+5}   %   ?? 5   
   $	??Age??5?      $
??Left=?5?      $??
32,179,0,0q?5?      $	??Top=?5?      ???	#FFF6F9FE5?      ?? 5?   
   -
   5        $ TbAge??5?      $
??Left=?5?      $??23??5?      $??109,179,0,0q?5?      $
 Wrap=?5?      $	??Top=?5?      $	??107??5?      
 ? Tag$	 Int??5?      ??5?      ?? *Age+5?      ?? 5?   
   $??Email??5?      $
??Left=?5?      $??
32,227,0,0q?5?      $	??Top=?5?      ???	#FFF6F9FE5?      ?? 5?   
   -   5        $ TbEmail??5?      $
??Left=?5?      $??23??5?      $??109,227,0,0q?5?      $
 Wrap=?5?      $	??Top=?5?      $	??107??5?      $ Email??5?      ??5?      ?? *Email+5?      ?? 5?   
   -   5        $ 	BtnCommit??5?      $??Commit??5?      $
??Left=?5?      $	??Top=?5?      $??75??5?      $??30??5?      
??????????#13242C$??
32,299,0,0q?5?      ?? 5?   
   -   5        $ 	BtnUpload??5?      $??Upload Image??5?      $
??Left=?5?      $	??Top=?5?      $??96??5?      $??30??5?      
???????
??? ???$??120,299,0,0q?5?      ?? 5?   
   -   5         ??Name$ PictureBorder??5?      
???????$	??0.3q?5?      $??Right=?5?      $	??Top=?5?      $??
0,79,350,0q?6%   ._?5?      ?? -   5        $ Picture??5?      $??Uniform=?5?      $	??206??5?      $	??252??5?      ??5?      ?? *Image+5?      5?      5?      