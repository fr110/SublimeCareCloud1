IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetSalary')
	BEGIN
		DROP  Procedure  GetSalary
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetSalary]
	-- Adding the parameters 
	@iSalId int=null,
	@iEmpId int=null,
	@bIsPaid bit=null,
	@dSrtDate datetime=null,
	@dEndDate datetime=null,
	@iDays int=null,
	@iHours int=null,
	@iTranId int=null,
	@dPaidDate datetime=null,
	@dGenratedDate datetime=null,
	@iAmount int=null,
	@iDeduction int=null,
	@vSortColumn varchar(50) = null,
	@vSortOrder varchar(20) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if @vSortColumn  is null 
		set @vSortColumn = 'dEndDate'
	if @vSortOrder is null 
			set @vSortOrder = 'DESC'
			
	declare @cmd varchar(2000)
	set @cmd='SELECT     iSalId,iEmpId, Case when bIsPaid IS null then ' + '''False''' + ' when bIsPaid is not null then bIsPaid end  as bIsPaid , dSrtDate, dEndDate, iDays, iHours, iTranId, dPaidDate, dGenratedDate, iAmount, iDeduction, iAbsentdays, fOverTime
FROM         Salary where 1=1'
	--if @Partyid is not null and @Partyid <> 0
	--	set @cmd = @cmd + ' and iPartyid = ' + Cast(@Partyid as varchar)
	--if @CompName is not null and @CompName <> ''
	--if @iSalId is not null and @iSalId <>  0
	--	set @cmd = @cmd + 'and iSalId = ' + @iSalId
	if @iSalId  is not null and @iSalId <>  0
		set @cmd = @cmd + ' and iSalId = ' + Cast(@iSalId as varchar)
	if @iEmpId  is not null and @iEmpId <>  0 
		set @cmd = @cmd + ' and iEmpId = ' + Cast(@iEmpId as varchar)
	if @bIsPaid  is not null 
		set @cmd = @cmd + ' and bIsPaid = ' + Cast(@bIsPaid as varchar)
	
	
	set @cmd = @cmd + ' order by ' + @vSortColumn
	set @cmd = @cmd + ' ' + @vSortOrder
		
		
	print (@cmd)	
		
	execute(@cmd)
	--select @cmd as cmd


END

GO

