CREATE PROCEDURE [dbo].[usp_UpdateRole]
	@RoleId uniqueidentifier,
	@RoleName nvarchar(50),
	@IsVerified int,
	@UserId uniqueidentifier,
	@OwnerId uniqueidentifier
AS
BEGIN
	update Role
	set RoleName = @RoleName, IsVerified = @IsVerified
	where RoleId = @RoleId
END
