CREATE TABLE [dbo].[Appointments] (
    [IdAppointment]   UNIQUEIDENTIFIER NOT NULL,
    [AppointmentDate] DATE             NOT NULL,
    [Status]          INT              NOT NULL,
    [DateTime]        ROWVERSION       NOT NULL,
    [IdCar]           UNIQUEIDENTIFIER NOT NULL,
    [IdWorkshop]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([IdAppointment] ASC),
    CONSTRAINT [FK_Appointments_Cars] FOREIGN KEY ([IdCar]) REFERENCES [dbo].[Cars] ([IdCar]),
    CONSTRAINT [FK_Appointments_Workshops] FOREIGN KEY ([IdWorkshop]) REFERENCES [dbo].[Workshops] ([IdWorkshop])
);

