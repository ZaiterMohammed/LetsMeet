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
 set UserId = @UserId,FirstName = @FirstName , IsFeatured = @IsFeatured -- you should not update userid
 where UserId = @UserId

 END
