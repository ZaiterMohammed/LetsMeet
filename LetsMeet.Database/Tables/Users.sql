CREATE TABLE [dbo].[Users]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Age] INT NULL, 
    [IsFeatured] INT NULL, 
    [CityId] UNIQUEIDENTIFIER NULL, 
    [CountryId] UNIQUEIDENTIFIER NULL, 
    [CreatedDate] DATE NULL, 
    [ModifiedDate] DATE NULL, 
    [OwnerId] UNIQUEIDENTIFIER NULL, 
    [MunicipalityId] UNIQUEIDENTIFIER NULL, 
    CONSTRAINT [FK_Users_ToCountry] FOREIGN KEY ([CountryId]) REFERENCES [Country]([CountryId]), 
    CONSTRAINT [FK_Users_ToCity] FOREIGN KEY ([CityId]) REFERENCES [City]([CityId]), 
    CONSTRAINT [FK_Users_ToOwner] FOREIGN KEY ([OwnerId]) REFERENCES [Owner]([OwnerId]), 
    CONSTRAINT [FK_Users_ToMunicipality] FOREIGN KEY ([MunicipalityId]) REFERENCES [Municipality]([MunicipalityId]) 
)
