IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetPurchase')
	BEGIN
		DROP  Procedure  GetPurchase
	END

GO

/****** Object:  StoredProcedure [dbo].[GetAppUsers]    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[GetPurchase]--  @iPurchaseid= 134 , @dFromDate = N'2013-07-20' , @dToDate = N'2013-08-20'
	@iPurchaseid bigint = null,
    @ipartyId int = null,
    @ddate datetime = null,
    @vpartyName varchar(255) = null,
    @vpartymobile varchar(25) = null,
    @ftotalamount float = null,
    @vPaymentMod varchar(255) = null,
    @vVehicleNo varchar(25) = null,
    @vDriverName varchar(255) = null,
    @iUserid bigint = null,
    @vDeliveryExpense varchar(50) = null,
    @vSeason varchar(50) = null,
    @iDiscountPersent int = null,
    @fPayAbleAmount float = null,
    @fAmmountRecived float = null,
    @vReciverName varchar(150) = null,
    @iPurchaseManID bigint = null,
    @fBalance float = null,
    @dFromDate datetime = null,
    @dToDate datetime = null,
    @formnumber bigint = null
AS
	declare @cmd varchar(2000)
	set @cmd = ' SELECT     posPurchase.iPurchaseid, posPurchase.formnumber, posPurchase.ipartyId, CONVERT(VARCHAR(20), posPurchase.ddate, 100) as ddate, posPurchase.ftotalamount, posPurchase.vPaymentMod, posPurchase.vVehicleNo, 
                      posPurchase.vDriverName, posPurchase.iUserid, posPurchase.vDeliveryExpense, posPurchase.vSeason, posPurchase.iDiscountPersent, 
                      posPurchase.fPayAbleAmount, posPurchase.fAmmountRecived, posPurchase.vReciverName, posPurchase.iPurchaseManID, posPurchase.fBalance, 
                      posPurchase.AmountwithDExpense, posParty.vPartyName, posParty.vPartyadress as VpartyAddress, posParty.vpartyMobile, posParty.iCreditLimit, posParty.vMarket, 
                      posParty.vArea, posParty.vDistrict, posParty.VCity, posParty.vContactPerson, posParty.vLandlineNumber
FROM         posPurchase INNER JOIN
                      posParty ON posPurchase.ipartyId = posParty.iPartyID  WHERE   1=1 '
	if @iPurchaseid is not null and @iPurchaseid > 0
		set @cmd = @cmd + 'and iPurchaseid = ' +Cast(@iPurchaseid as varchar)
	
	if @ipartyId is not null and @ipartyId > 0
		set @cmd = @cmd + 'and posPurchase.ipartyId = ' +Cast(@ipartyId as varchar)
	
	-- make join with party
	if @dFromDate  is not null and @dFromDate <>  ''  
		set @cmd = @cmd + ' and dDate >= CAST(''' + Convert(varchar(150),@dFromDate,101) + ''' as Datetime)'
		
	if @dToDate  is not null and @dToDate <>  ''  
		set @cmd = @cmd + ' and dDate <= CAST(''' + Convert(varchar(150),@dToDate,101) + ''' as Datetime)'
	
	
	set @cmd = @cmd + 'Order By posPurchase.iPurchaseid DESC'
	print @cmd
	execute(@cmd)
	-- return sec table
	declare @cmd2 varchar(1000)
	set @cmd2 = ' select * from   posPurchaseItem INNER JOIN
                      posItems ON posPurchaseItem.iItemID = posItems.iItemID  WHERE   1=1 '
	if @iPurchaseid is not null and @iPurchaseid > 0
		begin
		set @cmd2 = @cmd2 + 'and iPurchaseid = ' +Cast(@iPurchaseid as varchar)
		
		execute(@cmd2)
		end
	--print @cmd
	


GO
