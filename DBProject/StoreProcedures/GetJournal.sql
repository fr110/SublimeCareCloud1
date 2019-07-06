IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetJournal')
	BEGIN
		DROP  Procedure  GetJournal
	END

GO


Create PROCEDURE GetJournal
	@iJournalId int = null,
    @fAmount float = null,
    @vTranTitle varchar(150) = null,
    @dSystemEntryDateTime datetime = null,
    @dTransactionDate datetime = null,
    @iUserId int  = null,
      @dTransactionFromDate datetime = null,
    @dTransactionToDate datetime = null
AS
begin
	declare @cmd varchar(3000)
	set @cmd = 'Select * from posJournal where 1=1 '
                      
     if @iJournalId is not null and @iJournalId > 0
		set @cmd = @cmd + 'and iJournalId = ' +Cast(@iJournalId as varchar(11))
		
	if @dTransactionFromDate  is not null and @dTransactionFromDate <>  ''  
	begin 
		set @cmd = @cmd + ' and Convert(varchar(150),posJournal.dTransactionDate,101) >= CAST(''' + Convert(varchar(150),@dTransactionFromDate,101) + ''' as Datetime)'--@dTransactionFromDate as datetime)
	end
	
	if @dTransactionToDate  is not null and @dTransactionToDate <>  ''  
	begin
		set @cmd = @cmd + ' and Convert(varchar(150),posJournal.dTransactionDate,101) <= CAST(''' + Convert(varchar(150),@dTransactionToDate,101) + ''' as Datetime)'
		end	
		
	
	print (@cmd)	
		
	execute(@cmd)
end
Go