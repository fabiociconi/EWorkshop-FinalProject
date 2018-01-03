CREATE TABLE [Service].[Appointments] (
    [IdAppointment]   UNIQUEIDENTIFIER CONSTRAINT [DEF_ServiceAppointmentsIdAppointment] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [IdWorkshop]      UNIQUEIDENTIFIER NOT NULL,
    [IdCar]           UNIQUEIDENTIFIER NOT NULL,
    [AppointmentDate] DATE             NOT NULL,
    [Status]          INT              NOT NULL,
    [CreateDate]      DATETIME         CONSTRAINT [DEF_ServiceAppointmentsCreateDate] DEFAULT (getdate()) NOT NULL,
    [ChangeDate]      DATETIME         CONSTRAINT [DEF_ServiceAppointmentsChangeDate] DEFAULT (getdate()) NOT NULL,
    [Date]            DATETIME         CONSTRAINT [DEF_ServiceAppointmentsDate] DEFAULT (getdate()) NOT NULL,
    [IdAddress]       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_ServiceAppointments] PRIMARY KEY CLUSTERED ([IdAppointment] ASC),
    FOREIGN KEY ([IdAddress]) REFERENCES [Register].[Addresses] ([IdAddress]),
    CONSTRAINT [FK_RegisterCarsIdCarServiceAppointmentsIdCar] FOREIGN KEY ([IdCar]) REFERENCES [Register].[Cars] ([IdCar]),
    CONSTRAINT [FK_RegisterWorkshopsIdWorkshopServiceAppointmentsIdWorkshop] FOREIGN KEY ([IdWorkshop]) REFERENCES [Register].[Workshops] ([IdWorkshop])
);



