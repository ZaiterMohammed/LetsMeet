CREATE PROCEDURE [dbo].[usp_CreateCompany]
 @CompanyName nvarchar(50),  
 @CompanyTypes nvarchar(50),  
 @CityId uniqueidentifier,
 @CountryId uniqueidentifier,
 @CreatedDate date,
 @ModifiedDate date

AS
 BEGIN 
 Insert into Company (CompanyId,CompanyName,CompanyTypes,CityIdF,CountryIdF,CreatedDate,ModifiedDate)  
 values(newId(),@CompanyName,@CompanyTypes,@CityId,@CountryId,@CreatedDate,@ModifiedDate)  
 END
      