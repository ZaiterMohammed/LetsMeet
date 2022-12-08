CREATE PROCEDURE [dbo].[usp_CreatePost]
 @PostTitle nvarchar(50),  
 @CreatedDate date,
 @ModifiedDate date,
 @PostDescription nvarchar(50),
 @OwnerId uniqueidentifier,
 @CreatedBy uniqueidentifier,
 @UpdatedBy uniqueidentifier

AS
 BEGIN 
 Insert into Post (PostId,PostTitle,CreatedDate,ModifiedDate,PostDescription,OwnerId,CreatedBy,UpdatedBy)
 values(newId(),@PostTitle,@CreatedDate,@ModifiedDate,@PostDescription,@OwnerId,@CreatedBy,@UpdatedBy)  
END
      