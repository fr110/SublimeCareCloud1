IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateProduction')
	BEGIN
		DROP  Procedure  InsertUpdateProduction
	END

GO

/****** Object:  StoredProcedure dbo.GetAppUsers    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE dbo.InsertUpdateProduction
	@iProductionId bigint = null,
    @dDate datetime = null,
    @vLocation varchar(255) = null,
    @vPurchaseManager varchar(255) = null,
    @vProductionUnit varchar(255) = null,
    @fProductionCast float = null,
    @iUpdate int = null
AS
begin
		if(@iUpdate = 0) 
		Begin
		INSERT INTO dbo.posProduction 
		( dDate, vLocation, 
		 vPurchaseManager, vProductionUnit, fProductionCast
		 )values
		( @dDate, @vLocation, 
		 @vPurchaseManager, @vProductionUnit, @fProductionCast
		)
		
		set	@iProductionId = @@IDENTITY
		End	
		--Else if (@iUpdate = 1 and @iPurchaseid > 0 )
		
		--Begin
		
		--END
		
		SELECT * From posProduction where iProductionId = @iProductionId
end
GO


