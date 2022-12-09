CREATE PROCEDURE [dbo].[usp_UpdateAdmin]
	@AdminId uniqueidentifier,
	@UserId uniqueidentifier,
	@MunicipalityId uniqueidentifier

AS
BEGIN
update Admins
 set UserId = @UserId , MunicipalityId = @MunicipalityId
 where AdminId = @AdminId
END
