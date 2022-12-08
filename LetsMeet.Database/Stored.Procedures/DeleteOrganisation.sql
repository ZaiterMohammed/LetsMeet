CREATE PROCEDURE [dbo].[DeleteOrganisation]
 @OrganisationId uniqueidentifier 

AS
 BEGIN 
  delete from Organisation where OrganisationId = @OrganisationId 
 END