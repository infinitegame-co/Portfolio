CREATE TABLE [user] (
  [Id] int IDENTITY(0,1) PRIMARY KEY NOT NULL,
  [Nickname] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) UNIQUE NOT NULL,
  [Password] nvarchar(255) NOT NULL
)
GO

--CREATE TABLE [page] (
--  [Id] int PRIMARY KEY,
--  [category] Page_Category,
--  [content] nvarchar(255),
--  [CreationDate] datetime,
--  [EditDate] datetime,
--  [Comment] nvarchar(255)
--)
--GO

--CREATE TABLE [Comment] (
--  [Comment_Id] int PRIMARY KEY NOT NULL,
--  [page_id] int,
--  [User_Nickname] nvarchar(255),
--  [comment] nvarchar(255)
--)
--GO

--CREATE TABLE [GuestBook] (
--  [Id] int PRIMARY KEY,
--  [User_Nickname] nvarchar(255) NOT NULL,
--  [Message] nvarchar(255) NOT NULL,
--  [PostTime] datetime NOT NULL
--)
--GO

--CREATE TABLE [Category] (
--  [id] int UNIQUE PRIMARY KEY NOT NULL,
--  [Category_Name] nvarchar(255)
--)
--GO

--CREATE TABLE [Page_Category] (
--  [page_id] int,
--  [category_id] int
--)
--GO

--ALTER TABLE [Comment] ADD FOREIGN KEY ([User_Nickname]) REFERENCES [user] ([Nickname])
--GO

--ALTER TABLE [Comment] ADD FOREIGN KEY ([page_id]) REFERENCES [page] ([Id])
--GO

--ALTER TABLE [Page_Category] ADD FOREIGN KEY ([page_id]) REFERENCES [page] ([Id])
--GO

--ALTER TABLE [Page_Category] ADD FOREIGN KEY ([category_id]) REFERENCES [Category] ([id])
--GO

--ALTER TABLE [user] ADD FOREIGN KEY ([Nickname]) REFERENCES [GuestBook] ([User_Nickname])
--GO
