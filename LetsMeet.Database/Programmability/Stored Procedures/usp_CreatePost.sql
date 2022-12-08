CREATE PROCEDURE [dbo].[usp_CreatePost]
 @PostTitle nvarchar(50),  
 @CreatedDate date,
 @ModifiedDate date,
 @UserId uniqueidentifier,
 @OwnerId uniqueidentifier,
 @PostDescription nvarchar(50)


AS
 BEGIN 
 Insert into Post (PostId,PostTitle,CreatedDate,ModifiedDate,UserId,OwnerId,PostDescription)
 values(newId(),@PostTitle,@CreatedDate,@ModifiedDate,@UserId,@OwnerId,@PostDescription)  
 END
      