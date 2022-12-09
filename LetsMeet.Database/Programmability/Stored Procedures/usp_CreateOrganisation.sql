CREATE PROCEDURE [dbo].[usp_CreateOrganisation]
 @OrganisationName nvarchar(50),  
 @OrganisationType nvarchar(50),  
 @OrganisationCategory uniqueidentifier,
 @CreatedDate date,
 @ModifiedDate date,
 @IsFeatured int
AS
 BEGIN 
 Insert into Organisation(OrganisationId,OrganisationName,OrganisationType,OrganisationCategory,CreatedDate,ModifiedDate,IsFeatured)  
 values(newId(),@OrganisationName,@OrganisationType,@OrganisationCategory,@CreatedDate,@ModifiedDate,@IsFeatured)  
 END
      