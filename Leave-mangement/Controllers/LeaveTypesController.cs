using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Leave_mangement.Contracts;
using Leave_mangement.Data;
using Leave_mangement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leave_mangement.Controllers
{
    public class LeaveTypesController : Controller
    {

        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _Mapper;
        public LeaveTypesController(ILeaveTypeRepository repo, IMapper Mapper)
        {
            _repo = repo;
            _Mapper = Mapper;

        }


        // GET: LeaveTypes
        public ActionResult Index()

        {

            var LeaveTypes = _repo.FindAll().ToList();
            var model = _Mapper.Map<List<LeaveType>, List<LeaveTypeVm>>(LeaveTypes);

            return View(model);
        }

        // GET: LeaveTypes/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExist(id)) {

                return NotFound();

            }

            var leaveType = _repo.FindById(id);
            var model = _Mapper.Map<LeaveTypeVm>(leaveType);


            return View(model);
        }

        // GET: LeaveTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);

                }


                var leaveType = _Mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.Now;

                var isSuccess = _repo.create(leaveType);

                if (!isSuccess) {
                    ModelState.AddModelError("","Some thing went wrong with you man------");
                    return View(model);
                }


                 
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View(model);
            }
        }

        // GET: LeaveTypes/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExist(id))
            {

                return NotFound();


            }
              var leaveType= _repo.FindById(id);
              var model=  _Mapper.Map<LeaveTypeVm>(leaveType);
            
            return View(model);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }
                var leaveType = _Mapper.Map<LeaveType>(model);
                var isSuccess = _repo.update(leaveType);
                if (!isSuccess) {
                    ModelState.AddModelError("", "Some thing went wrong with you man------");

                    return View(model);
                }
             


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Some thing went wrong with you man------");

                return View();
            }
        }

        // GET: LeaveTypes/Delete/5
        public ActionResult Delete(int id)
        {

            var leaveType = _repo.FindById(id);
            if (leaveType == null)
            {

                return NotFound();
            }

            var isSuccess = _repo.delete(leaveType);
            if (!isSuccess)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LeaveTypeVm model)
        {
            try
            {

                var leaveType = _repo.FindById(id);
                if (leaveType==null) {

                    return NotFound();
                }

                var isSuccess = _repo.delete(leaveType);
                if (!isSuccess) {

                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Some thing went wrong with you man------");

                return View();
            }
        }
    }
}