--Get all municipality information: rooms (addresses)
SELECT dbo.room.roomId, dbo.room.name, dbo.room.address
FROM Room

--Get all societies (cvr, addresses and chairmen) by their activity
SELECT Chairman.name, dbo.Society.cvr, dbo.Society.address
FROM Society
         JOIN Chairman on Chairman.chairmanId = Society.chairmanId
         JOIN Activity on Society.SocietyID = Activity.societyId
ORDER BY Activity.activityId

--Get a list of booked rooms (name, location), with the booking society (name, chairmen) and the times it is booked.
SELECT dbo.Chairman.name,
       dbo.Society.Name,
       dbo.Room.name,
       dbo.room.address,
       dbo.Room.startTime,
       dbo.Room.endTime

FROM Room
         JOIN Chairman on Room.accessKey = Chairman.accessKey
         JOIN Society on Chairman.chairmanId = Society.chairmanId
WHERE (Room.isBooked = 1)