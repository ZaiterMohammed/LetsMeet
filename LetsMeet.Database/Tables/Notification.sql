CREATE TABLE [dbo].[Notification]
(
	[NotificationId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [NotificationType] NVARCHAR(50) NULL, 
    [CreatedDateNotification] DATETIME NULL
)
