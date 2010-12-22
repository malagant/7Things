<<<<<<< HEAD
﻿using System;
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
=======
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   The main page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Windows;
using System.Windows.Input;

using Microsoft.Phone.Controls;

using _7Things.ViewModels;

namespace _7Things
{
  /// <summary>
  /// The main page.
  /// </summary>
  public partial class MainPage
  {
    // Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="MainPage"/> class.
    /// </summary>
    public MainPage()
    {
      InitializeComponent();

      // Set the data context of the listbox control to the sample data
      DataContext = App.ViewModel;
      Loaded += MainPage_Loaded;
    }

    // Load data for the ViewModel Items
    /// <summary>
    /// The main page_ loaded.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
      if (!App.ViewModel.IsDataLoaded)
      {
        App.ViewModel.LoadData();
      }
    }

    /// <summary>
    /// The ab add click.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void AbAddClick(object sender, EventArgs e)
    {
      NavigationService.Navigate(new Uri("/TaskForm.xaml?newTask", UriKind.Relative));
    }

    /// <summary>
    /// The overview list box_ mouse left button up.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void OverviewListBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      var task = (TaskModel)OverviewListBox.SelectedItem;
      NavigationService.Navigate(new Uri("/TaskForm.xaml?task=" + task.Id, UriKind.Relative));
    }

    /// <summary>
    /// The delete task.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void DeleteTask(object sender, RoutedEventArgs e)
    {
      App.ViewModel.Items.Remove(App.ViewModel.SelectedTask);
    }

    /// <summary>
    /// The check box_ click.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void CheckBox_Click(object sender, RoutedEventArgs e)
    {
    }

    /// <summary>
    /// The today list box_ mouse left button up.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void TodayListBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      var task = (TaskModel)TodayListBox.SelectedItem;
      NavigationService.Navigate(new Uri("/TaskForm.xaml?task=" + task.Id, UriKind.Relative));
    }
  }
>>>>>>> e3da5ae79d67f08283c688a31cd8cb3fe316b103
}