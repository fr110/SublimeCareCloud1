IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateJournal')
	BEGIN
		DROP  Procedure  InsertUpdateJournal
	END
GO

Create PROCEDURE InsertUpdateJournal
	@iJournalId int = null,
    @fAmount float = null,
    @vTranTitle varchar(150) = null,
    @dSystemEntryDateTime datetime = null,
    @dTransactionDate datetime = null,
    @iUserId int  = null, 
    @iUpdate int  = null,
    @iJournalIdOut INT = null OUTPUT ,
    @iHideRetun int = 0
AS
begin
		if(@iUpdate = 0) 
		Begin
			INSERT INTO posJournal 
			(
				fAmount, vTranTitle, 
				dTransactionDate, iUserId
			)
			values(@fAmount, @vTranTitle, @dTransactionDate, @iUserId)
	
		set	@iJournalId = @@IDENTITY
		set @iJournalIdOut = @iJournalId
		End	
		Else if (@iUpdate = 1 and @iJournalId > 0 )
		Begin	
			UPDATE posJournal
			SET    fAmount = @fAmount, vTranTitle = @vTranTitle, dSystemEntryDateTime = @dSystemEntryDateTime, dTransactionDate = @dTransactionDate, iUserId = @iUserId
			WHERE  iJournalId = @iJournalId	
		END
		
		if(@iHideRetun = 0 )
		begin
		SELECT * From posJournal where iJournalId = @iJournalId
		end
end
Go