<<<<<<< HEAD
﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace _7Things.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private const int TASKS_FOR_TODAY = 2;
        private const int TASKS_FOR_PLANNED = 3;
        private const int TASKS_FOR_SOMETIME = 4;

        private ObservableCollection<TaskModel> _tasksForPlanned;
        private ObservableCollection<TaskModel> _tasksForSometime;
        private ObservableCollection<TaskModel> _tasksForToday;

        public MainViewModel()
        {
            Items = new ObservableCollection<TaskModel>();
        }

        /// <summary>
        /// A collection for TaskModel objects.
        /// </summary>
        public ObservableCollection<TaskModel> Items { get; set; }


        public bool IsDataLoaded { get; private set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        /// <summary>
        /// Creates and adds a few TaskModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            Items.Add(new TaskModel
                          {
                              Id = Guid.NewGuid(),
                              Title = "Einkaufen",
                              IsDone = false,
                              Description =
                                  "Alles für's Essen einkaufen, damit wir was zu essen haben."
                          });

            Items.Add(new TaskModel
                          {
                              Id = Guid.NewGuid(),
                              Title = "Essen kochen",
                              IsDone = false,
                              Description =
                                  "Die gekauften Lebensmittel zu einem wohlschmeckenden Mahl zubereiten."
                          });

            Items.Add(new TaskModel
                          {
                              Id = Guid.NewGuid(),
                              Title = "Bier kaltstellen",
                              IsDone = true,
                              Description =
                                  "Ansonsten schmeckt das Essen am Ende nicht so gut. ;)"
                          });

            IsDataLoaded = true;
        }

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            TasksForToday    = GetTasksFor(TASKS_FOR_TODAY);
            TasksForPlanned  = GetTasksFor(TASKS_FOR_PLANNED);
            TasksForSometime = GetTasksFor(TASKS_FOR_SOMETIME);
        }

        private ObservableCollection<TaskModel> GetTasksFor(int forWhat)
        {
            var _tasks = new ObservableCollection<TaskModel>();

            switch (forWhat)
            {
                case TASKS_FOR_SOMETIME:
                    foreach (var taskModel in Items.Where(t => t.ToBeFinished.Equals(DateTime.MinValue)))
                    {
                        _tasks.Add(taskModel);
                    }
                    break;
                case TASKS_FOR_PLANNED:
                    foreach (var taskModel in Items.Where(t => !t.ToBeFinished.Equals(DateTime.MinValue)))
                    {
                        _tasks.Add(taskModel);
                    }
                    break;
                case TASKS_FOR_TODAY:
                    foreach (var taskModel in Items.Where(t => t.ToBeFinished.Date.Equals(DateTime.Today.Date)))
                    {
                        _tasks.Add(taskModel);
                    }
                    break;
            }
            return _tasks;
        }

        #region business methods

        public ObservableCollection<TaskModel> TasksForOverview
        {
            get { return Items; }
        }

        public ObservableCollection<TaskModel> TasksForToday
        {
            get { return _tasksForToday; }
            set
            {
                _tasksForToday = value;
                NotifyPropertyChanged("TasksForToday");
            }
        }

        public ObservableCollection<TaskModel> TasksForNextDays
        {
            get { return Items; }
        }

        public ObservableCollection<TaskModel> TasksForProjects
        {
            get { return Items; }
        }

        public ObservableCollection<TaskModel> TasksForPlanned
        {
            get { return _tasksForPlanned; }

            set
            {
                _tasksForPlanned = value;
                NotifyPropertyChanged("TasksForPlanned");
            }
        }

        public ObservableCollection<TaskModel> TasksForSometime
        {
            get { return _tasksForSometime; }
            set
            {
                _tasksForSometime = value;
                NotifyPropertyChanged("TasksForSometime");
            }
        }

        public ObservableCollection<TaskModel> TasksForLogbook
        {
            get { return Items; }
        }

        public TaskModel SelectedTask { get; set; }

        public TaskModel GetTaskById(Guid id)
        {
            return Items.Where(taskModel => taskModel.Id == id).First();
        }

        #endregion
    }
