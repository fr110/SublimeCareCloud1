IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateModule')
	BEGIN
		DROP  Procedure  InsertUpdateModule
	END

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE dbo.InsertUpdateModule
    @iModuleID int =  null,
    @vModuleName varchar(255)=  null,
    @bIsActive bit=  null,
    @iModuleParentID int=  null,
    @vUrlPath varchar(255)=  null,
    @UriKind varchar(150)=  null,
    @vDisplayName varchar(150)=  null,
    @iDisplayOrder int=  null,
    @iUpdate int = 0
AS
	if(@iUpdate = 0) 
		Begin
			
			INSERT INTO dbo.posModule 
				(
					vModuleName, bIsActive, 
					iModuleParentID, vUrlPath, 
					UriKind, vDisplayName, 
					iDisplayOrder
				)values(
					@vModuleName, @bIsActive, 
					@iModuleParentID, @vUrlPath, 
					@UriKind, @vDisplayName, 
					@iDisplayOrder
					)
	
			set	@iModuleID = @@IDENTITY
			select * From posModule where @iModuleID = @iModuleID
		End	

	if(@iUpdate = 1) 
		Begin
				UPDATE dbo.posModule
					SET    
						vModuleName = @vModuleName, bIsActive = @bIsActive, 
						iModuleParentID = @iModuleParentID, vUrlPath = @vUrlPath, 
						UriKind = @UriKind, vDisplayName = @vDisplayName, 
						iDisplayOrder = @iDisplayOrder
						WHERE  iModuleID = @iModuleID
						
						--if(@iDisplayOrder is not null)
						--Begin
						--UPDATE dbo.posModule
						--SET    
						--iDisplayOrder = @iDisplayOrder
						--WHERE  iModuleID = @iModuleID
						--end
			select * From posModule where @iModuleID = @iModuleID
		End	

GO


