using Leave_mangement.Contracts;
using Leave_mangement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_mangement.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {


        private readonly ApplicationDbContext _db;
        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }




        public bool create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return save();
        }

        public bool delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            var leaveAllocations = _db.LeaveAllocations.ToList();
            return leaveAllocations;
        }

        public LeaveAllocation FindById(int ID)
        {
            var leaveAllocation = _db.LeaveAllocations.Find(ID);
            return leaveAllocation;

        }

        public bool isExist(int ID)
        {
            var exist = _db.LeaveAllocations.Any(q => q.Id == ID);
            return exist;
        }

        public bool save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;

        }

        public bool update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return save();
        }
    }
}
