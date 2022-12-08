CREATE PROCEDURE [dbo].[usp_CreateLike]
	@UserId uniqueidentifier,
	@PostId uniqueidentifier
AS
BEGIN
	INSERT INTO Likes (LikeId,UserId,PostId)
	VALUES( newId(), @UserId,@PostId)
END