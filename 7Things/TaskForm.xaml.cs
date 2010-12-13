// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskForm.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   The task form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace _7Things
{
  using System;
  using System.Windows.Navigation;

  using Microsoft.Phone.Controls;

  using _7Things.ViewModels;

  /// <summary>
  /// The task form.
  /// </summary>
  public partial class TaskForm : PhoneApplicationPage
  {
    #region Constants and Fields

    /// <summary>
    /// The task.
    /// </summary>
    private static TaskModel task;

    public TaskModel Task { get; set; }

    #endregion

    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskForm"/> class.
    /// </summary>
    public TaskForm()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Methods

    /// <summary>
    /// The on navigated to.
    /// </summary>
    /// <param name="e">
    /// The e.
    /// </param>
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);

      if (this.NavigationContext.QueryString.ContainsKey("newTask"))
      {
        task = new TaskModel { Id = Guid.NewGuid() };
      }
      else
      {
        task = App.ViewModel.SelectedTask;
        txtTitle.Text = task.Title;
        txtDescription.Text = task.Description;
        chkIsDone.IsChecked = task.IsDone;
        dpDate.Value = task.ToBeFinished;
      }
    }

    /// <summary>
    /// The btn cancel click.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void BtnCancelClick(object sender, EventArgs e)
    {
      this.NavigationService.GoBack();
    }

    /// <summary>
    /// The btn save click.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void BtnSaveClick(object sender, EventArgs e)
    {
      TaskModel task = App.ViewModel.SelectedTask;

      if (task == null)
      {
        task = new TaskModel();
      }

      task.Title = this.txtTitle.Text;
      task.Description = this.txtDescription.Text;
      if (this.chkIsDone.IsChecked != null)
      {
        task.IsDone = this.chkIsDone.IsChecked.Value;
      }

      if (this.dpDate.Value != null && !this.dpDate.Value.Equals(DateTime.MinValue))
      {
        task.ToBeFinished = (DateTime)this.dpDate.Value;
      }

      if (App.ViewModel.GetTaskById(task.Id) == null)
      {
        App.ViewModel.AddTask(task);
      }

      this.NavigationService.GoBack();
    }

    #endregion
  }
}