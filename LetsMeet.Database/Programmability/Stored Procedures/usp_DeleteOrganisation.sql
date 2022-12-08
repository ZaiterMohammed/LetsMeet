CREATE PROCEDURE [dbo].[usp_DeleteOrganisation]
 @OrganisationId uniqueidentifier 

AS
 BEGIN 
  delete from Organisation where OrganisationId = @OrganisationId 
 END