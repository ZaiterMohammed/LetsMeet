CREATE TABLE [dbo].[User]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Age] INT NULL, 
    [IsFeatured] INT NULL, 
    [CityId] UNIQUEIDENTIFIER NULL, 
    [CountryId] UNIQUEIDENTIFIER NULL, 
    [CreatedDate] DATE NULL, 
    [ModifiedDate] DATE NULL
)
