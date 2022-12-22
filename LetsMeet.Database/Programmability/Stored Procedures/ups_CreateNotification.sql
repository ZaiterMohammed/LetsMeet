CREATE PROCEDURE [dbo].[usp_CreateNotification]
	@NotificationType nvarchar(50),
	@CreatedDateNotification datetime
AS
BEGIN
	INSERT INTO Notification(NotificationId,NotificationType,CreatedDateNotification)
	VALUES( newId(), @NotificationType,@CreatedDateNotification)
END