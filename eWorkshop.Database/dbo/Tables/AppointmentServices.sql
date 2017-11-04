CREATE TABLE [dbo].[AppointmentServices] (
    [IdAppointmentService] UNIQUEIDENTIFIER NOT NULL,
    [Price]                FLOAT (53)       NOT NULL,
    [IdAppointment]        UNIQUEIDENTIFIER NOT NULL,
    [IdService]            UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_AppointmentServices] PRIMARY KEY CLUSTERED ([IdAppointmentService] ASC),
    CONSTRAINT [FK_AppointmentServices_Appointments] FOREIGN KEY ([IdAppointment]) REFERENCES [dbo].[Appointments] ([IdAppointment]),
    CONSTRAINT [FK_AppointmentServices_Services] FOREIGN KEY ([IdService]) REFERENCES [dbo].[Services] ([IdService])
);

