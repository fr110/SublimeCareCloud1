IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetPreference')
	BEGIN
		DROP  Procedure  GetPreference
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE GetPreference
	@iCompanyID int = null,
    @imLogoImage image = null,
    @vHeaderText varchar(500)= null,
    @bIsActive bit= null,
    @vDateFormat varchar(100)= null,
    @bStockOverRide bit= null,
    @vSaleType varchar(150)= null,
    @bDefaultCustomer bit = null,
    @iUpdate int = null
AS
	declare @cmd varchar(1000)
	set @cmd = 'select posPreference.* , posEmployee.*  from posPreference 
		left join posEmployee on posPreference.bCashierID =  posEmployee.iEmpid where 1=1 '
	if @iCompanyID is not null and @iCompanyID > 0
		set @cmd = @cmd + 'and posPreference.iCompanyID = ' +Cast(@iCompanyID as varchar)
		
	--print @cmd
	execute(@cmd)
