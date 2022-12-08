CREATE PROCEDURE [dbo].[DeleteUser]
 @UserId uniqueidentifier 

AS
 BEGIN 
  delete from Users where UserId = @UserId 
 END