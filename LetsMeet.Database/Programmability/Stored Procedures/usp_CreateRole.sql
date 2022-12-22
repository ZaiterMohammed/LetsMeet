CREATE PROCEDURE [dbo].[usp_CreateRole]
	@RoleId uniqueidentifier,
	@Name nvarchar(50),
	@IsVerified int,
	@UserId uniqueidentifier,
	@OwnerId uniqueidentifier
AS
BEGIN
	insert into Role (RoleId,RoleName,IsVerified,UserIdF,OwnerIdF)
	values(newId(),@Name,@IsVerified,@UserId,@OwnerId)
END
