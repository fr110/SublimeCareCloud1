IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetCostumer')
	BEGIN
		DROP  Procedure  GetCostumer
	END

GO
Create PROCEDURE [dbo].GetCostumer -- @CostumerBikeNumber = 'FDY123'
	@CostumerID bigint = null,
    @CostumerName varchar(150) = null,
    @CostumerBikeNumber varchar(50) = null,
    @CostumerMobileNumber varchar(50) = null,
    @CostumerLastVisit datetime = null,
    @MeterReading varchar(50) = null ,
    @ModelNumber varchar(50) = null
AS
	declare @cmd varchar(1000)
	set @cmd = 'SELECT *  from  tblCostumer  WHERE   1=1 '
	
	if @CostumerBikeNumber is not null 
		set @cmd = @cmd + 'and CostumerBikeNumber = ''' +@CostumerBikeNumber +''''
		
	if @CostumerID is not null and @CostumerID <> 0
		set @cmd = @cmd + 'and CostumerID = ''' + Cast(@CostumerID as varchar(10)) + ''''
	
	--print @cmd
	execute(@cmd)

GO


