CREATE TABLE [dbo].[Company]
(
	[CompanyId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CompanyName] NVARCHAR(50) NULL, 
    [CompanyTypes] NVARCHAR(50) NULL, 
    [CityId] UNIQUEIDENTIFIER NULL,  -- should be foreign key
    [CountryId] UNIQUEIDENTIFIER NULL, -- should be foreign key
    [CreatedDate] DATE NULL, 
    [ModifiedDate] DATE NULL,

    [IsFeatured] INT NULL, 
    CONSTRAINT [FK_Park_ToCity] FOREIGN KEY ([CityId]) REFERENCES [City]([CityId]), 
    CONSTRAINT [FK_Park_ToCountry] FOREIGN KEY ([CountryId]) REFERENCES [Country]([CountryId])
)
