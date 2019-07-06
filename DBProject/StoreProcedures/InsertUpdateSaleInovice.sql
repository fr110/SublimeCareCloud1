IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateSaleInovice')
	BEGIN
		DROP  Procedure  InsertUpdateSaleInovice
	END

GO

/****** Object:  StoredProcedure dbo.GetAppUsers    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE dbo.InsertUpdateSaleInovice
	@iSaleid bigint = null,
    @ipartyId int = null,
    @ddate datetime = null,
    @iCostumerId bigint = null,
    @MeterReading varchar(255) =  null,
    @LiftNumber int = null,
    --@vpartyName varchar(255) = null,
    --@vpartymobile varchar(25) = null,
    @ftotalamount float = null,
    @vPaymentMod varchar(255) = null,
    @vVehicleNo varchar(25) = null,
    @vDriverName varchar(255) = null,
    @iUserid bigint = null,
    @vDeliveryExpense varchar(50) = null,
    @vSeason varchar(50) = null,
    @iDiscountPersent int = null,
    @fPayAbleAmount float = null,
    @fAmmountRecived float = null,
    @vReciverName varchar(150) = null,
    @iSaleManID bigint = null,
    @fBalance float = 0,
    @iUpdate int,
    @AmountwithDExpense float = null ,
    @bReturnInvoice bit = null,
    @bCanelDone bit = null,
    @bIsDraft bit = null,
    @bFinalized bit = null,
    @VFirstElectricianName varchar(255) = null,
	@VSecElectricianName  varchar(255) = null ,
	@fServices float = 0 , 
	@fGrossPurchasePrice float = 0
    --,  @vpartyAddress text = null
AS
begin
		if(@iUpdate = 0) 
		Begin
			INSERT INTO posSaleInovice 
				(
				ipartyId, ddate, 
				ftotalamount, vPaymentMod, 
				vVehicleNo, vDriverName, 
				iUserid, vDeliveryExpense, 
				vSeason, iDiscountPersent, 
				fPayAbleAmount, fAmmountRecived, 
				vReciverName, iSaleManID,
				fBalance , AmountwithDExpense , bReturnInvoice , bCanelDone,
				bIsDraft , bFinalized , iCostumerId , MeterReading , LiftNumber , 
				VFirstElectricianName ,fServices, VSecElectricianName ,
				fGrossPurchasePrice
				)values (
				 @ipartyId, @ddate, 
				 
				 @ftotalamount, @vPaymentMod, 
				 @vVehicleNo, @vDriverName, 
				 @iUserid, @vDeliveryExpense, 
				 @vSeason, @iDiscountPersent, 
				 @fPayAbleAmount, @fAmmountRecived, 
				 @vReciverName, @iSaleManID,
				 @fBalance , @AmountwithDExpense ,@bReturnInvoice , @bCanelDone,
				 @bIsDraft, @bFinalized , @iCostumerId , @MeterReading, @LiftNumber ,
				  @VFirstElectricianName , @fServices,@VSecElectricianName , 
				  @fGrossPurchasePrice
				 )
				
				
				  
		set	@iSaleid = @@IDENTITY
		End	
		Else if ( @iUpdate = 1 and @iSaleid > 0 )
		Begin
				--UPDATE dbo.posSaleInovice
				--SET    bCanelDone = @bCanelDone--, bReturnInvoice = @bReturnInvoice
				--WHERE  iSaleid = @iSaleid
				
				UPDATE dbo.posSaleInovice
				SET    
				ipartyId = @ipartyId, ddate = @ddate, 
				ftotalamount = @ftotalamount, vPaymentMod = @vPaymentMod, 
				vVehicleNo = @vVehicleNo, vDriverName = @vDriverName, 
				iUserid = @iUserid, vDeliveryExpense = @vDeliveryExpense, 
				vSeason = @vSeason, iDiscountPersent = @iDiscountPersent, 
				fPayAbleAmount = @fPayAbleAmount, fAmmountRecived = @fAmmountRecived, 
				vReciverName = @vReciverName, iSaleManID = @iSaleManID, 
				fBalance = @fBalance, AmountwithDExpense = @AmountwithDExpense, 
				bCanelDone = @bCanelDone, bReturnInvoice = @bReturnInvoice, 
				bIsDraft = @bIsDraft, bFinalized = @bFinalized , iCostumerId = @iCostumerId,
				MeterReading  = @MeterReading , LiftNumber= @LiftNumber ,
				VFirstElectricianName = @VFirstElectricianName , VSecElectricianName = @VSecElectricianName , fServices = @fServices,
				fGrossPurchasePrice = @fGrossPurchasePrice
				WHERE  iSaleid = @iSaleid
				--SELECT * From posSaleInovice
		END
		 -- let we do some trick 
		 if @BReturnInvoice is not null and @BReturnInvoice = 1
				 begin 
				 set @iUpdate = 1
				 end
				 
		declare @DriAccountid as int
		declare @CriAccountid as int 
		declare @DrAccountNumber as varchar(50)
		declare @CrAccountNumber as varchar(50)
		declare @iJournalIdOut int 
		declare @vTranTitle varchar(255)
		declare @dGenratedDate as datetime
		declare @DriAccountid2 as int
		if(@bFinalized = 1)	and (@bCanelDone is null or @bCanelDone <> 1)
		begin
		
			-- jurnal adding
				set @DriAccountid  = (select iAccountid from posAccounts where iModuleID=33  and  AccountName='Cash') 
				set @CriAccountid  = (select iAccountid from posAccounts where iModuleID=1  and  AccountName='Sales')
				set @DrAccountNumber  = (select vAccountNo from posAccounts where iModuleID=33  and  iModuleFK_ID=0)  
				set @CrAccountNumber  = (select vAccountNo from posAccounts where iModuleID=1  and  iModuleFK_ID=0)  
				
				
				set @vTranTitle  = N'Sale Invoice # ' + Cast(@iSaleid as varchar(50)) + ',  Transaction Dated ' + cast(@ddate as varchar(255))
				set @dGenratedDate  = GETDATE()
				
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
				if (@fBalance is null or @fBalance = 0.0) -- its a full cash entry 
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
				if (@fBalance is not null and @fBalance <> 0.0) -- its a full cash entry 
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
						set @DriAccountid2 = (select iAccountid from posAccounts where iModuleID=26  and  iModuleFK_ID=@iCostumerId) 
					
						EXEC [dbo].[InsertUpdateJournalDetail]
						@vTransactionType = N'Dr',
						@iAccountID = @DriAccountid2,
						@fAmount = @fBalance,
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
						@fAmount = @fPayAbleAmount,
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
		
		-- cancling the inovice -- return inovice
		
		if((@bFinalized = 1)	and (@bCanelDone is not null and @bCanelDone = 1) and (@iUpdate = 1))
		begin
		
			-- jurnal adding
				set @DriAccountid  = (select iAccountid from posAccounts where iModuleID=33  and  AccountName='Cash') 
				set @CriAccountid  = (select iAccountid from posAccounts where iModuleID=37  and  AccountName='Sales Returns')
				set @DrAccountNumber  = (select vAccountNo from posAccounts where iModuleID=33  and  iModuleFK_ID=0)  
				set @CrAccountNumber  = (select vAccountNo from posAccounts where iModuleID=37  and  iModuleFK_ID=0)  
				
				
				set @vTranTitle  = N'Return Sale Invoice # ' + Cast(@iSaleid as varchar(50)) + ', Transaction Dated ' + cast(@ddate as varchar(255))
				set @dGenratedDate  = GETDATE()
				
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
				if (@fBalance is null or @fBalance = 0.0) -- its a full cash entry 
				begin 
					--posJournalDetail adding
					-- Dr Entry 
						EXEC [dbo].[InsertUpdateJournalDetail]
						@vTransactionType = N'Cr',
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
						@vTransactionType = N'Dr',
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
				if (@fBalance is not null and @fBalance <> 0.0) -- its a full cash entry 
				begin 
					--posJournalDetail adding
					-- Dr Entry 
						EXEC [dbo].[InsertUpdateJournalDetail]
						@vTransactionType = N'Cr',
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
						set @DriAccountid2 = (select iAccountid from posAccounts where iModuleID=26  and  iModuleFK_ID=@iCostumerId) 
					
						EXEC [dbo].[InsertUpdateJournalDetail]
						@vTransactionType = N'Cr',
						@iAccountID = @DriAccountid2,
						@fAmount = @fBalance,
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
						@vTransactionType = N'Dr',
						@iAccountID = @CriAccountid,
						@fAmount = @fPayAbleAmount,
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
		SELECT * From posSaleInovice where iSaleid = @iSaleid
end
GO


