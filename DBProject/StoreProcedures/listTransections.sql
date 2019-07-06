IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'listTransaction')
	BEGIN
		DROP  Procedure  listTransaction
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[listTransaction] --@iAccountID = 25--@bShowBlance = 0--null,null,3,5
	-- Add the parameters for the stored procedure here
	@iJournalId int = null,
    @iAccountID int = null, 
    @dTransactionFromDate datetime = null,
    @dTransactionToDate datetime = null,
    @dTransactionDate datetime = null,
    @vVoucherNo varchar(50) = null,
	@bShowBlance bit = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    declare @temp table (iJournalId int identity, dEntryDateTime datetime,dTransactionDate datetime,vTranTitle varchar(150),vPaymentMode varchar(50),DR float,CR float ,AccountName varchar(150), vModuleName varchar(150))
	declare @cmd varchar(1000)
	declare @cmd2 varchar(1000)
	set @cmd = 'select dEntryDateTime,dTransactionDate,vdescription,vPaymentMode,
	ISNULL((CASE
	WHEN vTransactionType = ''' + 'Dr' +''' THEN posJournalDetail.fAmount 
	END),0) AS DR,ISNULL((CASE
	WHEN vTransactionType = '''+'Cr'+''' THEN posJournalDetail.fAmount 
	END),0) AS CR ,posAccounts.AccountName, '''+''+''' as vModuleName
	from posJournalDetail  INNER JOIN
    posAccounts ON posJournalDetail.iAccountID = posAccounts.iAccountid inner join posJournal on posJournal.iJournalId =posJournalDetail.iJournalId   where 1=1'
	
	print(@cmd)
	
	if @iJournalId is not null and @iJournalId <> ''
		set @cmd = @cmd + ' and posJournalDetail.iJournalId =' + CAST(@iJournalId as varchar)
	
	if @iAccountID is not null and @iAccountID <> ''
		set @cmd = @cmd + ' and posJournalDetail.iAccountID =' + CAST(@iAccountID as varchar)	
	
	if @dTransactionDate is not null and @dTransactionDate <> ''
			set @cmd = @cmd + ' and Convert(varchar(150),posJournal.dTransactionDate,101) = CAST(''' + Convert(varchar(150),@dTransactionDate,101) + ''' as Datetime)'
	
	if @vVoucherNo is not null and @vVoucherNo <> ''
			set @cmd = @cmd + ' and vVoucherNo like  ''%' + @vVoucherNo + '%'''
			
	if @dTransactionFromDate  is not null and @dTransactionFromDate <>  ''  
	begin 
		set @cmd = @cmd + ' and Convert(varchar(150),posJournal.dTransactionDate,101) >= CAST(''' + Convert(varchar(150),@dTransactionFromDate,101) + ''' as Datetime)'--@dTransactionFromDate as datetime)
	end
	
	if @dTransactionToDate  is not null and @dTransactionToDate <>  ''  
	begin
		set @cmd = @cmd + ' and Convert(varchar(150),posJournal.dTransactionDate,101) <= CAST(''' + Convert(varchar(150),@dTransactionToDate,101) + ''' as Datetime)'
		end
		-- insert all the transections into @temp here 
	--print @cmd
		insert into @temp 
		EXEC (@cmd )
		
		--end insert
	
		if @dTransactionToDate  is null and @dTransactionFromDate is null and @bShowBlance = 1 and @bShowBlance is not null
		begin 
			--declare @BlCR as float = (select ISNULL(SUM(CR),0) from @temp)
			--declare @BlDR as float = (select ISNULL(SUM(DR),0) from @temp)
			--	if(@BlCR > @BlDR)
			--	begin
			--	insert into @temp (vPaymentMode,CR)
			--	(select 'Balance :',
			--		@BlCR as CR --, ISNULL(@PerviousBalance,0) as CR
			--		From @temp 
			--		)
			--	end
			--	else
			--	begin
			--	 insert into @temp (vPaymentMode,DR)
			--	(select 'Balance :',
			--		@BlCR as DR --, ISNULL(@PerviousBalance,0) as CR
			--		From @temp 
			--		)
			--	end
			--exec GetAccountBlance 
				insert into @temp (vPaymentMode, Dr,Cr) 
				(Select 'Balance' as AccountName , SUM(Dr),SUM(cr) from @temp)
				--insert into @temp (vPaymentMode,DR)
				--(select 'Balance :',
				--	(ISNULL(SUM(DR),0) +  ISNULL((SUM(CR)*-1),0)) as DR --, ISNULL(@PerviousBalance,0) as CR
				--	From @temp 
				--	)
					
					
			--		insert into @temp 
			--		EXEC (@cmd2 )
	   end
	
	
	select * from @temp
END
Go