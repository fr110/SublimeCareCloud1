IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetSaleInovice')
	BEGIN
		DROP  Procedure  GetSaleInovice
	END

GO

/****** Object:  StoredProcedure [dbo].[GetAppUsers]    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[GetSaleInovice] --@iSaleid= 2907 --@ICostumerId = 1 -- @iSaleid= 274 --, @dFromDate = N'9/12/2013' --, @dToDate = N'2013-08-20'
	@iSaleid bigint = null,
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
    @iSaleManID bigint = null,
    @fBalance float = null,
    @dFromDate datetime = null,
    @dToDate datetime = null,
    @ICostumerId int = null
AS
	declare @cmd varchar(2000)
--	set @cmd = ' SELECT     posSaleInovice.iSaleid, posSaleInovice.ipartyId, CONVERT(VARCHAR(20), posSaleInovice.ddate, 100) as ddate, posSaleInovice.ftotalamount, posSaleInovice.vPaymentMod, posSaleInovice.vVehicleNo, 
--                      posSaleInovice.vDriverName,  posSaleInovice.bReturnInvoice,posSaleInovice.bCanelDone, posSaleInovice.iUserid, posSaleInovice.vDeliveryExpense, posSaleInovice.vSeason, posSaleInovice.iDiscountPersent, 
--                      posSaleInovice.fPayAbleAmount, posSaleInovice.fAmmountRecived, posSaleInovice.vReciverName, posSaleInovice.iSaleManID, posSaleInovice.fBalance, 
--                      posSaleInovice.AmountwithDExpense, posParty.vPartyName, posParty.vPartyadress as VpartyAddress, posParty.vpartyMobile, posParty.iCreditLimit, posParty.vMarket, 
--                      posParty.vArea, posParty.vDistrict, posParty.VCity, posParty.vContactPerson, posParty.vLandlineNumber , posSaleInovice.bIsDraft,posSaleInovice.bFinalized
--FROM         posSaleInovice INNER JOIN
--                      posParty ON posSaleInovice.ipartyId = posParty.iPartyID  WHERE   1=1 '
set @cmd = ' SELECT     posSaleInovice.iSaleid,posSaleInovice.fGrossPurchasePrice, posSaleInovice.ipartyId, CONVERT(VARCHAR(20), posSaleInovice.ddate, 100) as ddate, posSaleInovice.ftotalamount, posSaleInovice.vPaymentMod, posSaleInovice.vVehicleNo, 
                      posSaleInovice.vDriverName,  posSaleInovice.bReturnInvoice,posSaleInovice.bCanelDone, posSaleInovice.iUserid, posSaleInovice.vDeliveryExpense, posSaleInovice.vSeason, posSaleInovice.iDiscountPersent, 
                      posSaleInovice.fPayAbleAmount,posSaleInovice.vFirstElectricianName ,posSaleInovice.vSecElectricianName , posSaleInovice.fAmmountRecived, posSaleInovice.vReciverName, posSaleInovice.iSaleManID, posSaleInovice.fBalance, 
                      posSaleInovice.AmountwithDExpense ,posSaleInovice.bIsDraft,posSaleInovice.bFinalized , tblCostumer.* ,posSaleInovice.ICostumerId
                      ,posSaleInovice.fServices, AppUsers.iUserid, AppUsers.vfName, AppUsers.vlName
                      FROM         posSaleInovice INNER JOIN
                       tblCostumer ON posSaleInovice.ICostumerId = tblCostumer.CostumerID left join   AppUsers on AppUsers.iUserid = posSaleInovice.iUserid WHERE   1=1 '
                       
	if @iSaleid is not null and @iSaleid > 0
		set @cmd = @cmd + 'and iSaleid = ' +Cast(@iSaleid as varchar)
	
	if @ICostumerId is not null and @ICostumerId > 0
		set @cmd = @cmd + 'and posSaleInovice.ICostumerId= ' +Cast(@ICostumerId as varchar)
	
	-- make join with party
	if @dFromDate  is not null and @dFromDate <>  ''  
		set @cmd = @cmd + ' and dDate >= CAST(''' + Convert(varchar(150),@dFromDate,101) + ''' as Datetime)'
		
	if @dToDate  is not null and @dToDate <>  ''  
		set @cmd = @cmd + ' and dDate <= CAST(''' + Convert(varchar(150),@dToDate,101) + ''' as Datetime)'
	
	set @cmd = @cmd + 'Order By posSaleInovice.iSaleid DESC'
	print @cmd
	execute(@cmd)
	-- return sec table
	declare @cmd2 varchar(2000)
	set @cmd2 = 'SELECT  posSaleItem.fUnitPurchasePrice, posSaleItem.fGrossPurchasePrice, posSaleItem.iSaleItemid, posSaleItem.iSaleid, posSaleItem.fUnitePrice, posSaleItem.iQuantity, posSaleItem.fGrossAmount, posSaleItem.iItemID, 
                      posSaleItem.iSerialNumber, posItems.vItemName, posItems.vDetailName, posItems.bFuzzyDelented, posItems.vCompanyName, posItems.fUnitePrice AS Expr1, 
                      posItems.fMaxDiscountPresent, posItems.vItemBarcode, posItems.bIsSaleAble, posItems.vPackDescription, posStock.iCurrantStock, posStock.iUserId, 
                      posStock.iStockIn, posStock.iStockOut, posStock.iProductionId, posStock.dDate,
                      CASE WHEN  posStock.iCurrantStock is null THEN '+'''Not Available'+'''  
			WHEN  posStock.iCurrantStock =0 THEN '+'''Not Available'+''' 
			WHEN  posStock.iCurrantStock <0 THEN '+'''Not Available'+''' 
			WHEN  posStock.iCurrantStock > 0 Then '+'''Available'+''' END  as StockStatus, 
			
			CASE WHEN  posItems.bIsSaleAble is null THEN '+'''False'+'''  
			WHEN  posItems.bIsSaleAble = 1 THEN '+'''True'+''' 
			WHEN  posItems.bIsSaleAble = 0 Then '+'''False'+''' END  as bIsSaleAble
                      , posStock.vAction
                      
FROM         posSaleItem left outer JOIN
                      posItems ON posSaleItem.iItemID = posItems.iItemID left outer JOIN
                         (select  * from (select * ,
    rowid = ROW_NUMBER() OVER (PARTITION BY posStock.iItemid ORDER BY iStokId DESC)  
    FROM posStock
    
     ) t WHERE rowid <= 1) posStock ON posItems.iItemID = posStock.iItemID  WHERE   1=1 '
	if @iSaleid is not null and @iSaleid > 0
		begin
		set @cmd2 = @cmd2 + 'and posSaleItem.iSaleid = ' +Cast(@iSaleid as varchar)
		set @cmd2 = @cmd2 + 'order by iSerialNumber asc'
--select * from 		
		print(@cmd2)
		execute(@cmd2)
		end
	--print @cmd
	


GO
