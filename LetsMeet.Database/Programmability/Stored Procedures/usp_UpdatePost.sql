CREATE PROCEDURE [dbo].[usp_UpdatePost]
 @PostId  uniqueidentifier, 
 @PostTitle nvarchar(50),  
 @ModifiedDate date,
 @UserId uniqueidentifier,
 @OwnerId uniqueidentifier,
 @PostDescription nvarchar(50)

AS
BEGIN
update Post
 set PostTitle = @PostTitle , PostDescription = @PostDescription , ModifiedDate = @ModifiedDate
 where PostId = @PostId
 END
