IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateEmployee')
	BEGIN
		DROP  Procedure  InsertUpdateEmployee
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsertUpdateEmployee] 
	-- Add the parameters for the stored procedure here
	   @Empid int = NULL
	  ,@Title VARCHAR(50) = NULL
	  ,@EmpfName  VARCHAR(50) = NULL
	  ,@EmplName VARCHAR(50) = NULL
	  ,@MaritalStatus VARCHAR(50) = NULL
      ,@EmpIdNo VARCHAR(50) = NULL
      ,@Passport VARCHAR(100) = NULL
      ,@EmpType VARCHAR(50) = NULL
      ,@Address VARCHAR(150) = NULL
      ,@City VARCHAR(100) = NULL
      ,@Nationality VARCHAR(50) = NULL
      ,@Mobile VARCHAR(50) = NULL
      ,@Designation VARCHAR(50) = NULL
      ,@JoiningDate datetime = NULL
      ,@Balance int = NULL
      ,@Desc VARCHAR(200) = NULL
	  ,@Active bit = NULL
	  ,@BasSal int = NULL
	  ,@Housing int = NULL
	  ,@Traveling int = NULL
	  ,@Miscellaneous int = NULL
	  ,@TotalSal int = NULL
	  ,@LastSalMonth VARCHAR(50) = NULL
	  ,@LastSalDate datetime = NULL
	  ,@HourRate int = NULL
	  ,@SalDue int = NULL
	  ,@Deduct int = NULL
	  ,@AccNo VARCHAR(50) = NULL
	  ,@TransactionID int = NULL
	  ,@iProjid int = null
	  ,@Update int = NULL
	  ,@vAccountCode varchar(100) = null,
	  @IEmpTypeId int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(@Update = 0) 
		Begin
		
		--if exists (Select * From dbo.Accounts where vAccountNo = @vAccountCode)
		--Begin
		--	Set @Empid = -3
		--End
		--	else
		--Begin
			if not exists(select * from dbo.posEmployee WHERE iEmpid  = @Empid)
			Begin		
				Select @Empid = max(iEmpid) from dbo.posEmployee
			
				insert into dbo.posEmployee
				        ( vTitle,
						  vEmpfName,
						  vEmplName,
						  vMartialStatus,
						  vIdNumber,
				          vPassportNo,
				          vEmployeeType,
				          vAddress,
				          vCity,
				          vNationality,
				          iMobile,
				          vDesignation,
				          dDateOfJoining,
				          iBalance,
				          vDescription,
						  Active,
						  iBasicSalary,
						  iHousing,
						  iTraveling,
						  iTotalSalary,
						  iMiscellaneous,
						  vLastPaidSalaryMonth,
						  iHourlyRate,
						  dLastPaidSalaryDay,
						  iSalaryDue,
						  iDeduction,
						  --vAccountNo,
						--  iProjid,
						  iTranid,iEmpTypeId )
				VALUES  (  @Title
						  ,@EmpfName
						  ,@EmplName
						  ,@MaritalStatus
						  ,@EmpIdNo 
						  ,@Passport 
						  ,@EmpType 
						  ,@Address
						  ,@City 
						  ,@Nationality 
						  ,@Mobile
						  ,@Designation 
						  ,@JoiningDate 
						  ,@Balance 
						  ,@Desc
						  ,@Active
						  ,@BasSal
						  ,@Housing
						  ,@Traveling
						  ,@TotalSal
						  ,@Miscellaneous
						  ,@LastSalMonth
						  ,@HourRate
						  ,@LastSalDate
						  ,@SalDue
						  ,@Deduct
						  --,@vAccountCode
						--  ,@iProjid
						  ,@TransactionID ,@IEmpTypeId )
      
      	Set @Empid = @@IDENTITY
      	-- Employ Insterted Its Time to Creat the Account
      	/* Accounts Type 
      	1	Assets Accounts	
		2	Capital Account	
		3	Liabilities Accounts	
		4	Incomes Accounts	Revenues 
		5	Expenses	Losses Accounts
      	*/
      
		--declare @vAccountNo2 varchar(50)= 'EMP'+ cast(@Empid as varchar(25))
	--	select @vAccountNo2 as acc
	   Declare @tempdate datetime 
	   set @tempdate = getdate();	
		Declare @AccountName varchar(150) = @EmpfName ,
		@vAccountNo varchar(50)=  'E-'+cast ( day(@tempdate) as varchar(5))+ cast (Month(@tempdate) as varchar(5))+ cast (Year(@tempdate) as varchar(5))+ '-'+ cast(@Empid as varchar(25)),
		@vAccountDesc varchar(200)='Employee Account Created on ' + cast(getdate() as varchar),--date(Now),
		@vAccountComments varchar(200) = '',
		@bEditable bit = 0,
		@iFinaceType int = 3,
		@iModuleID int = (Select top 1 iModuleID From posModule where vModuleName = 'Employee'),
		@iModuleFK_ID int = @Empid ,
		@type int = 0,
		@bNominal bit = 0
		EXECUTE InsertUpdateAccount  null,@AccountName,@vAccountNo, @vAccountDesc,  @vAccountComments,  @bEditable, @iFinaceType, @iModuleID,  @iModuleFK_ID,@Update , @bNominal ,@type
		
      	update posEmployee set IAccountid = (select IAccountid from posAccounts where iModuleID = @iModuleID  and @iModuleFK_ID = @Empid)
		
		End
			else
				Set @Empid = -1	
		End		
		END
     
       if (@Update = 1 and @Empid > 0 )
		Begin
			UPDATE dbo.posEmployee SET
				 vTitle = @Title,
				 vEmpfName = @EmpfName,
				 vEmplName = @EmplName,
				 vMartialStatus = @MaritalStatus,
				 vIdNumber = @EmpIdNo,
				 vPassportNo = @Passport,
				 vEmployeeType = @EmpType,
				 vAddress = @Address,
				 vCity = @City,
				 vNationality = @Nationality,
				 iMobile = @Mobile,
				 vDesignation = @Designation,
				 dDateOfJoining = @JoiningDate,
				 iBalance = @Balance,
				 vDescription = @Desc,
				 Active = @Active,
				 iBasicSalary = @BasSal,
				 iHousing = @Housing,
				 iTraveling = @Traveling,
				 iTotalSalary = @TotalSal,
				 iMiscellaneous = @Miscellaneous,
				 vLastPaidSalaryMonth = @LastSalMonth,
				 iHourlyRate = @HourRate,
				 dLastPaidSalaryDay = @LastSalDate,
				 iSalaryDue = @SalDue,
				 iDeduction = @Deduct,
				 --vAccountNo = @vAccountCode,
			--	 iProjid = @iProjid,
				 iTranid = @TransactionID,
				 IEmpTypeId = @iEmpTypeId
			WHERE iEmpid = @Empid
					
			-- Update the Account 
			
		-- update the Account Number 
		
		--declare @iFinaceTypeUpdate int = 3,
		--@iModuleIDUpdate int = (Select iModuleID From Modules where VTableName = 'Employee'),
		--@iModuleFK_IDUpdate int =   @Empid,
		--		@typeUpdate int = 1
		--		update dbo.Accounts set vAccountNo = @vAccountCode
		--		 where iModuleID =  @iModuleIDUpdate and iModuleFK_ID = @iModuleFK_IDUpdate and iFinaceType = @iFinaceTypeUpdate
		----
		END
 SELECT @Empid as iEmpid


GO