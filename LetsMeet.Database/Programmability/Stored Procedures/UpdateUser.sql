CREATE PROCEDURE [dbo].[UpdateUser]
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
 

 update Users
 set FirstName = @FirstName, LastName = @LastName , Age = @Age  , IsFeatured = @IsFeatured  , CreatedDate = @CreatedDate , ModifiedDate = @ModifiedDate
 where UserId = @UserId

 END
