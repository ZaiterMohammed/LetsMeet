CREATE TABLE [dbo].[Company]
(
	[CompanyId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CompanyName] NVARCHAR(50) NULL, 
    [CompanyTypes] NVARCHAR(50) NULL, 
    [CityId] UNIQUEIDENTIFIER NULL,  -- should be foreign key
    [CountryId] UNIQUEIDENTIFIER NULL, -- should be foreign key
    [CreatedDate] DATE NULL, 
    [ModifiedDate] DATE NULL
)
