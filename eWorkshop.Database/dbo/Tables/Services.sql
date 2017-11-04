CREATE TABLE [dbo].[Services] (
    [IdService]   UNIQUEIDENTIFIER NOT NULL,
    [Name]        VARCHAR (50)     NOT NULL,
    [Description] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED ([IdService] ASC)
);

