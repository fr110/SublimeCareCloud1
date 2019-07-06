IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetAppPreference')
	BEGIN
		DROP  Procedure  GetAppPreference
	END

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].GetAppPreference
	@iApplicationID int  = null,
    @vApplicationName varchar(255) = null,
    @imgCompanyLogo image= null,
    @vCompanyName varchar(255)= null
AS
	declare @cmd varchar(1000)
	set @cmd = ' select * from AppPreference  WHERE   1=1 '
	
	if @iApplicationID is not null and @iApplicationID > 0
		set @cmd = @cmd + 'and AppPreference.iApplicationID = ' +Cast(@iApplicationID as varchar)
		
		
	print @cmd
	execute(@cmd)

GO


