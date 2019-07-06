IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetAccounts')
	BEGIN
		DROP  Procedure  GetAccounts
	END

GO

create PROCEDURE [dbo].[GetAccounts] ---@IAccountid = 6--@VAccountName = 'Fir'--null,null,null,null,null,0
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
	set @cmd = 'SELECT posAccounts.iAccountid, posAccounts.AccountName, posAccounts.vAccountNo, posAccounts.vAccountDesc, posAccounts.vAccountComments, posAccounts.bEditable, 
                       posAccounts.iModuleID, posAccounts.iModuleFK_ID, posAccounts.bNominal, posFinaceType.iFinaceType, posFinaceType.vFinaceType, 
                       posFinaceType.vFinaceTypeDes
					   FROM         posAccounts INNER JOIN
                       posFinaceType ON posAccounts.iFinaceType = posFinaceType.iFinaceType where 1=1 '
                      
     if @VAccountName is not null and @VAccountName <> ''
		set @cmd = @cmd + ' and posAccounts.AccountName like  ''%' + @VAccountName + '%'''
				
	 if @VAccountNo is not null and @VAccountNo <> ''
		set @cmd = @cmd + ' and posAccounts.vAccountNo like  ''%' + @VAccountNo + '%'''
			
	if @IAccountid is not null and @IAccountid <> 0
		set @cmd = @cmd + 'and posAccounts.iAccountid = ''' + Cast(@IAccountid as varchar(10)) + ''''
	
	print (@cmd)	
		
	execute(@cmd)