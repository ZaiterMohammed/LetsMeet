CREATE PROCEDURE [dbo].[usp_UpdateCompany]
 @CompanyId  uniqueidentifier, 
 @CompanyName nvarchar(50),  
 @CompanyTypes nvarchar(50),  
 @CityId uniqueidentifier,
 @CountryId uniqueidentifier,
 @ModifiedDate date
 
AS
 BEGIN 

 update Company
 set CompanyName = @CompanyName , CompanyTypes = @CompanyTypes, ModifiedDate = @ModifiedDate
 where CompanyId = @CompanyId

 END
