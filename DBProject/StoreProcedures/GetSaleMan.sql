IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetSaleMan')
	BEGIN
		DROP  Procedure  GetSaleMan
	END

GO

/****** Object:  StoredProcedure [dbo].[GetAppUsers]    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].GetSaleMan
	@iSaleManID bigint  = null ,
    @vSaleManName varchar(255)= null ,
    @vAddresss varchar(255)= null ,
    @vMobile varchar(255)= null 
AS
	declare @cmd varchar(1000)
	set @cmd = ' select * from  posSaleMan  WHERE   1=1 '
	

	
	if @iSaleManID is not null and @iSaleManID > 0
		set @cmd = @cmd + 'and iSaleManID = ' +Cast(@iSaleManID as varchar)
		
	

		--print @cmd
	execute(@cmd)

GO


