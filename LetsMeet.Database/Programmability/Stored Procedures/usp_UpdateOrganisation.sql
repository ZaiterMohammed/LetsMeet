CREATE PROCEDURE [dbo].[usp_UpdateOrganisation]
 @OrganisationId  uniqueidentifier, 
 @OrganisationName nvarchar(50),  
 @OrganisationType nvarchar(50),  
 @OrganisationCategory uniqueidentifier,
 @ModifiedDate date
AS
BEGIN
update Organisation
 set OrganisationName = @OrganisationName , OrganisationType = @OrganisationType ,@OrganisationCategory = OrganisationCategory  , @ModifiedDate = ModifiedDate
 where OrganisationId = @OrganisationId
End
