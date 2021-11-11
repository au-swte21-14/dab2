USE au653289
GO

-- Get all municipality information: rooms (addresses)
SELECT room.id, room.name, room.address, municipality.name as municipality
FROM dbo.room
         JOIN municipality ON room.municipalityId = municipality.id
GO

-- Get all societies (cvr, addresses and chairmen) by their activity

SELECT society.id, society.cvr, society.name, society.address, society.activity, member.name as chairman, municipality.name as municipality
FROM dbo.society
         JOIN member ON society.id = member.societyId
         JOIN municipality on municipality.id = society.municipalityId
WHERE member.isChairman = 1
ORDER BY society.activity
GO

-- Get a list of booked rooms (name, location), with the booking society (name, chairmen) and the times it is book.

SELECT room.id,
       room.name,
       room.address,
       room_reservation.startTime,
       room_reservation.endTime,
       society.name,
       chairman.name
FROM dbo.room
         JOIN room_reservation on room.id = room_reservation.roomId
         JOIN member on member.id = room_reservation.memberId
         JOIN society on member.societyId = society.id
         JOIN member chairman on chairman.societyId = society.id
WHERE chairman.isChairman = 1
GO
