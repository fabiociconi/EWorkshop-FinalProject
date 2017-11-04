CREATE TABLE [dbo].[Users] (
    [IdUser]   UNIQUEIDENTIFIER NOT NULL,
    [Role]     INT              NOT NULL,
    [Password] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED ([IdUser] ASC)
);



