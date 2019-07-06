IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetProduction')
	BEGIN
		DROP  Procedure  GetProduction
	END

GO

/****** Object:  StoredProcedure [dbo].[GetAppUsers]    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].GetProduction --  @iPurchaseid= 134 , @dFromDate = N'2013-07-20' , @dToDate = N'2013-08-20'
	@iProductionId bigint = null,
    @dDate datetime = null,
    @vLocation varchar(255) = null,
    @vPurchaseManager varchar(255) = null,
    @vProductionUnit varchar(255) = null,
    @fProductionCast float = null,
    @dToDate datetime = null,
    @dFromDate datetime = null
   
AS
	declare @cmd varchar(1000)
	set @cmd = 'SELECT posProduction.* , 
				(select count (*) from dbo.posProductionItem 
				where iProductionid = posProduction.iProductionId and posProductionItem.iProductionItemType = 0) as NumberOfItemConsumed ,
				(select count (*) from dbo.posProductionItem 
				where iProductionid = posProduction.iProductionId and posProductionItem.iProductionItemType = 1) as NumberOfItemProduced 
				FROM         posProduction	  WHERE   1=1 '
	if @iProductionId is not null and @iProductionId > 0
		set @cmd = @cmd + 'and iProductionId = ' +Cast(@iProductionId as varchar)
	
	-- make join with party
	if @dFromDate  is not null and @dFromDate <>  ''  
		set @cmd = @cmd + ' and dDate >= CAST(''' + Convert(varchar(150),@dFromDate,101) + ''' as Datetime)'
		
	if @dToDate  is not null and @dToDate <>  ''  
		set @cmd = @cmd + ' and dDate <= CAST(''' + Convert(varchar(150),@dToDate,101) + ''' as Datetime)'
	
	
	set @cmd = @cmd + 'Order By posProduction.iProductionId DESC'
	print @cmd
	execute(@cmd)
	-- return sec table
	declare @cmd2 varchar(1000)
	set @cmd2 = ' select * from  posProductionItem INNER JOIN
	        posItems ON posProductionItem.iItemID = posItems.iItemID  WHERE   1=1 and iProductionItemType = 0'
	if @iProductionId is not null and @iProductionId > 0
		begin
		set @cmd2 = @cmd2 + 'and iProductionId = ' +Cast(@iProductionId as varchar)
		
		execute(@cmd2)
	 end
	 
	 
	 declare @cmd3 varchar(1000)
	set @cmd3 = ' select * from  posProductionItem INNER JOIN
	        posItems ON posProductionItem.iItemID = posItems.iItemID  WHERE   1=1 and iProductionItemType = 1'
	if @iProductionId is not null and @iProductionId > 0
		begin
		set @cmd3 = @cmd3 + 'and iProductionId = ' +Cast(@iProductionId as varchar)
		
		execute(@cmd3)
	 end
	--print @cmd
	


GO
