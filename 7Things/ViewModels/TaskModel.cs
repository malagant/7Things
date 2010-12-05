using System;
using System.ComponentModel;

namespace _7Things.ViewModels
{
    public class TaskModel : INotifyPropertyChanged
    {
        private Guid _id;
        private string _title;
        private bool _isDone;
        private string _description;
        private DateTime _toBeFinished;

        public Guid Id
        {
            get { return _id; }
            set
            {
                if(value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

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

        public DateTime ToBeFinished
        {
            get { return _toBeFinished; }
            set
            {
                if(value != _toBeFinished)
                {
                    _toBeFinished = value;
                    NotifyPropertyChanged("ToBeFinished");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

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