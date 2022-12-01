using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using okhunjonov_shoyatbek_todolist.IRepositories;
using okhunjonov_shoyatbek_todolist.Models;
using System.Collections.Generic;
using okhunjonov_shoyatbek_todolist.Models.ViewModels;

namespace okhunjonov_shoyatbek_todolist.Controllers
{
    /// <summary>
    /// HomeController that has all action method of the project.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IToDoEntryRepo _toDoEntryRepo;
        private readonly IToDoListRepo _toDoListRepo;
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Injecting dependency through constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="todoDListRepo"></param>
        /// <param name="toDoEntryRepo"></param>
        public HomeController(ILogger<HomeController> logger, IToDoListRepo todoDListRepo, IToDoEntryRepo toDoEntryRepo)
        {
            _toDoEntryRepo = toDoEntryRepo;
            _toDoListRepo = todoDListRepo;
            _logger = logger;
        }

        /// <summary>
        /// Default first action method of HomeController.
        /// Using HomeIndexViewModel passes values of all ToDoList s in database to view.
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                ToDoLists = _toDoListRepo.GetAll()
            };
            return View(homeIndexViewModel);
        }
        /// <summary>
        ///  Action method that passes all ToDoLists to view.
        /// Later, in view, ToDoLists are sorted according to ShowHidden status and show in body section.
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult Hiddentodolists()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                ToDoLists = _toDoListRepo.GetAll()
            };
            return View(homeIndexViewModel);
        }

        /// <summary>
        /// This controller passes Values, ToDoEntries to be specific to the View.
        /// In a View, method is routed using Id of ToDoList which helps to identify specific ToDoList by unique id.
        /// </summary>
        /// <returns>IActionResult</returns>
        public ViewResult Details(int id)
        {
            ToDoList toDoList = _toDoListRepo.Get(id);
            if(toDoList != null)
            {
                HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
                {
                    ToDoList = toDoList,
                    ToDoEntries = toDoList.ToDoEntries,
                    Id = toDoList.Id
                };
                return View(homeDetailsViewModel);
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// This action method gets and Id of passed ToDoList and deletes it from database and redirects to Index view.
        /// </summary>
        public IActionResult Delete(int id)
        {
            ToDoList toDoList = _toDoListRepo.Get(id);
            if(toDoList != null)
            {
                _toDoListRepo.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// This action methods redirects request to Create view where form to create new to do list is presented. 
        /// </summary>
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        /// <summary>
        /// This action method shows a form which has post method that has form to be filled to create a new ToDoList.
        /// </summary>
        [HttpPost]
        public IActionResult Create(ToDoList todolist)
        {
            if (ModelState.IsValid) { 
            ToDoList toDoList = new ToDoList
            {
                Name = todolist.Name
            };
            toDoList = _toDoListRepo.Create(toDoList);
            return RedirectToAction("details", new {id = toDoList.Id });
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// This action method redirects request to Edit view where as a parameter receives id of specific ToDoList.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ViewResult</returns>
        [HttpGet]
        public ViewResult Edit(int id)
        {
            ToDoList toDoList = _toDoListRepo.Get(id);
            if(toDoList != null)
            {
                HomeEditViewModel homeEditViewModel = new HomeEditViewModel()
                {
                    Name = toDoList.Name
                };
                return View(homeEditViewModel);
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// This action method edits data that has been collected from form and posted using post method and changes are made in database.
        /// </summary>
        /// <param name="toDoList"></param>
        /// <returns>IActionresult</returns>
        [HttpPost]
        public IActionResult Edit(ToDoList toDoList)
        {
            if (ModelState.IsValid) { 
            ToDoList existingToDoList = _toDoListRepo.Get(toDoList.Id);
            existingToDoList.Name = toDoList.Name;
            _toDoListRepo.Update(existingToDoList);
            return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// This action method redirects requst to view where there is a form.
        /// Receives ToDoList id as a parameter.
        /// </summary>
        /// <param name="toDoListId"></param>
        /// <returns>ViewResult</returns>
        [HttpGet]
        public ViewResult AddToDoEntry(int toDoListId)
        {
            ToDoEntry toDoEntry = new ToDoEntry() { ToDoListId = toDoListId };
            return View(toDoEntry);
        }

        /// <summary>
        /// This action method receives as a parameter object of ToDoEntry class which submitted as using form in a view and adds ToDoEntry to database.E
        /// </summary>
        /// <param name="toDoEntry"></param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult AddToDoEntry(ToDoEntry toDoEntry)
        {
            if (ModelState.IsValid) { 
            ToDoEntry newToDoEntry = new ToDoEntry()
            {
                ToDoListId = toDoEntry.ToDoListId,
                Title = toDoEntry.Title,
                Description = toDoEntry.Description,
                DueDate = toDoEntry.DueDate,
                ToDoEntryStatus = toDoEntry.ToDoEntryStatus
            };
            newToDoEntry = _toDoEntryRepo.Create(newToDoEntry);
            return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// This action method passes request to View where details of specific ToDoEntry that has been passed as an argument as input fields.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ViewResult</returns>
        [HttpGet]
        public ViewResult Entrydetails (int id)
        {
            ToDoEntry todoentry = _toDoEntryRepo.Get(id);
            if(todoentry != null)
            {
                HomeEntriesViewModel hevm = new HomeEntriesViewModel()
                {
                    Title = todoentry.Title,
                    Description = todoentry.Description,
                    DueDate = todoentry.DueDate,
                    CreationDate = todoentry.CreationDate,
                    EntryStatus = todoentry.ToDoEntryStatus
                };
                return View(hevm);
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// This action method responses to post method of form and changes details that has been inserted.
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult Entrydetails(ToDoEntry toDoEntry)
        {
            if (ModelState.IsValid) { 
            ToDoEntry existingToDoEntry = _toDoEntryRepo.Get(toDoEntry.Id);
            existingToDoEntry.Title = toDoEntry.Title;
            existingToDoEntry.Description = toDoEntry.Description;
            existingToDoEntry.DueDate = toDoEntry.DueDate;
            existingToDoEntry.ToDoEntryStatus = toDoEntry.ToDoEntryStatus;
            existingToDoEntry.AdditionalField = toDoEntry.AdditionalField;
            _toDoEntryRepo.Update(existingToDoEntry);
            return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// This action method receives as an argument Id of ToDoEntry passed and gets it. After that it changes enum status of it from Show to Hide and Redirects to Index view.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        public IActionResult Hide(int id)
        {
            var toDoEntry = _toDoEntryRepo.Get(id);
            _toDoEntryRepo.Hide(toDoEntry);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This action method receives as an argument Id of ToDoEntry passed and gets it. After that it changes enum status of it from Hide to Show and Redirects to Index view.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        public IActionResult Show(int id)
        {
            var toDoEntry = _toDoEntryRepo.Get(id);
            _toDoEntryRepo.Show(toDoEntry);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This action method receives as a parameter an Id of ToDoList passed and passes values of it to controller and then to view using ViewModel.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ViewResult</returns>
        public ViewResult Hiddenentries(int id)
        {
            ToDoList todolist = _toDoListRepo.Get(id);
            if (todolist != null)
            {
                HomeEntriesDetailsViewModel homeDetailsViewModel = new HomeEntriesDetailsViewModel()
                {
                    ToDoList = todolist,
                    ToDoEntries = todolist.ToDoEntries,
                    Id = todolist.Id
                };
                return View(homeDetailsViewModel);
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// This action method receieves as an argument an Id of ToDoList passed and passes its values to controller and to View.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ViewResult</returns>
        public ViewResult Completedentries(int id)
        {
            ToDoList toDoList  = _toDoListRepo.Get(id);
            if (toDoList != null)
            {
                HomeEntriesDetailsViewModel homeDetailsViewModel = new HomeEntriesDetailsViewModel()
                {
                    ToDoList = toDoList,
                    ToDoEntries = toDoList.ToDoEntries,
                    Id = toDoList.Id
                };
                return View(homeDetailsViewModel);
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// This action method returns a view where from controller all to do entries that has due time today are sorted.
        /// </summary>
        /// <returns>ViewResult</returns>
        public ViewResult Entriesduetoday()
        {
            List<ToDoEntry> toDoEntries = _toDoEntryRepo.GetAllEntriesDueToday();
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                ToDoEntries = toDoEntries
            };
            return View(homeDetailsViewModel);
        }

    }
}
