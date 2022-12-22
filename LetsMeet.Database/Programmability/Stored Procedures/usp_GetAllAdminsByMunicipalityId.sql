CREATE PROCEDURE [dbo].[usp_GetAllAdminsByMunicipalityId]
@MunicipalityId uniqueidentifier

AS
BEGIN
	SELECT * from Admins 
	where MunicipalityIdF = @MunicipalityId
END
