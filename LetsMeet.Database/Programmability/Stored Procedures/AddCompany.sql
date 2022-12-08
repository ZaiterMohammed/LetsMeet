CREATE PROCEDURE [dbo].[AddCompany]
 @CompanyId  uniqueidentifier, 
 @CompanyName nvarchar(50),  
 @CompanyTypes nvarchar(50),  
 @CityId uniqueidentifier,
 @CountryId uniqueidentifier,
 @CreatedDate date,
 @ModifiedDate date


AS
 BEGIN 
 Insert into Company (CompanyId,CompanyName,CompanyTypes,CityId,CountryId,CreatedDate,ModifiedDate)  
 values(@CompanyId,@CompanyName,@CompanyTypes,@CityId,@CountryId,@CreatedDate,@ModifiedDate)  
 END
      