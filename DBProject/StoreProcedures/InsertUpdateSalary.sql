IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateSalary')
	BEGIN
		DROP  Procedure  InsertUpdateSalary
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[InsertUpdateSalary]
	@iSalId int =  null,
    @iEmpId int =  null,
    @bIsPaid bit =  null,
    @dSrtDate datetime =  null,
    @dEndDate datetime =  null,
    @iDays float =  null,
    @iHours int =  null,
    @iTranId int =  null,
    @dPaidDate datetime =  null,
    @dGenratedDate datetime =  null,
    @iAmount float =  null,
    @iDeduction float =  null,
    @iAbsentdays float =  null,
    @fOverTime float =  null,
	@iUpdate int = null,
	@iUserId int = null
    
AS
BEGIN
	SET NOCOUNT ON;
		if (@iUpdate = 0 )
		Begin
			INSERT INTO [dbo].[Salary] ([iEmpId], [bIsPaid], [dSrtDate], [dEndDate], [iDays], [iHours], [iTranId], [dPaidDate], [dGenratedDate], [iAmount], [iDeduction], [iAbsentdays], [fOverTime])
			values( @iEmpId, @bIsPaid, @dSrtDate, @dEndDate, @iDays, @iHours, @iTranId, @dPaidDate, GETDATE(), @iAmount, @iDeduction, @iAbsentdays, @fOverTime)
			Set @iSalId = @@IDENTITY
		end
		if (@iUpdate = 1 ) and @bIsPaid is not null
		Begin
			UPDATE [dbo].[Salary]
			SET    [bIsPaid] = @bIsPaid , dPaidDate = GETDATE()
			where Salary.iSalId = @iSalId
	Set @iSalId = @@IDENTITY
		end
		
		begin
				
				-- jurnal adding
				declare @CriAccountid as int = (select iAccountid from posAccounts where iModuleID=29  and  iModuleFK_ID=@iEmpId) 
				declare @DriAccountid as int = (select iAccountid from posAccounts where iModuleID=32  and  AccountName='Salary') 
				declare @AccNo as varchar(50) = (select vAccountNo from posAccounts where iModuleID=29  and  iModuleFK_ID=@iEmpId) 
				declare @EmpName varchar(255) = (select vEmpfName from posEmployee where   iEmpid=@iEmpId) 
				
				
				declare @iJournalIdOut int 
				declare @vTranTitle varchar(255) = N'Salary Generated For Employ '''+  @EmpName + ''' , Account Number ''' + @AccNo  + ''''
				set @dGenratedDate = GETDATE()
				if(@bIsPaid is null)
				begin
				EXEC	[dbo].[InsertUpdateJournal]
				@fAmount = @iAmount,
				@dSystemEntryDateTime = @dGenratedDate,
				@dTransactionDate = @dGenratedDate,
				@vTranTitle = @vTranTitle,
				@iUserId = 1,
				@iUpdate = 0,
				@iJournalIdOut = @iJournalIdOut OutPut
				,@iHideRetun = 1
				-- jurnal End
				
				--posJournalDetail adding
				-- Dr Entry 
				EXEC [dbo].[InsertUpdateJournalDetail]
				@vTransactionType = N'Dr',
				@iAccountID = @DriAccountid,
				@fAmount = @iAmount,
				@dEntryDateTime = @dGenratedDate,
				@iJournalID = @iJournalIdOut,
				@vdescription = @vTranTitle,	
				@vModuleFK_Table = N'Salary',
				@vModuleFK_Name = N'Salary',
				@iModuleFK_ID = 0,
				@vPaymentMode = N'Cash',
				@iUpdate = 0,@iHideRetun = 1
				-- Cr Entry 
				EXEC [dbo].[InsertUpdateJournalDetail]
				@vTransactionType = N'Cr',
				@iAccountID = @CriAccountid,
				@fAmount = @iAmount,
				@dEntryDateTime = @dGenratedDate,
				@iJournalID = @iJournalIdOut,
				@vdescription = @vTranTitle,	
				@vModuleFK_Table = N'Salary',
				@vModuleFK_Name = N'Salary',
				@vPaymentMode = N'Cash',
				@iModuleFK_ID = 0,
				@iUpdate = 0,@iHideRetun = 1
				end
				if(@bIsPaid is not null)
				begin
				set @vTranTitle  = N'Salary Paid to Employ '''+  @EmpName + ''' , Account Number ''' + @AccNo  + ''''
				
				EXEC	[dbo].[InsertUpdateJournal]
				@fAmount = @iAmount,
				@dSystemEntryDateTime = @dGenratedDate,
				@dTransactionDate = @dGenratedDate,
				@vTranTitle = @vTranTitle,
				@iUserId = 1,
				@iUpdate = 0,
				@iJournalIdOut = @iJournalIdOut OutPut,@iHideRetun = 1
				--- 
				-- Dr Entry The Emp Entry
				EXEC [dbo].[InsertUpdateJournalDetail]
				@vTransactionType = N'Dr',
				@iAccountID = @CriAccountid,
				@fAmount = @iAmount,
				@dEntryDateTime = @dGenratedDate,
				@iJournalID = @iJournalIdOut,
				@vdescription = @vTranTitle,	
				@vModuleFK_Table = N'Salary',
				@vModuleFK_Name = N'Salary',
				@iModuleFK_ID = 0,
				@vPaymentMode = N'Cash',
				@iUpdate = 0,@iHideRetun = 1
				
				--EXEC [dbo].[InsertUpdateJournalDetail]
				--@vTransactionType = N'Cr',
				--@iAccountID = @DriAccountid,
				--@fAmount = @iAmount,
				--@dEntryDateTime = @dGenratedDate,
				--@iJournalID = @iJournalIdOut,
				--@vdescription = @vTranTitle,	
				--@vModuleFK_Table = N'Salary',
				--@vModuleFK_Name = N'Salary',
				--@iModuleFK_ID = 0,
				--@vPaymentMode = N'Cash',
				--@iUpdate = 0
				-- changing the cr side as now we have paid
				declare @CashAccountID as int  =  (select iAccountid from posAccounts where iModuleID=33  and  AccountName='Cash') 
				
				-- Cr Entry For Salary Pay Able
				EXEC [dbo].[InsertUpdateJournalDetail]
				@vTransactionType = N'Cr',
				@iAccountID = @CashAccountID,
				@fAmount = @iAmount,
				@dEntryDateTime = @dGenratedDate,
				@iJournalID = @iJournalIdOut,
				@vdescription = @vTranTitle,	
				@vModuleFK_Table = N'Salary',
				@vModuleFK_Name = N'Salary',
				@vPaymentMode = N'Cash',
				@iModuleFK_ID = 0,
				@iUpdate = 0,@iHideRetun = 1
				end
				--posJournalDetail adding
				
			End
	SELECT @iSalId as iSalId
END
Go