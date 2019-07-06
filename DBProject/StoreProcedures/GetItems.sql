IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetItems')
	BEGIN
		DROP  Procedure  GetItems
	END

GO

/****** Object:  StoredProcedure [dbo].[GetAppUsers]    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].GetItems --@iItemID = 13 --@vItemBarcode = '123' @StockStatus = 'Not Available'--

	@iItemID int  = null ,
    @vItemName varchar(250) = null ,
    @vDetailName varchar(250) = null ,
    @bFuzzyDelented bit = null ,
    @vCompanyName varchar(250) = null ,
    @fUnitePrice float = null ,
    @fMaxDiscountPresent float = null ,
    @vItemBarcode varchar(255)  = null ,
    @StockStatus varchar(255)  = null 
AS
	declare @cmd varchar(2000)
	set @cmd = 'select row_number() over (ORDER BY iItemID) as SR, * from 
		(SELECT       posItems.iItemID, ISNULL( posItems.BIsEditAbleInInvoice , 0) as BIsEditAbleInInvoice,
		posItems.vItemName, posItems.fUnitPurchasePrice, posItems.vItemType, posItems.vDetailName, posItems.bFuzzyDelented, posItems.vCompanyName, posItems.fUnitePrice, 
                      posItems.fMaxDiscountPresent, posItems.vItemBarcode,  posStock.iStokId, coalesce(posStock.iCurrantStock,0) as iCurrantStock, 
	posStock.iStockIn, posStock.iStockOut, posStock.iSaleId, posStock.iProductionId, posStock.dDate,
			CASE WHEN  posStock.iCurrantStock is null THEN '+'''Not Available'+'''  
			WHEN  posStock.iCurrantStock =posItems.iAlertAmount THEN '+'''Not Available'+''' 
			WHEN  posStock.iCurrantStock <posItems.iAlertAmount THEN '+'''Not Available'+''' 
			WHEN  posStock.iCurrantStock > posItems.iAlertAmount Then '+'''Available'+''' END  as StockStatus, 
			
			CASE WHEN  posItems.bIsSaleAble is null THEN '+'''False'+'''  
			WHEN  posItems.bIsSaleAble = 1 THEN '+'''True'+''' 
			WHEN  posItems.bIsSaleAble = 0 Then '+'''False'+''' END  as bIsSaleAble, posItems.vPackDescription, posItems.iAlertAmount ,
			case when posItems.BIsEditAbleInInvoice is null then
			'+'''False'+'''  
			when posItems.BIsEditAbleInInvoice = 1 then
			'+'''True'+'''   end as BIsEditAbleInInvoice2
			
FROM         posItems left JOIN 
                      (select  * from (select * ,
    rowid = ROW_NUMBER() OVER (PARTITION BY posStock.iItemid ORDER BY iStokId DESC)  
    FROM posStock
    
     ) t WHERE rowid <= 1) posStock ON posItems.iItemID = posStock.iItemID  ) st WHERE   1=1 '
	

	
	if @iItemID is not null and @iItemID > 0
		set @cmd = @cmd + 'and st.iItemID = ' +Cast(@iItemID as varchar)
		
	if @vItemBarcode is not null 
		set @cmd = @cmd + 'and st.vItemBarcode = ''' +@vItemBarcode + ''''
	if @StockStatus is not null 
		set @cmd = @cmd + 'and st.StockStatus = ''' +@StockStatus + ''''

		print @cmd
	execute(@cmd)

GO


