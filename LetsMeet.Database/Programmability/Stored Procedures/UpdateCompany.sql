CREATE PROCEDURE [dbo].[UpdateCompany]
 @CompanyId  uniqueidentifier, 
 @CompanyName nvarchar(50),  
 @CompanyTypes nvarchar(50),  
 @CityId uniqueidentifier,
 @CountryId uniqueidentifier,
 @CreatedDate date,
 @ModifiedDate date
 
AS
 BEGIN 
 

 update Company
 set CompanyId = @CompanyId,CompanyName = @CompanyName , CompanyTypes = @CompanyTypes
 where COmpanyId = @CompanyId

 END
