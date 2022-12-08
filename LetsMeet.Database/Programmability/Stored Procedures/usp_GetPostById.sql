CREATE PROCEDURE [dbo].[usp_GetPostById]
@PostId uniqueidentifier


AS
BEGIN
	SELECT * from Post 
	where PostId = @PostId
END
