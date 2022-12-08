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
 

 update User
 set UserId = @UserId,FirstName = @FirstName , IsFeatured = @IsFeatured
 where UserId = @UserId

 END
