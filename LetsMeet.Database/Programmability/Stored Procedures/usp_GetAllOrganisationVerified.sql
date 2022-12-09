CREATE PROCEDURE [dbo].[usp_GetAllOrganisationVerified]
AS
BEGIN
	SELECT * from Organisation 
	where IsFeatured = 1
END
