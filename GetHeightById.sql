USE [CompanyStructured]
GO

/****** Object:  StoredProcedure [dbo].[GetHeightById]    Script Date: 2019/02/10 08:05:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetHeightById]
        @Id1 int = null
        AS
        BEGIN
            -- SET NOCOUNT ON added to prevent extra result sets from
            -- interfering with SELECT statements.
            SET NOCOUNT ON;

  
       With
  NodeCTE (Id, [Name], ParentId)
  as
  (
    Select Id, [Name], ParentId
    from Node
    where Id =@Id1
    
    union all
    
    Select Node.Id, Node.Name, 
    Node.ParentId
    from Node
    join NodeCTE
    on Node.Id = NodeCTE.ParentId
  )
  Select count(*) -1 as height
from NodeCTE EmpCTE
        END

GO


