using Leave_mangement.Contracts;
using Leave_mangement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_mangement.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryrepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool create(LeaveHistory entity)
        {
            _db.LeaveHistories.Add(entity);
            return save();
        }

        public bool delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            return save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var LeaveHistories = _db.LeaveHistories.ToList();
            return LeaveHistories;
        }

        public LeaveHistory FindById(int ID)
        {
            var LeaveHistory = _db.LeaveHistories.Find(ID);
            return LeaveHistory;
        }

        public bool save()
        {
            var changes = _db.SaveChanges();

            return changes > 0;


        }

        public bool update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            return save();
        }
    }
}
