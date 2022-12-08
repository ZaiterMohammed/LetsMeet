CREATE PROCEDURE [dbo].[GetRoleByUserId]
@UserId uniqueidentifier


AS
BEGIN
	SELECT * from Role 
	where UserId = @UserId
END
