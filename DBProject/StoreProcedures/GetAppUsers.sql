IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetAppUsers')
	BEGIN
		DROP  Procedure  GetAppUsers
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetAppUsers]
	@iUserId int = null, 
	@vLogin varchar(50) = null,
	@vPassword varchar(100) = null,
	@vUserType varchar(50) = null,
	@vfName varchar(150) = null,
	@vlName varchar(150) = null,
	@vEmail varchar(50) =null
AS
	declare @cmd varchar(1000)
	--iUserid,vfName,vlName,dDOB,vUserType,vLogin,vPassword,vEmail,dLastLoginTime,vAllowdModule
	set @cmd = 'select 
		   iUserId
		   ,vfName
           ,vlName
           ,dDOB
           ,vUserType
           ,vLogin
           ,vPassword
           ,dLastLoginTime
           ,vEmail
           ,vAllowdModule
           ,bIsActive
           ,ISNULL(bCanMakeEditAble , 0) as bCanMakeEditAble from AppUsers where 1=1 '
	
	if exists(select * from appusers where vlogin=@vlogin and vpassword = @vpassword)
		update Appusers
			set dLastLoginTime = GETDATE()
		where  vlogin=@vlogin and vpassword = @vpassword
	
	if @vLogin is not null and @vLogin <> ''
		set @cmd = @cmd + 'and vlogin = ''' +@vLogin + ''''
		
	if @vPassword is not null and @vPassword <> ''
		set @cmd = @cmd + 'and vpassword = ''' + @vPassword + ''''
		
	if @iUserId is not null and @iUserId <> 0
		set @cmd = @cmd + 'and iUserId = ''' + Cast(@iUserId as varchar) + ''''

	if @vUserType is not null and @vUserType <> '' -- and @vUserType = 'user'
		set @cmd = @cmd + 'and vUserType = ''' + Cast(@vUserType as varchar) + ''''
		
		
	if @vUserType is not null and @vUserType <> '' and @vUserType = 'admin'
		set @cmd = @cmd + 'and vUserType <> ''' + Cast('MD Admin' as varchar) + ''''
		
	 --enable use to get by name 
	if @vfName is not null and @vfName <> ''
		set @cmd = @cmd + ' and vfName like  ''%' + @vfName + '%'''
			
	if @vlName is not null and @vlName <> ''
		set @cmd = @cmd + ' and vlName like  ''%' + @vlName + '%'''
		
		if @vEmail is not null and @vEmail <> ''
		set @cmd = @cmd + ' and vEmail like  ''%' + @vEmail + '%'''

		--print @cmd
	execute(@cmd)
