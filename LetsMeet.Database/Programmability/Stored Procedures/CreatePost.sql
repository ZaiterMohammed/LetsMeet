CREATE PROCEDURE [dbo].[CreatePost]
 @PostTitle nvarchar(50),  
 @CreatedDate date,
 @ModifiedDate date,
 @UserId uniqueidentifier,
 @OwnerId uniqueidentifier,
 @PostDescription nvarchar(50)


AS
 BEGIN 
 Insert into Post (PostId,PostTitle,PostDescription,UserId,OwnerId,CreatedDate,ModifiedDate)
 values(newId(),@PostTitle,@CreatedDate,@ModifiedDate,@OwnerId,@UserId,@PostDescription)  
 END
      