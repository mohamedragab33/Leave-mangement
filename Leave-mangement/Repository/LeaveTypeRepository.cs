using Leave_mangement.Contracts;
using Leave_mangement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_mangement.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveTypeRepository( ApplicationDbContext db)
        {
            _db = db;
        }
        public bool create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            return save();

        }

        public bool delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return save();
        }

        public ICollection<LeaveType> FindAll()
        {

            var leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
        }

        public LeaveType FindById(int ID)
        {

            var leaveType = _db.LeaveTypes.Find(ID);
            return leaveType;


        }

        public ICollection<LeaveType> GetEmployeesLeaveType(int ID)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int ID)
        {

            var exist = _db.LeaveTypes.Any(q => q.Id == ID);
            return exist;

        }

        public bool save()
        {
            var Changes = _db.SaveChanges();
            return Changes > 0;
        }

        public bool update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return save();
        }
    }
}
