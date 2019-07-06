IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateSaleInoviceItem')
	BEGIN
		DROP  Procedure  InsertUpdateSaleInoviceItem
	END

GO

/****** Object:  StoredProcedure dbo.GetAppUsers    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE dbo.InsertUpdateSaleInoviceItem --@iSaleid = 110
    @iSaleItemid bigint = null,
    @iSaleid bigint= null,
    @fUnitePrice float= null,
    @iQuantity int= null,
    @fGrossAmount float= null,
    @iItemID int= null,
    @iSerialNumber int = null,
    @iUpdate int= 0,
    @iUserId int = null,
    @iProductionId int = null ,
    @dDate datetime = null,
    @bReturnInvoice bit = null
AS
begin
set @dDate = GETDATE()
	declare @isReturn bit = (select CASE WHEN bReturnInvoice IS NULL THEN 'FALSE' ELSE bReturnInvoice END bReturnInvoice   from posSaleInovice where iSaleid = @iSaleid)
	declare @bIsDraft bit = (select CASE WHEN bIsDraft IS NULL THEN 'FALSE' ELSE bIsDraft END bIsDraft   from posSaleInovice  where iSaleid = @iSaleid)
		if(@iUpdate = 0) 
		Begin
			INSERT INTO posSaleItem 
			(
				iSaleid, fUnitePrice, 
				iQuantity, fGrossAmount, 
				iItemID,iSerialNumber , fUnitPurchasePrice , fGrossPurchasePrice
			)
			values
			(
				@iSaleid, @fUnitePrice, 
				@iQuantity, @fGrossAmount, 
				@iItemID, @iSerialNumber , (select fUnitPurchasePrice 
								from posItems where posItems.iItemID = @iItemID )  , 
								(select fUnitPurchasePrice * @iQuantity
								from posItems where posItems.iItemID = @iItemID 
						 )  
			)	
			
			set	@iSaleItemid = @@IDENTITY
			
		--	select SUM(istockin) as istockin , SUM(istockout) as istockout from posStock
			----declare @iPreviousStock int = select iCurrantStock from posStock where iItemID = 1 and iStokId = (select MAX(iStokId) from posStock where iItemID=1)
			----declare iCrntStock = @iPreviousStock - @istockout + (@istockin)
			--insert into posStock (iItemID,iCurrantStock,iUserId,iStockOut,iSaleId,iProductionId,dDate) 
			--select @iItemID,((SUM(istockin) - SUM(istockout))-@iQuantity),@iUserId, @iQuantity , @iSaleid ,@iProductionId,@dDate from posStock where iItemID = @iItemID
			--@iCurrantStock int= null,
			if(@bIsDraft = 'False')
			Begin
				if(@isReturn = 'False')
				begin 
				--print @isReturn
				execute InsertUpdateStock
				@iStokId = null, @iItemID = @iItemID, 
				@iUserId = @iUserId,
				@iStockIn = 0,
				@iStockOut = @iQuantity, 
				@iUpdate  = 0,  
				@iSaleId = @iSaleid,
				@dDate = @dDate,
				@bitReturn = 0,
				@vAction = N'Sale-Invoice'
				end
				
					if(@isReturn = 'True')
					begin 
					--print @isReturn
					execute InsertUpdateStock
					@iStokId = null, @iItemID = @iItemID, 
					@iUserId = @iUserId,
					@iStockIn = @iQuantity,
					@iStockOut = 0, 
					@iUpdate  = 0,  
					@iSaleId = @iSaleid,
					@dDate = @dDate,
					@bitReturn = 0,
					@vAction = N'Return-Invoice'
					end
			End
		--	Else
			
		End	
		
		
		if(@iUpdate = 1)
		Begin
			UPDATE dbo.posSaleItem
			SET    iSaleid = @iSaleid, fUnitePrice = @fUnitePrice, iQuantity = @iQuantity, fGrossAmount = @fGrossAmount, iItemID = @iItemID, iSerialNumber = @iSerialNumber
			WHERE  iSaleItemid = @iSaleItemid
			if(@bIsDraft = 'False')
			Begin
				if(@isReturn = 'False')
				begin 
				--print @isReturn
				execute InsertUpdateStock
				@iStokId = null, @iItemID = @iItemID, 
				@iUserId = @iUserId,
				@iStockIn = 0,
				@iStockOut = @iQuantity, 
				@iUpdate  = 0,  
				@iSaleId = @iSaleid,
				@dDate = @dDate,
				@bitReturn = 0,
				@vAction = N'Sale-Invoice'
				end
				
					if(@isReturn = 'True')
					begin 
					--print @isReturn
					execute InsertUpdateStock
					@iStokId = null, @iItemID = @iItemID, 
					@iUserId = @iUserId,
					@iStockIn = @iQuantity,
					@iStockOut = 0, 
					@iUpdate  = 0,  
					@iSaleId = @iSaleid,
					@dDate = @dDate,
					@bitReturn = 0,
					@vAction = N'Return-Invoice'
					end
			End
		End
		
		SELECT * From posSaleItem where iSaleItemid = @iSaleItemid
end

GO


