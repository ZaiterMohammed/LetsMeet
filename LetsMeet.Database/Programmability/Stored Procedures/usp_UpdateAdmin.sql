CREATE PROCEDURE [dbo].[usp_UpdateAdmin]
	@AdminId uniqueidentifier,
	@UserId uniqueidentifier,
	@MunicipalityId uniqueidentifier

AS
BEGIN
update Admins
 set UserIdF = @UserId , MunicipalityIdF = @MunicipalityId
 where AdminId = @AdminId
END
