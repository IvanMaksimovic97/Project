using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IGetActorsCommand getActors;
        private readonly IGetOneActorCommand getOneActor;
        private readonly ICreateActorCommand createActor;
        private readonly IDeleteActorCommand deleteActor;

        public ActorsController(IGetActorsCommand getActors, ICreateActorCommand createActor, IDeleteActorCommand deleteActor, IGetOneActorCommand getOneActor)
        {
            this.getActors = getActors;
            this.createActor = createActor;
            this.deleteActor = deleteActor;
            this.getOneActor = getOneActor;
        }
        // GET: Actors
        public ActionResult Index(ActorDTO actor)
        {
            var glumci = getActors.Execute(actor);
            return View(glumci);
        }

        // GET: Actors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateActorDTO collection)
        {
            if (!ModelState.IsValid)
            {
                TempData["greska"] = "Greska pri unosu";
                RedirectToAction("create");
            }

            try
            {
                createActor.Execute(collection);

                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExist e)
            {
                TempData["error"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return View();
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Actors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Actors/Delete/5
        public ActionResult Delete(int id)
        {
            var glumac = getOneActor.Execute(id);
            return View(glumac);
        }

        // POST: Actors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ActorDTO collection)
        {
            try
            {
                deleteActor.Execute(id);

                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException e)
            {
                TempData["error"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return View();
        }
    }
}