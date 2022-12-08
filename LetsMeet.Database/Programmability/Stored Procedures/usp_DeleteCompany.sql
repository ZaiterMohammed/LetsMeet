CREATE PROCEDURE [dbo].[usp_DeleteCompany]
 @CompanyId uniqueidentifier 

AS
 BEGIN 
  delete from Company where CompanyId = @CompanyId 
 END