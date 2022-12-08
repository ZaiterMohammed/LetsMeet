CREATE PROCEDURE [dbo].[UpdatePost]
 @PostId  uniqueidentifier, 
 @PostTitle nvarchar(50),  
 @CompanyId uniqueidentifier,
 @CreatedDate date,
 @ModifiedDate date,
 @UserId uniqueidentifier,
 @OrganisationId uniqueidentifier,
 @PostDescription nvarchar(50)

AS
BEGIN
update Post
 set PostTitle = @PostTitle , PostDescription = @PostDescription -- you should not update postId
 where PostId = @PostId

 END
