è
4C:\Cds.BusinessCustomer\src\Api\Bootstrap\Program.cs
	namespace 	
Cds
 
. 
BusinessCustomer 
. 
Api "
." #
	Bootstrap# ,
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

static 
class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public   
static   
IHostBuilder   "
CreateHostBuilder  # 4
(  4 5
string  5 ;
[  ; <
]  < =
args  > B
)  B C
=>  D F
Host!! 
.!!  
CreateDefaultBuilder!! %
(!!% &
args!!& *
)!!* +
."" $
ConfigureWebHostDefaults"" )
("") *

webBuilder""* 4
=>""5 7
{## #
ConfigureWebHostBuilder$$ +
($$+ ,

webBuilder$$, 6
)$$6 7
;$$7 8
}%% 
)%% 
;%% 
public,, 
static,, 
IWebHostBuilder,, %#
ConfigureWebHostBuilder,,& =
(,,= >
IWebHostBuilder,,> M

webBuilder,,N X
),,X Y
{-- 	

webBuilder.. 
.// 
ConfigurePorts// 
(//  
)//  !
.00 %
ConfigureAppConfiguration00 *
(00* +
(00+ ,
context00, 3
,003 4
builder005 <
)00< =
=>00> @
AddConfiguration00A Q
(00Q R
builder00R Y
)00Y Z
)00Z [
.11 
ConfigureLogging11 !
(11! "
(11" #
context11# *
,11* +
builder11, 3
)113 4
=>115 7

AddLogging118 B
(11B C
context11C J
,11J K
builder11L S
)11S T
)11T U
.22 

UseMetrics22 
(22 
)22 
.33 

UseStartup33 
<33 
Startup33 #
>33# $
(33$ %
)33% &
;33& '
return55 

webBuilder55 
;55 
}66 	
private<< 
static<< 
void<< 
AddConfiguration<< ,
(<<, -!
IConfigurationBuilder<<- B
builder<<C J
)<<J K
{== 	
builderAA 
.CC "
AddKubernetesConfigMapCC '
(CC' (
)CC( )
.EE  
AddKubernetesSecretsEE %
(EE% &
)EE& '
;EE' (
}FF 	
privateMM 
staticMM 
voidMM 

AddLoggingMM &
(MM& '!
WebHostBuilderContextMM' <
contextMM= D
,MMD E
ILoggingBuilderMMF U
builderMMV ]
)MM] ^
{NN 	
builderOO 
.PP 
ClearProvidersPP 
(PP  
)PP  !
;PP! "
ifRR 
(RR 
contextRR 
.RR 
HostingEnvironmentRR *
.RR* +
IsDevelopmentRR+ 8
(RR8 9
)RR9 :
)RR: ;
{SS 
builderTT 
.UU 

AddConsoleUU 
(UU  
)UU  !
.VV 
AddDebugVV 
(VV 
)VV 
;VV  
}WW 
builderYY 
.ZZ 
AddConfigurationZZ !
(ZZ! "
contextZZ" )
.ZZ) *
ConfigurationZZ* 7
)ZZ7 8
.[[ 
AddMonithorLog4Net[[ #
([[# $
)[[$ %
;\\ 
}]] 	
}^^ 
}__ ©*
4C:\Cds.BusinessCustomer\src\Api\Bootstrap\Startup.cs
	namespace 	
Cds
 
. 
BusinessCustomer 
. 
Api "
." #
	Bootstrap# ,
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
Startup 
{ 
private 
readonly 
IConfiguration '
_configuration( 6
;6 7
private 
readonly 
IHostEnvironment )
_environment* 6
;6 7
public'' 
Startup'' 
('' 
IHostEnvironment'' '
environment''( 3
,''3 4
IConfiguration''5 C
configuration''D Q
)''Q R
{(( 	
_environment)) 
=)) 
environment)) &
??))' )
throw))* /
new))0 3!
ArgumentNullException))4 I
())I J
nameof))J P
())P Q
environment))Q \
)))\ ]
)))] ^
;))^ _
_configuration** 
=** 
configuration** *
??**+ -
throw**. 3
new**4 7!
ArgumentNullException**8 M
(**M N
nameof**N T
(**T U
configuration**U b
)**b c
)**c d
;**d e
}++ 	
public11 
void11 
ConfigureServices11 %
(11% &
IServiceCollection11& 8
services119 A
)11A B
{22 	
services33 
.44 
AddHealthChecks44  
(44  !
)44! "
.55 
AddCheck55 
(55 
$str55 #
,55# $
(55% &
)55& '
=>55( *
HealthCheckResult55+ <
.55< =
Healthy55= D
(55D E
$str55E I
)55I J
)55J K
;55K L
services77 
.99 
AddCustomSwaggerGen99 $
<99$ %
Startup99% ,
>99, -
(99- .
)99. /
.;; 
AddData;; 
(;; 
(;; 
builder;; !
);;! "
=>;;# %
{<< 
builder== 
.>> !
WithConfigurationRoot>> .
(>>. /
(>>/ 0
IConfigurationRoot>>0 B
)>>B C
_configuration>>C Q
)>>Q R
.?? 
AddSqlServer?? %
(??% &
)??& '
;@@ 
}AA 
)AA 
.CC  
AddDefaultHttpClientCC %
(CC% &
)CC& '
.EE "
AddResponseCompressionEE '
(EE' (
)EE( )
.GG 
AddDataProtectionGG "
(GG" #
)GG# $
;GG$ %
servicesII 
.KK 

AddMvcCoreKK 
(KK 
)KK 
.LL 
AddDataAnnotationsLL '
(LL' (
)LL( )
.MM 
AddAuthorizationMM %
(MM% &
)MM& '
.OO 
AddApiExplorerOO #
(OO# $
)OO$ %
.QQ 
AddUnifiedRestApiQQ &
(QQ& '
)QQ' (
;QQ( )
servicesTT 
.UU 
	AddScopedUU 
<UU 
ICartegieApiUU '
,UU' (
CartegieApiUU) 4
>UU4 5
(UU5 6
)UU6 7
.WW 
	AddScopedWW 
<WW 
IParametersHandlerWW -
,WW- .
ParametersHandlerWW/ @
>WW@ A
(WWA B
)WWB C
.YY 
AddSingletonYY 
(YY 
_configurationYY ,
.YY, -

GetSectionYY- 7
(YY7 8
$strYY8 O
)YYO P
.YYP Q
GetYYQ T
<YYT U!
CartegieConfigurationYYU j
>YYj k
(YYk l
)YYl m
)YYm n
;YYn o
}[[ 	
publicaa 
voidaa 
	Configureaa 
(aa 
IApplicationBuilderaa 1
applicationaa2 =
)aa= >
{bb 	
ifcc 
(cc 
_environmentcc 
.cc 
IsDevelopmentcc *
(cc* +
)cc+ ,
)cc, -
{dd 
applicationee 
.ff 
UseBrowserLinkff #
(ff# $
)ff$ %
.gg %
UseDeveloperExceptionPagegg .
(gg. /
)gg/ 0
.hh %
UseWebApiExceptionHandlerhh .
(hh. /
)hh/ 0
;hh0 1
}ii 
elsejj 
{kk 
applicationll 
.ll '
UseExceptionMonithorLoggingll 7
(ll7 8
)ll8 9
;ll9 :
}mm 
applicationoo 
.oo 

UseRoutingoo "
(oo" #
)oo# $
;oo$ %
applicationqq 
.rr "
UseResponseCompressionrr '
(rr' (
)rr( )
.ss 
UseCustomSwaggerss !
<ss! "
Startupss" )
>ss) *
(ss* +
)ss+ ,
.tt 
UseEndpointstt 
(tt 
	endpointstt '
=>tt( *
{uu 
	endpointsvv 
.vv 
MapControllersvv ,
(vv, -
)vv- .
;vv. /
	endpointsww 
.ww 
MapHealthChecksww -
(ww- .
)ww. /
;ww/ 0
}xx 
)xx 
;xx 
}yy 	
}zz 
}|| Ï_
MC:\Cds.BusinessCustomer\src\Api\CustomerFeature\BusinessCustomerController.cs
	namespace 	
