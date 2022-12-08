CREATE TABLE [dbo].[Organisation]
(
	[OrganisationId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [OrganisationName] NVARCHAR(50) NULL, 
    [OrganisationType] NVARCHAR(50) NULL, 
    [OrganisationCategory] NVARCHAR(50) NULL, 
    [CreatedDate] DATE NULL, 
    [ModifiedDate] DATE NULL
)
