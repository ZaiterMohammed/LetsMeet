CREATE PROCEDURE [dbo].[usp_GetRoleByUserId]
@UserId uniqueidentifier


AS
BEGIN
	SELECT * from Role 
	where UserIdF = @UserId
END