Cds
 
. 
BusinessCustomer 
. 
Api "
." #
CustomerFeature# 2
{ 
[ 
Route 

(
 
$str +
)+ ,
], -
public 

class &
BusinessCustomerController +
:, -

Controller. 8
{ 
private 
readonly 
ICartegieApi %
_service& .
;. /
private 
readonly 
ILogger  
<  !&
BusinessCustomerController! ;
>; <
_logger= D
;D E
private 
readonly 
IParametersHandler +
_handler, 4
;4 5
public!! &
BusinessCustomerController!! )
(!!) *
ICartegieApi!!* 6
service!!7 >
,!!> ?
ILogger!!@ G
<!!G H&
BusinessCustomerController!!H b
>!!b c
logger!!d j
,!!j k
IParametersHandler!!l ~
handler	!! Ü
)
!!Ü á
{"" 	
_service## 
=## 
service## 
??## !
throw##" '
new##( +!
ArgumentNullException##, A
(##A B
nameof##B H
(##H I
service##I P
)##P Q
)##Q R
;##R S
_logger$$ 
=$$ 
logger$$ 
??$$ 
throw$$  %
new$$& )!
ArgumentNullException$$* ?
($$? @
nameof$$@ F
($$F G
logger$$G M
)$$M N
)$$N O
;$$O P
_handler%% 
=%% 
handler%% 
??%% !
throw%%" '
new%%( +!
ArgumentNullException%%, A
(%%A B
nameof%%B H
(%%H I
handler%%I P
)%%P Q
)%%Q R
;%%R S
}&& 	
[// 	
HttpGet//	 
]// 
[00 	 
ProducesResponseType00	 
(00 
StatusCodes00 )
.00) *
Status200OK00* 5
,005 6
Type007 ;
=00< =
typeof00> D
(00D E#
SingleCustomerViewModel00E \
)00\ ]
)00] ^
]00^ _
[11 	 
ProducesResponseType11	 
(11 
StatusCodes11 )
.11) *
Status200OK11* 5
,115 6
Type117 ;
=11< =
typeof11> D
(11D E&
MultipleCustomersViewModel11E _
)11_ `
)11` a
]11a b
[22 	 
ProducesResponseType22	 
(22 
StatusCodes22 )
.22) *
Status400BadRequest22* =
)22= >
]22> ?
[33 	 
ProducesResponseType33	 
(33 
StatusCodes33 )
.33) *
Status404NotFound33* ;
)33; <
]33< =
[44 	 
ProducesResponseType44	 
(44 
StatusCodes44 )
.44) *(
Status500InternalServerError44* F
)44F G
]44G H
public55 
async55 
Task55 
<55 
ActionResult55 &
<55& '
object55' -
>55- .
>55. /$
SearchByMultipleCriteria550 H
(55H I
[55I J
	FromQuery55J S
]55S T
string55U [
socialReason55\ h
,55h i
[55j k
	FromQuery55k t
]55t u
string55v |
zipCode	55} Ñ
,
55Ñ Ö
[
55Ü á
	FromQuery
55á ê
]
55ê ë
string
55í ò
siret
55ô û
)
55û ü
{66 	
try77 
{88 
if99 
(99 
string99 
.99 
IsNullOrEmpty99 (
(99( )
socialReason99) 5
)995 6
&&997 9
string99: @
.99@ A
IsNullOrEmpty99A N
(99N O
zipCode99O V
)99V W
&&99X Z
string99[ a
.99a b
IsNullOrEmpty99b o
(99o p
siret99p u
)99u v
)99v w
throw:: 
new:: !
ArgumentNullException:: 3
(::3 4
null::4 8
,::8 9
$str::: w
)::w x
;::x y
if<< 
(<< 
!<< 
string<< 
.<< 
IsNullOrEmpty<< )
(<<) *
siret<<* /
)<</ 0
)<<0 1
{== 
var>> 
isValid>> 
=>>  !
_handler>>" *
.>>* +
Validate>>+ 3
(>>3 4
siret>>4 9
)>>9 :
;>>: ;
if?? 
(?? 
!?? 
isValid??  
)??  !
throw@@ 
new@@ !
BadRequestException@@" 5
(@@5 6
$str@@6 ^
)@@^ _
;@@_ `#
CustomerSingleSearchDtoBB +
responseBB, 4
=BB5 6
awaitBB7 <
_serviceBB= E
.BBE F
GetInfosBySiretBBF U
(BBU V
siretBBV [
)BB[ \
;BB\ ]
ifDD 
(DD 
responseDD  
==DD! #
nullDD$ (
)DD( )
throwEE 
newEE !
NotFoundExceptionEE" 3
(EE3 4
$strEE4 c
)EEc d
;EEd e
returnGG 
OkGG 
(GG 
responseGG &
.GG& '
ToViewModelGG' 2
(GG2 3
)GG3 4
)GG4 5
;GG5 6
}HH 
elseJJ 
ifJJ 
(JJ 
!JJ 
stringJJ 
.JJ  
IsNullOrEmptyJJ  -
(JJ- .
zipCodeJJ. 5
)JJ5 6
||JJ7 9
!JJ: ;
stringJJ; A
.JJA B
IsNullOrEmptyJJB O
(JJO P
socialReasonJJP \
)JJ\ ]
)JJ] ^
{KK 
varLL 
isValidLL 
=LL  !
_handlerLL" *
.LL* +
ValidateLL+ 3
(LL3 4
socialReasonLL4 @
,LL@ A
zipCodeLLB I
)LLI J
;LLJ K
ifMM 
(MM 
!MM 
isValidMM  
)MM  !
throwNN 
newNN !
BadRequestExceptionNN" 5
(NN5 6
$strNN6 f
)NNf g
;NNg h
ListPP 
<PP %
CustomerMultipleSearchDtoPP 2
>PP2 3
responsePP4 <
=PP= >
awaitPP? D
_servicePPE M
.PPM N
GetInfosByCriteriaPPN `
(PP` a
socialReasonPPa m
,PPm n
zipCodePPo v
)PPv w
;PPw x
ifRR 
(RR 
responseRR  
==RR! #
nullRR$ (
)RR( )
throwSS 
newSS !
NotFoundExceptionSS" 3
(SS3 4
$strSS4 w
)SSw x
;SSx y
returnVV 
OkVV 
(VV 
responseVV &
.VV& '
ToViewModelVV' 2
(VV2 3
)VV3 4
)VV4 5
;VV5 6
}WW 
elseYY 
{ZZ 
throw[[ 
new[[ 
BadRequestException[[ 1
([[1 2
$str[[2 l
)[[l m
;[[m n
}\\ 
}]] 
catch^^ 
(^^ !
ArgumentNullException^^ (
e^^) *
)^^* +
{__ 
_logger`` 
.`` 
LogError``  
(``  !
$"``! #$
ArgumentNullException : ``# ;
{``; <
e``< =
.``= >
Message``> E
}``E F
"``F G
)``G H
;``H I
returnaa 
newaa 
BadRequestErroraa *
(aa* +
eaa+ ,
.aa, -
Messageaa- 4
)aa4 5
.aa5 6
Resultaa6 <
;aa< =
}cc 
catchdd 
(dd 
BadRequestExceptiondd &
edd' (
)dd( )
{ee 
_loggerff 
.ff 
LogErrorff  
(ff  !
$"ff! #!
BadRequetException : ff# 8
{ff8 9
eff9 :
.ff: ;
Messageff; B
}ffB C
"ffC D
)ffD E
;ffE F
returngg 
newgg 
BadRequestErrorgg *
(gg* +
egg+ ,
.gg, -
Messagegg- 4
)gg4 5
.gg5 6
Resultgg6 <
;gg< =
}hh 
catchii 
(ii 
NotFoundExceptionii #
eii$ %
)ii% &
{jj 
_loggerkk 
.kk 
LogErrorkk  
(kk  !
$"kk! #!
NotFoundException :  kk# 8
{kk8 9
ekk9 :
.kk: ;
Messagekk; B
}kkB C
"kkC D
)kkD E
;kkE F
returnll 
newll 
NotFoundErrorll (
(ll( )
ell) *
.ll* +
Messagell+ 2
)ll2 3
.ll3 4
Resultll4 :
;ll: ;
}mm 
catchnn 
(nn 
	Exceptionnn 
)nn 
{oo 
_loggerpp 
.pp 
LogErrorpp  
(pp  !
$strpp! W
)ppW X
;ppX Y
returnqq 

StatusCodeqq !
(qq! "
$numqq" %
)qq% &
;qq& '
}rr 
}ss 	
[zz 	
HttpGetzz	 
(zz 
$strzz 
)zz 
]zz 
[{{ 	 
ProducesResponseType{{	 
({{ 
StatusCodes{{ )
.{{) *
Status200OK{{* 5
,{{5 6
Type{{7 ;
={{< =
typeof{{> D
({{D E#
SingleCustomerViewModel{{E \
){{\ ]
){{] ^
]{{^ _
[|| 	 
ProducesResponseType||	 
(|| 
StatusCodes|| )
.||) *
Status404NotFound||* ;
)||; <
]||< =
[}} 	 
ProducesResponseType}}	 
(}} 
StatusCodes}} )
.}}) *(
Status500InternalServerError}}* F
)}}F G
]}}G H
public~~ 
async~~ 
Task~~ 
<~~ 
ActionResult~~ &
<~~& '#
SingleCustomerViewModel~~' >
>~~> ?
>~~? @

SearchById~~A K
(~~K L
[~~L M
	FromRoute~~M V
]~~V W
string~~X ^
Id~~_ a
)~~a b
{ 	
try
ÄÄ 
{
ÅÅ %
CustomerSingleSearchDto
ÇÇ '
response
ÇÇ( 0
=
ÇÇ1 2
await
ÇÇ3 8
_service
ÇÇ9 A
.
ÇÇA B
GetInfosById
ÇÇB N
(
ÇÇN O
Id
ÇÇO Q
)
ÇÇQ R
;
ÇÇR S
if
ÉÉ 
(
ÉÉ 
response
ÉÉ 
==
ÉÉ 
null
ÉÉ  $
)
ÉÉ$ %
{
ÑÑ 
throw
ÖÖ 
new
ÖÖ 
NotFoundException
ÖÖ /
(
ÖÖ/ 0
$str
ÖÖ0 a
)
ÖÖa b
;
ÖÖb c
}
ÜÜ 
return
áá 
Ok
áá 
(
áá 
response
áá "
.
áá" #
ToViewModel
áá# .
(
áá. /
)
áá/ 0
)
áá0 1
;
áá1 2
}
àà 
catch
ââ 
(
ââ 
NotFoundException
ââ #
e
ââ$ %
)
ââ% &
{
ää 
_logger
ãã 
.
ãã 
LogError
ãã  
(
ãã  !
$"
ãã! #"
NotFoundException : 
ãã# 7
{
ãã7 8
e
ãã8 9
.
ãã9 :
Message
ãã: A
}
ããA B
"
ããB C
)
ããC D
;
ããD E
return
åå 
new
åå 
NotFoundError
åå (
(
åå( )
e
åå) *
.
åå* +
Message
åå+ 2
)
åå2 3
.
åå3 4
Result
åå4 :
;
åå: ;
}
çç 
catch
éé 
(
éé 
	Exception
éé 
)
éé 
{
èè 
_logger
êê 
.
êê 
LogError
êê  
(
êê  !
$str
êê! V
)
êêV W
;
êêW X
return
ëë 

StatusCode
ëë !
(
ëë! "
$num
ëë" %
)
ëë% &
;
ëë& '
}
íí 
}
ìì 	
}
ïï 
}ññ ƒ
DC:\Cds.BusinessCustomer\src\Api\CustomerFeature\CustomerExtension.cs
	namespace 	
Cds
 
. 
BusinessCustomer 
. 
Api "
." #
CustomerFeature# 2
{ 
public 

static 
class 
CustomerExtension )
{ 
public 
static #
SingleCustomerViewModel -
ToViewModel. 9
(9 :
this: >#
CustomerSingleSearchDto? V
businessCustomerW g
)g h
{ 	
if 
( 
businessCustomer  
!=! #
null$ (
)( )
{ 
return 
new #
SingleCustomerViewModel 2
{ 
Name 
= 
businessCustomer +
.+ ,
Name, 0
,0 1
Adress 
= 
businessCustomer -
.- .
Adress. 4
,4 5
Siret 
= 
businessCustomer ,
., -
Siret- 2
,2 3
NafCode 
= 
businessCustomer .
.. /
NafCode/ 6
,6 7
Phone 
= 
businessCustomer ,
., -
Phone- 2
,2 3
ZipCode 
= 
businessCustomer .
.. /
ZipCode/ 6
,6 7
City 
= 
businessCustomer +
.+ ,
SocialReason, 8
,8 9
Civility 
= 
businessCustomer /
./ 0
Civility0 8
,8 9
SocialReason  
=! "
businessCustomer# 3
.3 4
SocialReason4 @
}   
;   
}!! 
return"" 
null"" 
;"" 
}## 	
public)) 
static)) 
IEnumerable)) !
<))! "&
MultipleCustomersViewModel))" <
>))< =
ToViewModel))> I
())I J
this))J N
IEnumerable))O Z
<))Z [%
CustomerMultipleSearchDto))[ t
>))t u
businessCustomers	))v á
)
))á à
{** 	
if++ 
(++ 
businessCustomers++ !
!=++" $
null++% )
)++) *
{,, 
List-- 
<-- &
MultipleCustomersViewModel-- /
>--/ 0
list--1 5
=--6 7
businessCustomers--8 I
.--I J
Select--J P
(--P Q
e--Q R
=>--S U
ToViewModel--V a
(--a b
e--b c
)--c d
)--d e
.--e f
ToList--f l
(--l m
)--m n
;--n o
return.. 
list.. 
;.. 
}// 
return00 
new00 
List00 
<00 &
MultipleCustomersViewModel00 6
>006 7
(007 8
)008 9
;009 :
}11 	
private88 
static88 &
MultipleCustomersViewModel88 1
ToViewModel882 =
(88= >
this88> B%
CustomerMultipleSearchDto88C \
e88] ^
)88^ _
{99 	
if:: 
(:: 
e:: 
!=:: 
null:: 
):: 
{;; 
return<< 
new<< &
MultipleCustomersViewModel<< 5
{== 
Id>> 
=>> 
e>> 
.>> 
Id>> 
,>> 
Name?? 
=?? 
e?? 
.?? 
Name?? !
,??! "
Adress@@ 
=@@ 
e@@ 
.@@ 
Adress@@ %
,@@% &
SocialReasonAA  
=AA! "
eAA# $
.AA$ %
SocialReasonAA% 1
,AA1 2
}BB 
;BB 
}CC 
returnDD 
nullDD 
;DD 
}FF 	
}GG 
}HH ¢	
IC:\Cds.BusinessCustomer\src\Api\CustomerFeature\Errors\BadRequestError.cs
	namespace 	
Cds
 
. 
BusinessCustomer 
. 
Api "
." #
CustomerFeature# 2
.2 3
Errors3 9
{ 
public		 

class		 
BadRequestError		  
{

 
public 

JsonResult 
Result  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
BadRequestError 
( 
string %
s& '
)' (
{ 	
Result 
= 
new 

JsonResult #
(# $
s$ %
)% &
{ 

StatusCode 
= 
StatusCodes (
.( )
Status400BadRequest) <
,< =
Value 
= 
new 
{ 
code "
=# $
$str% *
,* +
message, 3
=4 5
s6 7
}8 9
} 
; 
} 	
} 
} Í
GC:\Cds.BusinessCustomer\src\Api\CustomerFeature\Errors\NotFoundError.cs
	namespace 	
Cds
 
. 
BusinessCustomer 
. 
Api "
." #
CustomerFeature# 2
.2 3
Errors3 9
{ 
public		 

class		 
NotFoundError		 
{

 
public 

JsonResult 
Result  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
NotFoundError 
( 
string #
message$ +
)+ ,
{ 	
Result 
= 
new 

JsonResult #
(# $
message$ +
)+ ,
{ 

StatusCode 
= 
StatusCodes (
.( )
Status404NotFound) :
,: ;
Value 
= 
new 
{ 
message %
=& '
message( /
}0 1
} 
; 
} 	
} 
} ¿
QC:\Cds.BusinessCustomer\src\Api\CustomerFeature\Exceptions\BadRequestException.cs
	namespace 	
Cds
 
. 
BusinessCustomer 
. 
Api "
." #
CustomerFeature# 2
.2 3

Exceptions3 =
{ 
[ 
Serializable 
] 
public 

class 
BadRequestException $
:% &
	Exception' 0
{ 
public 
BadRequestException "
(" #
)# $
:$ %
base% )
() *
)* +
{ 	
} 	
public 
BadRequestException "
(" #
string# )
message* 1
,1 2
	Exception3 <
innerException= K
)K L
:L M
baseN R
(R S
messageS Z
,Z [
innerException\ j
)j k
{l m
}n o
	protected## 
BadRequestException## %
(##% &
SerializationInfo##& 7
info##8 <
,##< =
StreamingContext##> N
context##O V
)##V W
:$$ 
base$$	 
($$ 
info$$ 
,$$ 
context$$ 
)$$ 
{%% 	
}&& 	
public,, 
BadRequestException,, "
(,," #
string,,# )
s,,* +
),,+ ,
:-- 
base-- 
(-- 
s-- 
)-- 
{.. 	
}00 	
}11 
}22 	
OC:\Cds.BusinessCustomer\src\Api\CustomerFeature\Exceptions\NotFoundException.cs
	namespace 	
Cds
 
. 
BusinessCustomer 
. 
Api "
." #
CustomerFeature# 2
.2 3

Exceptions3 =
{ 
[ 
Serializable 
] 
public 

class 
NotFoundException "
:# $
	Exception% .
{ 
public 
NotFoundException  
(  !
)! "
{ 	
} 	
public 
NotFoundException  
(  !
string! '
s( )
)) *
: 
base 
( 
String 
. 
Format  
(  !
s! "
)" #
)# $
{ 	
} 	
public%% 
NotFoundException%%  
(%%  !
string%%! '
message%%( /
,%%/ 0
	Exception%%1 :
innerException%%; I
)%%I J
:&& 
base&& 
(&& 
message&& 
,&& 
innerException&& *
)&&* +
{'' 
}'' 
}(( 
})) ˙
PC:\Cds.BusinessCustomer\src\Api\CustomerFeature\Validation\IParametersHandler.cs
	namespace 	
Cds
 
. 
BusinessCustomer 
. 
Api "
." #
CustomerFeature# 2
.2 3

Validation3 =
{ 
public 

	interface 
IParametersHandler '
{ 
public 
bool 
Validate 
( 
string #
siret$ )
)) *
;* +
public 
bool 
Validate 
( 
string #
socialreason$ 0
,0 1
string2 8
zipcode9 @
)@ A
;A B
} 
} Î
OC:\Cds.BusinessCustomer\src\Api\CustomerFeature\Validation\ParametersHandler.cs
	namespace 	
Cds
 
. 
BusinessCustomer 
. 
Api "
." #
CustomerFeature# 2
.2 3

Validation3 =
{ 
public		 

class		 
ParametersHandler		 "
:		# $
IParametersHandler		% 7
{

 
private 
readonly 
ILogger  
<  !
ParametersHandler! 2
>2 3
_logger4 ;
;; <
public 
ParametersHandler  
(  !
ILogger! (
<( )
ParametersHandler) :
>: ;
logger< B
)B C
{ 	
_logger 
= 
logger 
; 
} 	
public 
bool 
Validate 
( 
string #
siret$ )
)) *
{ 	
if 
( 
string 
. 
IsNullOrEmpty $
($ %
siret% *
)* +
||, .
siret/ 4
.4 5
Length5 ;
!=< >
	Constants? H
.H I
SiretRequiredLengthI \
)\ ]
{ 
_logger 
. 
LogError  
(  !
$"! #5
)Failed to retreive customer with siret = # L
{L M
siretM R
}R S/
#, Siret string should be of length S v
{v w
	Constants	w Ä
.
Ä Å!
SiretRequiredLength
Å î
}
î ï
"
ï ñ
)
ñ ó
;
ó ò
return   
false   
;   
}!! 
return"" 
true"" 
;"" 
}## 	
public++ 
bool++ 
Validate++ 
(++ 
string++ #
socialreason++$ 0
,++0 1
string++2 8
zipcode++9 @
)++@ A
{,, 	
if-- 
(-- 
string-- 
.-- 
IsNullOrEmpty-- $
(--$ %
socialreason--% 1
)--1 2
&&--3 5
string--6 <
.--< =
IsNullOrEmpty--= J
(--J K
zipcode--K R
)--R S
)--S T
{.. 
_logger// 
.// 
LogError//  
(//  !
$str//! v
)//v w
;//w x
return00 
false00 
;00 
}11 
if22 
(22 
string22 
.22 
IsNullOrEmpty22 $
(22$ %
socialreason22% 1
)221 2
||223 5
string226 <
.22< =
IsNullOrEmpty22= J
(22J K
zipcode22K R
)22R S
)22S T
{33 
_logger44 
.44 
LogError44  
(44  !
$str44! r
)44r s
;44s t
return55 
false55 
;55 
}66 
return77 
true77 
;77 
}88 	
}99 
}:: ª	
XC:\Cds.BusinessCustomer\src\Api\CustomerFeature\ViewModels\MultipleCustomersViewModel.cs
	namespace 	
Cds
 
. 
BusinessCustomer 
. 
Api "
." #
CustomerFeature# 2
.2 3

ViewModels3 =
{ 
public 

class &
MultipleCustomersViewModel +
{ 
public &
MultipleCustomersViewModel )
() *
)* +
{, -
}. /
[ 	
Required	 
] 
public 
string 
Id 
{ 
get 
; 
set  #
;# $
}% &
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public"" 
string"" 
Adress"" 
{"" 
get"" "
;""" #
set""$ '
;""' (
}"") *
public'' 
string'' 
SocialReason'' "
{''# $
get''% (
;''( )
set''* -
;''- .
}''/ 0
})) 
}** ø
UC:\Cds.BusinessCustomer\src\Api\CustomerFeature\ViewModels\SingleCustomerViewModel.cs
	namespace 	
Cds
 
. 
BusinessCustomer 
. 
Api "
." #
CustomerFeature# 2
.2 3

ViewModels3 =
{ 
public 

class #
SingleCustomerViewModel (
{ 
public #
SingleCustomerViewModel &
(& '
)' (
{) *
}+ ,
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
	MaxLength	 
( 
$num 
) 
, 
	MinLength !
(! "
$num" $
)$ %
]% &
public 
string 
Siret 
{ 
get !
;! "
set# &
;& '
}( )
public"" 
string"" 
NafCode"" 
{"" 
get""  #
;""# $
set""% (
;""( )
}""* +
public'' 
string'' 
Adress'' 
{'' 
get'' "
;''" #
set''$ '
;''' (
}'') *
public,, 
string,, 
Phone,, 
{,, 
get,, !
;,,! "
set,,# &
;,,& '
},,( )
public11 
string11 
ZipCode11 
{11 
get11  #
;11# $
set11% (
;11( )
}11* +
public66 
string66 
City66 
{66 
get66  
;66  !
set66" %
;66% &
}66' (
public;; 
string;; 
SocialReason;; "
{;;# $
get;;% (
;;;( )
set;;* -
;;;- .
};;/ 0
public@@ 
string@@ 
Civility@@ 
{@@  
get@@! $
;@@$ %
set@@& )
;@@) *
}@@+ ,
}BB 
}CC 