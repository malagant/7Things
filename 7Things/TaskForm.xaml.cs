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
            _task = App.ViewModel.SelectedTask;
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            _task.Title = txtTitle.Text;
            _task.Description = txtDescription.Text;
            if (chkIsDone.IsChecked != null)
                _task.IsDone = chkIsDone.IsChecked.Value;
            if (dpDate.Value != null)
            {
                _task.ToBeFinished = (DateTime) dpDate.Value;
            }

            if (App.ViewModel.GetTaskById(_task.Id) == null)
            {
                App.ViewModel.Items.Add(_task);
            }

            App.ViewModel.Refresh();
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
                if (_task != null)
                {
                    txtTitle.Text = _task.Title;
                    chkIsDone.IsChecked = _task.IsDone;
                    txtDescription.Text = _task.Description;
                }
            }
            else
            {
                _task = new TaskModel {Id = Guid.NewGuid()};
            }
        }

        private void dpDate_ValueChanged(object sender, DateTimeValueChangedEventArgs e)
        {
            if (e.NewDateTime != null)
                _task.ToBeFinished = (DateTime) e.NewDateTime;
        }
    }
}