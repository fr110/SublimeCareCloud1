IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateAppUsers')
	BEGIN
		DROP  Procedure  InsertUpdateAppUsers
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[InsertUpdateAppUsers]
	@iUserid int =  null,
	@vfName nvarchar(150) =  null,
	@vlName nvarchar(150)=  null,
	@dDOB DateTime = null,
	@vUserType varchar(50)  = null,
	@vLogin varchar(50) = null,	
	@vPassword varchar(100) = null,
	@vEmail varchar(50) = null,
	@bUpdate int = 0 , 
	@AllowdModule varchar(255) = null,
	@bIsActive  bit = null ,
	@bCanMakeEditAble bit = null
	-- 0 - Add User
	-- 1 - Edit User Profile
	-- 2 - Change Password
AS


	if(@bUpdate = 0) 
		Begin
	
			if not exists(select * from AppUsers where vLogin = @vLogin)
			Begin
			
				insert into AppUsers(vfName,vlName,dDOB,vUserType,vLogin,vPassword,
				vEmail,vAllowdModule,bIsActive, bCanMakeEditAble) 
					values(@vfName,@vlName,@dDOB,@vUserType,@vLogin,@vPassword,@vEmail,@AllowdModule,@bIsActive , @bCanMakeEditAble)
					
				Set @iUserid = @@IDENTITY
				
			End
			else
				Set @iUserid = -1
			
			select @iUserid as UseriID
		End
	Else if (@bUpdate = 1)
		Begin
			update AppUsers set
				vfName = @vfName,
				vlName = @vlName,
				vPassword = @vPassword,
				dDOB = @dDOB,
				vUserType = @vUserType,
				vEmail = @vEmail, 
				vAllowdModule = @AllowdModule,
				bIsActive = @bIsActive ,
				bCanMakeEditAble = @bCanMakeEditAble
			where iuserid = @iuserid and vLogin = @vLogin
			
			select @iuserid as UserID
		End
	Else if (@bUpdate = 2)
		Begin
			update AppUsers set
				vPassword = @vPassword				
			where iuserid = @iuserid and vLogin = @vLogin
			select @iuserid as UserID
		End

GO
