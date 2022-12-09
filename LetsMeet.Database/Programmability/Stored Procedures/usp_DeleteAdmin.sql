CREATE PROCEDURE [dbo].[usp_DeleteAdmin]
 @AdminId uniqueidentifier 

AS
BEGIN 
delete from Admins where AdminId = @AdminId 
END