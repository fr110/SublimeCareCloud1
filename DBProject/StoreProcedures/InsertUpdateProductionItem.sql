IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateProductionItem')
	BEGIN
		DROP  Procedure  InsertUpdateProductionItem
	END
GO

/****** Object:  StoredProcedure dbo.GetAppUsers    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE InsertUpdateProductionItem
    @iProductionItemid bigint = null,
    @iProductionid bigint = null ,
    @fUnitePrice float  = null ,
    @iQuantity int  = null ,
    @fGrossAmount float = null ,
    @iItemID int  = null ,
    @iSerialNumber int  = null ,
    @iProductionItemType int  = null ,  -- 0 mean consumed 1 mean prduced 
    @iUserId int = null,
    @dDate datetime = null , 
    @iUpdate int = 0
AS
begin
--set @dDate = GETDATE()
		if(@iUpdate = 0) 
		Begin
				INSERT INTO posProductionItem 
				( iProductionid, fUnitePrice, 
				  iQuantity, fGrossAmount, 
				  iItemID, iSerialNumber, 
				  iProductionItemType
				  )values(
				   @iProductionid, @fUnitePrice, 
				   @iQuantity, @fGrossAmount, 
				   @iItemID, @iSerialNumber, 
				   @iProductionItemType )
			set	@iProductionItemid = @@IDENTITY
			
			if (@iProductionItemType = 0)
			begin 
				execute InsertUpdateStock
				@iStokId = null, @iItemID = @iItemID, 
				@iUserId = @iUserId, 
				@iStockOut = @iQuantity, 
				@iUpdate  = 0,  
				--	@iPurchaseId = @iPurchaseid,
				@dDate = @dDate,
				@bitReturn = 0,
				@vAction = N'Production-Consumed',
				@iProductionId = @iProductionid
				--@dDate datetime= null,
   			end 
   			
		if (@iProductionItemType = 1)
			begin 
				execute InsertUpdateStock
				@iStokId = null, @iItemID = @iItemID, 
				@iUserId = @iUserId, @iStockIn = @iQuantity, 
				@iUpdate  = 0,  
				--	@iPurchaseId = @iPurchaseid,
				@dDate = @dDate,
				@bitReturn = 0,
				@vAction = N'Production-Produced',
				@iProductionId =@iProductionid
				--@dDate datetime= null,
   			end 
			
		End	
		
		
		SELECT * From posProductionItem where iProductionItemid = @iProductionItemid
end
GO


