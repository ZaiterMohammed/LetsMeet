CREATE TABLE [dbo].[Post]
(
	[PostId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [PostTitle] NVARCHAR(50) NULL, 
    [CreatedDate] DATE NULL, 
    [ModifiedDate] DATE NULL, 
    [CompanyId] UNIQUEIDENTIFIER NULL, 
    [OrganizationId] UNIQUEIDENTIFIER NULL, 
    [PostDescription] NVARCHAR(50) NULL
)
