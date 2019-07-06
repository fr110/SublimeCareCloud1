IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateJournalDetail')
	BEGIN
		DROP  Procedure  InsertUpdateJournalDetail
	END

GO


Create PROCEDURE InsertUpdateJournalDetail
	@iJournalDetailId int = null,
    @iJournalId int = null,
    @vTransactionType varchar(50) = null,
    @iAccountID int = null,
    @fAmount float = null,
    @dEntryDateTime datetime = null,
    @vReceivedBy varchar(50) = null,
    @vVoucherNo varchar(50) = null,
    @vdescription varchar(150)= null,
    @iChequeNumber int = null,
    @vBankAccountNumber varchar(50)= null,
    @vPaymentMode varchar(50) = null,
    @vModuleFK_Table varchar(150) = null,
    @vModuleFK_Name varchar(150) = null,
    @iModuleFK_ID int = null,
    @iUpdate int = null,
        @iHideRetun int = 0
AS
begin
		if(@iUpdate = 0) 
		Begin
			INSERT INTO posJournalDetail 
			(	
					iJournalId, vTransactionType, iAccountID, 
					fAmount, dEntryDateTime, vReceivedBy, 
					vVoucherNo, vdescription, iChequeNumber, 
					vBankAccountNumber, vPaymentMode, vModuleFK_Table, 
					vModuleFK_Name, iModuleFK_ID
			)values 
			(
					@iJournalId, @vTransactionType, @iAccountID, 
					@fAmount, GETDATE(), @vReceivedBy, 
					@vVoucherNo, @vdescription, @iChequeNumber, 
					@vBankAccountNumber, @vPaymentMode, @vModuleFK_Table, 
					@vModuleFK_Name, @iModuleFK_ID
			)
		set	@iJournalDetailId = @@IDENTITY
		End	
		
		
		Else if (@iUpdate = 1 and @iJournalDetailId > 0 )
		Begin	
		
				UPDATE posJournalDetail
					SET    
						iJournalId = @iJournalId, vTransactionType = @vTransactionType, 
						iAccountID = @iAccountID, fAmount = @fAmount, 
						dEntryDateTime = @dEntryDateTime, vReceivedBy = @vReceivedBy, 
						vVoucherNo = @vVoucherNo, vdescription = @vdescription, 
						iChequeNumber = @iChequeNumber, vBankAccountNumber = @vBankAccountNumber, 
						vPaymentMode = @vPaymentMode, vModuleFK_Table = @vModuleFK_Table, 
						vModuleFK_Name = @vModuleFK_Name, iModuleFK_ID = @iModuleFK_ID
				WHERE  iJournalDetailId = @iJournalDetailId

		END
		if(@iHideRetun = 0 )
		begin
		SELECT * From posJournalDetail where iJournalDetailId = @iJournalDetailId
		end
end
Go