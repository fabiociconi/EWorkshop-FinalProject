CREATE TABLE [Service].[AppointmentsServices] (
    [IdAppointmentService] UNIQUEIDENTIFIER CONSTRAINT [DEF_ServiceAppointmentsServicesIdAppointmentService] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [IdAppointment]        UNIQUEIDENTIFIER NOT NULL,
    [IdService]            UNIQUEIDENTIFIER NOT NULL,
    [Price]                NUMERIC (18, 2)  CONSTRAINT [DEF_ServiceAppointmentsServicesPrice] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ServiceAppointmentsServices] PRIMARY KEY CLUSTERED ([IdAppointmentService] ASC),
    CONSTRAINT [CHECK_ServiceAppointmentsServicesPrice] CHECK ([Price]>=(0)),
    CONSTRAINT [FK_ServiceAppointmentsIdAppointmentServiceAppointmentsServicesIdAppointment] FOREIGN KEY ([IdAppointment]) REFERENCES [Service].[Appointments] ([IdAppointment]),
    CONSTRAINT [FK_ServiceServicesIdServiceServiceAppointmentsServicesIdService] FOREIGN KEY ([IdService]) REFERENCES [Service].[Services] ([IdService])
);

