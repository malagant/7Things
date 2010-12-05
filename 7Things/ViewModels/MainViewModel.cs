using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace _7Things.ViewModels
{
  public class MainViewModel : INotifyPropertyChanged
  {
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

    #region business methods

    public TaskModel GetTaskById(Guid id)
    {
      return Items.FirstOrDefault(taskModel => taskModel.Id == id);
    }

    public ObservableCollection<TaskModel> TasksForOverview
    {
      get
      {
        return Items;
      }
    }

    public ObservableCollection<TaskModel> TasksForToday
    {
      get
      {
        return Items;
      }
    }

    public ObservableCollection<TaskModel> TasksForNextDays
    {
      get
      {
        return Items;
      }
    }

    public ObservableCollection<TaskModel> TasksForProjects
    {
      get
      {
        return Items;
      }
    }

    public ObservableCollection<TaskModel> TasksForPlanned
    {
      get
      {
        return Items;
      }
    }

    public ObservableCollection<TaskModel> TasksForSometime
    {
      get
      {
        return Items;
      }
    }

    public ObservableCollection<TaskModel> TasksForLogbook
    {
      get
      {
        return Items;
      }
    }

    public TaskModel SelectedTask { get; set; }

    #endregion

    private void NotifyPropertyChanged(String propertyName)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (null != handler)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}