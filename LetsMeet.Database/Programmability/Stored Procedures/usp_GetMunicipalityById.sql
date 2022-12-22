CREATE PROCEDURE [dbo].[usp_GetMunicipalityById]
@MunicipalityId uniqueidentifier


AS
BEGIN
	SELECT * from Municipality 
	where MunicipalityId = @MunicipalityId
END
