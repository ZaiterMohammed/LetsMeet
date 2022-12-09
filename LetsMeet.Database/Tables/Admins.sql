CREATE TABLE [dbo].[Admins]
(
	[AdminId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserId] UNIQUEIDENTIFIER NULL, 
    [MunicipalityId] UNIQUEIDENTIFIER NULL, 
    CONSTRAINT [FK_Admins_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_Admins_ToMunicipacity] FOREIGN KEY ([MunicipalityId]) REFERENCES [Municipality]([MunicipalityId])
)
