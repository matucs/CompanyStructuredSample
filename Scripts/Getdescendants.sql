USE [CompanyStructured]
GO
/****** Object:  StoredProcedure [dbo].[GetDescendantsByParentId]    Script Date: 2019/02/12 06:32:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [dbo].[GetDescendantsByParentId]
        @parentId1 int = null
        AS
        BEGIN
            -- SET NOCOUNT ON added to prevent extra result sets from
            -- interfering with SELECT statements.
            SET NOCOUNT ON;

            -- Insert statements for procedure here
       With
  NodeCTE (Id, [Name], ParentId)
  as
  (
    Select Id, [Name], ParentId
    from Node
    where ParentId = @parentId1
    
    union all
    
    Select Node.Id, Node.Name, 
    Node.ParentId
    from Node
    join NodeCTE
    on Node.ParentId = NodeCTE.Id
  )
  Select EmpCTE.Id as Id, EmpCTE.Name as Name, EmpCTE.ParentId as ParentId
from NodeCTE EmpCTE
        END