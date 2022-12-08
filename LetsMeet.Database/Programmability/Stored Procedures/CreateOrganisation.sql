CREATE PROCEDURE [dbo].[CreateOrganisation]
 @OrganisationName nvarchar(50),  
 @OrganisationType nvarchar(50),  
 @OrganisationCategory uniqueidentifier,
 @CreatedDate date,
 @ModifiedDate date

AS
 BEGIN 
 Insert into Organisation(OrganisationId,OrganisationName,OrganisationType,OrganisationCategory,CreatedDate,ModifiedDate)  
 values(newId(),@OrganisationName,@OrganisationType,@OrganisationCategory,@CreatedDate,@ModifiedDate)  
 END
      