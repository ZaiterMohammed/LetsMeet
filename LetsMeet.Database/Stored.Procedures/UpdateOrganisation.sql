CREATE PROCEDURE [dbo].[UpdateOrganisation]
 @OrganisationId  uniqueidentifier, 
 @OrganisationName nvarchar(50),  
 @OrganisationType nvarchar(50),  
 @OrganisationCategory uniqueidentifier,
 @CreatedDate date,
 @ModifiedDate date
AS
BEGIN
update Organisation
 set OrganisationId = @OrganisationId,OrganisationName = @OrganisationName , OrganisationType = @OrganisationType
 where OrganisationId = @OrganisationId

End
