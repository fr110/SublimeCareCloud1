IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetModule')
	BEGIN
		DROP  Procedure  GetModule
	END

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].GetModule -- @AllowdModule = '1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21'
	@iModuleID int = null,
    @vModuleName varchar(255)= null,
    @bIsActive bit= null,
    @iModuleParentID int= null,
    @vUrlPath varchar(255)= null,
    @UriKind varchar(150)= null, 
    @vDisplayName varchar(150) = null,
    @AllowdModule varchar(255) = null
AS
	declare @cmd varchar(1000)
	set @cmd = ' select * from posModule  WHERE   1=1 '
	
	if @iModuleID is not null and @iModuleID > 0
		set @cmd = @cmd + 'and posModule.iModuleID = ' +Cast(@iModuleID as varchar)
	
	if @vDisplayName is not null
		set @cmd = @cmd + 'and posModule.vDisplayName = ' +Cast(@vDisplayName as varchar)
	
	if @AllowdModule is not null
		set @cmd = @cmd + 'and posModule.iModuleID IN (' +Cast(@AllowdModule as varchar(255)) + ')'
		
--		select * from posModule  WHERE   1=1 order by iModuleParentID
	set @cmd = @cmd + 'order by iModuleParentID , iDisplayOrder'
	print @cmd
	execute(@cmd)

GO


