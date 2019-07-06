IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetItemStock')
	BEGIN
		DROP  Procedure  GetItemStock
	END

GO

/****** Object:  StoredProcedure [dbo].[GetAppUsers]    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].GetItemStock 
	@iStokId bigint = null,
    @iItemID int= null,
    @iCurrantStock int= 0,
    @iUserId int= null,
    @iStockIn int= 0,
    @iStockOut int= 0,
    @iSaleId int= null,
    @iProductionId int= null,
    @dDate datetime= null,
    @iUpdate int = 0,
    @bitReturn int = 0,
    @vAction varchar(255) = null,
     @dFromDate datetime = null,
    @dToDate datetime = null
AS
	declare @cmd varchar(1000)
	set @cmd = 'SELECT     posStock.iStokId, posStock.iItemID, posStock.iCurrantStock, posStock.iUserId, posStock.iStockIn, posStock.iStockOut, posStock.iSaleId, 
                      posStock.iProductionId, CONVERT(VARCHAR(8),posStock.dDate,108)as tTime ,posStock.dDate, posStock.vAction, posItems.vItemName, posItems.vDetailName, posItems.bFuzzyDelented, posItems.vCompanyName, posItems.fUnitePrice, posItems.fMaxDiscountPresent, 
                      posItems.vItemBarcode
FROM         posStock INNER JOIN
                      posItems ON posStock.iItemID = posItems.iItemID
                      where 1=1 '
	if @iItemID is not null and @iItemID > 0
		set @cmd = @cmd + 'and posItems.iItemID = ' +Cast(@iItemID as varchar)
		
		if @dFromDate  is not null and @dFromDate <>  ''  
		set @cmd = @cmd + ' and posStock.dDate >= CAST(''' + Convert(varchar(150),@dFromDate,101) + ''' as Datetime)'
		
	if @dToDate  is not null and @dToDate <>  ''  
		set @cmd = @cmd + ' and posStock.dDate <= CAST(''' + Convert(varchar(150),@dToDate,101) + ''' as Datetime)'

set @cmd = @cmd + 'order By posStock.iStokId DESC, posStock.dDate DESC'
	print @cmd
	execute(@cmd)

GO


