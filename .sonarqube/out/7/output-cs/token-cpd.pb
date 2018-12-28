Ì
>D:\WorkSpace\Rasot\src\Library\Rasot.Core\Domain\BaseEntity.cs
	namespace 	
Rasot
 
. 
Core 
. 
Domain 
{ 
public 

abstract 
class 

BaseEntity $
{ 
public		 
int		 
Id		 
{		 
get		 
;		 
set		  
;		  !
}		" #
} 
} ±
AD:\WorkSpace\Rasot\src\Library\Rasot.Core\Domain\Contents\Page.cs
	namespace 	
Rasot
 
. 
Core 
. 
Domain 
. 
Contents $
{ 
class 	
Page
 
{ 
}		 
}

 î
FD:\WorkSpace\Rasot\src\Library\Rasot.Core\Domain\Customers\Customer.cs
	namespace 	
Rasot
 
. 
Core 
. 
Domain 
. 
	Customers %
{ 
public 

class 
Customer 
: 

BaseEntity $
{ 
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
PasswordSalt "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
int 
PasswordFormatType %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
}		 
}

 