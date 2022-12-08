CREATE PROCEDURE [dbo].[DeletePost]
 @PostId uniqueidentifier 

AS
 BEGIN 
  delete from Post where PostId = @PostId 
 END