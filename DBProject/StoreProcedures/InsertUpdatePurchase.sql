IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdatePurchase')
	BEGIN
		DROP  Procedure  InsertUpdatePurchase
	END

GO

/****** Object:  StoredProcedure dbo.GetAppUsers    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE dbo.InsertUpdatePurchase
	@iPurchaseid bigint = null,
    @ipartyId int = null,
    @ddate datetime = null,
    --@vpartyName varchar(255) = null,
    --@vpartymobile varchar(25) = null,
    @ftotalamount float = null,
    @vPaymentMod varchar(255) = null,
    @vVehicleNo varchar(25) = null,
    @vDriverName varchar(255) = null,
    @iUserid bigint = null,
    @vDeliveryExpense varchar(50) = null,
    @vSeason varchar(50) = null,
    @iDiscountPersent int = 0,
    @fPayAbleAmount float = null,
    @fAmmountRecived float = null,
    @vReciverName varchar(150) = null,
    @iPurchaseManID bigint = null,
    @fBalance float = 0.0,
    @iUpdate int,
    @AmountwithDExpense float = null ,
    @formnumber varchar(255) = null
    --,  @vpartyAddress text = null
AS
begin
		if(@iUpdate = 0) 
		Begin
			INSERT INTO posPurchase 
				(
				ipartyId, ddate, 
			
				ftotalamount, vPaymentMod, 
				vVehicleNo, vDriverName, 
				iUserid, vDeliveryExpense, 
				vSeason, iDiscountPersent, 
				fPayAbleAmount, fAmmountRecived, 
				vReciverName, iPurchaseManID,
				fBalance , AmountwithDExpense,formnumber
				)values (
				 @ipartyId, @ddate, 
				 
				 @ftotalamount, @vPaymentMod, 
				 @vVehicleNo, @vDriverName, 
				 @iUserid, @vDeliveryExpense, 
				 @vSeason, @iDiscountPersent, 
				 @fPayAbleAmount, @fAmmountRecived, 
				 @vReciverName, @iPurchaseManID,
				 @fBalance , @AmountwithDExpense ,@formnumber
				 )
		set	@iPurchaseid = @@IDENTITY
		
			begin
		
			-- jurnal adding
				declare @CriAccountid  as int = (select iAccountid from posAccounts where iModuleID=33  and  AccountName='Cash') 
				declare @DriAccountid as int = (select iAccountid from posAccounts where iModuleID=11  and  AccountName='Purchase')
				declare @DrAccountNumber as varchar(50) = (select vAccountNo from posAccounts where iModuleID=33  and  iModuleFK_ID=0)  
				declare @CrAccountNumber as varchar(50) = (select vAccountNo from posAccounts where iModuleID=11  and  iModuleFK_ID=0)  	
				
				declare @iJournalIdOut int 
				declare @vTranTitle varchar(255) = N'Purchase Invoice Transaction Dated ' + cast(@ddate as varchar(255))
				declare @dGenratedDate as datetime = GETDATE()
				
				EXEC	[dbo].[InsertUpdateJournal]
				@fAmount = @fAmmountRecived,
				@dSystemEntryDateTime = @ddate,
				@dTransactionDate = @ddate,
				@vTranTitle = @vTranTitle,
				@iUserId = 1,
				@iUpdate = 0,
				@iJournalIdOut = @iJournalIdOut OutPut, 
				@iHideRetun = 1
				--is it full entry or partial entry 
				if (@fBalance is null or @fBalance = 0.0 or @fBalance=0) -- its a full cash entry 
					begin 
					--posJournalDetail adding
					-- Dr Entry 
						EXEC [dbo].[InsertUpdateJournalDetail]
						@vTransactionType = N'Dr',
						@iAccountID = @DriAccountid,
						@fAmount = @fAmmountRecived,
						@dEntryDateTime = @dGenratedDate,
						@iJournalID = @iJournalIdOut,
						@vdescription = @vTranTitle,	
						@vModuleFK_Table = N'Cash',
						@vModuleFK_Name = N'Cash',
						@iModuleFK_ID = 0,
						@vPaymentMode = @vPaymentMod,
						@iUpdate = 0 ,
						@iHideRetun = 1
						-- Cr Entry 
						EXEC [dbo].[InsertUpdateJournalDetail]
						@vTransactionType = N'Cr',
						@iAccountID = @CriAccountid,
						@fAmount = @fAmmountRecived,
						@dEntryDateTime = @dGenratedDate,
						@iJournalID = @iJournalIdOut,
						@vdescription = @vTranTitle,	
						@vModuleFK_Table = N'Sales',
						@vModuleFK_Name = N'Sales',
						@vPaymentMode = @vPaymentMod,
						@iModuleFK_ID = 0,
						@iUpdate = 0,@iHideRetun = 1
					
				end 
				if (@fBalance is not null and @fBalance <> 0.0 ) -- its a full cash entry 
					begin 
					--posJournalDetail adding
					-- Dr Entry for purchase	
						EXEC [dbo].[InsertUpdateJournalDetail]
						@vTransactionType = N'Dr',
						@iAccountID = @DriAccountid,
						@fAmount = @fPayAbleAmount,
						@dEntryDateTime = @dGenratedDate,
						@iJournalID = @iJournalIdOut,
						@vdescription = @vTranTitle,	
						@vModuleFK_Table = N'Cash',
						@vModuleFK_Name = N'Cash',
						@iModuleFK_ID = 0,
						@vPaymentMode = @vPaymentMod,
						@iUpdate = 0 ,
						@iHideRetun = 1
						
						declare @CriAccountid2 as int = (select iAccountid from posAccounts where iModuleID=5  and  iModuleFK_ID=@ipartyId) -- Party Account
					-- Cash account 
						EXEC [dbo].[InsertUpdateJournalDetail]
						@vTransactionType = N'Cr',
						@iAccountID = @CriAccountid,
						@fAmount = @fAmmountRecived,
						@dEntryDateTime = @dGenratedDate,
						@iJournalID = @iJournalIdOut,
						@vdescription = @vTranTitle,	
						@vModuleFK_Table = N'Cash',
						@vModuleFK_Name = N'Cash',
						@iModuleFK_ID = 0,
						@vPaymentMode = @vPaymentMod,
						@iUpdate = 0 ,
						@iHideRetun = 1
						
						-- Cr Entry as now we have to pay to selecte
						EXEC [dbo].[InsertUpdateJournalDetail]
						@vTransactionType = N'Cr',
						@iAccountID = @CriAccountid2,
						@fAmount = @fBalance ,
						@dEntryDateTime = @dGenratedDate,
						@iJournalID = @iJournalIdOut,
						@vdescription = @vTranTitle,	
						@vModuleFK_Table = N'Sales',
						@vModuleFK_Name = N'Sales',
						@vPaymentMode = @vPaymentMod,
						@iModuleFK_ID = 0,
						@iUpdate = 0,@iHideRetun = 1
					
				end 
				
				--posJournalDetail adding
		end
		
		End	
		--Else if (@iUpdate = 1 and @iPurchaseid > 0 )
		
		--Begin
		
		--END
		
		SELECT * From posPurchase where iPurchaseid = @iPurchaseid
end
GO


