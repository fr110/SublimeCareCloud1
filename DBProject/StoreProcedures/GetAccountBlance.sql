IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetAccountBlance')
	BEGIN
		DROP  Procedure  GetAccountBlance
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].GetAccountBlance --@iAccountID = 79 --@IFinaceType=5, @iAccountID = 31, @dTransactionFromDate  = '2014-03-28 15:27:13.777' ,@dTransactionToDate = '2014-04-19 15:52:32.100' 
	-- Add the parameters for the stored procedure here
    @iAccountID int = null, 
    @IFinaceType int = null,
    @dTransactionFromDate datetime = null,
    @dTransactionToDate datetime = null ,
    @Where varchar(max) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    declare @temp table 
    (iJournalId int identity, dEntryDateTime datetime,
    dTransactionDate datetime,Drr float,Crr float ,iAccountid int, iFinaceType int)
	declare @cmd varchar(2000)
	declare @cmd2 varchar(2500)
	set @cmd = 'select dEntryDateTime,dTransactionDate,
			ISNULL((CASE
			WHEN vTransactionType = ''' + 'Dr' +''' THEN posJournalDetail.fAmount 
			END),0) AS Drr,ISNULL((CASE
			WHEN vTransactionType = '''+'Cr'+''' THEN posJournalDetail.fAmount 
			END),0) AS Crr ,posAccounts.iAccountid , iFinaceType
			from posJournalDetail  INNER JOIN
			posAccounts ON posJournalDetail.iAccountID = posAccounts.iAccountid left JOIN
			posModule ON posAccounts.iModuleID = posModule.iModuleID inner join posJournal on posJournal.iJournalId =posJournalDetail.iJournalId
			where 1=1'
		if @dTransactionFromDate  is not null and @dTransactionFromDate <>  ''  
	begin 
		set @cmd = @cmd + ' and Convert(varchar(150),posJournal.dTransactionDate,101) >= CAST(''' + Convert(varchar(150),@dTransactionFromDate,101) + ''' as Datetime)'--@dTransactionFromDate as datetime)
	end
	
	if @dTransactionToDate  is not null and @dTransactionToDate <>  ''  
	begin
		set @cmd = @cmd + ' and Convert(varchar(150),posJournal.dTransactionDate,101) <= CAST(''' + Convert(varchar(150),@dTransactionToDate,101) + ''' as Datetime)'
	end	
	
	if @Where  is not null and @Where <>  ''  
	begin
		set @cmd = @cmd + ' ' + @Where
	end	
	insert into @temp 
	EXEC (@cmd)

	declare @tempTab table (iAccountid int, vAccountNo varchar(255),	AccountName varchar(255),	iFinaceType int,	vFinaceType varchar(255),	Dr float,	Cr float,	Balance float,	BlancType varchar(255))
--16	Salary	5	Expenses	17851.87	3130.55	14721.32	Dr
	insert into @tempTab Select posAccounts.iAccountid ,posAccounts.vAccountNo, posAccounts.AccountName,posAccounts.iFinaceType,
	posFinaceType.vFinaceType , ROUND(Dr,2) , ROUND(CR,2), 
	ROUND(ISNULL((case when Dr > Cr then (Dr-Cr) when Cr > Dr then (Cr-Dr) end),0),2) as Blance ,
	 (case when Dr=Cr then ' ' when Dr > Cr then 'Dr'  when Cr > Dr then   'Cr' end) as BlancType 
	from (
		select sum(Drr) as Dr ,  sum(Crr) as Cr  , iFinaceType ,iAccountid
		from (select * from @temp
		 ) transections group by iFinaceType , iAccountid
		
		) SomeUpTable inner join posAccounts on posAccounts.iAccountid = SomeUpTable.iAccountid inner join posFinaceType 
		on SomeUpTable.iFinaceType=posFinaceType.iFinaceType  
	-- Append The balnce 
	insert into @tempTab (vFinaceType, Dr,Cr) (Select 'Balance' as AccountName , SUM(Dr),SUM(cr) from @tempTab)
	-- Let We Filter 
	if @IAccountid is not null and @IAccountid <> 0 and @IFinaceType is not null and @IFinaceType <> 0
		begin 
			select * from @tempTab where 1=1 and IAccountid = @IAccountid and IFinaceType = @IFinaceType
		end
	if @IAccountid is not null and @IAccountid <> 0 and @IFinaceType is null or @IFinaceType = 0
		begin 
			select * from @tempTab where 1=1 and IAccountid = @IAccountid 
		end
	if @IFinaceType is not null and @IFinaceType <> 0 and @IAccountid is null or @IAccountid = 0
		begin 
			select * from @tempTab where 1=1 and IFinaceType = @IFinaceType
		end
	if @IFinaceType is null or @IFinaceType = 0 and @IAccountid is null or @IAccountid = 0
		begin 
			select * from @tempTab where 1=1
		end
	
END
Go