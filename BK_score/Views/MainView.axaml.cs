using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using BK_score.Models;
using BK_score.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace BK_score.Views;

public partial class MainView : UserControl
{

    public MainView()
    {
        InitializeComponent();
    }

    /*
    public void ButtonClicked(object source, RoutedEventArgs args)
    {
        if (double.TryParse(celsius.Text, out double C))
        {
            fahrenheit.Text = (C * (9d / 5d) + 32).ToString("0.0");
        }
        else
        {
            celsius.Text = "0";
            fahrenheit.Text = "0";
        }

    }
    public void TextBox_KeyDown(object source, RoutedEventArgs args)
    {
        if (double.TryParse(celsius.Text, out double C))
        {
            fahrenheit.Text = (C * (9d / 5d) + 32).ToString("0.0");
        }
        else
        {
            celsius.Text = "0";
            fahrenheit.Text = "0";
        }

    }*/
}
