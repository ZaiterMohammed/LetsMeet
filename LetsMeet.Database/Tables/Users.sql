CREATE TABLE [dbo].[Users]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Age] INT NULL, 
    [IsFeatured] INT NULL, 
    [CityIdF] UNIQUEIDENTIFIER NULL, 
    [CountryIdF] UNIQUEIDENTIFIER NULL, 
    [CreatedDate] DATE NULL, 
    [ModifiedDate] DATE NULL, 
    [OwnerIdF] UNIQUEIDENTIFIER NULL, 
    [MunicipalityIdF] UNIQUEIDENTIFIER NULL, 
    CONSTRAINT [FK_Users_ToCountry] FOREIGN KEY ([CountryIdF]) REFERENCES [Country]([CountryId]), 
    CONSTRAINT [FK_Users_ToCity] FOREIGN KEY ([CityIdF]) REFERENCES [City]([CityId]), 
    CONSTRAINT [FK_Users_ToOwner] FOREIGN KEY ([OwnerIdF]) REFERENCES [Owner]([OwnerId]), 
    CONSTRAINT [FK_Users_ToMunicipality] FOREIGN KEY ([MunicipalityIdF]) REFERENCES [Municipality]([MunicipalityId]) 
)
