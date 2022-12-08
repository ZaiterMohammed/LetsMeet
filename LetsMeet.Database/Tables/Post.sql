CREATE TABLE [dbo].[Post]
(
	[PostId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [PostTitle] NVARCHAR(50) NULL, 
    [CreatedDate] DATE NULL, 
    [ModifiedDate] DATE NULL, 
    [OwnerId] UNIQUEIDENTIFIER NULL, (Id of comapny or organization)
    [OwnerType] UNIQUEIDENTIFIER NULL, (Company, Organization)
    [PostDescription] NVARCHAR(50) NULL

    --missing createdBy and modifiedBy
)
