IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetEmployee')
	BEGIN
		DROP  Procedure   GetEmployee
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEmployee] --@Empid =7
	-- Add the parameters for the stored procedure here
	@Empid int = null, 
	@iProjid int = null,	
	@EmpfName varchar(50) = null,
	@EmplName varchar(50) = null,
	@EmpIdNo varchar(50) = null,
    
	@vSortColumn varchar(20) = null,
	@vSortOrder varchar(5) = null
	
AS
	set @vSortColumn = 'vEmpfName'
	set @vSortOrder = 'asc'
    declare @totalBal as varchar(30)= ''
	declare @cmd varchar(2000)

	set @cmd='SELECT     posEmployee.*, posAccounts.* FROM         posEmployee INNER JOIN
                         posAccounts ON posAccounts.iModuleFK_ID = posEmployee.iEmpid
						 WHERE     1=1 and (posAccounts.iModuleID = 29)'
		
	if @Empid is not null and @Empid <> 0
	   begin
	   
	        declare @iAccountid as int = (select iAccountid from posAccounts where iModuleID=29  and iModuleFK_ID =@Empid) 
		    declare @totalCr as bigint = 0 --cast( (select   SUM(iAmount) as Amount from Journal  where iAccountID =@iAccountid and vType like '%Cr%') as bigint)
		    declare @totalDr as bigint = 0--cast( (select   SUM(iAmount) as Amount from Journal  where iAccountID =@iAccountid and vType like'%Dr%') as bigint)
			if @totalCr is null
				    set @totalCr = 0
			if @totalDr is null 
					set @totalDr = 0
			set @totalBal  =  cast((@totalDr - @totalCr) as varchar)
	   
	       	set @cmd='SELECT   posEmployee.*, posAccounts.* 
					  ,' + @totalBal + ' as TotalBal    
					  FROM         posEmployee INNER JOIN
                      posAccounts ON posAccounts.iModuleFK_ID = posEmployee.iEmpid
					  WHERE     1=1 and (posAccounts.iModuleID = 29)'
					  
		   set @cmd = @cmd + ' and posEmployee.iEmpid = ' + Cast(@Empid as varchar)
	
	   end 
	if @iProjid is not null and @iProjid <> 0
		set @cmd = @cmd + ' and EmployeeAssignment.iProjid = ' + Cast(@iProjid as varchar)	
	if @EmpfName is not null and @EmpfName <> ''
		set @cmd = @cmd + ' and posEmployee.vEmpfName like  ''%' + @EmpfName + '%'''
		
	if @EmplName is not null and @EmplName <> ''
		set @cmd = @cmd + ' and posEmployee.vEmplName like  ''%' + @EmplName + '%'''
		
	if @EmpIdNo is not null and @EmpIdNo <> ''
		set @cmd = @cmd + ' and posEmployee.vIdNumber like  ''%' + @EmpIdNo + '%'''
		
	set @cmd = @cmd + ' order by ' + @vSortColumn
	set @cmd = @cmd + ' ' + @vSortOrder

	print (@cmd)	
		
	execute(@cmd)

GO

