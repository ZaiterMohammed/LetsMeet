CREATE TABLE [dbo].[Post]
(
	[PostId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [PostTitle] NVARCHAR(50) NULL, 
    [CreatedDate] DATE NULL, 
    [ModifiedDate] DATE NULL, 
    [PostDescription] NVARCHAR(50) NULL, 
    [OwnerIdF] UNIQUEIDENTIFIER NULL, 
    [CreatedByF] UNIQUEIDENTIFIER NULL,

    [UpdatedByF] UNIQUEIDENTIFIER NULL, 

CONSTRAINT [FK_Post_ToOwner] FOREIGN KEY ([OwnerIdF]) REFERENCES [Owner]([OwnerId]), 
    CONSTRAINT [FK_Post_ToUser] FOREIGN KEY ([CreatedByF]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_Post_ToUserU] FOREIGN KEY ([UpdatedByF]) REFERENCES [Users]([UserId]) 
)
