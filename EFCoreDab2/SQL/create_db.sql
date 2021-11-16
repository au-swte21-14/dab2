DROP TABLE IF EXISTS Act
DROP TABLE IF EXISTS Activity
DROP TABLE IF EXISTS Booking
DROP TABLE IF EXISTS Members
DROP TABLE IF EXISTS Props
DROP TABLE IF EXISTS Soc
DROP TABLE IF EXISTS Society
DROP TABLE IF EXISTS Municipality
DROP TABLE IF EXISTS Properties
DROP TABLE IF EXISTS Room
DROP TABLE IF EXISTS Chairman

    IF EXISTS(SELECT name
          FROM sys.databases
          WHERE name = N'au653289')
    BEGIN
        DROP DATABASE au653289;
    END;
GO



CREATE DATABASE au653289;
GO;
USE au653289
GO

CREATE TABLE municipality
(
    id   INT IDENTITY (1,1) PRIMARY KEY,
    name VARCHAR(200) NOT NULL,
    cvr  INT          NOT NULL,
);
GO

CREATE TABLE society
(
    id             INT IDENTITY (1,1) PRIMARY KEY,
    municipalityId INT          NOT NULL,
    FOREIGN KEY (municipalityId) REFERENCES municipality (id),
    name           VARCHAR(200) NOT NULL,
    cvr            INT          NOT NULL,
    address        VARCHAR(200) NOT NULL,
    activity       VARCHAR(200) NOT NULL
);
GO

CREATE TABLE member
(
    id         INT IDENTITY (1,1) PRIMARY KEY,
    societyId  INT          NOT NULL,
    FOREIGN KEY (societyId) REFERENCES society (id),
    isChairman BIT DEFAULT 0,
    name       VARCHAR(200) NOT NULL,
    cpr        INT          NOT NULL,
    address    VARCHAR(200) NOT NULL
);
GO

CREATE TABLE room
(
    id      INT IDENTITY (1,1) PRIMARY KEY,
    municipalityId INT          NOT NULL,
    FOREIGN KEY (municipalityId) REFERENCES municipality (id),
    limit   INT DEFAULT -1,
    name    VARCHAR(200) NOT NULL,
    address VARCHAR(200) NOT NULL,
    access  VARCHAR(200) NOT NULL
);
GO

CREATE TABLE room_property
(
    id     INT IDENTITY (1,1) PRIMARY KEY,
    roomId INT          NOT NULL,
    FOREIGN KEY (roomId) REFERENCES room (id),
    name   VARCHAR(200) NOT NULL
);
GO

CREATE TABLE room_reservation
(
    id        INT IDENTITY (1,1) PRIMARY KEY,
    roomId    INT      NOT NULL,
    FOREIGN KEY (roomId) REFERENCES room (id),
    memberId  INT      NOT NULL,
    FOREIGN KEY (memberId) REFERENCES member (id),
    startTime DATETIME NOT NULL,
    endTime   DATETIME NOT NULL
);
GO

CREATE TABLE Access
(
    KeyId     INT IDENTITY (1,1) PRIMARY KEY,
    MemberID  INT,
    FOREIGN KEY (MemberID) REFERENCES member (id)
)
