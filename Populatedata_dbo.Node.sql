USE [CompanyStructured]
GO


/****** Object: Table [dbo].[Node] Script Date: 2019/02/08 02:32:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

delete from dbo.Node

go

DECLARE @NumberOfRecordsToInsert INT ;
set @NumberOfRecordsToInsert = 100;
DECLARE @Inner INT ;
set @Inner =1;
DECLARE @id1 INT ;
set @id1 = 1;
DECLARE @name1 nvarchar(70) ;
set @name1 = 'CEO ';
DECLARE @parentId1 INT ;
set @parentId1 = null;

SET NOCOUNT ON
WHILE (@NumberOfRecordsToInsert > 0)
BEGIN
    BEGIN TRAN
      SET @Inner = 0
      WHILE (@Inner < @NumberOfRecordsToInsert)
      BEGIN
	  if(@id1 = 2)
	  begin
	    set  @name1 = 'Manager';
	    set @parentId1 = 1;
      end	  
        INSERT INTO [dbo].[Node] ([Id],[Name],[ParentId]) VALUES(@id1,@name1 ,@parentId1);
        SET @Inner = @Inner+1;
		set  @name1  = 'stuff ' + convert(nvarchar(30), @id1 + 1);
	    set @parentId1  = ABS(CHECKSUM(NEWID()) % @id1) + 1;-- generate random parent for given id between 1 to @Id
		SET @id1 = @id1+1;
      END
    COMMIT
    SET @NumberOfRecordsToInsert = @NumberOfRecordsToInsert - @Inner
END


