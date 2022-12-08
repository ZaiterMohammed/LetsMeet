CREATE PROCEDURE [dbo].[DeleteRole]
 @RoleId uniqueidentifier 

AS
 BEGIN 
  delete from Role where RoleId = @RoleId 
 END