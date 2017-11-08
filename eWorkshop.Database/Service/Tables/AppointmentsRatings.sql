CREATE TABLE [Service].[AppointmentsRatings] (
    [IdAppointmentRating] UNIQUEIDENTIFIER CONSTRAINT [DEF_ServiceAppointmentsRatingsIdAppointmentRating] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [IdAppointment]       UNIQUEIDENTIFIER NOT NULL,
    [RateValue]           INT              NOT NULL,
    [CreateDate]          DATETIME         CONSTRAINT [DEF_ServiceAppointmentsRatingsCreateDate] DEFAULT (getdate()) NOT NULL,
    [ChangeDate]          DATETIME         CONSTRAINT [DEF_ServiceAppointmentsRatingsChangeDate] DEFAULT (getdate()) NOT NULL,
    [Comments]            VARCHAR (MAX)    NULL,
    CONSTRAINT [PK_ServiceAppointmentsRatings] PRIMARY KEY CLUSTERED ([IdAppointmentRating] ASC),
    CONSTRAINT [FK_ServiceAppointmentsIdAppointmentServiceAppointmentsRatingsIdAppointment] FOREIGN KEY ([IdAppointment]) REFERENCES [Service].[Appointments] ([IdAppointment]),
    CONSTRAINT [UNQ_ServiceAppointmentsRatingsIdAppointment] UNIQUE NONCLUSTERED ([IdAppointment] ASC)
);



