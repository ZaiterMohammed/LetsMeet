CREATE PROCEDURE [dbo].[DeleteLike]
 @LikeId uniqueidentifier 

AS
 BEGIN 
  delete from Likes where LikeId = @LikeId 
 END