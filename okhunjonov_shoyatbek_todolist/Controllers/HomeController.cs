using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using okhunjonov_shoyatbek_todolist.IRepositories;
using okhunjonov_shoyatbek_todolist.Models;
using okhunjonov_shoyatbek_todolist.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using okhunjonov_shoyatbek_todolist.Models.ViewModels;

namespace okhunjonov_shoyatbek_todolist.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoEntryRepo _toDoEntryRepo;
        private readonly IToDoListRepo _toDoListRepo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IToDoListRepo todoDListRepo, IToDoEntryRepo toDoEntryRepo)
        {
            _toDoEntryRepo = toDoEntryRepo;
            _toDoListRepo = todoDListRepo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                ToDoLists = _toDoListRepo.GetAll()
            };
            return View(homeIndexViewModel);
        }

        public IActionResult Hiddentodolists()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                ToDoLists = _toDoListRepo.GetAll()
            };
            return View(homeIndexViewModel);
        }

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

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HomeCreateViewModel todolist)
        {
            ToDoList toDoList = new ToDoList
            {
                Name = todolist.Name
            };
            toDoList = _toDoListRepo.Create(toDoList);
            return RedirectToAction("details", new {id = toDoList.Id });
        }

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

        [HttpPost]
        public IActionResult Edit(HomeEditViewModel toDoList)
        {
            ToDoList existingToDoList = _toDoListRepo.Get(toDoList.Id);
            existingToDoList.Name = toDoList.Name;
            _toDoListRepo.Update(existingToDoList);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ViewResult AddToDoEntry(int toDoListId)
        {
            ToDoEntry toDoEntry = new ToDoEntry() { ToDoListId = toDoListId };
            return View(toDoEntry);
        }

        [HttpPost]
        public IActionResult AddToDoEntry(ToDoEntry toDoEntry)
        {
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

        [HttpPost]
        public IActionResult Entrydetails(HomeEntriesViewModel homeEntriesViewModel)
        {
            ToDoEntry existingToDoEntry = _toDoEntryRepo.Get(homeEntriesViewModel.Id);
            existingToDoEntry.Title = homeEntriesViewModel.Title;
            existingToDoEntry.Description = homeEntriesViewModel.Description;
            existingToDoEntry.DueDate = homeEntriesViewModel.DueDate;
            existingToDoEntry.ToDoEntryStatus = homeEntriesViewModel.EntryStatus;
            existingToDoEntry.AdditionalField = homeEntriesViewModel.AdditionalField;
            _toDoEntryRepo.Update(existingToDoEntry);
            return RedirectToAction("Index");
        }

        public IActionResult Hide(int id)
        {
            var toDoEntry = _toDoEntryRepo.Get(id);
            _toDoEntryRepo.Hide(toDoEntry);
            return RedirectToAction("Index");
        }

        public IActionResult Show(int id)
        {
            var toDoEntry = _toDoEntryRepo.Get(id);
            _toDoEntryRepo.Show(toDoEntry);
            return RedirectToAction("Index");
        }

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
