CREATE TABLE [dbo].[WorkshopServices] (
    [IdWorkshopService] UNIQUEIDENTIFIER NOT NULL,
    [Price]             FLOAT (53)       NOT NULL,
    [IdWorkshop]        UNIQUEIDENTIFIER NOT NULL,
    [IdService]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_WorkshopServices] PRIMARY KEY CLUSTERED ([IdWorkshopService] ASC),
    CONSTRAINT [FK_WorkshopServices_Services] FOREIGN KEY ([IdService]) REFERENCES [dbo].[Services] ([IdService]),
    CONSTRAINT [FK_WorkshopServices_Workshops] FOREIGN KEY ([IdWorkshop]) REFERENCES [dbo].[Workshops] ([IdWorkshop])
);

