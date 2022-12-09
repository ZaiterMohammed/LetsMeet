CREATE PROCEDURE [dbo].[usp_DeleteMunicipality]
 @MunicipalityId uniqueidentifier 

AS
 BEGIN 
  delete from Municipality where MunicipalityId = @MunicipalityId
 END