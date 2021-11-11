using System.Collections.Generic;
using System.Linq;
using EFCoreDab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace EFCoreDab2
{
    public class DbClient
    {
        private au653289Context _context;

        public DbClient(string server, string database, string user, string password)
        {
            _context = new au653289Context(server, database, user, password);
        }

        public IIncludableQueryable<Municipality, ICollection<Room>> GetMunicipalities()
        {
            /*var a = from municipality in _context.Municipalities
                join room in _context.Rooms on municipality.Id equals room.Id*/
            return _context.Municipalities
                .Include(municipality => municipality.Rooms);

        }

        public IIncludableQueryable<Society, Municipality> GetSocieties()
        {
            return _context.Societies
                .Include(society => society.Members
                    .Where(member => member.IsChairman == true))
                .Include(society => society.Municipality);
        }
        
        public IIncludableQueryable<Room, Municipality> GetRooms()
        {
            return _context.Rooms
                .Include(room => room.Municipality);
        }

        public IIncludableQueryable<Room, Society> GetBookedRooms()
        {
            return _context.Rooms

                .Include(room => room.RoomReservations)
                .ThenInclude(roomRes => roomRes.Member)
                .ThenInclude(member => member.Society);
        }
    }
}