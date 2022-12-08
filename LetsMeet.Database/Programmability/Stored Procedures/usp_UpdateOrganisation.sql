CREATE PROCEDURE [dbo].[usp_UpdateOrganisation]
 @OrganisationId  uniqueidentifier, 
 @OrganisationName nvarchar(50),  
 @OrganisationType nvarchar(50),  
 @OrganisationCategory uniqueidentifier,
 @CreatedDate date,
 @ModifiedDate date
AS
BEGIN
update Organisation
 set OrganisationName = @OrganisationName , OrganisationType = @OrganisationType ,@OrganisationCategory = OrganisationCategory ,@CreatedDate = CreatedDate , @ModifiedDate = ModifiedDate
 where OrganisationId = @OrganisationId
End
