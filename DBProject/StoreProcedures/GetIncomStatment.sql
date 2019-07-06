IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetIncomStatment')
	BEGIN
		DROP  Procedure  GetIncomStatment
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].GetIncomStatment --@iAccountID = 29--@bShowBlance = 0--null,null,3,5
	
    @dTransactionFromDate datetime = null,
    @dTransactionToDate datetime = null,
    @dTransactionDate datetime = null
   
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--update posAccounts  set iFinaceType =5 where AccountName = 'Purchase'  and iModuleID = 11
	--update posAccounts  set iFinaceType =5 where AccountName = 'Salary'  and iModuleID = 32
	--update posAccounts  set iFinaceType =4 where AccountName = 'Sales'  and iModuleID = 1
	--update posAccounts  set iFinaceType =1 where AccountName = 'Purchase Returns'  and iModuleID = 36
	--update posAccounts  set iFinaceType =3 where AccountName = 'Sales Returns'  and iModuleID = 37
	--update posAccounts  set iFinaceType =1 where AccountName = 'Cash'  and iModuleID = 33
	SET NOCOUNT ON;

    declare @ProfitAndLoss table 
    (id int identity, vdescription varchar(255),vNote varchar(255),balance float,balanceType varchar(150))
    Declare @iAccountID int , @iFinaceType int 
	-- Calculate for Revnue
	select @iAccountID = iAccountID , @iFinaceType = iFinaceType from posAccounts where AccountName = 'Sales'  and iModuleID = 1
	
	select  @iAccountID ,@iFinaceType
END
Go