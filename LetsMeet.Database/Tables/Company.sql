CREATE TABLE [dbo].[Company]
(
	[CompanyId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CompanyName] NVARCHAR(50) NULL, 
    [CompanyTypes] NVARCHAR(50) NULL, 
    [CityId] UNIQUEIDENTIFIER NULL, 
    [CountryId] UNIQUEIDENTIFIER NULL, 
    [CreatedDate] DATE NULL, 
    [ModifiedDate] DATE NULL
)
