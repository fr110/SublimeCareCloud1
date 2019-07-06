IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateCostumer')
	BEGIN
		DROP  Procedure  InsertUpdateCostumer
	END

GO

/****** Object:  StoredProcedure dbo.GetAppUsers    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE InsertUpdateCostumer
	@CostumerID bigint = null,
    @CostumerName varchar(150) = null,
    @CostumerBikeNumber varchar(50)= null,
    @CostumerMobileNumber varchar(50)= null,
    @CostumerLastVisit datetime= null,
    @MeterReading varchar(50)= null,
    @ModelNumber varchar(50)= null,
    @bFallowUp bit = null,
    @dLastInovice datetime= null,
    @dAlertDate datetime= null,
    @iUpdate int = null
AS
begin
	if @dLastInovice is null
	set @dLastInovice = GetDate()
		if(@iUpdate = 0) 
		Begin
			
			INSERT INTO tblCostumer (CostumerName, CostumerBikeNumber, CostumerMobileNumber, CostumerLastVisit, MeterReading, ModelNumber, bFallowUp , dLastInovice , dAlertDate)
			SELECT @CostumerName, @CostumerBikeNumber, @CostumerMobileNumber, @CostumerLastVisit, @MeterReading, @ModelNumber ,@bFallowUp , @dLastInovice , @dAlertDate
			set @CostumerID	 = SCOPE_IDENTITY()
			-- Employ Insterted Its Time to Creat the Account
      		/* Accounts Type 
      		1	Assets Accounts	
			2	Capital Account	
			3	Liabilities Accounts	
			4	Incomes Accounts	Revenues 
			5	Expenses	Losses Accounts
      		*/
      		--declare @vAccountNo2 varchar(50)= 'EMP'+ cast(@Empid as varchar(25))
			--	select @vAccountNo2 as acc
		
				Declare @AccountName varchar(150) = @CostumerName ,
				@vAccountNo varchar(50)=  'CSTU-'+ cast(@CostumerID as varchar(25)),
				@vAccountDesc varchar(200)='Costumer Account Created on ' + cast(getdate() as varchar),--date(Now),
				@vAccountComments varchar(200) = '',
				@bEditable bit = 0,
				@iFinaceType int = 1,
				@iModuleID int = (Select top 1 iModuleID From posModule where vModuleName = 'Costumer'),
				@iModuleFK_ID int = @CostumerID ,
				@type int = 0,
				@bNominal bit = 0
				EXECUTE InsertUpdateAccount  null,@AccountName,@vAccountNo, @vAccountDesc,  @vAccountComments,  @bEditable, @iFinaceType, @iModuleID,  @iModuleFK_ID,@iUpdate , @bNominal ,@type
				
		End	
		
		Else if (@iUpdate = 1 and @CostumerID > 0 )
		
		Begin
		
			UPDATE tblCostumer
			SET    CostumerName = @CostumerName, CostumerBikeNumber = @CostumerBikeNumber, CostumerMobileNumber = @CostumerMobileNumber, CostumerLastVisit = @CostumerLastVisit, MeterReading = @MeterReading, ModelNumber = @ModelNumber,
			bFallowUp = @bFallowUp , dLastInovice = @dLastInovice , dAlertDate = @dAlertDate 
			WHERE  CostumerID = @CostumerID
			
		END
		
		SELECT *
	FROM   tblCostumer
	WHERE  CostumerID = @CostumerID	
End
GO


