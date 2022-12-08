CREATE PROCEDURE [dbo].[usp_UpdatePost]
 @PostId  uniqueidentifier, 
 @PostTitle nvarchar(50),  
 @CreatedDate date,
 @ModifiedDate date,
 @UserId uniqueidentifier,
 @OwnerId uniqueidentifier,
 @PostDescription nvarchar(50)

AS
BEGIN
update Post
 set PostTitle = @PostTitle , PostDescription = @PostDescription 
 where PostId = @PostId
 END
