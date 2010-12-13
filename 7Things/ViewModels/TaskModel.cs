// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskModel.cs" company="">
//   
// </copyright>
// <summary>
//   The task model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace _7Things.ViewModels
{
  using System;
  using System.ComponentModel;

  /// <summary>
  /// The task model.
  /// </summary>
  public class TaskModel : INotifyPropertyChanged
  {
    #region Constants and Fields

    /// <summary>
    /// The _description.
    /// </summary>
    private string _description;

    /// <summary>
    /// The _id.
    /// </summary>
    private Guid _id;

    /// <summary>
    /// The _is done.
    /// </summary>
    private bool _isDone;

    /// <summary>
    /// The _title.
    /// </summary>
    private string _title;

    /// <summary>
    /// The _to be finished.
    /// </summary>
    private DateTime _toBeFinished;

    #endregion

    #region Events

    /// <summary>
    /// The property changed.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets Description.
    /// </summary>
    public string Description
    {
      get
      {
        return this._description;
      }

      set
      {
        if (value != this._description)
        {
          this._description = value;
          this.NotifyPropertyChanged("Description");
        }
      }
    }

    /// <summary>
    /// Gets or sets Id.
    /// </summary>
    public Guid Id
    {
      get
      {
        return this._id;
      }

      set
      {
        if (value != this._id)
        {
          this._id = value;
          this.NotifyPropertyChanged("Id");
        }
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether IsDone.
    /// </summary>
    public bool IsDone
    {
      get
      {
        return this._isDone;
      }

      set
      {
        if (value != this._isDone)
        {
          this._isDone = value;
          this.NotifyPropertyChanged("IsDone");
        }
      }
    }

    /// <summary>
    /// Gets or sets Title.
    /// </summary>
    public string Title
    {
      get
      {
        return this._title;
      }

      set
      {
        if (value != this._title)
        {
          this._title = value;
          this.NotifyPropertyChanged("Title");
        }
      }
    }

    /// <summary>
    /// Gets or sets ToBeFinished.
    /// </summary>
    public DateTime ToBeFinished
    {
      get
      {
        return this._toBeFinished;
      }

      set
      {
        if (value != this._toBeFinished)
        {
          this._toBeFinished = value;
          this.NotifyPropertyChanged("ToBeFinished");
        }
      }
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