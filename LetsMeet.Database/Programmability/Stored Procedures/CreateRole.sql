CREATE PROCEDURE [dbo].[CreateRole]
	@RoleId uniqueidentifier,
	@Name nvarchar(50),
	@IsVerified int,
	@UserId uniqueidentifier,
	@OwnerId uniqueidentifier
AS
BEGIN
	insert into Role (RoleId,RoleName,IsVerified,UserId,OwnerId)
	values(@RoleId,@Name,@IsVerified,@UserId,@OwnerId)
END
