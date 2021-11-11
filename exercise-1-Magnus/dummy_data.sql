INSERT INTO dbo.Municipality(Name, municipatityId, CVR)
VALUES('Aarhus', 1, 1234),
      ('KomuneBy', 2, 2345)

INSERT INTO dbo.Room(roomId, limit, name, address, accessKey, isBooked, startTime, endTime, municipatityId)
VALUES(1, 10, 'Rum 1', 'Universitetsvej 1', 112, 1, 2021-02-19, 2021-02-20, 1),
      (2, 20, 'Rum 2', 'Rum2vej 1', 911, 1, 2021-01-01, 2021-01-02, 2),
      (3, 3, 'Magnus Vaerelse', 'Tage-Hansens Gade', 114, 0, 2021-04-04, 2021-04-05, 1)

INSERT INTO dbo.Chairman(chairmanId, name, cpr, address, accessKey)
VALUES(1, 'Magnus', 12345678, 'Universitetsvej 123', 112),
      (2, 'Mikkel', 234567890, 'Boedvej 234', 911)

INSERT INTO dbo.Society(SocietyID, Name, cvr, address, chairmanId)
VALUES(1, 'Hyggeholdet', 73615378, 'Aarhusvej 1', 1),
      (2, 'Gutterne', 27461534, 'Sæbyvej 2', 1),
      (3, 'Studerende', 59483725, 'Aarhus Universitet 1', 2)

INSERT INTO dbo.Activity(name, societyId)
VALUES('Fodbold',1),
       ('Bordtennis', 2),
       ('Tennis', 3)

INSERT INTO dbo.Properties(roomId, name)
VALUES(1, '15 stole'),
      (1, '5 baenke'),
      (1, 'Wifi'),
      (2, 'Fan'),
      (2, 'Hoejtalere'),
      (3, 'TV'),
      (3, 'Sofa')

INSERT INTO dbo.Members(MemberID, SocietyID, name, cpr, address)
VALUES(1, 1, 'Thomas', 17284637, 'Univej 1'),
       (4, 1, 'Magnus 2', 28192725, 'Universitetsvej 123'),
       (2, 2, 'Andreas', 18263847, 'DropUdvej 2'),
       (5, 2, 'Oliver', 28199725, 'DropUdvej 2'),
       (3, 3, 'Markus', 37491635, 'VedSidenAfUnivej 2'),
        (6, 3, 'Jonas', 28172635, 'VedSidenAfUnivej 2')
