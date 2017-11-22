IF NOT EXISTS (SELECT TOP 1 1 FROM Service.Services WHERE IdService = '00000000-0000-0000-0000-000000000001')
	INSERT INTO Service.Services (IdService, Name, Description)
	VALUES ('00000000-0000-0000-0000-000000000001', 'Oil change', 'Preventive maintenance should be performed seasonally as it may increase the longevity of your vehicle')

IF NOT EXISTS (SELECT TOP 1 1 FROM Service.Services WHERE IdService = '00000000-0000-0000-0000-000000000002')
	INSERT INTO Service.Services (IdService, Name, Description)
	VALUES ('00000000-0000-0000-0000-000000000002', 'Battery test', 'Check how good is your battery')

IF NOT EXISTS (SELECT TOP 1 1 FROM Service.Services WHERE IdService = '00000000-0000-0000-0000-000000000003')
	INSERT INTO Service.Services (IdService, Name, Description)
	VALUES ('00000000-0000-0000-0000-000000000003', 'Tire rotation and Inflation', 'Increase your tires life time doing the rotation')

IF NOT EXISTS (SELECT TOP 1 1 FROM Service.Services WHERE IdService = '00000000-0000-0000-0000-000000000004')
	INSERT INTO Service.Services (IdService, Name, Description)
	VALUES ('00000000-0000-0000-0000-000000000004', 'Windshield washer', 'Have a clean vision is important')

IF NOT EXISTS (SELECT TOP 1 1 FROM Service.Services WHERE IdService = '00000000-0000-0000-0000-000000000005')
	INSERT INTO Service.Services (IdService, Name, Description)
	VALUES ('00000000-0000-0000-0000-000000000005', 'Engine diagnostics', 'Engine diagnostics can identify emissions or sensor problems, and in some case, prevent catalytic converter damage.')

IF NOT EXISTS (SELECT TOP 1 1 FROM Service.Services WHERE IdService = '00000000-0000-0000-0000-000000000006')
	INSERT INTO Service.Services (IdService, Name, Description)
	VALUES ('00000000-0000-0000-0000-000000000006', 'Fuel injector', 'Proper maintenance of fuel injectors can significantly improve your vehicle’s performance, help fuel system components attain their intended life span and reduce harmful emissions.')

IF NOT EXISTS (SELECT TOP 1 1 FROM Service.Services WHERE IdService = '00000000-0000-0000-0000-000000000007')
	INSERT INTO Service.Services (IdService, Name, Description)
	VALUES ('00000000-0000-0000-0000-000000000007', 'Brake inspection', 'To identify parts that are worn or no longer meet design specifications before they damage other parts of the brake system. This helps minimize repair costs over the long term.')

IF NOT EXISTS (SELECT TOP 1 1 FROM Service.Services WHERE IdService = '00000000-0000-0000-0000-000000000008')
	INSERT INTO Service.Services (IdService, Name, Description)
	VALUES ('00000000-0000-0000-0000-000000000008', 'Steering & suspension inspection', 'To make sure that your wheels stay in contact with the road and the vehicle doesn’t veer off course.')