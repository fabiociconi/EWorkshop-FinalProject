CREATE TABLE [Service].[Services] (
    [IdService]   UNIQUEIDENTIFIER CONSTRAINT [DEF_ServiceServicesIdService] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [Name]        VARCHAR (50)     NOT NULL,
    [Description] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_ServiceServices] PRIMARY KEY CLUSTERED ([IdService] ASC)
);

