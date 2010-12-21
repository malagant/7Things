using System;
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
}