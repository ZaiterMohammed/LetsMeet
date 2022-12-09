CREATE PROCEDURE [dbo].[usp_CreateAdmin]
	@UserId uniqueidentifier,
	@MunicipalityId uniqueidentifier
AS
BEGIN
	INSERT INTO Admins (AdminId,UserId,MunicipalityId)
	VALUES( newId(), @UserId,@MunicipalityId)
END