IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetAccountsReport')
	BEGIN
		DROP  Procedure  GetAccountsReport
	END

GO
CREATE PROCEDURE [dbo].[GetAccountsReport]--@vTypeToFilter = N'Receivables'

@vTypeToFilter varchar(50) = null,
@iAccountID int = null
AS
BEGIN

			declare @iposParty_moduleid as int
			declare @iposEmployee_moduleid as int
			declare @iposCostumer_moduleid as int
			select top 1 @iposParty_moduleid= iModuleID from posModule where posModule.vModuleName = 'Party'
			select top 1 @iposEmployee_moduleid=iModuleID from posModule where posModule.vModuleName = 'Employee'
			select top 1 @iposCostumer_moduleid=iModuleID from posModule where posModule.vModuleName = 'Costumer'
			declare  @temp as table (balance int ,iAccountID int)
			if @vTypeToFilter = 'Payable'
			begin

			insert into @temp

			select
			SUM(CASE
					WHEN vTransactionType = 'Dr' THEN fAmount 
					WHEN vTransactionType = 'Cr' THEN fAmount * -1
					END) AS balance ,iAccountID
					from posJournalDetail
					where iAccountID  in (select iAccountid from posAccounts where bNominal = 0)
			--and balance < 0
			group by iAccountID

			select row_number() over (ORDER BY balance) as SR,
			(CASE When b.iModuleID = @iposParty_moduleid THEN(Select posParty.vPartyName from posParty where posParty.iPartyID = b.iModuleFK_ID)   
			 When b.iModuleID = @iposEmployee_moduleid Then (Select posEmployee.vEmpfName from posEmployee where posEmployee.iEmpid = b.iModuleFK_ID) END) HolderName,
			(CASE When b.iModuleID = @iposParty_moduleid THEN 'Party'    
			 When b.iModuleID = @iposEmployee_moduleid Then 'Employee' 
			 When b.iModuleID = @iposCostumer_moduleid Then 'Customer' 
			 END) vAccountNature,a.iAccountID,a.balance,b.AccountName,@vTypeToFilter as vAccType
			from @temp a,posAccounts b where a.iAccountID = b.iAccountid and balance < 0
			order by a.balance
			--select * From @temp where balance < 0
			end

			-- Accouts Racive able 
			if @vTypeToFilter = 'Receivables'
			begin

			insert into @temp

			select
			SUM(CASE
					WHEN vTransactionType = 'Dr' THEN fAmount 
					WHEN vTransactionType = 'Cr' THEN fAmount * -1
					END) AS balance ,iAccountID
					from posJournalDetail
					where iAccountID  in (select iAccountid from posAccounts where bNominal = 0)
			--and balance < 0
			group by iAccountID

			select row_number() over (ORDER BY balance) as SR,
			(CASE When b.iModuleID = @iposParty_moduleid THEN(Select posParty.vPartyName from posParty where posParty.iPartyID = b.iModuleFK_ID)   
			 When b.iModuleID = @iposEmployee_moduleid Then (Select posEmployee.vEmpfName from posEmployee where posEmployee.iEmpid = b.iModuleFK_ID) END) HolderName,
			(CASE When b.iModuleID = @iposParty_moduleid THEN 'Party'    
			 When b.iModuleID = @iposEmployee_moduleid Then 'Employee' 
			 When b.iModuleID = @iposCostumer_moduleid Then 'Customer' 
			 END) vAccountNature,a.iAccountID,a.balance,b.AccountName,@vTypeToFilter as vAccType
			 from @temp a,posAccounts b where a.iAccountID = b.iAccountid and balance > 0
			order by a.balance
			--select * From @temp where balance < 0
			end

			--@iAccountID
			if @vTypeToFilter = 'Account'
			begin

			insert into @temp

			select
			SUM(CASE
					WHEN vTransactionType = 'Dr' THEN fAmount 
					WHEN vTransactionType = 'Cr' THEN fAmount * -1
					END) AS balance ,iAccountID
					from posJournalDetail
					where iAccountID  in (select iAccountid from posAccounts where bNominal = 0)
			--and balance < 0
			group by iAccountID

			select row_number() over (ORDER BY balance) as SR,
			(CASE When b.iModuleID = @iposParty_moduleid THEN(Select posParty.vPartyName from posParty where posParty.iPartyID = b.iModuleFK_ID)   
			 When b.iModuleID = @iposEmployee_moduleid Then (Select posEmployee.vEmpfName from posEmployee where posEmployee.iEmpid = b.iModuleFK_ID) END) HolderName,
			(CASE When b.iModuleID = @iposParty_moduleid THEN 'Party'    
			 When b.iModuleID = @iposEmployee_moduleid Then 'Employee' 
			 When b.iModuleID = @iposCostumer_moduleid Then 'Customer' 
			 END)vAccountNature,a.iAccountID,a.balance,b.AccountName,@vTypeToFilter as vAccType
			 from @temp a,posAccounts b where a.iAccountID = b.iAccountid and a.iAccountID = @iAccountID-- b.iAccountid --and balance > 0 
			order by a.balance
			--select * From @temp where balance < 0
			end
			END

GO
