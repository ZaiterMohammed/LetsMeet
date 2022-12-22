CREATE TABLE [dbo].[Admins]
(
	[AdminId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserIdF] UNIQUEIDENTIFIER NULL, 
    [MunicipalityIdF] UNIQUEIDENTIFIER NULL, 
    CONSTRAINT [FK_Admins_ToUsers] FOREIGN KEY ([UserIdF]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_Admins_ToMunicipacity] FOREIGN KEY ([MunicipalityIdF]) REFERENCES [Municipality]([MunicipalityId])
)
