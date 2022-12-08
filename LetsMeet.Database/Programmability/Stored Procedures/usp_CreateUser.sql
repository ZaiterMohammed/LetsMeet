CREATE PROCEDURE [dbo].[usp_CreateUser]
 @FirstName   nvarchar(50),  
 @LastName nvarchar(50),  
 @Age int,  
 @IsFeatured int,
 @CityId uniqueidentifier,
 @CountryId uniqueidentifier,
 @CreatedDate date,
 @ModifiedDate date

AS
 BEGIN 
 Insert into Users (UserId,FirstName,LastName,Age,IsFeatured,CityId,CountryId,CreatedDate,ModifiedDate)  
 values(newId(),@FirstName,@LastName,@Age,@IsFeatured,@CityId,@CountryId,@CreatedDate,@ModifiedDate)  
 END
      