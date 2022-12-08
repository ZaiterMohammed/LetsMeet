CREATE PROCEDURE [dbo].[AddUser]
 @UserId  uniqueidentifier,
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
 Insert into User (UserId,FirstName,LastName,Age,IsFeatured,CityId,CountryId,CreatedDate,ModifiedDate)  
 values(@UserId,@FirstName,@LastName,@Age,@IsFeatured,@CityId,@CountryId,@CreatedDate,@ModifiedDate)  
 END
      