using System;
using System.Windows.Navigation;
using _7Things.ViewModels;
using Microsoft.Phone.Controls;

namespace _7Things
{
  public partial class TaskForm : PhoneApplicationPage
  {
    private static TaskModel _task;

    public TaskForm()
    {
      InitializeComponent();
    }

    private void BtnSaveClick(object sender, EventArgs e)
    {
      _task.Title = txtTitle.Text;
      _task.Description = txtDescription.Text;
      if (chkIsDone.IsChecked != null) _task.IsDone = chkIsDone.IsChecked.Value;
      if (dpDate.Value != null && !dpDate.Value.Equals(DateTime.MinValue))
        _task.ToBeFinished = (DateTime) dpDate.Value;

      if (App.ViewModel.GetTaskById(_task.Id) == null)
      {
        App.ViewModel.Items.Add(_task);
      }
      NavigationService.GoBack();
    }

    private void BtnCancelClick(object sender, EventArgs e)
    {
      NavigationService.GoBack();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);

      if (!NavigationContext.QueryString.ContainsKey("newTask"))
      {
        _task = App.ViewModel.SelectedTask;
        if (_task != null)
        {
          txtTitle.Text = _task.Title;
          chkIsDone.IsChecked = _task.IsDone;
          txtDescription.Text = _task.Description;
          if (!_task.ToBeFinished.Equals(DateTime.MinValue))
          {
            dpDate.Value = _task.ToBeFinished.Date;
          }
        }
      } else
      {
          _task = new TaskModel {Id = Guid.NewGuid()};
      }
    }
  }
}