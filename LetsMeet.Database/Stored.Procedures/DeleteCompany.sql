CREATE PROCEDURE [dbo].[DeleteCompany]
 @CompanyId uniqueidentifier 

AS
 BEGIN 
  delete from Company where CompanyId = @CompanyId 
 END