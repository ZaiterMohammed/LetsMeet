CREATE PROCEDURE [dbo].[CreatePost]
 @PostId  uniqueidentifier, 
 @PostTitle nvarchar(50),  
 @CreatedDate date,
 @ModifiedDate date,
 @UserId uniqueidentifier,
 @OwnerId uniqueidentifier,
 @PostDescription nvarchar(50)


AS
 BEGIN 
 Insert into Post (PostId,PostTitle,PostDescription,UserId,OwnerId,CreatedDate,ModifiedDate)  --reflect table changes
 values(@PostId,@PostTitle,@CreatedDate,@ModifiedDate,@OwnerId,@UserId,@PostDescription)  
 END
      