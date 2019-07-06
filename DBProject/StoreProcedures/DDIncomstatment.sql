IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DDIncomstatment')
	BEGIN
		DROP  Procedure  DDIncomstatment
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].DDIncomstatment-- @dFromDate  = '2014-10-05 18:05:59.547' ,@dToDate = '2014-11-05 18:05:59.547' 
	-- Add the parameters for the stored procedure here 
    @dFromDate datetime = null,
    @dToDate datetime = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @cmd varchar(2000)
	set @cmd = 'select 
				isnull( SUM (fAmmountRecived),0)AS CashCollect, 
				isnull(sum(fBalance),0) as fBalance, 
				isnull(SUM(iDiscountPersent),0) as Discount ,
				isnull(SUM(fGrossPurchasePrice),0) as fGrossPurchasePrice  
				from posSaleInovice where 1=1 and bReturnInvoice = 0 and bIsDraft = 0'
	
	if @dFromDate  is not null and @dFromDate <>  ''  
	begin 
		set @cmd = @cmd + ' and Convert(varchar(150),posSaleInovice.ddate,101) >= CAST(''' + Convert(varchar(150),@dFromDate,101) + ''' as Datetime)'--@dTransactionFromDate as datetime)
	end
	
	if @dToDate  is not null and @dToDate <>  ''  
	begin
		set @cmd = @cmd + ' and Convert(varchar(150),posSaleInovice.ddate,101) <= CAST(''' + Convert(varchar(150),@dToDate,101) + ''' as Datetime)'
	end	
	
	declare @salryQuery as varchar(2000)
	set @salryQuery  = 'select isnull(SUM(iAmount),0) as SalaryPaid from Salary where  1=1 and 	bIsPaid=1 '
	if @dFromDate  is not null and @dFromDate <>  ''  
	begin 
		set @salryQuery = @salryQuery + ' and Convert(varchar(150),Salary.dPaidDate,101) >= CAST(''' + Convert(varchar(150),@dFromDate,101) + ''' as Datetime)'--@dTransactionFromDate as datetime)
	end
	
	if @dToDate  is not null and @dToDate <>  ''  
	begin
		set @salryQuery = @salryQuery + ' and Convert(varchar(150),Salary.dPaidDate,101) <= CAST(''' + Convert(varchar(150),@dToDate,101) + ''' as Datetime)'
	end	
	
	print(@cmd)
	print(@salryQuery)
	exec(@cmd)
	exec(@salryQuery)
	-- Let we have the Expens account 
	declare @iFinID as int = (select iFinaceType  From posFinaceType where vFinaceType = 'Expenses')
		execute GetAccountBlance 
		@IFinaceType  = @iFinID,
        @dTransactionFromDate =@dFromDate,
        @dTransactionToDate =@dToDate,
        @Where = 'and posAccounts.iAccountid not in (3,4)'
END
Go