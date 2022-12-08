CREATE PROCEDURE [dbo].[usp_DeletePost]
 @PostId uniqueidentifier 

AS
 BEGIN 
  delete from Post where PostId = @PostId 
 END