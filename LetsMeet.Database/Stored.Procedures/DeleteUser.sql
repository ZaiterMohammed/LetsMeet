CREATE PROCEDURE [dbo].[DeleteUser]
 @UserId uniqueidentifier 

AS
 BEGIN 
  delete from User where UserId = @UserId 
 END