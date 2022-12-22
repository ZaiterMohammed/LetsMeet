CREATE PROCEDURE [dbo].[usp_CreateAdmin]
	@UserId uniqueidentifier,
	@MunicipalityId uniqueidentifier
AS
BEGIN
	INSERT INTO Admins(AdminId,UserIdF,MunicipalityIdF)
	VALUES( newId(), @UserId,@MunicipalityId)
END