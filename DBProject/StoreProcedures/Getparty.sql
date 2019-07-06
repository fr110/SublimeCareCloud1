IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Getparty')
	BEGIN
		DROP  Procedure  Getparty
	END

GO

/****** Object:  StoredProcedure [dbo].[GetAppUsers]    Script Date: 06/27/2013 16:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].Getparty
	  @iPartyID bigint  = null ,
    @vPartyName varchar(255)  = null ,
    @vPartyadress varchar(255)  = null ,
    @vpartyMobile varchar(25)  = null ,
    @iSaleManID int   = null 
AS
	declare @cmd varchar(1000)
	set @cmd = '	SELECT *  from  posParty  WHERE   1=1 '
	

	
	if @iPartyID is not null and @iPartyID > 0
		set @cmd = @cmd + 'and iPartyID = ' +Cast(@iPartyID as varchar)
		
	

		--print @cmd
	execute(@cmd)

GO


