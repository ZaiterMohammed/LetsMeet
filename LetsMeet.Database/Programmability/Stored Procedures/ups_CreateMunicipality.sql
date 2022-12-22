CREATE PROCEDURE [dbo].[usp_CreateMunicipality]
	@MunicipalityName nvarchar(50),
	@CountryId uniqueidentifier
AS
BEGIN
	INSERT INTO Municipality(MunicipalityId,MunicipalityName,CountryIdF)
	VALUES( newId(), @MunicipalityName,@CountryId)
END