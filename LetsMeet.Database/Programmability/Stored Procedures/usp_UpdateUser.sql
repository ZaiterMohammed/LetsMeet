CREATE PROCEDURE [dbo].[usp_UpdateUser]
 @UserId  uniqueidentifier,
 @FirstName   nvarchar(50),  
 @LastName nvarchar(50),  
 @Age int,  
 @IsFeatured int,
 @CityId uniqueidentifier,
 @CountryId uniqueidentifier,
 @ModifiedDate date,
 @OwnerId uniqueidentifier,
 @MunicipalityId uniqueidentifier
AS
 BEGIN 

 update Users
 set FirstName = @FirstName, LastName = @LastName , Age = @Age  , IsFeatured = @IsFeatured  , ModifiedDate = @ModifiedDate , OwnerId = @OwnerId , MunicipalityId = @MunicipalityId
 where UserId = @UserId

 END
