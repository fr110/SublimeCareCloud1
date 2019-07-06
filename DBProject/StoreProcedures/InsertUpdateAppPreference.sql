IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateAppPreference')
	BEGIN
		DROP  Procedure  InsertUpdateAppPreference
	END

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE dbo.InsertUpdateAppPreference
	@iApplicationID int = null,
    @vApplicationName varchar(255) = null,
    @imgCompanyLogo image = null,
    @vCompanyName varchar(255) = null,
    @vEnableModules varchar(255) = null , 
    @vHeaderAdress varchar(255) = null,
    @vCompanyMobile  varchar(255) = null,
    @iUpdate int = 0
AS
	if(@iUpdate = 0) 
		Begin
			INSERT INTO dbo.AppPreference 
				(
					vApplicationName, imgCompanyLogo,
					vCompanyName, vEnableModules , vHeaderAdress ,vCompanyMobile 
				)values(
					 @vApplicationName, @imgCompanyLogo, 
					 @vCompanyName, @vEnableModules , @vHeaderAdress ,@vCompanyMobile 
					 )
			set	@iApplicationID = @@IDENTITY
			select * From AppPreference where iApplicationID = @iApplicationID
		End	

	
	if(@iUpdate = 1) 
		Begin
				UPDATE dbo.AppPreference
					SET   
					 vApplicationName = @vApplicationName, 
					 imgCompanyLogo = @imgCompanyLogo, 
					 vCompanyName = @vCompanyName, 
					 vEnableModules = @vEnableModules,
					 vHeaderAdress = @vHeaderAdress,
					 vCompanyMobile = @vCompanyMobile
					WHERE  iApplicationID = @iApplicationID
			select * From AppPreference where iApplicationID = @iApplicationID
		End	

GO


