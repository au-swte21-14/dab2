
--
-- Create Table    : 'Municipality'
-- Name            :
-- municipatityId  :
-- CVR             :
--
CREATE TABLE Municipality (
    Name           NVARCHAR(200) NOT NULL,
    municipatityId INT NOT NULL UNIQUE,
    CVR            INT NOT NULL UNIQUE,
    CONSTRAINT pk_Municipality PRIMARY KEY CLUSTERED (municipatityId))
GO

--
-- Create Table    : 'Room'
-- roomId          :
-- limit           :
-- name            :
-- address         :
-- accessKey       :
-- startTime       :
-- endTime         :
-- municipatityId  :  (references Municipality.municipatityId)
--
CREATE TABLE Room (
    roomId         INT NOT NULL UNIQUE,
    limit          INT NOT NULL,
    name           NVARCHAR(200) NOT NULL,
    address        NVARCHAR(200) NOT NULL,
    accessKey      INT UNIQUE,
    isBooked       BIT,
    startTime      DATETIME NOT NULL,
    endTime        DATETIME NOT NULL,
    municipatityId INT NULL,
CONSTRAINT pk_Room PRIMARY KEY CLUSTERED (roomId),
CONSTRAINT fk_Room FOREIGN KEY (municipatityId)
    REFERENCES Municipality (municipatityId)
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Chairman'
-- chairmanId      :
-- name            :
-- SocietyId       :
-- cpr             :
-- address         :
--
CREATE TABLE Chairman (
    chairmanId     INT NOT NULL UNIQUE,
    name           NVARCHAR(200) NOT NULL,
    cpr            INT NOT NULL UNIQUE,
    address        NVARCHAR(200) NOT NULL,
    accessKey      INT UNIQUE,
    FOREIGN KEY (accessKey) REFERENCES Room (accessKey),
CONSTRAINT pk_Chairman PRIMARY KEY CLUSTERED (chairmanId))
GO
--
-- Create Table    : 'Society'
-- SocietyID       :
-- Name            :
-- cvr             :
-- address         :
-- activityId      :
-- chairmanId      :  (references Chairman.chairmanId)
-- municipatityId  :
--
CREATE TABLE Society (
    SocietyID      INT NOT NULL UNIQUE,
    Name           NVARCHAR(200) NOT NULL,
    cvr            INT NOT NULL UNIQUE,
    address        NVARCHAR(200) NOT NULL,
    chairmanId     INT NULL,
CONSTRAINT pk_Society PRIMARY KEY CLUSTERED (SocietyID),
CONSTRAINT fk_Society FOREIGN KEY (chairmanId)
    REFERENCES Chairman (chairmanId)
    ON UPDATE CASCADE)
GO
--
-- Create Table    : 'Activity'
-- activityId      :
-- name            :
--

CREATE TABLE Activity (
    activityId     INT IDENTITY (1,1),
    name           NVARCHAR(200) NOT NULL,
    societyId      INT NOT NULL,
    FOREIGN KEY (societyId) REFERENCES Society (SocietyID),
CONSTRAINT pk_Activity PRIMARY KEY CLUSTERED (activityId))
GO


--
-- Create Table    : 'Properties'
-- id              :
-- roomId          :
-- name            :
--

CREATE TABLE Properties (
    id             INT IDENTITY (1,1),
    roomId         INT NOT NULL,
    FOREIGN KEY (roomId) REFERENCES Room (roomId),
    name           NVARCHAR(200) NOT NULL,
CONSTRAINT pk_Properties PRIMARY KEY CLUSTERED (id))
GO

--
-- Create Table    : 'Members'
-- MemberID        :
-- SocietyID       :
-- name            :
-- cpr             :
-- address         :
-- SocietyID1      :  (references Society.SocietyID)
--
CREATE TABLE Members (
    MemberID       INT NOT NULL UNIQUE,
    SocietyID      INT NOT NULL,
    name           NVARCHAR(200) NOT NULL,
    cpr            INT NOT NULL UNIQUE,
    address        NVARCHAR(200) NOT NULL,
CONSTRAINT pk_Members PRIMARY KEY CLUSTERED (MemberID),
CONSTRAINT fk_Members FOREIGN KEY (SocietyID)
    REFERENCES Society (SocietyID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Act'
-- activityId      :  (references Activity.activityId)
-- SocietyID       :  (references Society.SocietyID)
--
CREATE TABLE Act (
    activityId     INT NOT NULL,
    SocietyID      INT NOT NULL,
CONSTRAINT pk_Act PRIMARY KEY CLUSTERED (activityId,SocietyID),
CONSTRAINT fk_Act FOREIGN KEY (activityId)
    REFERENCES Activity (activityId)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_Act2 FOREIGN KEY (SocietyID)
    REFERENCES Society (SocietyID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Soc'
-- SocietyID       :  (references Society.SocietyID)
-- municipatityId  :  (references Municipality.municipatityId)
--
CREATE TABLE Soc (
    SocietyID      INT NOT NULL,
    municipatityId INT NOT NULL,
CONSTRAINT pk_Soc PRIMARY KEY CLUSTERED (SocietyID,municipatityId),
CONSTRAINT fk_Soc FOREIGN KEY (SocietyID)
    REFERENCES Society (SocietyID)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_Soc2 FOREIGN KEY (municipatityId)
    REFERENCES Municipality (municipatityId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Booking'
-- SocietyID       :  (references Society.SocietyID)
-- roomId          :  (references Room.roomId)
--
CREATE TABLE Booking (
    SocietyID      INT NOT NULL,
    roomId         INT NOT NULL,
CONSTRAINT pk_Booking PRIMARY KEY CLUSTERED (SocietyID,roomId),
CONSTRAINT fk_Booking FOREIGN KEY (SocietyID)
    REFERENCES Society (SocietyID)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_Booking2 FOREIGN KEY (roomId)
    REFERENCES Room (roomId)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Props'
-- roomId          :  (references Room.roomId)
-- id              :  (references Properties.id)
--
CREATE TABLE Props (
    roomId         INT NOT NULL,
    id             INT NOT NULL,
CONSTRAINT pk_Props PRIMARY KEY CLUSTERED (roomId,id),
CONSTRAINT fk_Props FOREIGN KEY (roomId)
    REFERENCES Room (roomId)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_Props2 FOREIGN KEY (id)
    REFERENCES Properties (id)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Permissions for: 'public'
--
GRANT ALL ON Chairman TO public
GO
GRANT ALL ON Activity TO public
GO
GRANT ALL ON Municipality TO public
GO
GRANT ALL ON Properties TO public
GO
GRANT ALL ON Society TO public
GO
GRANT ALL ON Members TO public
GO
GRANT ALL ON Act TO public
GO
GRANT ALL ON Soc TO public
GO
GRANT ALL ON Room TO public
GO
GRANT ALL ON Booking TO public
GO
GRANT ALL ON Props TO public
GO

