create database db_notifications;

IF OBJECT_ID(N'dbo.Notification') IS NOT NULL  
   DROP TABLE [dbo].Notification;  
GO

use db_notifications
CREATE TABLE Notification (
    Id INT PRIMARY KEY IDENTITY,
    Message NVARCHAR(255) NOT NULL,
    CreationDate DATETIME NOT NULL
);

GO