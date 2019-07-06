IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveSaleInoviceItem')
	BEGIN
		DROP  Procedure  RemoveSaleInoviceItem
	END

GO

/****** Object:  StoredProcedure dbo.GetAppUsers    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE dbo.RemoveSaleInoviceItem --@iSaleid = 110
    @iSaleItemid bigint = null,
    @bIsDraft bigint = null
    ----,
    ----@iSaleid bigint= null,
    ----@fUnitePrice float= null,
    ----@iQuantity int= null,
    ----@fGrossAmount float= null,
    ----@iItemID int= null,
    ----@iSerialNumber int = null,
    ----@iUpdate int= 0,
    ----@iUserId int = null,
    ----@iProductionId int = null ,
    ----@dDate datetime = null,
    ----@bReturnInvoice bit = null
AS
begin

		
		if(@bIsDraft = 1) 
		Begin
			delete from posSaleItem where iSaleItemid = @iSaleItemid		
			--set	@iSaleItemid = @@IDENTITY
		End				
		SELECT @@ROWCOUNT as Result 
		SELECT * From posSaleItem where iSaleItemid = @iSaleItemid
end

GO


