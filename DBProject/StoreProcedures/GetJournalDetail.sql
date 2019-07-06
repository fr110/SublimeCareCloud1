IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetJournalDetail')
	BEGIN
		DROP  Procedure  GetJournalDetail
	END

GO


Create PROCEDURE GetJournalDetail -- @vTransactionType = 'CR', @iJournalId = 1
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
    @iModuleFK_ID int = null
AS
begin
	declare @cmd varchar(3000)
	set @cmd = 'Select * from posJournalDetail where 1=1 '                  
     
    if @iJournalId is not null and @iJournalId > 0
		set @cmd = @cmd + 'and iJournalId = ' +Cast(@iJournalId as varchar(11))
		
	 if @iJournalDetailId is not null and @iJournalDetailId > 0
		set @cmd = @cmd + 'and iJournalDetailId = ' +Cast(@iJournalDetailId as varchar(11))
	
	 if @vTransactionType is not null 
		set @cmd = @cmd + 'and vTransactionType = ''' +Cast(@vTransactionType as varchar(11)) + ''''
	
	
	print (@cmd)	
		
	execute(@cmd)
end
Go