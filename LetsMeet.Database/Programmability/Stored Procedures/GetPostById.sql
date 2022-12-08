CREATE PROCEDURE [dbo].[GetPostById]
@PostId uniqueidentifier


AS
BEGIN
	SELECT * from Post 
	where PostId = @PostId
END
