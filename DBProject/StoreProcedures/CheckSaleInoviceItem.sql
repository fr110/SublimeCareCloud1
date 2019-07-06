IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CheckItemInvoiced')
	BEGIN
		DROP  Procedure  CheckItemInvoiced
	END

GO

/****** Object:  StoredProcedure [dbo].[GetAppUsers]    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].CheckItemInvoiced --@iCostumerId = 10 ,@iItemID = 13-- @ipartyId = 2 -- ,@iItemID = 2
	@iSaleid bigint = null,
    @iCostumerId int = null,
    @iItemID int = null
    
AS
	declare @cmd varchar(2000)
	set @cmd = ' 
		SELECT   SUM( 
			case 
				when posSaleInovice.bReturnInvoice is null 
				then posSaleItem.iQuantity 
				when posSaleInovice.bReturnInvoice = 1 
				then - posSaleItem.iQuantity 
				when posSaleInovice.bReturnInvoice = 0
				then posSaleItem.iQuantity 
				end 
			) as iQuantity,
			posSaleInovice.ICostumerId, posSaleItem.iItemID
FROM         posSaleInovice INNER JOIN
                      posSaleItem ON posSaleInovice.iSaleid = posSaleItem.iSaleid INNER JOIN
                      posItems ON posSaleItem.iItemID = posItems.iItemID 
                      where 
                      1=1
                    '
                    
                    
	if @iCostumerId is not null and @iCostumerId > 0
		set @cmd = @cmd + 'and posSaleInovice.iCostumerId = ' +Cast(@iCostumerId as varchar)
		
		if @iItemID is not null and @iItemID > 0
		set @cmd = @cmd + 'and posSaleItem.iItemID  = ' +Cast(@iItemID as varchar)
	--  and posSaleItem.iItemID = 2
	
	set @cmd = @cmd + ' Group by
                    posSaleItem.iItemID
                    ,posSaleInovice.ICostumerId
                     ,posSaleItem.iItemID'
	print @cmd
	execute(@cmd)
GO


