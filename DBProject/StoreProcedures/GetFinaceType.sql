IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetFinaceType')
	BEGIN
		DROP  Procedure  GetFinaceType
	END

GO

create PROCEDURE dbo.GetFinaceType --@VAccountName = 'Fir'--null,null,null,null,null,0
    @IAccountid int = null
   ,@VAccountName varchar(150) = null
   ,@VAccountNo  varchar(150) = null
   ,@VAccountDesc varchar(200) = null
   ,@VAccountComments varchar(200) = null
   ,@BEditable bit = null
   ,@IFinaceType int = null
   ,@IModuleID int = null
   ,@IModuleFK_ID int = null
   ,@bNominal bit = null
	
	--@SrtDate int = null,

	,@vSortColumn varchar(20) = null,
	@vSortOrder varchar(5) = null
AS
	declare @cmd varchar(3000)
	set @cmd = 'SELECT * from posFinaceType where 1=1'
	--   if @VAccountName is not null and @VAccountName <> ''
	--  set @cmd = @cmd + ' and posAccounts.AccountName like  ''%' + @VAccountName + '%'''
				
	 --if @VAccountNo is not null and @VAccountNo <> ''
		--set @cmd = @cmd + ' and posAccounts.vAccountNo like  ''%' + @VAccountNo + '%'''
		
	
	print (@cmd)	
		
	execute(@cmd)