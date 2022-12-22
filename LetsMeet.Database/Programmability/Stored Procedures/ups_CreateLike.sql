CREATE PROCEDURE [dbo].[usp_CreateLike]
	@UserId uniqueidentifier,
	@PostId uniqueidentifier
AS
BEGIN
	INSERT INTO Likes (LikeId,UserIdF,PostIdF)
	VALUES( newId(), @UserId,@PostId)
END