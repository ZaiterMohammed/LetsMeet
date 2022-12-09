CREATE PROCEDURE [dbo].[usp_GetAllOrganisationNotVerified]
AS
BEGIN
	SELECT * from Organisation 
	where IsFeatured = 0
END
