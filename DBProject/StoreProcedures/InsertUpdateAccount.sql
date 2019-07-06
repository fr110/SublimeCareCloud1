IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUpdateAccount')
	BEGIN
		DROP  Procedure  InsertUpdateAccount
	END
go

CREATE PROCEDURE InsertUpdateAccount
    @IAccountid int = null,
	@AccountName varchar(150) = null,
    @vAccountNo varchar(50) = null,
    @vAccountDesc varchar(200) = null,
    @vAccountComments varchar(200) =null,
    @bEditable bit = null,
    @iFinaceType int = null,
    @iModuleID int = null,
    @iModuleFK_ID int = null,
    @iUpdate int = null,
    @bNominal bit = 0,
    @type  int = 1
AS

BEGIN
   if(@iUpdate = 0) 
   Begin		
    -- Insert statements for procedure here
    --if not exists(select * from Accounts WHERE vAccountNo = @vAccountNo)
    --begin
  --  BEGIN 
    --TRAN
	INSERT INTO posAccounts
		(
		AccountName,
		vAccountNo, 
		vAccountDesc, 
		vAccountComments, 
		bEditable, 
		iFinaceType, 
		iModuleID, 
		iModuleFK_ID,
		bNominal
		)values
		(
		 @AccountName, 
		 @vAccountNo, 
		 @vAccountDesc, 
		 @vAccountComments, 
		 @bEditable, 
		 @iFinaceType, 
		 @iModuleID, 
		 @iModuleFK_ID,
		 @bNominal	
		 )
		 set @IAccountid = @@identity 
		-- select * from pos.dbo.posAccounts where iAccountid = @IAccountid
	--COMMIT
--	    End
	    --else  -- else if not exists(select * from d.............
	    -- begin
	    --     set @IAccountid = -1
	 End
	    
	
--end -- if update
  Else if (@iUpdate = 1 and @IAccountid  > 0 )
    begin
        UPDATE posAccounts SET
				 AccountName = @AccountName,
				 --vAccountNo = @vAccountNo,
				 vAccountDesc = @vAccountDesc,
				vAccountComments = @vAccountComments,
				bNominal = @bNominal,
				 iFinaceType=  @iFinaceType
			WHERE iAccountid = @IAccountid
     
    End
  
      if @type = 1
      begin
		select @IAccountid as iAccountid
	  end
	   
	  
END
