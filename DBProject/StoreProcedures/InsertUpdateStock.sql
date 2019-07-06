IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateStock')
	BEGIN
		DROP  Procedure  InsertUpdateStock
	END

GO

/****** Object:  StoredProcedure dbo.GetAppUsers    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE InsertUpdateStock  --@iItemID = 2,@iStockIn =520 , @iProductionId = 2
	@iStokId bigint = null,
    @iItemID int= null,
    @iCurrantStock int= 0,
    @iUserId int= null,
    @iStockIn int= 0,
    @iStockOut int= 0,
    @iSaleId int= null,
    @iProductionId int= null,
    @dDate datetime= null,
    @iUpdate int = 0,
    @bitReturn int = 0,
    @vAction varchar(255) = null
AS
begin
		if(@iUpdate = 0) 
		Begin
			declare @iPreviousStock int =( select iCurrantStock from posStock where iItemID = 1 and iStokId = (select MAX(iStokId) from posStock where iItemID=1))
			--set @iCurrantStock = @iPreviousStock - @istockout + (@istockin)
			--insert into posStock (iItemID,iCurrantStock,iUserId,iStockOut,iSaleId,iProductionId,dDate) 
			--select @iItemID,((SUM(istockin) - SUM(istockout))-@iQuantity),@iUserId, @iQuantity , @iSaleid ,@iProductionId,@dDate from posStock where iItemID = @iItemID
			if(@iCurrantStock  = 0)
			begin
				set @iCurrantStock = COALESCE((select((SUM(istockin) - SUM(istockout))-@istockout + (@istockin)) from posStock where iItemID = @iItemID ),0)
			end
			if @iCurrantStock = 0 
			begin
			set @iCurrantStock = @iStockIn
			end
		INSERT INTO posStock (iItemID, iCurrantStock, iUserId, iStockIn, iStockOut, iSaleId, iProductionId, dDate , vAction)
		values( @iItemID, @iCurrantStock, @iUserId, @iStockIn, @iStockOut, @iSaleId, @iProductionId, @dDate,@vAction)
		set	@iStokId = @@IDENTITY
		
		End	
		
		--Else if (@iUpdate = 1 and @iPartyID > 0 )
		
		--Begin
		if(@bitReturn = 1)
		begin 
			select @iPreviousStock 
			end
			
			
		--END
		
		--             SELECT * From posParty  where iPartyID = @iPartyID
End
GO


