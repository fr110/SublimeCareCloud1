IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdatePreference')
	BEGIN
		DROP  Procedure  InsertUpdatePreference
	END

GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE InsertUpdatePreference  --@iItemID = 2,@iStockIn =520 , @iProductionId = 2
	@iCompanyID int = null,
    @imLogoImage image = null,
    @vHeaderText varchar(500)= null,
    @bIsActive bit= null,
    @vDateFormat varchar(100)= null,
    @bStockOverRide bit= null,
    @vSaleType varchar(150)= null,
    @bDefaultCustomer bit = null,
    @iUpdate int = null,
    @bDurationReturnOnly bit = null,
    @iAllowedBackDays int = null, 
    @bShowPartyDetail bit =null,
	@bShowDeliveryDetail bit = null , 
	@bShowStockStatus bit = null  , 
	@iSalaryDays int = null,
	@bCashierID  int = null
    
AS
begin
		if(@iUpdate = 0) 
		Begin
			INSERT INTO dbo.posPreference 
			(
				 imLogoImage, vHeaderText,
				 bIsActive, vDateFormat, 
				 bStockOverRide, vSaleType,
				 bDefaultCustomer ,
				 bDurationReturnOnly,
				 iAllowedBackDays , 
				 bShowPartyDetail , bShowDeliveryDetail,
				 bShowStockStatus , iSalaryDays
				 ,bCashierID
			 )
			values
			(
				 @imLogoImage, @vHeaderText, 
				 @bIsActive, @vDateFormat, 
				 @bStockOverRide, @vSaleType, 
				 @bDefaultCustomer,@bDurationReturnOnly,
				 @iAllowedBackDays , @bShowPartyDetail , @bShowDeliveryDetail,
				 @bShowStockStatus , @iSalaryDays ,
				 @bCashierID
			 )
			
				set	@iCompanyID = @@IDENTITY
				select * From posPreference where iCompanyID = @iCompanyID
		End	
		
		if(@iUpdate=1)
		Begin 
			UPDATE dbo.posPreference
			SET    
				
				imLogoImage = @imLogoImage, 
				vHeaderText = @vHeaderText, 
				bIsActive = @bIsActive, 
				vDateFormat = @vDateFormat, 
				bStockOverRide = @bStockOverRide, 
				vSaleType = @vSaleType, 
				bDefaultCustomer = @bDefaultCustomer
				,bDurationReturnOnly = @bDurationReturnOnly,
				 iAllowedBackDays  = @iAllowedBackDays,
				 bShowPartyDetail =  @bShowPartyDetail ,
				  bShowDeliveryDetail= @bShowDeliveryDetail , 
				  bShowStockStatus = @bShowStockStatus,
				  iSalaryDays = @iSalaryDays ,
				  bCashierID = @bCashierID
			WHERE  iCompanyID = @iCompanyID
			
			select * From posPreference where iCompanyID = @iCompanyID
		End
		
End
GO


