IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateItem')
	BEGIN
		DROP  Procedure  InsertUpdateItem
	END
GO

/****** Object:  StoredProcedure dbo.GetAppUsers    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE InsertUpdateItem
	@iItemID int = null,
    @vItemName varchar(250)  = null,
    @vDetailName varchar(250) = null,
    @bFuzzyDelented bit = null,
    @vCompanyName varchar(250) = null,
    @fUnitePrice float = null,
    @fMaxDiscountPresent float = 0,
    @vItemBarcode varchar(255) = null,
    @iUpdate int = 0,
    @iUserId int = null, 
    @dDate datetime = null,
    @bIsSaleAble bit = null, 
    @VPackDescription varchar(255) = null,
    @vItemType varchar(255) = null,
    @fUnitPurchasePrice float = null,
    @initialStock int = 0,
    @iAlertAmount int = null ,
    @bIsEditAbleInInvoice bit = 0 
AS
begin
set @dDate = GETDATE()
		if(@iUpdate = 0) 
		Begin
		if not exists (Select * From dbo.posItems where vItemName = @vItemName or vItemBarcode = @vItemBarcode)
		begin 
			INSERT INTO posItems 
			(vItemName, vDetailName, 
			 bFuzzyDelented, vCompanyName, 
			 fUnitePrice, fMaxDiscountPresent, 
			 vItemBarcode , bIsSaleAble,
			  vPackDescription , fUnitPurchasePrice ,vItemType,iAlertAmount , 
			  bIsEditAbleInInvoice
			 )
			values (
			@vItemName, @vDetailName, 
			@bFuzzyDelented, @vCompanyName, 
			@fUnitePrice, @fMaxDiscountPresent, 
			@vItemBarcode , @bIsSaleAble,
			 @VPackDescription,@fUnitPurchasePrice ,@vItemType,@iAlertAmount,
			 @bIsEditAbleInInvoice)
			
			set @iItemID  = SCOPE_IDENTITY()
			
			execute InsertUpdateStock
			@iStokId = null, @iItemID = @iItemID, 
			@iUserId = @iUserId, @iStockOut = 0,@iCurrantStock = 0, @iStockIn = 0,
			@iUpdate  = 0,  
			@iSaleId = null,
			@dDate = @dDate,
			@bitReturn = 0,
			@vAction = N'New-Item [ Opening Stock ]'
			end
			else
			begin
			set @iItemID = -1 
			select  @iItemID as iItemID
			end 
		End	
		
		Else if (@iUpdate = 1 and @iItemID  > 0 )
		Begin
		UPDATE posItems
			SET    vItemName = @vItemName, vDetailName = @vDetailName, bFuzzyDelented = @bFuzzyDelented, 
			vCompanyName = @vCompanyName, fUnitePrice = @fUnitePrice, fMaxDiscountPresent = @fMaxDiscountPresent, 
			vItemBarcode = @vItemBarcode , bIsSaleAble = @bIsSaleAble ,  vPackDescription = @VPackDescription,
			fUnitPurchasePrice = @fUnitPurchasePrice ,vItemType = @vItemType , iAlertAmount = @iAlertAmount ,
			bIsEditAbleInInvoice = @bIsEditAbleInInvoice
		WHERE  iItemID = @iItemID
	

		End
		

	SELECT * From posItems  where iItemID  = @iItemID 	
END

GO


