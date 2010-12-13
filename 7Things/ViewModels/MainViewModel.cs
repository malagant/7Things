// --------------------------------------------------------------------------------------------------------------------
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
}