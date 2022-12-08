CREATE TABLE [dbo].[Post]
(
	[PostId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [PostTitle] NVARCHAR(50) NULL, 
    [CreatedDate] DATE NULL, 
    [ModifiedDate] DATE NULL, 
    [UserId] UNIQUEIDENTIFIER NULL, 
    [OrganisationId] UNIQUEIDENTIFIER NULL, 
    [PostDescription] NVARCHAR(50) NULL,

    --missing createdBy and modifiedBy

CONSTRAINT [FK_Post_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]),
CONSTRAINT [FK_Post_ToOrganisation] FOREIGN KEY ([OrganisationId]) REFERENCES [Organisation]([OrganisationId])
)
