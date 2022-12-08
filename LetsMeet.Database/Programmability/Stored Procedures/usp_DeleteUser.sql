CREATE PROCEDURE [dbo].[usp_DeleteUser]
 @UserId uniqueidentifier 

AS
 BEGIN 
  delete from Users where UserId = @UserId 
 END