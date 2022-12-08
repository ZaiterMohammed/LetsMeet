CREATE TABLE [dbo].[Post]
(
	[PostId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [PostTitle] NVARCHAR(50) NULL, 
    [CreatedDate] DATE NULL, 
    [ModifiedDate] DATE NULL, 
    [PostDescription] NVARCHAR(50) NULL, 
    [OwnerId] UNIQUEIDENTIFIER NULL, 
    [CreatedBy] UNIQUEIDENTIFIER NULL,

    [UpdatedBy] UNIQUEIDENTIFIER NULL, 

CONSTRAINT [FK_Post_ToOwner] FOREIGN KEY ([OwnerId]) REFERENCES [Owner]([OwnerId]), 
    CONSTRAINT [FK_Post_ToUser] FOREIGN KEY ([CreatedBy]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_Post_ToUserU] FOREIGN KEY ([UpdatedBy]) REFERENCES [Users]([UserId]) 
)
