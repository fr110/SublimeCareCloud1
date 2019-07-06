IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveSaleInovice')
	BEGIN
		DROP  Procedure  RemoveSaleInovice
	END

GO

/****** Object:  StoredProcedure dbo.GetAppUsers    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE dbo.RemoveSaleInovice
	@iSaleid bigint = null
AS
begin
		-- delete from saleitems
		delete from posSaleItem where iSaleid = @iSaleid
		select @@ROWCOUNT as ItemDeleted
		-- detele from sale 
		delete from posSaleInovice where iSaleid = @iSaleid
		select @@ROWCOUNT as InvoiceDeleted
end
GO


