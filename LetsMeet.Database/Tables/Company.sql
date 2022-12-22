CREATE TABLE [dbo].[Company]
(
	[CompanyId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CompanyName] NVARCHAR(50) NULL, 
    [CompanyTypes] NVARCHAR(50) NULL, 
    [CityIdF] UNIQUEIDENTIFIER NULL,  -- should be foreign key
    [CountryIdF] UNIQUEIDENTIFIER NULL, -- should be foreign key
    [CreatedDate] DATE NULL, 
    [ModifiedDate] DATE NULL,

    [IsFeatured] INT NULL, 
    CONSTRAINT [FK_Park_ToCity] FOREIGN KEY ([CityIdF]) REFERENCES [City]([CityId]), 
    CONSTRAINT [FK_Park_ToCountry] FOREIGN KEY ([CountryIdF]) REFERENCES [Country]([CountryId])
)
