CREATE TABLE [Register].[WorkshopServices] (
    [IdWorkshopService] UNIQUEIDENTIFIER CONSTRAINT [DEF_RegisterWorkshopServicesIdWorkshopService] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [IdWorkshop]        UNIQUEIDENTIFIER NOT NULL,
    [IdService]         UNIQUEIDENTIFIER NOT NULL,
    [Price]             NUMERIC (18, 2)  CONSTRAINT [DEF_RegisterWorkshopServicesPrice] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_RegisterWorkshopServices] PRIMARY KEY CLUSTERED ([IdWorkshopService] ASC),
    CONSTRAINT [CHECK_RegisterWorkshopServicesPrice] CHECK ([Price]>=(0)),
    CONSTRAINT [FK_RegisterWorkshopsIdWorkshopRegisterWorkshopServicesIdWorkshop] FOREIGN KEY ([IdWorkshop]) REFERENCES [Register].[Workshops] ([IdWorkshop]),
    CONSTRAINT [FK_ServiceServicesIdServiceRegisterWorkshopServicesIdService] FOREIGN KEY ([IdService]) REFERENCES [Service].[Services] ([IdService])
);

