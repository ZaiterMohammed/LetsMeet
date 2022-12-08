CREATE PROCEDURE [dbo].[usp_DeleteLike]
 @LikeId uniqueidentifier 

AS
 BEGIN 
  delete from Likes where LikeId = @LikeId 
 END