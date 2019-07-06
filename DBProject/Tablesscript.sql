

IF not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBScriptLog]') AND TYPE IN (N'U'))
Begin 

CREATE TABLE [dbo].[DBScriptLog](
	[iScriptID] bigint NOT NULL,
	[dDate] [date] NOT NULL,
	[vDescription] [varchar](8000) NULL
) ON [PRIMARY]
-- Table Created Mow Insert First Log 
insert into DBScriptLog(iScriptID,dDate,vDescription) values(1,GetDate(),'Script No#1 -- Dated 06-17-2012 -- Atif -- [dbo].[DBScriptLog] is created')

End 

else
begin 
Print('DBScriptLog is already created')
end 

-- *************************** Script No#2 -- Dated 06-17-2012 -- Atif -- Create AppUserTable*************************************
if not exists (select * from DBScriptLog where iScriptID >=2)
Begin
	

	/****** Object:  Table [dbo].[AppUsers]    Script Date: 06/17/2013 14:42:33 ******/

CREATE TABLE [dbo].[AppUsers](
	[iUserid] [int] IDENTITY(1,1) NOT NULL,
	[vfName] [varchar](150) NULL,
	[vlName] [varchar](150) NULL,
	[dDOB] [datetime] NULL,
	[vUserType] [varchar](50) NULL,
	[vLogin] [varchar](50) NULL,
	[vPassword] [varchar](100) NULL,
	[dLastLoginTime] [datetime] NULL,
	[vEmail] [varchar](50) NULL,
 CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED 
(
	[iUserid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


	insert into DBScriptLog(iScriptID,dDate,vDescription) values(2,GetDate(),'Script No#2 -- Dated 06-17-2012 -- Atif -- Create AppUserTable')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'

Go





-- *************************** Script No#3 -- Dated 06-17-2012 -- Atif -- Insert First User*************************************
if not exists (select * from DBScriptLog where iScriptID >=3)
Begin
	

insert into appusers values('ammar','ghaffar','2/2/1982','MD Admin','a','a','9/9/2011','ammar@gmail.com')

	insert into DBScriptLog(iScriptID,dDate,vDescription) values(3,GetDate(),'Script No#3 -- Dated 06-17-2012 -- Atif -- Insert First User')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'

Go



-- *************************** Script No#4 -- Dated 06-18-2012 -- Atif -- Create Table posItems*************************************
if not exists (select * from DBScriptLog where iScriptID >=4)
Begin
	
	
CREATE TABLE [dbo].[posItems](
	[iItemID] [int] IDENTITY(1,1) NOT NULL,
	[vItemName] [varchar](250) NULL,
	[vDetailName] [varchar](250) NULL,
	[bFuzzyDelented] [bit] NULL,
	[vCompanyName] [varchar](250) NULL,
	[fUnitePrice] [float] NULL,
	[fMaxDiscountPresent] [float] NULL,
	[vItemBarcode] [varchar](255) NULL,
 CONSTRAINT [PK_posItem] PRIMARY KEY CLUSTERED 
(
	[iItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



insert into DBScriptLog(iScriptID,dDate,vDescription) values(4,GetDate(),'Script No#4 -- Dated 06-18-2012 -- Atif -- Create Table posItems')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'

Go



-- *************************** Script No#5 -- Dated 06-27-2013 -- Atif -- Create Table posParty *************************************
if not exists (select * from DBScriptLog where iScriptID >=5)
Begin
	
	
CREATE TABLE [dbo].[posParty](
	[iPartyID] [bigint] IDENTITY(1,1) NOT NULL,
	[vPartyName] [varchar](255) NULL,
	[vPartyadress] [varchar](255) NULL,
	[vpartyMobile] [varchar](25) NULL,
	[iSaleManID] [int] NULL,
 CONSTRAINT [PK_posParty] PRIMARY KEY CLUSTERED 
(
	[iPartyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


insert into DBScriptLog(iScriptID,dDate,vDescription) values(5,GetDate(),'Script No#5 -- Dated 06-27-2013 -- Atif -- Create Table posParty')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'

Go



-- *************************** Script No#6 -- Dated 06-27-2013 -- Atif -- Create Table posSaleInovice *************************************
if not exists (select * from DBScriptLog where iScriptID >=6)
Begin
	
	
CREATE TABLE [dbo].[posSaleInovice](
	[iSaleid] [bigint] IDENTITY(1,1) NOT NULL,
	[ipartyId] [int] NULL,
	[ddate] [datetime] NULL,
	[vpartyName] [varchar](255) NULL,
	[vpartymobile] [varchar](25) NULL,
	[ftotalamount] [float] NULL,
	[vPaymentMod] [varchar](255) NULL,
	[vVehicleNo] [varchar](25) NULL,
	[vDriverName] [varchar](255) NULL,
	[iUserid] [bigint] NULL,
	[vDeliveryExpense] [varchar](50) NULL,
	[vSeason] [varchar](50) NULL,
	[iDiscountPersent] [int] NULL,
	[fPayAbleAmount] [float] NULL,
	[fAmmountRecived] [float] NULL,
	[vReciverName] [varchar](150) NULL,
	[iSaleManID] [bigint] NULL,
	[fBalance] [float] NULL,
 CONSTRAINT [PK_posSaleInovice] PRIMARY KEY CLUSTERED 
(
	[iSaleid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


insert into DBScriptLog(iScriptID,dDate,vDescription) values(6,GetDate(),'Script No#6 -- Dated 06-27-2013 -- Atif -- Create Table posSaleInovice')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'

Go





-- *************************** Script No#8 -- Dated 06-27-2013 -- Atif -- Create Table posSaleItem *************************************
if not exists (select * from DBScriptLog where iScriptID >=8)
Begin
	
CREATE TABLE [dbo].[posSaleItem](
	[iSaleItemid] [bigint] IDENTITY(1,1) NOT NULL,
	[iSaleid] [bigint]  NULL,
	[fUnitePrice] [float] NULL,
	[iQuantity] [int] NULL,
	[fGrossAmount] [float] NULL,
	[iItemID] [int] NULL,
 CONSTRAINT [PK_posSsaleItem] PRIMARY KEY CLUSTERED 
(
	[iSaleItemid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into DBScriptLog(iScriptID,dDate,vDescription) values(8,GetDate(),'Script No#8 -- Dated 06-27-2013 -- Atif -- Create Table posSaleItem')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'

Go



-- *************************** Script No#9 -- Dated 06-27-2013 -- Atif -- Create Table posSaleMan *************************************
if not exists (select * from DBScriptLog where iScriptID >=9)
Begin
	
CREATE TABLE [dbo].[posSaleMan](
	[iSaleManID] [bigint] IDENTITY(1,1) NOT NULL,
	[vSaleManName] [varchar](255) NULL,
	[vAddresss] [varchar](255) NULL,
	[vMobile] [varchar](255) NULL,
 CONSTRAINT [PK_posSaleMan] PRIMARY KEY CLUSTERED 
(
	[iSaleManID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into DBScriptLog(iScriptID,dDate,vDescription) values(9,GetDate(),'Script No#9 -- Dated 06-27-2013 -- Atif -- Create Table posSaleMan')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'

Go


-- *************************** Script No#10 -- Dated 06-27-2013 -- Atif -- Create Table posStock *************************************
if not exists (select * from DBScriptLog where iScriptID >=10)
Begin
	
CREATE TABLE [dbo].[posStock](
	[iStokId] [bigint] IDENTITY(1,1) NOT NULL,
	[iItemID] [int] NULL,
	[iCurrantStock] [int] NULL,
	[iUserId] [int] NULL,
	[iStockIn] [int] NULL,
	[iStockOut] [int] NULL,
	[iSaleId] [int] NULL,
	[iProductionId] [int] NULL,
 CONSTRAINT [PK_posStock] PRIMARY KEY CLUSTERED 
(
	[iStokId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into DBScriptLog(iScriptID,dDate,vDescription) values(10,GetDate(),'Script No#10 -- Dated 06-27-2013 -- Atif -- Create Table posStock')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'

Go
-- *************************** Script No#11 -- Dated 08-13-2013 -- Atif -- Add Sr# Colum in posSaleItem *************************************
if not exists (select * from DBScriptLog where iScriptID >=11)
Begin
	
ALTER TABLE dbo.posSaleItem ADD
	iSerialNumber int NULL

insert into DBScriptLog(iScriptID,dDate,vDescription) values(11,GetDate(),'Script No#11 -- Dated 08-13-2013 -- Atif -- Add Sr# Colum in posSaleItem')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'

Go

-- *************************** Script No#12 -- Dated 08-13-2013 -- Atif -- Add  AmountwithDExpense Colum in posSaleInovice *************************************
if not exists (select * from DBScriptLog where iScriptID >=12)
Begin
	
ALTER TABLE  posSaleInovice ADD
	AmountwithDExpense float NULL

insert into DBScriptLog(iScriptID,dDate,vDescription) values(12,GetDate(),'Script No#12 -- Dated 08-13-2013 -- Atif -- Add  AmountwithDExpense Colum in posSaleInovice ')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'

Go

-- *************************** Script No#13 -- Dated 08-16-2013 -- Atif -- Add  vpartyAddress Colum in posSaleInovice *************************************
if not exists (select * from DBScriptLog where iScriptID >=13)
Begin
	
ALTER TABLE  posSaleInovice ADD
	vpartyAddress text NULL

insert into DBScriptLog(iScriptID,dDate,vDescription) values(13,GetDate(),'Script No#13 -- Dated 08-16-2013 -- Atif -- Add  vpartyAddress Colum in posSaleInovice')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'

Go

-- *************************** Script No#14 -- Dated 09-04-2013 -- Atif -- Add  dDate  Colum in posStock *************************************
if not exists (select * from DBScriptLog where iScriptID >=14)
Begin
	
ALTER TABLE dbo.posStock ADD
	dDate datetime NULL

insert into DBScriptLog(iScriptID,dDate,vDescription) values(14,GetDate(),'Script No#14 -- Dated 09-04-2013 -- Atif -- Add  dDate  Colum in posStock ')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'

Go


-- *************************** Script No#15 -- Dated 09-09-2013 -- Atif -- Add Colums in posParty *************************************
if not exists (select * from DBScriptLog where iScriptID >=15)
Begin
	
ALTER TABLE dbo.posParty ADD
	iCreditLimit bigint NULL,
	vMarket varchar(250) NULL,
	vArea varchar(250) NULL,
	vDistrict varchar(250) NULL,
	VCity varchar(250) NULL

insert into DBScriptLog(iScriptID,dDate,vDescription) values(15,GetDate(),'Script No#15 -- Dated 09-09-2013 -- Atif -- Add Colums in posParty')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

-- *************************** Script No#16 -- Dated 09-09-2013 -- Atif -- Add Colums in posParty *************************************
if not exists (select * from DBScriptLog where iScriptID >=16)
Begin
	
ALTER TABLE dbo.posParty ADD
	vContactPerson varchar(250) NULL,
	vLandlineNumber varchar(25) NULL

insert into DBScriptLog(iScriptID,dDate,vDescription) values(16,GetDate(),'Script No#16 -- Dated 09-09-2013 -- Atif -- Add Colums in posParty')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



-- *************************** Script No#17 -- Dated 09-09-2013 -- Atif -- Add Colum vAction in posStock *************************************
if not exists (select * from DBScriptLog where iScriptID >=17)
Begin
	
ALTER TABLE dbo.posStock ADD
	vAction  varchar(250) NULL

insert into DBScriptLog(iScriptID,dDate,vDescription) values(17,GetDate(),'Script No#17 -- Dated 09-09-2013 -- Atif -- Add Colums in posParty')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-- *************************** Script No#18 -- Dated 10-02-2013 -- Atif -- Add table posPurchase *************************************
if not exists (select * from DBScriptLog where iScriptID >=18)
Begin

CREATE TABLE [dbo].[posPurchase](
	[iPurchaseid] [bigint] IDENTITY(1,1) NOT NULL,
	[ipartyId] [int] NULL,
	[ddate] [datetime] NULL,
	[ftotalamount] [float] NULL,
	[vPaymentMod] [varchar](255) NULL,
	[vVehicleNo] [varchar](25) NULL,
	[vDriverName] [varchar](255) NULL,
	[iUserid] [bigint] NULL,
	[vDeliveryExpense] [varchar](50) NULL,
	[vSeason] [varchar](50) NULL,
	[iDiscountPersent] [int] NULL,
	[fPayAbleAmount] [float] NULL,
	[fAmmountRecived] [float] NULL,
	[vReciverName] [varchar](150) NULL,
	[iPurchaseManID] [bigint] NULL,
	[fBalance] [float] NULL,
	[AmountwithDExpense] [float] NULL,
	[formnumber] [bigint] null
 CONSTRAINT [PK_posPurchase] PRIMARY KEY CLUSTERED 
(
	[iPurchaseid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
insert into DBScriptLog(iScriptID,dDate,vDescription) values(18,GetDate(),'Script No#18 -- Dated 10-02-2013 -- Atif -- Add table posPurchase ')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-- *************************** Script No#19 -- Dated 10-03-2013 -- Atif -- Add table posEmployeeType *************************************
if not exists (select * from DBScriptLog where iScriptID >=19)
Begin

		CREATE TABLE [dbo].[posEmpType](
		[iEmpTypeId] [int] IDENTITY(1,1) NOT NULL,
		[vEmpType] [varchar](100) NULL,
		[vEmpTypeDes] [varchar](150) NULL,
	 CONSTRAINT [PK_EmpType] PRIMARY KEY CLUSTERED 
	(
		[iEmpTypeId] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

insert into DBScriptLog(iScriptID,dDate,vDescription) values(19,GetDate(),'Script No#19 -- Dated 10-03-2013 -- Atif -- Add table posEmployeeType')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-- *************************** Script No#20 -- Dated 10-03-2013 -- Atif -- Add table posEmployee *************************************
if not exists (select * from DBScriptLog where iScriptID >=20)
Begin

		CREATE TABLE [dbo].[posEmployee](
			[iEmpid] [int] IDENTITY(1,1) NOT NULL,
			[vTitle] [varchar](50) NULL,
			[vEmpfName] [varchar](150) NULL,
			[vEmplName] [varchar](150) NULL,
			[vMartialStatus] [varchar](50) NULL,
			[vEmployeeType] [varchar](50) NULL,
			[vIdNumber] [varchar](150) NULL,
			[vPassportNo] [varchar](100) NULL,
			[vAddress] [varchar](50) NULL,
			[vCity] [varchar](100) NULL,
			[vNationality] [varchar](100) NULL,
			[iMobile] varchar(50) NULL,
			[vDesignation] [varchar](50) NULL,
			[dDateOfJoining] [datetime] NULL,
			[vDescription] [varchar](200) NULL,
			[Active] [bit] NULL,
			[iBasicSalary] [int] NULL,
			[iHousing] [int] NULL,
			[iTraveling] [int] NULL,
			[iTotalSalary] [int] NULL,
			[iMiscellaneous] [int] NULL,
			[vLastPaidSalaryMonth] [varchar](50) NULL,
			[iHourlyRate] [int] NULL,
			[dLastPaidSalaryDay] [datetime] NULL,
			[iSalaryDue] [int] NULL,
			[iDeduction] [int] NULL,
			[iBalance] [int] NULL,
			[vAccountNo] [varchar](50) NULL,
			[iTranid] [int] NULL,
			[bIsGenerated] [bit] NULL,
			[iEmpTypeId] [int] NULL,
		 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
		(
			[iEmpid] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

insert into DBScriptLog(iScriptID,dDate,vDescription) values(20,GetDate(),'Script No#19 -- Dated 10-03-2013 -- Atif -- Add table posEmployeeType')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-- *************************** Script No#21 -- Dated 10-03-2013 -- Atif -- Add table posPurchaseItem *************************************
if not exists (select * from DBScriptLog where iScriptID >=21)
Begin

CREATE TABLE [dbo].[posPurchaseItem](
	[iPurchaseItemid] [bigint] IDENTITY(1,1) NOT NULL,
	[iPurchaseid] [bigint] NULL,
	[fUnitePrice] [float] NULL,
	[iQuantity] [int] NULL,
	[fGrossAmount] [float] NULL,
	[iItemID] [int] NULL,
	[iSerialNumber] [int] NULL,
 CONSTRAINT [PK_posSPurchaseItem] PRIMARY KEY CLUSTERED 
(
	[iPurchaseItemid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


insert into DBScriptLog(iScriptID,dDate,vDescription) values(21,GetDate(),'Script No#21 -- Dated 10-03-2013 -- Atif -- Add table posPurchaseItem ')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-- *************************** Script No#22 -- Dated 10-10-2013 -- Atif -- Add table posProduction *************************************
if not exists (select * from DBScriptLog where iScriptID >=22)
Begin
CREATE TABLE [dbo].[posProduction](
	[iProductionId] [bigint] IDENTITY(1,1) NOT NULL,
	[dDate] [datetime] NULL,
	[vLocation] [varchar](255) NULL,
	[vPurchaseManager] [varchar](255) NULL,
	[vProductionUnit] [varchar](255) NULL,
	[fProductionCast] [float] NULL,
 CONSTRAINT [PK_posProduction] PRIMARY KEY CLUSTERED 
(
	[iProductionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into DBScriptLog(iScriptID,dDate,vDescription) values(22,GetDate(),'Script No#22 -- Dated 10-10-2013 -- Atif -- Add table posProduction')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



-- *************************** Script No#23 -- Dated 28-10-2013 -- Atif -- Add table posProductionItem *************************************
if not exists (select * from DBScriptLog where iScriptID >=23)
Begin
CREATE TABLE [dbo].[posProductionItem](
	[iProductionItemid] [bigint] IDENTITY(1,1) NOT NULL,
	[iProductionid] [bigint] NULL,
	[fUnitePrice] [float] NULL,
	[iQuantity] [int] NULL,
	[fGrossAmount] [float] NULL,
	[iItemID] [int] NULL,
	[iSerialNumber] [int] NULL,
	[iItemType] [int] NULL
 CONSTRAINT [PK_posSProductionItem] PRIMARY KEY CLUSTERED 
(
	[iProductionItemid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into DBScriptLog(iScriptID,dDate,vDescription) values(23,GetDate(),'Script No#23 -- Dated 28-10-2013 -- Atif -- Add table posProductionItem ')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

-- *************************** Script No#24 -- Dated 4-11-2013 -- Atif -- alter formnumber field in posPurchase  *************************************
if not exists (select * from DBScriptLog where iScriptID >=24)
Begin

ALTER TABLE posPurchase
ALTER COLUMN formnumber varchar(255)

insert into DBScriptLog(iScriptID,dDate,vDescription) values(24,GetDate(),'Script No#24 -- Dated 4-11-2013 -- Atif -- alter formnumber field in posPurchase  ')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

-- *************************** Script No#25 -- Dated 5-11-2013 -- Atif -- alter table posItem add caolumn bIsSaleAble  *************************************
if not exists (select * from DBScriptLog where iScriptID >=25)
Begin

ALTER TABLE dbo.posItems ADD
	bIsSaleAble bit NULL

insert into DBScriptLog(iScriptID,dDate,vDescription) values(25,GetDate(),'Script No#25 -- Dated 5-11-2013 -- Atif -- alter table posItem add caolumn bIsSaleAble')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go




-- *************************** Script No#26 -- Dated 6-11-2013 -- Atif -- Add Table posPreference *************************************
if not exists (select * from DBScriptLog where iScriptID >=26)
Begin

CREATE TABLE dbo.posPreference
	(
	iCompanyID int NOT NULL IDENTITY (1, 1),
	imLogoImage image NULL,
	vHeaderText varchar(500) NULL,
	bIsActive bit NULL,
	vDateFormat varchar(100) NULL,
	bStockOverRide bit NULL,
	vSaleType varchar(150) NULL,
	bDefaultCustomer bit NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]

	ALTER TABLE dbo.posPreference ADD CONSTRAINT
	PK_posPreference PRIMARY KEY CLUSTERED 
	(
	iCompanyID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]



insert into DBScriptLog(iScriptID,dDate,vDescription) values(26,GetDate(),'Script No#26 -- Dated 6-11-2013 -- Atif -- Add Table posPreference')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



-- *************************** Script No#27 -- Dated 6-11-2013 -- Atif -- Insert Party *************************************
if not exists (select * from DBScriptLog where iScriptID >=27)
Begin

SET IDENTITY_INSERT [dbo].[posParty] ON
--INSERT [dbo].[posParty] ([iPartyID], [vPartyName], [vPartyadress], [vpartyMobile], [iSaleManID], [iCreditLimit], [vMarket], [vArea], [vDistrict], [VCity], [vContactPerson], [vLandlineNumber]) VALUES (1, N'Abfa', N'Testing Market , Area Goes here , Lahore , Multan', N'0425557750', 3, 500, N'Testing Market', N'Area Goes here', N'Lahore', N'Multan', N'Atif', N'042')
SET IDENTITY_INSERT [dbo].[posParty] OFF

insert into DBScriptLog(iScriptID,dDate,vDescription) values(27,GetDate(),'Script No#27 -- Dated 6-11-2013 -- Atif -- Insert Party')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



-- *************************** Script No#28 -- Dated 7-11-2013 -- Atif -- Add Col to PosInovice *************************************
if not exists (select * from DBScriptLog where iScriptID >=28)
Begin

ALTER TABLE dbo.posSaleInovice ADD
	bCanelDone bit NULL,
	bReturnInvoice bit NULL

insert into DBScriptLog(iScriptID,dDate,vDescription) values(28,GetDate(),'Script No#28 -- Dated 7-11-2013 -- Atif -- Add Col to PosInovice')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go





-- *************************** Script No#29 -- Dated 13-11-2013 -- Atif -- Add Col to poprefrence *************************************
if not exists (select * from DBScriptLog where iScriptID >=29)
Begin

ALTER TABLE dbo.posPreference ADD
	bDurationReturnOnly bit NULL,
	iAllowedBackDays int NULL

insert into DBScriptLog(iScriptID,dDate,vDescription) values(29,GetDate(),'Script No#29 -- Dated 13-11-2013 -- Atif -- Add Col to poprefrence')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



-- *************************** Script No#30 -- Dated 18-11-2013 -- Atif -- Add Col iProductionItemType to posProductionItem*************************************
if not exists (select * from DBScriptLog where iScriptID >=30)
Begin

ALTER TABLE dbo.posProductionItem ADD
	iProductionItemType int NULL

insert into DBScriptLog(iScriptID,dDate,vDescription) values(30,GetDate(),'Script No#30 -- Dated 18-11-2013 -- Atif -- Add Col iProductionItemType to posProductionItem')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



-- *************************** Script No#31 -- Dated 22-11-2013 -- Atif -- Add Records for saleman *************************************
if not exists (select * from DBScriptLog where iScriptID >=31)
Begin

SET IDENTITY_INSERT [dbo].[posSaleMan] ON
INSERT [dbo].[posSaleMan] ([iSaleManID], [vSaleManName], [vAddresss], [vMobile]) VALUES (1, N'Rizwan', N'178 k2', N'03007478650')
INSERT [dbo].[posSaleMan] ([iSaleManID], [vSaleManName], [vAddresss], [vMobile]) VALUES (2, N'Irfan', N'178 k2', N'03007478650')
INSERT [dbo].[posSaleMan] ([iSaleManID], [vSaleManName], [vAddresss], [vMobile]) VALUES (3, N'Ali Raza', N'178 k2', N'03007478650')
SET IDENTITY_INSERT [dbo].[posSaleMan] OFF


insert into DBScriptLog(iScriptID,dDate,vDescription) values(31,GetDate(),'Script No#31 -- Dated 22-11-2013 -- Atif -- Add Records for saleman')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go




-- *************************** Script No#32 -- Dated 25-11-2013 -- Atif -- Create TABLE  posModule *************************************
if not exists (select * from DBScriptLog where iScriptID >=32)
Begin

CREATE TABLE dbo.posModule
	(
	iModuleID int NOT NULL IDENTITY (1, 1),
	vModuleName varchar(255) NULL,
	bIsActive bit NULL
	)  ON [PRIMARY]
ALTER TABLE dbo.posModule ADD CONSTRAINT
	PK_posModule PRIMARY KEY CLUSTERED 
	(
	iModuleID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


insert into DBScriptLog(iScriptID,dDate,vDescription) values(32,GetDate(),' Script No#32 -- Dated 25-11-2013 -- Atif -- Create TABLE  posModule')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go





-- *************************** Script No#33 -- Dated 25-11-2013 -- Atif -- AddColum iModuleParentID,vUrlPath,UriKind*************************************
if not exists (select * from DBScriptLog where iScriptID >=33)
Begin

ALTER TABLE dbo.posModule ADD
	iModuleParentID int NULL,
	vUrlPath varchar(255) NULL,
	UriKind varchar(150) NULL,
	vDisplayName varchar(150) NULL
insert into DBScriptLog(iScriptID,dDate,vDescription) values(33,GetDate(),'Script No#33 -- Dated 25-11-2013 -- Atif -- AddColum iModuleParentID')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


---- *************************** Script No#33 -- Dated 25-11-2013 -- Atif -- AddColum iModuleParentID,vUrlPath,UriKind*************************************
--if not exists (select * from DBScriptLog where iScriptID >=34)
--Begin

--ALTER TABLE dbo.posModule ADD
--	iModuleParentID int NULL,
--	vUrlPath varchar(255) NULL,
--	UriKind varchar(150) NULL,
--	vDisplayName varchar(150) NULL
--insert into DBScriptLog(iScriptID,dDate,vDescription) values(34,GetDate(),'Script No#34 -- Dated 25-11-2013 -- Atif -- Add Data of iModule')
--Print 'Script has Executed successfully'
--End
--Else
--	Print 'Script was executed before'
--Go




-- *************************** Script No#35 -- Dated 25-11-2013 -- Atif -- Create Table AppPreference Setting used by Super User*************************************
if not exists (select * from DBScriptLog where iScriptID >=35)
Begin

CREATE TABLE dbo.AppPreference
	(
	iApplicationID int NOT NULL IDENTITY (1, 1),
	vApplicationName varchar(255) NULL,
	imgCompanyLogo image NULL,
	vCompanyName varchar(255) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
	
	ALTER TABLE dbo.AppPreference ADD CONSTRAINT
	PK_AppPreference PRIMARY KEY CLUSTERED 
	(
	iApplicationID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


insert into DBScriptLog(iScriptID,dDate,vDescription) values(35,GetDate(),'Script No#35 -- Dated 25-11-2013 -- Atif -- Create Table AppPreference Setting used by Super User')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



-- *************************** Script No#36 -- Dated 25-11-2013 -- Atif -- InsertDefult Script *************************************
if not exists (select * from DBScriptLog where iScriptID >=36)
Begin
SET IDENTITY_INSERT [dbo].[AppPreference] ON
INSERT INTO [dbo].[AppPreference]
           (iApplicationID , vApplicationName
           ,imgCompanyLogo
           ,vCompanyName)
     VALUES
           (1,'POS' , 0x89504E470D0A1A0A0000000D49484452000000710000004608020000007463EC92000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000EC300000EC301C76FA864000000EC49444154785EEDD2310D00000CC3B0F127DD91F09902C861F5D6B4C0E960BD65EA4F9069A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FB69A65EC017FBA9377D3E475AB3FEE52B970000000049454E44AE426082
           ,'ABFA Company')

SET IDENTITY_INSERT [dbo].[AppPreference] OFF
insert into DBScriptLog(iScriptID,dDate,vDescription) values(36,GetDate(),'Script No#36 -- Dated 25-11-2013 -- Atif -- InsertDefult Script')

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go





-- *************************** Script No#37 -- Dated 26-11-2013 -- Atif -- alter table AppPreference  *************************************
if not exists (select * from DBScriptLog where iScriptID >=37)
Begin

			ALTER TABLE dbo.AppPreference ADD
			vEnableModules varchar(255) NULL

insert into DBScriptLog(iScriptID,dDate,vDescription) values(37,GetDate(),'Script No#37 -- Dated 26-11-2013 -- Atif -- alter table AppPreference')

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go




-- *************************** Script No#38 -- Dated 26-11-2013 -- Atif -- alter table posModule  *************************************
if not exists (select * from DBScriptLog where iScriptID >=38)
Begin
ALTER TABLE dbo.posModule ADD
	iDisplayOrder int NULL
insert into DBScriptLog(iScriptID,dDate,vDescription) values(38,GetDate(),'Script No#38 -- Dated 26-11-2013 -- Atif -- alter table posModule ')

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



-- *************************** Script No#39 -- Dated 27-11-2013 -- Atif -- alter table AppUsers  *************************************
if not exists (select * from DBScriptLog where iScriptID >=39)
Begin
ALTER TABLE dbo.AppUsers ADD
	vAllowdModule varchar(255) NULL
insert into DBScriptLog(iScriptID,dDate,vDescription) values(39,GetDate(),'Script No#39 -- Dated 27-11-2013 -- Atif -- alter table AppUsers')

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go






-- *************************** Script No#40 -- Dated 29-11-2013 -- Atif -- Insert Data in posModule  *************************************
if not exists (select * from DBScriptLog where iScriptID >=40)
Begin

SET IDENTITY_INSERT [dbo].posModule ON
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('1','Invoice','1','0','','Relative','Invoice','1')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('2','Invoice','1','1','/Pages/Invoice/ListInvoices.xaml','Relative','List Invoices','1')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('3','Invoice','1','1','/Pages/Invoice/AddInvoices.xaml','Relative','Add Invoice','2')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('4','Invoice','0','1','/Pages/Invoice/InvoiceReturn.xaml','Relative','Return Invoice','3')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('5','Party','1','0',NULL,'Relative','Party','2')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('6','Party','1','5','/Pages/Party/ListParty.xaml','Relative','List Party','1')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('7','Party','1','5','/Pages/Party/AddParty.xaml','Relative','Add Party','2')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('8','Items','1','0',NULL,'Relative','Items','3')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('9','Items','1','8','/Pages/Items/ListItem.xaml','Relative','List Items','1')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('10','Items','1','8','/Pages/Items/AddItem.xaml','Relative','Add Item','2')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('11','Purchase','1','0',NULL,'Relative','Purchase','4')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('12','Purchase','1','11','/Pages/Purchase/ListPurchase.xaml','Relative','List Purchase','1')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('13','Purchase','1','11','/Pages/Purchase/AddPurchase.xaml','Relative','Add Purchase','2')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('14','Welcome','1','0',NULL,'Relative','Welcome','0')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('15','Welcome','1','14','/Pages/Home.xaml',NULL,'Home','1')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('16','Production','0','0','','Relative','Production','5')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('17','Production','1','16','/Pages/Production/ListProduction.xaml','Relative','List Production','1')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('18','Production','1','16','/Pages/Production/addProduction.xaml','Relative','Add Production','2')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('19','Preferences','1','0','','Relative','Preferences','6')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('20','Preferences','1','19','/Pages/Setting/Setting.xaml','Relative','Setting','1')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder) VALUES('21','Preferences','1','19','/Pages/Setting/appuser.xaml','Relative','Mange User','2')
SET IDENTITY_INSERT [dbo].posModule OFF


insert into DBScriptLog(iScriptID,dDate,vDescription) values(40,GetDate(),'Script No#40 -- Dated 29-11-2013 -- Atif -- Insert Data in posModule')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go




-- *************************** Script No#41 -- Dated 03-12-2013 -- Atif -- alter table posPreference  *************************************
if not exists (select * from DBScriptLog where iScriptID >=41)
Begin
ALTER TABLE dbo.posPreference ADD
	bShowPartyDetail bit null,
	bShowDeliveryDetail bit null



insert into DBScriptLog(iScriptID,dDate,vDescription) values(41,GetDate(),'Script No#41 -- Dated 03-12-2013 -- Atif -- alter table posPreference')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go




-- *************************** Script No#42 -- Dated 04-12-2013 -- Atif -- alter table posPreference  *************************************
if not exists (select * from DBScriptLog where iScriptID >=42)
Begin
ALTER TABLE dbo.posPreference ADD
	bShowStockStatus bit null
	
insert into DBScriptLog(iScriptID,dDate,vDescription) values(42,GetDate(),'Script No#42 -- Dated 04-12-2013 -- Atif -- alter table posPreference')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go




-- *************************** Script No#43 -- Dated 04-12-2013 -- Atif -- alter table posItems  *************************************
if not exists (select * from DBScriptLog where iScriptID >=43)
Begin
ALTER TABLE dbo.posItems ADD
	vPackDescription varchar(255) null
	
insert into DBScriptLog(iScriptID,dDate,vDescription) values(43,GetDate(),'Script No#43 -- Dated 04-12-2013 -- Atif -- alter table posItems')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



-- *************************** Script No#44 -- Dated 05-12-2013 -- Atif -- alter table posModule  *************************************
if not exists (select * from DBScriptLog where iScriptID >=44)
Begin
ALTER TABLE dbo.posModule ADD
	vShortDescription varchar(255) NULL,
	vIconName varchar(255) NULL
	
insert into DBScriptLog(iScriptID,dDate,vDescription) values(44,GetDate(),'Script No#44 -- Dated 05-12-2013 -- Atif -- alter table posModule')
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-- *************************** Script No#45 -- Dated 12-12-2013 -- Atif -- update User Type  *************************************
if not exists (select * from DBScriptLog where iScriptID >=45)
Begin
if EXISTS (select * From AppUsers where iUserid = 1 )
	Begin 
	update dbo.AppUsers set vUserType = 'Super' where iUserid = 1
	End
	else
	Begin
		insert into appusers values('ammar','ghaffar','2/2/1982','Super','a','a','9/9/2011','ammar@gmail.com')
	End

insert into DBScriptLog(iScriptID,dDate,vDescription) values(45,GetDate(),'Script No#45 -- Dated 12-12-2013 -- Atif -- Update User Type' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-- *************************** Script No#46 -- Dated 12-12-2013 -- Atif -- alter table posSaleInovice  *************************************
if not exists (select * from DBScriptLog where iScriptID >=46)
Begin

	ALTER TABLE dbo.posSaleInovice ADD
		bIsDraft bit NULL,
		bFinalized  bit NOT NULL default 0
insert into DBScriptLog(iScriptID,dDate,vDescription) values(46,GetDate(),'Script No#46 -- Dated 12-12-2013 -- Atif -- alter table posSaleInovice' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-- *************************** Script No#47 -- Dated 24-12-2013 -- Atif -- Delete Module Records To Updats Later  *************************************
if not exists (select * from DBScriptLog where iScriptID >=47)
Begin
 delete from posModule
insert into DBScriptLog(iScriptID,dDate,vDescription) values(47,GetDate(),'Script No#47 -- Dated 24-12-2013 -- Atif -- Delete Module Records To Updats Later' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go
-- *************************** Script No#48 -- Dated 24-12-2013 -- Atif -- InsertNew Records  *************************************
if not exists (select * from DBScriptLog where iScriptID >=48)
Begin

SET IDENTITY_INSERT [dbo].posModule ON

INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('1','Invoice','1','0',NULL,'Relative','Invoice','1','This is a welcome screen. You can find all POS features on this page and also update all features.','invoice.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('2','Invoice','1','1','/Pages/Invoice/ListInvoices.xaml','Relative','List Invoices','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('3','Invoice','1','1','/Pages/Invoice/AddInvoices.xaml','Relative','Add Invoice','2',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('4','Invoice','1','1','/Pages/Invoice/InvoiceReturn.xaml','Relative','Return Invoice','3',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('5','Party','1','0',NULL,'Relative','Party','2','This is a welcome screen. You can find all POS features on this page and also update all features.','party.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('6','Party','1','5','/Pages/Party/ListParty.xaml','Relative','List Party','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('7','Party','1','5','/Pages/Party/AddParty.xaml','Relative','Add Party','2',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('8','Store','1','0',NULL,'Relative','Store','3','This is a welcome screen. You can find all POS features on this page and also update all features.',NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('9','Store','1','8','/Pages/Items/ListItem.xaml','Relative','List Items','1',NULL,'Items.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('10','Store','1','8','/Pages/Items/AddItem.xaml','Relative','Add Item','2',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('11','Purchase','1','0',NULL,'Relative','Purchase','4','This is a welcome screen. You can find all POS features on this page and also update all features.','purchase.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('12','Purchase','1','11','/Pages/Purchase/ListPurchase.xaml','Relative','List Purchase','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('13','Purchase','1','11','/Pages/Purchase/AddPurchase.xaml','Relative','Add Purchase','2',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('14','Welcome','1','0',NULL,'Relative','Welcome','0','This is a welcome screen. You can find all POS features on this page and also update all features.','welcome.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('15','Welcome','1','14','/Pages/Home.xaml','Relative','Home','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('16','Production','1','0',NULL,'Relative','Production','5','This is a welcome screen. You can find all POS features on this page and also update all features.','production.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('17','Production','1','16','/Pages/Production/ListProduction.xaml','Relative','List Production','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('18','Production','1','16','/Pages/Production/addProduction.xaml','Relative','Add Production','2',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('19','Setting','1','0',NULL,'Relative','Setting','6','This is a welcome screen. You can find all POS features on this page and also update all features.','Setting.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('20','Setting','1','19','/Pages/Setting/Setting.xaml','Relative','Preference','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('21','Setting','1','19','/Pages/Setting/appuser.xaml','Relative','Mange User','2',NULL,NULL)
SET IDENTITY_INSERT [dbo].posModule OFF
insert into DBScriptLog(iScriptID,dDate,vDescription) values(48,GetDate(),'Script No#48 -- Dated 24-12-2013 -- Atif -- InsertNew Records' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



-- *************************** Script No#49 -- Dated 25-12-2013 -- Atif -- alter table AppUsers  *************************************
if not exists (select * from DBScriptLog where iScriptID >=49)
	Begin

		ALTER TABLE dbo.AppUsers ADD
			bIsActive bit NULL
			
		insert into DBScriptLog(iScriptID,dDate,vDescription) values(49,GetDate(),'Script No#49 -- Dated 25-12-2013 -- Atif -- alter table AppUsers' )
		
		Print 'Script has Executed successfully'
	End
Else
	Print 'Script was executed before'
Go




-- *************************** Script No#50 -- Dated 31-12-2013 -- Atif -- Create Table [posFinaceType] *************************************
if not exists (select * from DBScriptLog where iScriptID >=50)
Begin
CREATE TABLE [dbo].[posFinaceType](
	[iFinaceType] [int] IDENTITY(1,1) NOT NULL,
	[vFinaceType] [varchar](100) NULL,
	[vFinaceTypeDes] [varchar](150) NULL,
 CONSTRAINT [PK_FinaceType] PRIMARY KEY CLUSTERED 
(
	[iFinaceType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into DBScriptLog(iScriptID,dDate,vDescription) values(50,GetDate(),'Script No#50 -- Dated 31-12-2013 -- Atif -- Create Table [posFinaceType]' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



-- *************************** Script No#51 -- Dated 24-12-2013 -- Atif -- InsertNew Records in Modules Table and update order*************************************
if not exists (select * from DBScriptLog where iScriptID >=51)
Begin

SET IDENTITY_INSERT [dbo].posModule ON
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('22','Account','1','0',NULL,'Relative','Accounts','6',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('23','AccountsHead','1','22','/Pages/Accounts/ListAccounts.xaml','Relative','Accounts Head','1',NULL,NULL)
SET IDENTITY_INSERT [dbo].posModule OFF
update posModule set iDisplayOrder = 7 where iModuleID = 19
insert into DBScriptLog(iScriptID,dDate,vDescription) values(51,GetDate(),'Script No#51 -- Dated 24-12-2013 -- Atif -- InsertNew Records' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go




-- *************************** Script No#52 -- Dated 1-1-2014 -- Atif -- Insert Finace Type *************************************
if not exists (select * from DBScriptLog where iScriptID >=52)
Begin

SET IDENTITY_INSERT [dbo].posFinaceType ON

INSERT posFinaceType(iFinaceType,vFinaceType,vFinaceTypeDes) VALUES('1','Assets Accounts','')
INSERT posFinaceType(iFinaceType,vFinaceType,vFinaceTypeDes) VALUES('2','Capital Account','')
INSERT posFinaceType(iFinaceType,vFinaceType,vFinaceTypeDes) VALUES('3','Liabilities Accounts','')
INSERT posFinaceType(iFinaceType,vFinaceType,vFinaceTypeDes) VALUES('4','Incomes Accounts','Revenues ')
INSERT posFinaceType(iFinaceType,vFinaceType,vFinaceTypeDes) VALUES('5','Expenses','Losses Accounts')


SET IDENTITY_INSERT [dbo].posFinaceType OFF


insert into DBScriptLog(iScriptID,dDate,vDescription) values(52,GetDate(),'Script No#52 -- Dated 1-1-2014 -- Atif -- Insert Finace Type')

Print 'Script has Executed successfully'
End
Else
Print 'Script was executed before'
Go


-- *************************** Script No#53 -- Dated 1-1-2014 -- Atif -- Create Table Accounts *************************************
if not exists (select * from DBScriptLog where iScriptID >=53)
Begin
CREATE TABLE [dbo].[posAccounts](
	[iAccountid] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [varchar](150) NULL,
	[vAccountNo] [varchar](50) NULL,
	[vAccountDesc] [varchar](200) NULL,
	[vAccountComments] [varchar](200) NULL,
	[bEditable] [bit] NULL,
	[iFinaceType] [int] NULL,
	[iModuleID] [int] NULL,
	[iModuleFK_ID] [int] NULL,
	bNominal bit null
 CONSTRAINT [PK_posAccounts] PRIMARY KEY CLUSTERED 
(
	[iAccountid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into DBScriptLog(iScriptID,dDate,vDescription) values(53,GetDate(),' Script No#53 -- Dated 1-1-2014 -- Atif -- Create Table Accounts')

Print 'Script has Executed successfully'
End
Else
Print 'Script was executed before'
Go

-- *************************** Script No#54 -- Dated 03-01-2014 -- Atif -- InsertNew Records in Modules Table *************************************
if not exists (select * from DBScriptLog where iScriptID >=54)
Begin

SET IDENTITY_INSERT [dbo].posModule ON
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('24','Journal','1','22','/Pages/Accounts/Journal/ListJournal.xaml','Relative','Journal','1',NULL,NULL)
SET IDENTITY_INSERT [dbo].posModule OFF

insert into DBScriptLog(iScriptID,dDate,vDescription) values(54,GetDate(),'Script No#54 -- Dated 03-01-2014 -- Atif -- InsertNew Records in Modules Table' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-- *************************** Script No#55 -- Dated 03-01-2014 -- Atif -- Create Table posJournal *************************************
if not exists (select * from DBScriptLog where iScriptID >=55)
Begin

CREATE TABLE [dbo].[posJournal](
	[iJournalId] [int] IDENTITY(1,1) NOT NULL,
	[fAmount] float(25) NULL,	
	[vTranTitle] [varchar](150) NULL,
	[dSystemEntryDateTime] [datetime] NULL,
	[dTransactionDate] [datetime] NULL,
	[iUserId] [int] NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[iJournalId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into DBScriptLog(iScriptID,dDate,vDescription) values(55,GetDate(),'Script No#55 -- Dated 03-01-2014 -- Atif -- Create Table posJournal' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-- *************************** Script No#56 -- Dated 03-01-2014 -- Atif -- Create Table posJournalDetail *************************************
if not exists (select * from DBScriptLog where iScriptID >=56)
Begin
CREATE TABLE [dbo].[posJournalDetail](
	[iJournalDetailId] [int] IDENTITY(1,1) NOT NULL,
	[iJournalId] [int],
	[vTransactionType] [varchar](50) NULL,
	[iAccountID] [int] NULL,	
	[fAmount] float(25) NULL,
	[dEntryDateTime] [datetime] NULL,
	[vReceivedBy] [varchar](50) NULL,
	[vVoucherNo] [varchar](50) NULL,
	[vdescription] [varchar](150) NULL,	
	[iChequeNumber] [int] NULL,
	[vBankAccountNumber] [varchar](50) NULL,
	[vPaymentMode] [varchar](50) NULL,	
	[vModuleFK_Table] [varchar](150) NULL,
	[vModuleFK_Name] [varchar](150) NULL,
	[iModuleFK_ID] [int] NULL,
 CONSTRAINT [PK_JournalDetail] PRIMARY KEY CLUSTERED 
(
	[iJournalDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into DBScriptLog(iScriptID,dDate,vDescription) values(56,GetDate(),'Script No#56 -- Dated 03-01-2014 -- Atif -- Create Table posJournalDetail' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go




-- *************************** Script No#57 -- Dated 03-01-2014 -- Atif -- alter Table posJournal *************************************
if not exists (select * from DBScriptLog where iScriptID >=57)
Begin
UPDATE posJournal SET dSystemEntryDateTime=GETDATE()
ALTER TABLE posJournal ALTER COLUMN dSystemEntryDateTime datetime NOT NULL
ALTER TABLE posJournal ADD CONSTRAINT DF_posJournal DEFAULT GETDATE() FOR dSystemEntryDateTime

insert into DBScriptLog(iScriptID,dDate,vDescription) values(57,GetDate(),'Script No#57 -- Dated 03-01-2014 -- Atif -- alter Table posJournal' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

-- *************************** Script No#58 -- Dated 23-01-2014 -- Atif -- alter Table ITEM *************************************
if not exists (select * from DBScriptLog where iScriptID >=58)
Begin

ALTER TABLE dbo.posItems ADD
	fUnitPurchasePrice float(53) NULL,
	vItemType varchar(250) NULL

insert into DBScriptLog(iScriptID,dDate,vDescription) values(58,GetDate(),' Script No#58 -- Dated 23-01-2014 -- Atif -- alter Table ITEM' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-- *************************** Script No#59 -- Dated 23-01-2014 -- Atif -- alter Table Costumer *************************************
if not exists (select * from DBScriptLog where iScriptID >=59)
Begin


CREATE TABLE [dbo].[tblCostumer](
	[CostumerID] [bigint] IDENTITY(1,1) NOT NULL,
	[CostumerName] [varchar](150) NULL,
	[CostumerBikeNumber] [varchar](50) NULL,
	[CostumerMobileNumber] [varchar](50) NULL,
	[CostumerLastVisit] [datetime] NULL,
 CONSTRAINT [PK_tblCostumer] PRIMARY KEY CLUSTERED 
(
	[CostumerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into DBScriptLog(iScriptID,dDate,vDescription) values(59,GetDate(),'Script No#59 -- Dated 23-01-2014 -- Atif -- alter Table Costumer' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



if not exists (select * from DBScriptLog where iScriptID >=60)
Begin

ALTER TABLE dbo.tblCostumer ADD
	MeterReading varchar(50) NULL,
	ModelNumber varchar(50) NULL
	
insert into DBScriptLog(iScriptID,dDate,vDescription) values(59,GetDate(),'Script No#56 -- Dated 26-01-2014 -- Atif -- alter Table Costumer' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=61)
Begin

	ALTER TABLE posSaleInovice ADD
		ICostumerId bigint NULL
	
insert into DBScriptLog(iScriptID,dDate,vDescription) values(61,GetDate(),'Script No#51 -- Dated 26-01-2014 -- Atif -- alter posSaleInovice' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=62)
Begin

	ALTER TABLE posSaleInovice ADD
		MeterReading varchar(250) NULL , 
		LiftNumber int null
	
insert into DBScriptLog(iScriptID,dDate,vDescription) values(62,GetDate(),'Script No#62 -- Dated 14-02-2014 -- Atif -- alter posSaleInovice' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


--------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=63)
Begin

	ALTER TABLE posItems ADD
		iAlertAmount int not NULL DEFAULT(1)
	
insert into DBScriptLog(iScriptID,dDate,vDescription) values(63,GetDate(),'Script No#62 -- Dated 14-02-2014 -- Atif -- alter posItems' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


--------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=64)
Begin

	ALTER TABLE posSaleInovice ADD
		vFirstElectricianName varchar(255) NULL,
		vSecElectricianName varchar(255) NULL
	
insert into DBScriptLog(iScriptID,dDate,vDescription) values(64,GetDate(),'Script No#62 -- Dated 14-02-2014 -- Atif -- alter posSaleInovice' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=65)
Begin
SET IDENTITY_INSERT [dbo].posModule ON
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('22','Account','1','0',NULL,'Relative','Accounts','6',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('23','AccountsHead','1','22','/Pages/Accounts/ListAccounts.xaml','Relative','Accounts Head','1',NULL,NULL)
SET IDENTITY_INSERT [dbo].posModule OFF
insert into DBScriptLog(iScriptID,dDate,vDescription) values(65,GetDate(),'Script No#62 -- Enable Account' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


--------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=66)
Begin
SET IDENTITY_INSERT [dbo].posModule ON
INSERT [dbo].[posModule] ([iModuleID], [vModuleName], [bIsActive], [iModuleParentID], [vUrlPath], [UriKind], [vDisplayName], [iDisplayOrder], [vShortDescription], [vIconName]) VALUES (29, N'Employee', 1, 0, NULL, N'Relative', N'Employee', 0, NULL, NULL)
INSERT [dbo].[posModule] ([iModuleID], [vModuleName], [bIsActive], [iModuleParentID], [vUrlPath], [UriKind], [vDisplayName], [iDisplayOrder], [vShortDescription], [vIconName]) VALUES (30, N'Employee', 1, 29, N'/Pages/emp/listEmp.xaml', N'Relative', N'List Employee', 1, NULL, NULL)
INSERT [dbo].[posModule] ([iModuleID], [vModuleName], [bIsActive], [iModuleParentID], [vUrlPath], [UriKind], [vDisplayName], [iDisplayOrder], [vShortDescription], [vIconName]) VALUES (31, N'Employee', 1, 29, N'/Pages/emp/addEmp.xaml', N'Relative', N'Add Employee', 2, NULL, NULL)

SET IDENTITY_INSERT [dbo].posModule OFF
insert into DBScriptLog(iScriptID,dDate,vDescription) values(66,GetDate(),'Script No#62 -- Enable Emp' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=67)
Begin

CREATE TABLE [dbo].[Salary](
	[iSalId] [int] IDENTITY(1,1) NOT NULL,
	[iEmpId] [int] NULL,
	[bIsPaid] [bit] NULL,
	[dSrtDate] [datetime] NULL,
	[dEndDate] [datetime] NULL,
	[iDays] [int] NULL,
	[iHours] [int] NULL,
	[iTranId] [int] NULL,
	[dPaidDate] [datetime] NULL,
	[dGenratedDate] [datetime] NULL,
	[iAmount] [int] NULL,
	[iDeduction] [int] NULL,
 CONSTRAINT [PK_Salary] PRIMARY KEY CLUSTERED 
(
	[iSalId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into DBScriptLog(iScriptID,dDate,vDescription) values(67,GetDate(),'Script No#62 -- Enable Emp' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



--------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=68)
Begin

ALTER TABLE dbo.posSaleInovice ADD
	fServices float NULL


insert into DBScriptLog(iScriptID,dDate,vDescription) values(68,GetDate(),'Script No#68 -- ' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=69)
Begin

ALTER TABLE dbo.posPreference ADD
	iSalaryDays int NULL


insert into DBScriptLog(iScriptID,dDate,vDescription) values(69,GetDate(),'Script No#69 -- ' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=70)
Begin

ALTER TABLE dbo.posEmployee alter column
	iBasicSalary float NULL


insert into DBScriptLog(iScriptID,dDate,vDescription) values(70,GetDate(),'Script No#70 -- ' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


--------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=71)
Begin

ALTER TABLE dbo.Salary alter column
	iAmount float NULL

ALTER TABLE dbo.Salary alter column
	iDays float NULL
	
ALTER TABLE dbo.Salary alter column
	iDeduction float NULL

ALTER TABLE dbo.Salary alter column
	iAmount float NULL

ALTER TABLE dbo.Salary add 
	iAbsentdays float NULL 
	
ALTER TABLE dbo.Salary add 
	fOverTime float NULL 
	
insert into DBScriptLog(iScriptID,dDate,vDescription) values(71,GetDate(),'Script No#71 -- ' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=72)
Begin

SET IDENTITY_INSERT [dbo].posModule ON
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) 
VALUES('32','Salary','0','0',NULL,'Relative','Salary','6',NULL,NULL)
SET IDENTITY_INSERT [dbo].posModule OFF
insert into DBScriptLog(iScriptID,dDate,vDescription) values(72,GetDate(),'Script No#72' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

-------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=73)
Begin
alter table posEmployee drop column vAccountNo
insert into DBScriptLog(iScriptID,dDate,vDescription) values(73,GetDate(),'Script No#73' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go




-------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=74)
Begin
INSERT [dbo].[posAccounts] ( [AccountName], [vAccountNo], [vAccountDesc], [vAccountComments], [bEditable], [iFinaceType], [iModuleID], [iModuleFK_ID], [bNominal]) 
VALUES ( N'Sales', N'Sales001', N'Sales Account to Maintain Sales Records', N'Sales Account to Maintain Sales Records', 0, 4, 1, 0, 1)
insert into DBScriptLog(iScriptID,dDate,vDescription) values(74,GetDate(),'Script No#74' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

-------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=75)
Begin

SET IDENTITY_INSERT [dbo].posModule ON
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) 
VALUES('33','Cash','0','0',NULL,'Relative','Cash','6',NULL,NULL)
SET IDENTITY_INSERT [dbo].posModule OFF
insert into DBScriptLog(iScriptID,dDate,vDescription) values(75,GetDate(),'Script No#75' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=76)
Begin
INSERT [dbo].[posAccounts] ( [AccountName], [vAccountNo], [vAccountDesc], [vAccountComments], [bEditable], [iFinaceType], [iModuleID], [iModuleFK_ID], [bNominal]) 
VALUES ( N'Cash', N'Cash001', N'Cash Account to Maintain Cash Records', N'Cash Account to Maintain Cash Records', 0, 4, 33, 0, 1)
insert into DBScriptLog(iScriptID,dDate,vDescription) values(76,GetDate(),'Script No#76' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

-------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=77)
Begin
INSERT [dbo].[posAccounts] ( [AccountName], [vAccountNo], [vAccountDesc], [vAccountComments], [bEditable], [iFinaceType], [iModuleID], [iModuleFK_ID], [bNominal]) 
VALUES ( N'Purchase', N'Purchase001', N'Purchase Account to Maintain Purchase Records', N'Purchase Account to Maintain Purchase Records', 0, 5, 11, 0, 1)
insert into DBScriptLog(iScriptID,dDate,vDescription) values(77,GetDate(),'Script No#77' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-- Drop the modules i dont know what is the issu


-- insert new all from my system

-------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=79)
Begin
delete from posModule
SET IDENTITY_INSERT [dbo].posModule ON
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('1','Invoice','1','0',NULL,'Relative','Invoice','1',NULL,'invoice.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('2','Invoice','1','1','/Pages/Invoice/ListInvoices.xaml','Relative','List Invoices','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('3','Invoice','1','1','/Pages/Invoice/AddInvoices.xaml','Relative','Add Invoice','2',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('4','Invoice','1','1','/Pages/Invoice/InvoiceReturn.xaml','Relative','Return Invoice','3',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('5','Party','1','0',NULL,'Relative','Party','2',NULL,'party.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('6','Party','1','5','/Pages/Party/ListParty.xaml','Relative','List Party','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('7','Party','1','5','/Pages/Party/AddParty.xaml','Relative','Add Party','2',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('8','Store','1','0',NULL,'Relative','Store','3',NULL,'Items.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('9','Store','1','8','/Pages/Items/ListItem.xaml','Relative','List Items','1',NULL,'Items.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('10','Store','1','8','/Pages/Items/AddItem.xaml','Relative','Add Item','2',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('11','Purchase','1','0',NULL,'Relative','Purchase','4',NULL,'purchase.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('12','Purchase','1','11','/Pages/Purchase/ListPurchase.xaml','Relative','List Purchase','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('13','Purchase','1','11','/Pages/Purchase/AddPurchase.xaml','Relative','Add Purchase','2',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('14','Welcome','1','0',NULL,'Relative','Welcome','0',NULL,'welcome.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('15','Welcome','1','14','/Pages/Home.xaml','Relative','Home','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('16','Production','0','0',NULL,'Relative','Production','5',NULL,'production.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('17','Production','0','16','/Pages/Production/ListProduction.xaml','Relative','List Production','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('18','Production','0','16','/Pages/Production/addProduction.xaml','Relative','Add Production','2',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('19','Setting','1','0',NULL,'Relative','Setting','7',NULL,'Setting.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('20','Setting','1','19','/Pages/Setting/Setting.xaml','Relative','Preference','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('21','Setting','1','19','/Pages/Setting/appuser.xaml','Relative','Mange User','2',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('22','Account','1','0',NULL,'Relative','Accounts','6',NULL,'account.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('23','AccountsHead','1','22','/Pages/Accounts/ListAccounts.xaml','Relative','Accounts Head','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('24','Journal','1','22','/Pages/Accounts/Journal/ListJournal.xaml','Relative','Journal','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('26','Costumer','1','0',NULL,'Relative','Customer','1',NULL,'customer.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('27','Costumer','1','26','/Pages/Costumer/lstCostumer.xaml','Relative','List Customer','0',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('29','Employee','1','0',NULL,'Relative','Employee','0',NULL,'employee.png')
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('30','Employee','1','29','/Pages/emp/listEmp.xaml','Relative','List Employee','1',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('31','Employee','1','29','/Pages/emp/addEmp.xaml','Relative','Add Employee','2',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('32','Salary','0','-1',NULL,'Relative','Accounts','6',NULL,NULL)
INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) VALUES('33','Cash','0','-1',NULL,'Relative','Cash','6',NULL,NULL)
SET IDENTITY_INSERT [dbo].posModule OFF
insert into DBScriptLog(iScriptID,dDate,vDescription) values(79,GetDate(),'Script No#78' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

-- Now Delete the Prefrance 
-------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=80)
Begin
delete  From dbo.AppPreference
insert into DBScriptLog(iScriptID,dDate,vDescription) values(80,GetDate(),'Script No#80' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

-- Now Delete the Prefrance 
-------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=81)
Begin

SET IDENTITY_INSERT [dbo].[AppPreference] ON
INSERT [dbo].[AppPreference] ([iApplicationID], [vApplicationName], [imgCompanyLogo], [vCompanyName], [vEnableModules]) VALUES (1, N'Login', 0xFFD8FFE000104A46494600010101006000600000FFDB00430001010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101FFDB00430101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101FFC00011080046007103012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00FEFE28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00FFD9, N'Pakistan Honda Service', N'29,30,31,14,15,1,2,3,4,26,27,5,6,7,8,9,10,11,12,13,22,23,24,19,20,21')
SET IDENTITY_INSERT [dbo].[AppPreference] OFF

insert into DBScriptLog(iScriptID,dDate,vDescription) values(81,GetDate(),'Script No#81' )

Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=82)
Begin
if not  exists(select * from [posAccounts] where [AccountName]='Salary' and[vAccountNo]= 'Salary001' )
	INSERT [dbo].[posAccounts] ( [AccountName], [vAccountNo], [vAccountDesc], [vAccountComments], [bEditable], [iFinaceType], [iModuleID], [iModuleFK_ID], [bNominal]) 
	VALUES ( N'Salary', N'Salary001', N'Salary Account to Maintain salary Records ', N'Salary Account to Maintain salary Records ', 0, 5, 32, 0, 1)
	
insert into DBScriptLog(iScriptID,dDate,vDescription) values(82,GetDate(),'Script No#82 -- ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--------------------------------------------------------------------------
if not exists (select * from DBScriptLog where iScriptID >=83)
Begin
ALTER TABLE dbo.AppPreference ADD
	vHeaderAdress text NULL
insert into DBScriptLog(iScriptID,dDate,vDescription) values(83,GetDate(),'Script No#83 -- ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--------------------------------------------------------------------------
	if not exists (select * from DBScriptLog where iScriptID >=84)
	Begin

	SET IDENTITY_INSERT [dbo].posModule ON
	INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName)
	 VALUES('34','Reports','1','0',NULL,'Relative','Reports','6',NULL,'Reports.png')
	 INSERT posModule(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName)
	 VALUES('35','Reports','1','34','/Pages/Reports/Reports.xaml','Relative','Reports','6',NULL,NULL)
	SET IDENTITY_INSERT [dbo].posModule OFF
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(84,GetDate(),'Script No#84 -- ' )
	Print 'Script has Executed successfully'
	End
	Else
		Print 'Script was executed before'
	Go
---------------------------------------------------------------------------
--	if not exists (select * from DBScriptLog where iScriptID >=85)
--	Begin
--	update posModule set vUrlPath = N'/Pages/Items/ListItem.xaml' where iModuleID iModuleID 
	
--	insert into DBScriptLog(iScriptID,dDate,vDescription) values(85,GetDate(),'Script No#85 -- ' )
--	Print 'Script has Executed successfully'
--	End
--	Else
--		Print 'Script was executed before'
--	Go

-- module for the purchase return and sale return 

if not exists (select * from DBScriptLog where iScriptID >=85)
Begin
SET IDENTITY_INSERT [dbo].posModule on
	INSERT posModule
	(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) 
	VALUES(36,'PurchasR','0','-1',NULL,'Relative','Accounts','6',NULL,NULL)
	INSERT posModule
	(iModuleID,vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) 
	VALUES(37,'SalesR','0','-1',NULL,'Relative','Accounts','6',NULL,NULL)
	SET IDENTITY_INSERT [dbo].posModule OFF
insert into DBScriptLog(iScriptID,dDate,vDescription) values(85,GetDate(),'Script No#85 -- ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go
--------------------------------------------------------------------------Purchase Returns
if not exists (select * from DBScriptLog where iScriptID >=86)
Begin

	INSERT [dbo].[posAccounts] ( [AccountName], [vAccountNo], [vAccountDesc], [vAccountComments], [bEditable], [iFinaceType], [iModuleID], [iModuleFK_ID], [bNominal]) 
	VALUES ( N'Purchase Returns', N'PR-001',
	 N'Purchase Returns Account to Maintain Purchase Returns Records ', N'Purchase Returns Account to Maintain Purchase Returns Records', 0, 5, 36, 0, 1)
	 
	 INSERT [dbo].[posAccounts] ( [AccountName], [vAccountNo], [vAccountDesc], [vAccountComments], [bEditable], [iFinaceType], [iModuleID], [iModuleFK_ID], [bNominal]) 
	VALUES ( N'Sales Returns', N'SR-001',
	 N'Sales Returns Account to Maintain Sales Returns Records ', N'Sales Returns Account to Maintain Sales Returns Records', 0, 5, 37, 0, 1)
	
insert into DBScriptLog(iScriptID,dDate,vDescription) values(86,GetDate(),'Script No#86 -- ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go
-- reset the accounts type for the pre defined accounts
if not exists (select * from DBScriptLog where iScriptID >=87)
Begin
update posAccounts  set iFinaceType =5 where AccountName = 'Purchase'  and iModuleID = 11
update posAccounts  set iFinaceType =5 where AccountName = 'Salary'  and iModuleID = 32
update posAccounts  set iFinaceType =4 where AccountName = 'Sales'  and iModuleID = 1
update posAccounts  set iFinaceType =1 where AccountName = 'Purchase Returns'  and iModuleID = 36
update posAccounts  set iFinaceType =3 where AccountName = 'Sales Returns'  and iModuleID = 37
update posAccounts  set iFinaceType =1 where AccountName = 'Cash'  and iModuleID = 33
insert into DBScriptLog(iScriptID,dDate,vDescription) values(87,GetDate(),'Script No#87 reset the accounts type for the pre defined accounts -- ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

-- reset the opning stock data 
if not exists (select * from DBScriptLog where iScriptID >=88)
Begin
delete  from [posStock] where [vAction] = 'New-Item [ Opening Stock ]'
insert into DBScriptLog(iScriptID,dDate,vDescription) values(88,GetDate(),'Script No#88 -- reset the opning stock data ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



-- Enable the report Data
if not exists (select * from DBScriptLog where iScriptID >=89)
Begin
update AppPreference set vEnableModules = N'29,30,31,14,15,1,2,3,4,26,27,5,6,7,8,9,10,11,12,13,22,23,24,34,35,19,20,21' where iApplicationID = 1
insert into DBScriptLog(iScriptID,dDate,vDescription) values(89,GetDate(),'Script No#89 -- reset the report data ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


-- reset the opning stock data 
if not exists (select * from DBScriptLog where iScriptID >=90)
Begin
delete  from [posStock] 
insert into DBScriptLog(iScriptID,dDate,vDescription) values(90,GetDate(),'Script No#90 -- reset the opning stock data ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--Script No#91 -- Update usr Name password
if not exists (select * from DBScriptLog where iScriptID >=91)
Begin
update AppUsers set vfName = N'Rizwan' , vlName = N'Saqib' where vUserType = 'Super'
insert into DBScriptLog(iScriptID,dDate,vDescription) values(91,GetDate(),'Script No#91 -- Update usr Name password' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--Script No#92 -- Set for proceccer id
if not exists (select * from DBScriptLog where iScriptID >=92)
Begin
	
	ALTER TABLE dbo.AppPreference ADD
	vPID varchar(255) NULL
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(92,GetDate(),'Script No#92 -- Set for proceccer id' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


--Script No#93 -- Set for proceccer id
if not exists (select * from DBScriptLog where iScriptID >=93)
Begin
	update dbo.AppPreference set vPID = N'BFEBFBFF000006FB' where iApplicationID = 1	
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(93,GetDate(),'Script No#93 -- Set for proceccer id' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--Script No#94 -- Add For Mobile Number
if not exists (select * from DBScriptLog where iScriptID >=94)
Begin
	ALTER TABLE dbo.AppPreference ADD
	vCompanyMobile varchar(255) NULL
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(94,GetDate(),'Script No#94 -- Add For Mobile Number' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


--Script No#95 -- Add col for edit able items 
if not exists (select * from DBScriptLog where iScriptID >=95)
Begin
	ALTER TABLE dbo.posItems ADD
	bIsEditAbleInInvoice bit DEFAULT 1 
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(95,GetDate(),'Script No#95 -- Add col for edit able items ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--Script No#96 -- Add right to user that can edit item price in invoice or not
if not exists (select * from DBScriptLog where iScriptID >=96)
Begin
	ALTER TABLE dbo.AppUsers ADD
	bCanMakeEditAble bit DEFAULT(0)
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(96,GetDate(),'Script No#96 -- Add right to user that can edit item price in invoice or not' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


--Script No#97 -- add column to posPreference ad cashier select from employ
if not exists (select * from DBScriptLog where iScriptID >=97)
Begin
	ALTER TABLE dbo.posPreference ADD
	bCashierID int null
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(97,GetDate(),'Script No#97 -- add column cashier select from employ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--Script No#98 -- add column to posSaleItem add fUnitPurchasePrice select from posItems
if not exists (select * from DBScriptLog where iScriptID >=98)
Begin
	ALTER TABLE dbo.posSaleItem ADD
	fUnitPurchasePrice float null
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(98,GetDate(),'Script No#98 -- add column to posSaleItem add fUnitPurchasePrice select from posItems' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--Script No#99 -- add column to posSaleItem add fGrossPurchasePrice select from posItems * iQuantity
if not exists (select * from DBScriptLog where iScriptID >=99)
Begin
	ALTER TABLE dbo.posSaleItem ADD
	fGrossPurchasePrice float null
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(99,GetDate(),'Script No#99 -- add column to posSaleItem add fGrossPurchasePrice select from posItems * iQuantity' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--Script No#100 -- update all existing invoices
if not exists (select * from DBScriptLog where iScriptID >=100)
Begin
	update posSaleItem 
	set fUnitPurchasePrice = (		select fUnitPurchasePrice 
								from posItems where posItems.iItemID = posSaleItem.iItemID 
						 ) , 
	fGrossPurchasePrice = (		select fUnitPurchasePrice * posSaleItem.iQuantity
								from posItems where posItems.iItemID = posSaleItem.iItemID 
						 )  
						 
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(100,GetDate(),'Script No#100 -- update all existing invoices' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


--Script No#101 -- add field to journal for total unit purchase
if not exists (select * from DBScriptLog where iScriptID >=101)
Begin

	ALTER TABLE dbo.posJournal ADD
	fGrossPurchasePrice float null
						 
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(101,GetDate(),'Script No#101 -- add field to journal for total unit purchase' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


--Script No#102 -- add field to journal for total unit purchase
if not exists (select * from DBScriptLog where iScriptID >=102)
Begin

	--ALTER TABLE dbo.posJournalDetail ADD
	--fUnitPurchasePrice float null
		
	--ALTER TABLE dbo.posJournalDetail ADD
	--fGrossPurchasePrice float null		
			 
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(102,GetDate(),'Script No#102 -- add field to journal for total unit purchase' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


--Script No#103 -- add field to posSaleInovice for total unit purchase
if not exists (select * from DBScriptLog where iScriptID >=103)
Begin

	ALTER TABLE dbo.posSaleInovice ADD
	fGrossPurchasePrice float null
						 
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(103,GetDate(),'Script No#103 -- add field to posSaleInovice for total unit purchase' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go
--Script No#104 -- update the invoices with unit purchase 
if not exists (select * from DBScriptLog where iScriptID >=104)
Begin

	update [posSaleInovice]
set fGrossPurchasePrice = (select SUM(fGrossPurchasePrice) as fGrossPurchasePrice from posSaleItem where iSaleid = posSaleInovice.iSaleid)
  
						 
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(104,GetDate(),'Script No#104 -- update the invoices with unit purchase ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--Script No#105 -- Update old invoice for the total ..... just fuck
if not exists (select * from DBScriptLog where iScriptID >=105)
Begin

	ALTER TABLE dbo.posSaleInovice ADD
	fbackup float null
	
  insert into DBScriptLog(iScriptID,dDate,vDescription) values(105,GetDate(),'Script No#105  -- Update old invoice for the total ..... just fuck' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go


--Script No#105 -- Update old invoice for the total ..... just fuck
if not exists (select * from DBScriptLog where iScriptID >=106)
Begin

	update posSaleInovice set fbackup = ftotalamount,
	  ftotalamount =  ftotalamount + ISNULL(fServices ,0)				 
  insert into DBScriptLog(iScriptID,dDate,vDescription) values(105,GetDate(),'Script No#106  -- Update old invoice for the total ..... just fuck' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



--Script No#107 -- update the invoices with unit purchase 
if not exists (select * from DBScriptLog where iScriptID >=107)
Begin

	update [posSaleInovice]
set fGrossPurchasePrice = (select SUM(fGrossPurchasePrice) as fGrossPurchasePrice from posSaleItem where iSaleid = posSaleInovice.iSaleid)
  
						 
insert into DBScriptLog(iScriptID,dDate,vDescription) values(107,GetDate(),'Script No#107 -- update the invoices with unit purchase ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go



--Script No#108 -- add column to tblcostumer for last inovice and fallow for alert.
if not exists (select * from DBScriptLog where iScriptID >=108)
Begin
	ALTER TABLE dbo.tblCostumer ADD
	bFallowUp bit null  , dLastInovice datetime NOT NULL DEFAULT (GETDATE()) , dAlertDate datetime NULL
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(108,GetDate(),'Script No#108 -- add column cashier select from employ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--Script No#109 -- update tblCostumer for last inovice date
if not exists (select * from DBScriptLog where iScriptID >=109)
Begin
	update tblCostumer set dLastInovice = isnull((select top 1 posSaleInovice.ddate from possaleinovice where  posSaleInovice.ICostumerId = CostumerID order by posSaleInovice.iSaleid desc),GETDATE())
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(109,GetDate(),'Script No#109 -- update tblCostumer for last inovice date' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--Script No#110 -- update tblCostumer for last inovice date
if not exists (select * from DBScriptLog where iScriptID >=110)
Begin
	
	INSERT posModule(vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName) 
	VALUES('AlertCostumer','1','26','/Pages/Costumer/alertCostumer.xaml','Relative','Alert Customer','2',NULL,NULL)
	
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(110,GetDate(),'Script No#110 -- update tblCostumer for last inovice date' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go

--Script No#107 -- update the invoices with unit purchase 
if not exists (select * from DBScriptLog where iScriptID >=111)
Begin

	update [posSaleInovice]
set fGrossPurchasePrice = (select SUM(fGrossPurchasePrice) as fGrossPurchasePrice from posSaleItem where iSaleid = posSaleInovice.iSaleid)
  
						 
insert into DBScriptLog(iScriptID,dDate,vDescription) values(111,GetDate(),'Script No#111 -- update the invoices with unit purchase ' )
Print 'Script has Executed successfully'
End
Else
	Print 'Script was executed before'
Go






--Strtring for care cloud add for screen

--Script No#107 -- update the invoices with unit purchase 
if not exists (select * from DBScriptLog where iScriptID >=112)
Begin

	ALTER TABLE posModule ADD
	VLoadScreen varchar(255) NULL
						 
insert into DBScriptLog(iScriptID,dDate,vDescription) values(112,GetDate(),'Script No#112 -- care cloud add for screen.' )
Print 'Script No#112 -- care cloud add for screen. Script has Executed successfully'
End
Else
	Print 'Script No#112  was executed before'
Go

if not exists (select * from DBScriptLog where iScriptID >=113)
Begin

	
	--CREATE TABLE dhDoctors(
	--	iDocid bigint IDENTITY(1,1) NOT NULL Primary Key,

	--	vTitle varchar(50) NULL,
	--	vSuffix varchar(50) NULL,

	--	vfName varchar(150) NULL,

	--	vlName varchar(150) NULL,

	--	vQualification varchar(150) NULL,

	--	dDOB datetime NULL,
	--	vMartialStatus varchar(50) NULL,
	--	vGender varchar(1) NULL,
	--	vFatherName varchar(150) NULL,

	--	vSSN varchar(50) NULL,
	--	vNPI varchar(50) NULL,
	--	vDEA varchar(50) NULL,

	--	vLicNumber varchar(50) NULL,
	--	vLicState varchar(50) NULL,

	--	vAddress1 varchar(150) NULL,
	--	vAddress2 varchar(150) NULL,


	--	vHomePhone varchar(50) NULL,
	--	vWorkPhone varchar(50) NULL,
	--	vMobile varchar(50) NULL,
	--	vHospital varchar(50) NULL,
	--	vSpeacility varchar(50) NULL,
	--	vEmail varchar(50) NULL,

	--	bActive bit NULL,
	--	bRendering bit NULL,
	--	bBilling bit NULL,
	--	bPay_to_Provider bit NULL,
	--	bSupervising bit NULL,
	--	bPysician_Assitant bit NULL,
	--	bOperating bit NULL,
	--	bAssitant_Surgeon bit NULL,
	--	bPurchaed_Services bit NULL,
	--	bPAtteding bit NULL,
	--	iPracID int NULL,
	--	vMediCare_Doctor_Type varchar(50) NULL,
	--	vEvening_Time_Start varchar(10) NULL,
	--	vEvening_Time_End varchar(10) NULL,
	--	vMorning_Time_Start varchar(10) NULL,
	--	vMorning_Time_End varchar(10) NULL,
	--	iHospital_Charges int NULL,
	--	iPatient_Fee int NULL,
	--	iDaily_Patient_Token_Limit int NULL,
	--	iReturn_Patient_Fee int NULL
	--) 




						 
insert into DBScriptLog(iScriptID,dDate,vDescription) values(113,GetDate(),'Script No#113 -- Care Cloud Dcotor Table  ' )
Print 'Script No#113 -- Care Cloud Dcotor Table  Script has Executed successfully'
End
Else
	Print 'Script No#113 was executed before'
Go




--Script No#110 -- update tblCostumer for last inovice date
if not exists (select * from DBScriptLog where iScriptID >=114)
Begin
	
	INSERT posModule(vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName,VLoadScreen) 
	VALUES('Doctors','1','0','/Pages/Costumer/alertCostumer.xaml','Relative','Doctors','2',NULL,'','DoctorsViewModel')
	
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(114,GetDate(),'Script No#114 -- update Module for doctors' )
Print 'Script No#114 -- update Module for doctors- Script has Executed successfully'
End
Else
	Print 'Script No#114 -- Script was executed before'
Go


--Script No#115 -- update app prefrance for docotr module
if not exists (select * from DBScriptLog where iScriptID >=115)
Begin
	
	update [dbo].[AppPreference]
	set 
          [vEnableModules] = CONCAT([vEnableModules], ',', (select iModuleID from posModule where  vModuleName = 'Doctors' and vDisplayName =  'Doctors' ))

	--INSERT posModule(vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName,VLoadScreen) 
	--VALUES('Doctor','1','26','/Pages/Costumer/alertCostumer.xaml','Relative','Doctor','2',NULL,'','DoctorsViewModel')
	
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(115,GetDate(),'Script No#115 -- update app prefrance for docotr module' )
Print 'Script No#115 -- update app prefrance for docotr module - Script has Executed successfully'
End
Else
	Print 'Script No#115 -- update app prefrance for docotr module'
Go




--Script No#116 -- update app prefrance for docotr module
if not exists (select * from DBScriptLog where iScriptID >=116)
Begin
	
	declare @iModuleId  int
	set @iModuleId =  (select iModuleID from posModule where  vModuleName = 'Doctors' and vDisplayName = 'Doctors') 
	INSERT posModule(vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName,VLoadScreen) 
	VALUES('Doctors','1',@iModuleId,'/Pages/Costumer/alertCostumer.xaml','Relative','List Doctor','2',NULL,'','DoctorsViewModel')

    INSERT posModule(vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName,VLoadScreen) 
	VALUES('Doctors','1',@iModuleId,'/Pages/Costumer/alertCostumer.xaml','Relative','Add Doctor','2',NULL,'','AddDoctorsViewModel')

	
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(116,GetDate(),'Script No#116 -- update app prefrance for docotr module' )

Print 'Script No#116 -- update app prefrance for docotr module - Script has Executed successfully'
End
Else
	Print 'Script No#116 -- update app prefrance for docotr module'
Go

 --delete  from DBScriptLog where iScriptID >=117 
--Script No#117 -- update app prefrance for docotr module
if not exists (select * from DBScriptLog where iScriptID >=117)
Begin
	
	update [dbo].[AppPreference]
	set 
          [vEnableModules] = CONCAT([vEnableModules], ',', (select iModuleID from posModule where  vModuleName = 'Doctors' and vDisplayName= 'List Doctor'))



	update [dbo].[AppPreference]
	set 
          [vEnableModules] = CONCAT([vEnableModules], ',', (select iModuleID from posModule where  vModuleName = 'Doctors'  and vDisplayName= 'Add Doctor'))

	--INSERT posModule(vModuleName,bIsActive,iModuleParentID,vUrlPath,UriKind,vDisplayName,iDisplayOrder,vShortDescription,vIconName,VLoadScreen) 
	--VALUES('Doctor','1','26','/Pages/Costumer/alertCostumer.xaml','Relative','Doctor','2',NULL,'','DoctorsViewModel')
	
	insert into DBScriptLog(iScriptID,dDate,vDescription) values(117,GetDate(),'Script No#117 -- update app prefrance for docotr module' )
Print 'Script No#117 -- update app prefrance for docotr module - Script has Executed successfully'
End
Else
	Print 'Script No#117 -- update app prefrance for docotr module'
Go