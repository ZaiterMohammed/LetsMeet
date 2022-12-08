CREATE PROCEDURE [dbo].[usp_UpdateCompany]
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
 set CompanyName = @CompanyName , CompanyTypes = @CompanyTypes, CreatedDate = @CreatedDate, ModifiedDate = @ModifiedDate
 where CompanyId = @CompanyId

 END
