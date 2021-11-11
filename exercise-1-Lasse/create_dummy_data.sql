USE au653289
GO

-- Create municipality
INSERT INTO dbo.municipality (name, cvr)
VALUES ('Magnus kommune', 42200011),
       ('Lasses kommune', 42200019)
GO

-- Create societies
INSERT INTO dbo.society (name, municipalityId, cvr, address, activity)
VALUES ('Pet society', 1, 42200010, 'Facebook app 1', 'Internat'),
       ('Hurlumhejhuset', 2, 42200018, 'Aldersrovej 26', N'Bofællesskab')
GO

-- Create members
INSERT INTO dbo.member(societyId, isChairman, name, cpr, address)
VALUES (1, 1, 'Mark Marsvin', 0105882521, 'Dyrevej 25'),
       (2, 1, 'Lasse Hyldahl', 0108002352, 'Aldersrovej 26'),
       (1, 0, 'Gurli gris', 2102772423, N'Park Allé 24')
GO

-- Create rooms and properties
INSERT INTO dbo.room(limit, municipalityId, name, address, access)
VALUES (20, 1, N'Mødelokale', N'Rumallé 1', N'Brækjern'),
       (3, 1, N'Toilet', N'Rumallé 1', N'Åbent'),
       (-1, 2, N'Sportshal', N'Motionsvej 24', N'2426')
GO
INSERT INTO dbo.room_property(roomId, name)
VALUES (1, 'WiFi'),
       (1, 'Projektor'),
       (1, '10 Stole'),
       (2, 'Toilet'),
       (2, N'Håndvask'),
       (3, N'2 Fodboldmål')
GO

-- Create reservations
INSERT INTO dbo.room_reservation(roomId, memberId, startTime, endTime)
VALUES (1, 2, DATETIMEFROMPARTS(2021, 09, 22, 16, 0, 0, 0), DATETIMEFROMPARTS(2021, 09, 22, 20, 0, 0, 0)),
       (2, 2, DATETIMEFROMPARTS(2021, 09, 21, 10, 0, 0, 0), DATETIMEFROMPARTS(2021, 09, 21, 12, 0, 0, 0))
GO
