CREATE PROCEDURE [dbo].[CreateLike]
	@LikeId uniqueidentifier,
	@UserId uniqueidentifier,
	@PostId uniqueidentifier
AS
BEGIN
	INSERT INTO Likes (LikeId,UserId,PostId)
	VALUES( @LikeId, @UserId,@PostId)
	END