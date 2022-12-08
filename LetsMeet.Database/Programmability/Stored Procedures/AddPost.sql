CREATE PROCEDURE [dbo].[AddPost]
 @PostId  uniqueidentifier, 
 @PostTitle nvarchar(50),  
 @CreatedDate date,
 @ModifiedDate date,
 @UserId uniqueidentifier,
 @OrganisationId uniqueidentifier,
 @PostDescription nvarchar(50)


AS
 BEGIN 
 Insert into Post (PostId,PostTitle,PostDescription,UserId,OrganisationId,CreatedDate,ModifiedDate)  --reflect table changes
 values(@PostId,@PostTitle,@CreatedDate,@ModifiedDate,@OrganisationId,@UserId,@PostDescription)  
 END
      