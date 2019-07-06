IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetCostumerAlert')
	BEGIN
		DROP  Procedure  GetCostumerAlert
	END

GO
--GetCostumerAlert @dAlertDate = N'2015-03-20 00:48:49.357'
Create PROCEDURE [dbo].GetCostumerAlert --@dAlertDate = N'2015-05-11 00:48:49.357'-- @CostumerBikeNumber = 'FDY123'
	@CostumerID bigint = null,
	@CostumerBikeNumber varchar(50) = null,
    @dAlertDate datetime = null
AS
		
	declare @cmd varchar(1000)
	set @cmd = 'SELECT * from (SELECT * , DATEDIFF(DAY,  dAlertDate, '''+Convert(varchar(150),@dAlertDate,101)+''') as DayDiff  from  tblCostumer  WHERE bFallowUp = 1) temp where 1=1 '
	
	if @dAlertDate is not null 
		set @cmd = @cmd + 'and temp.dAlertDate <=  CAST(''' + Convert(varchar(150),@dAlertDate,101) + ''' as Datetime)  and temp.DayDiff <= 10 and temp.DayDiff >-1'
	if @CostumerBikeNumber is not null 
		set @cmd = @cmd + 'and temp.CostumerBikeNumber = ''' +@CostumerBikeNumber +''''
	if @CostumerID is not null and @CostumerID <> 0
		set @cmd = @cmd + 'and temp.CostumerID = ''' + Cast(@CostumerID as varchar(10)) + ''''
		
	if @dAlertDate is  null 
		set @cmd = 'SELECT * from tblCostumer  WHERE bFallowUp = 1'
	print @cmd
	execute(@cmd)

GO


