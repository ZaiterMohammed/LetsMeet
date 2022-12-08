CREATE PROCEDURE [dbo].[usp_DeleteRole]
 @RoleId uniqueidentifier 

AS
 BEGIN 
  delete from Role where RoleId = @RoleId 
 END