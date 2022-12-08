CREATE PROCEDURE [dbo].[AddPost]
 @PostId  uniqueidentifier, 
 @PostTitle nvarchar(50),  
 @CompanyId uniqueidentifier,
 @CreatedDate date,
 @ModifiedDate date,
 @OrganisationId uniqueidentifier,
 @PostDescription nvarchar(50)


AS
 BEGIN 
 Insert into Post(PostId,PostTitle,CompanyId,PostDescription,OrganizationId,CreatedDate,ModifiedDate)  
 values(@PostId,@PostTitle,@CompanyId,@CreatedDate,@ModifiedDate,@OrganisationId,@PostDescription)  
 END
      