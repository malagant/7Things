// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskModel.cs" company="">
//   
// </copyright>
// <summary>
//   The task model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;

namespace _7Things.ViewModels
{
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
            get { return _description; }

            set
            {
                if (value != _description)
                {
                    _description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public Guid Id
        {
            get { return _id; }

            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsDone.
        /// </summary>
        public bool IsDone
        {
            get { return _isDone; }

            set
            {
                if (value != _isDone)
                {
                    _isDone = value;
                    NotifyPropertyChanged("IsDone");
                }
            }
        }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        public string Title
        {
            get { return _title; }

            set
            {
                if (value != _title)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        /// <summary>
        /// Gets or sets ToBeFinished.
        /// </summary>
        public DateTime ToBeFinished
        {
            get { return _toBeFinished; }

            set
            {
                if (value != _toBeFinished)
                {
                    _toBeFinished = value;
                    NotifyPropertyChanged("ToBeFinished");
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
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}