IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdatePurchaseItem')
	BEGIN
		DROP  Procedure  InsertUpdatePurchaseItem
	END

GO

/****** Object:  StoredProcedure dbo.GetAppUsers    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE InsertUpdatePurchaseItem
    @iPurchaseItemid bigint = null,
    @iPurchaseid bigint= null,
    @fUnitePrice float= null,
    @iQuantity int= null,
    @fGrossAmount float= null,
    @iItemID int= null,
    @iSerialNumber int = null,
    @iUpdate int= 0,
    @iUserId int = null,
    @iProductionId int = null ,
    @dDate datetime = null
AS
begin
set @dDate = GETDATE()
		if(@iUpdate = 0) 
		Begin
			INSERT INTO posPurchaseItem 
			(
				iPurchaseid, fUnitePrice, 
				iQuantity, fGrossAmount, 
				iItemID,iSerialNumber
			)
			values
			(
				@iPurchaseid, @fUnitePrice, 
				@iQuantity, @fGrossAmount, 
				@iItemID, @iSerialNumber
			)	
			
			set	@iPurchaseItemid = @@IDENTITY
			
		--	select SUM(istockin) as istockin , SUM(istockout) as istockout from posStock
			----declare @iPreviousStock int = select iCurrantStock from posStock where iItemID = 1 and iStokId = (select MAX(iStokId) from posStock where iItemID=1)
			----declare iCrntStock = @iPreviousStock - @istockout + (@istockin)
			--insert into posStock (iItemID,iCurrantStock,iUserId,iStockOut,iPurchaseId,iProductionId,dDate) 
			--select @iItemID,((SUM(istockin) - SUM(istockout))-@iQuantity),@iUserId, @iQuantity , @iPurchaseid ,@iProductionId,@dDate from posStock where iItemID = @iItemID
			--@iCurrantStock int= null,
			execute InsertUpdateStock
			@iStokId = null, @iItemID = @iItemID, 
			@iUserId = @iUserId, @iStockIn = @iQuantity, 
			@iUpdate  = 0,  
		--	@iPurchaseId = @iPurchaseid,
			@dDate = @dDate,
			@bitReturn = 0,
			@vAction = N'Purchase-Invoice'
			--@iProductionId int= null,
			--@dDate datetime= null,
   		
			
		End	
		
		
		SELECT * From posPurchaseItem where iPurchaseItemid = @iPurchaseItemid
end
GO


