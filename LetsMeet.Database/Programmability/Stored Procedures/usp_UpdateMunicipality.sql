CREATE PROCEDURE [dbo].[usp_UpdateMunicipality]
@MunicipalityId  uniqueidentifier, 
@MunicipalityName nvarchar(50),
@CountryId uniqueidentifier
 
AS
 BEGIN 
	 update Municipality
	 set MunicipalityName = @MunicipalityName , CountryId = @CountryId
	 where MunicipalityId = @MunicipalityId
 END
