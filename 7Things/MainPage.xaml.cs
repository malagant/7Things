using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using _7Things.ViewModels;
using Microsoft.Phone.Controls;

namespace _7Things
{
  public partial class MainPage : PhoneApplicationPage
  {
    // Constructor
    public MainPage()
    {
      InitializeComponent();

      // Set the data context of the listbox control to the sample data
      DataContext = App.ViewModel;
      this.Loaded += new RoutedEventHandler(MainPage_Loaded);
    }

    // Load data for the ViewModel Items
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
      if (!App.ViewModel.IsDataLoaded)
      {
        App.ViewModel.LoadData();
      }
    }

    private void AbAddClick(object sender, EventArgs e)
    {
      NavigationService.Navigate(new Uri("/TaskForm.xaml?newTask", UriKind.Relative));
    }

    private void OverviewListBox_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      var task = (TaskModel)OverviewListBox.SelectedItem;
      NavigationService.Navigate(new Uri("/TaskForm.xaml?task=" + task.Id, UriKind.Relative));
    }

    private void DeleteTask(object sender, RoutedEventArgs e)
    {
      App.ViewModel.Items.Remove(App.ViewModel.SelectedTask);
    }

    private void CheckBox_Click(object sender, RoutedEventArgs e)
    {
      
    }

    private void TodayListBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      var task = (TaskModel)TodayListBox.SelectedItem;
      NavigationService.Navigate(new Uri("/TaskForm.xaml?task=" + task.Id, UriKind.Relative));
    }
  }
}