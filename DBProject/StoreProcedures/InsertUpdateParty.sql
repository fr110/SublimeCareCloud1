IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateParty')
	BEGIN
		DROP  Procedure  InsertUpdateParty
	END

GO

/****** Object:  StoredProcedure dbo.GetAppUsers    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE InsertUpdateParty
	@iPartyID bigint = null,
    @vPartyName varchar(255) = null,
    @vPartyadress varchar(255) = null,
    @vpartyMobile varchar(25) = null,
    @iSaleManID int = null,
    @iUpdate int = null,
    @iCreditLimit bigint= null,
    @vMarket varchar(250)= null,
    @vArea varchar(250)= null,
    @vDistrict varchar(250)= null,
    @VCity varchar(250)= null,
    @vContactPerson varchar(250)= null,
    @vLandlineNumber varchar(25)= null
AS
begin
		if(@iUpdate = 0) 
		Begin
			
			INSERT INTO posParty (vPartyName, vPartyadress, vpartyMobile, iSaleManID, iCreditLimit, vMarket, vArea, vDistrict, VCity, vContactPerson, vLandlineNumber)
			values( @vPartyName, @vPartyadress, @vpartyMobile, @iSaleManID, @iCreditLimit, @vMarket, @vArea, @vDistrict, @VCity, @vContactPerson, @vLandlineNumber)
			set	@iPartyID = @@IDENTITY
			-- Set Up a Account
		Declare @tempdate datetime 
	   set @tempdate = getdate();
		
		Declare @AccountName varchar(150) = @vPartyName ,
		@vAccountNo varchar(50)= 'P-'+ +cast ( day(@tempdate) as varchar(5))+ cast (Month(@tempdate) as varchar(5))+ cast (Year(@tempdate) as varchar(20))+'-'+ cast(@iPartyID as varchar(12)),
		@vAccountDesc varchar(200)='Party Account Created on ' + cast(getdate() as varchar),--date(Now),
		@vAccountComments varchar(200) = '',
		@bEditable bit = 0,
		@iFinaceType int = 3,
		@iModuleID int = (Select top 1 iModuleID From posModule where vModuleName = 'Party'),
		@iModuleFK_ID int = @iPartyID ,
		@type int = 0,
		@bNominal bit = 0,
		@vAccountCode varchar(255)= null
		EXECUTE InsertUpdateAccount  null,@AccountName,@vAccountNo, @vAccountDesc,  @vAccountComments,  @bEditable, @iFinaceType, @iModuleID,  @iModuleFK_ID,@iUpdate , @bNominal ,@type
			
		End	
		
		Else if (@iUpdate = 1 and @iPartyID > 0 )
		
		Begin
		
			UPDATE posParty
			SET    vPartyName = @vPartyName, vPartyadress = @vPartyadress, vpartyMobile = @vpartyMobile, iSaleManID = @iSaleManID, iCreditLimit = @iCreditLimit, vMarket = @vMarket, vArea = @vArea, vDistrict = @vDistrict, VCity = @VCity, vContactPerson = @vContactPerson, vLandlineNumber = @vLandlineNumber
			WHERE  iPartyID = @iPartyID
			
			
		END
		
		SELECT * From posParty  where iPartyID = @iPartyID
End
GO


