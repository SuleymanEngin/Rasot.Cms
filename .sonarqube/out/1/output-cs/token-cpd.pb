ù
^D:\WorkSpace\Rasot\src\Library\Rasot.Service\Services\Authentications\AuthenticationService.cs
	namespace 	
Rasot
 
. 
Service 
. 
Services  
.  !
Authentications! 0
{ 
public 

class !
AuthenticationService &
:' ("
IAuthenticationService) ?
{ 
public 
void 
Login 
( 
LoginRequest &
loginRequest' 3
)3 4
{		 	
throw

 
new

 #
NotImplementedException

 -
(

- .
)

. /
;

/ 0
} 	
public 
void 
Register 
( 
RegisterRequest ,
registerRequest- <
)< =
{ 	
throw 
new #
NotImplementedException -
(- .
). /
;/ 0
} 	
} 
} š
_D:\WorkSpace\Rasot\src\Library\Rasot.Service\Services\Authentications\IAuthenticationService.cs
	namespace 	
Rasot
 
. 
Service 
. 
Services  
.  !
Authentications! 0
{ 
public 

	interface "
IAuthenticationService ,
{ 
void 
Register 
( 
RegisterRequest %
registerRequest& 5
)5 6
;6 7
void 
Login 
( 
LoginRequest 
loginRequest  ,
), -
;- .
}		 
}

 Ì
\D:\WorkSpace\Rasot\src\Library\Rasot.Service\Services\Authentications\Models\LoginRequest.cs
	namespace 	
Rasot
 
. 
Service 
. 
Services  
.  !
Authentications! 0
.0 1
Models1 7
{ 
public 

class 
LoginRequest 
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
}+ ,
} 
} –
]D:\WorkSpace\Rasot\src\Library\Rasot.Service\Services\Authentications\Models\LoginResponse.cs
	namespace 	
Rasot
 
. 
Service 
. 
Services  
.  !
Authentications! 0
.0 1
Models1 7
{ 
public 

class 
LoginResponse 
{ 
public 
IList 
< 
string 
> 
Errors #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
bool 
Success 
=> 
Errors %
.% &
Count& +
==, .
$num/ 0
;0 1
}		 
}

 î
_D:\WorkSpace\Rasot\src\Library\Rasot.Service\Services\Authentications\Models\RegisterRequest.cs
	namespace 	
Rasot
 
. 
Service 
. 
Services  
.  !
Authentications! 0
.0 1
Models1 7
{ 
public 

class 
RegisterRequest  
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
UserName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
}		 œ
`D:\WorkSpace\Rasot\src\Library\Rasot.Service\Services\Authentications\Models\RegisterResponse.cs
	namespace 	
Rasot
 
. 
Service 
. 
Services  
.  !
Authentications! 0
.0 1
Models1 7
{ 
public 

class 
RegisterResponse !
{ 
public 
IList 
< 
string 
> 
Errors #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
bool 
Success 
=> 
Errors %
.% &
Count& +
==, .
$num/ 0
;0 1
}		 
}

 “
RD:\WorkSpace\Rasot\src\Library\Rasot.Service\Services\Customers\CustomerService.cs
	namespace 	
Rasot
 
. 
Service 
. 
Services  
.  !
	Customers! *
{ 
public 

class 
CustomerService  
:! "
ICustomerService# 3
{ 
public 
void 
Insert 
( 
Customer #
item$ (
)( )
{ 	
item		 
.		 
Id		 
=		 
$num		 
;		 
}

 	
} 
} è
SD:\WorkSpace\Rasot\src\Library\Rasot.Service\Services\Customers\ICustomerService.cs
	namespace 	
Rasot
 
. 
Service 
. 
Services  
.  !
	Customers! *
{ 
public 

	interface 
ICustomerService %
{		 
void

 
Insert

 
(

 
Customer

 
item

 !
)

! "
;

" #
} 
} 