CREATE TABLE [dbo].[Municipality]
(
	[MunicipalityId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [MunicipalityName] NVARCHAR(50) NULL, 
    [CountryIdF] UNIQUEIDENTIFIER NULL
)