=======
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The main view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace _7Things.ViewModels
{
  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.ComponentModel;
  using System.Linq;

  /// <summary>
  /// The main view model.
  /// </summary>
  public class MainViewModel : INotifyPropertyChanged
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// </summary>
    public MainViewModel()
    {
      this.Items = new ObservableCollection<TaskModel>();
    }

    #endregion

    #region Events

    /// <summary>
    /// The property changed.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

    #region Properties

    /// <summary>
    /// Gets a value indicating whether IsDataLoaded.
    /// </summary>
    public bool IsDataLoaded { get; private set; }

    /// <summary>
    /// A collection for TaskModel objects.
    /// </summary>
    public ObservableCollection<TaskModel> Items { get; set; }

    /// <summary>
    /// Gets or sets SelectedTask.
    /// </summary>
    public TaskModel SelectedTask { get; set; }

    /// <summary>
    /// Gets TasksForLogbook.
    /// </summary>
    public ObservableCollection<TaskModel> TasksForLogbook
    {
      get
      {
        return this.Items;
      }
    }

    /// <summary>
    /// Gets TasksForNextDays.
    /// </summary>
    public ObservableCollection<TaskModel> TasksForNextDays
    {
      get
      {
        return this.Items;
      }
    }

    /// <summary>
    /// Gets TasksForOverview.
    /// </summary>
    public ObservableCollection<TaskModel> TasksForOverview
    {
      get
      {
        return this.Items;
      }
    }

    /// <summary>
    /// Gets TasksForPlanned.
    /// </summary>
    public ObservableCollection<TaskModel> TasksForPlanned
    {
      get
      {
        return this.Items;
      }
    }

    /// <summary>
    /// Gets TasksForProjects.
    /// </summary>
    public ObservableCollection<TaskModel> TasksForProjects
    {
      get
      {
        return this.Items;
      }
    }

    /// <summary>
    /// Gets TasksForSometime.
    /// </summary>
    public ObservableCollection<TaskModel> TasksForSometime
    {
      get
      {
        return this.Items;
      }
    }

    /// <summary>
    /// Gets TasksForToday.
    /// </summary>
    public IEnumerable<TaskModel> TasksForToday
    {
      get
      {
        return this.Items.Where(t => t.ToBeFinished.Equals(DateTime.Today));
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// The get task by id.
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// </returns>
    public TaskModel GetTaskById(Guid id)
    {
      return this.Items.FirstOrDefault(taskModel => taskModel.Id == id);
    }

    /// <summary>
    /// Creates and adds a few TaskModel objects into the Items collection.
    /// </summary>
    public void LoadData()
    {
      // Sample data; replace with real data
      this.Items.Add(
        new TaskModel
          {
            Id = Guid.NewGuid(), 
            Title = "Einkaufen", 
            IsDone = false, 
            Description = "Alles für's Essen einkaufen, damit wir was zu essen haben.", 
            ToBeFinished = DateTime.Today
          });

      this.Items.Add(
        new TaskModel
          {
            Id = Guid.NewGuid(), 
            Title = "Essen kochen", 
            IsDone = false, 
            Description = "Die gekauften Lebensmittel zu einem wohlschmeckenden Mahl zubereiten.", 
            ToBeFinished = DateTime.Today
          });

      this.Items.Add(
        new TaskModel
          {
            Id = Guid.NewGuid(), 
            Title = "Bier kaltstellen", 
            IsDone = true, 
            Description = "Ansonsten schmeckt das Essen am Ende nicht so gut. ;)"
          });

      this.IsDataLoaded = true;
    }

    /// <summary>
    /// Adds a Task to the Items list.
    /// </summary>
    /// <param name="taskModel">
    /// The task model.
    /// </param>
    public void AddTask(TaskModel taskModel)
    {
      App.ViewModel.Items.Add(taskModel);
      this.NotifyPropertyChanged("AddTask");
    }

    /// <summary>
    /// Removing a task
    /// </summary>
    /// <param name="taskModel">
    /// The task model.
    /// </param>
    public void RemoveTask(TaskModel taskModel)
    {
      App.ViewModel.Items.Remove(taskModel);
      this.NotifyPropertyChanged("RemoveTask");
    }

    #endregion

    #region Methods

    /// <summary>
    /// The notify property changed.
    /// </summary>
    /// <param name="propertyName">
    /// The property name.
    /// </param>
    private void NotifyPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler handler = this.PropertyChanged;
      if (null != handler)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    #endregion
  }
>>>>>>> e3da5ae79d67f08283c688a31cd8cb3fe316b103
}