using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using BK_score.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BK_score.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string scoreText;
    [ObservableProperty]
    private Color scoreColor;
    [ObservableProperty]
    private int overallMinus;
    public ObservableCollection<GridItem> _collection;
    private List<int> overallScore;
    private int currentShot;
    private bool IsNextValueMinus;

    public MainViewModel()
    {
        InputElement.KeyDownEvent.AddClassHandler<TopLevel>(OnKeyDown, handledEventsToo: true);

        _collection = [];
        ScoreText = "";
        overallScore = [];
        overallScore.Add(0);
        currentShot = 0;
        IsNextValueMinus = false;
        scoreColor = Colors.LightGray;

        for (int  i = 0; i < 100; i++)
        {
            _collection.Add(new GridItem());
        }
    }

    public ObservableCollection<GridItem> GridItems { get { return _collection; } }

    private void OnKeyDown(TopLevel level, KeyEventArgs args)
    {
        if (currentShot > 99) return;
        ScoreColor = IsNextValueMinus ? Colors.DarkRed : Colors.LightGray;
        int key = (int)args.Key;

        //Minus
        if (key == 143 || key == 87) { MinusPressed(); return; }
        //Main Numbers
        if (key > 33 && key < 44) key -= 34;
        //NumPad with NumLock
        if (key > 73 && key < 84) key -= 74;
        //Numpad without NumLock
        switch (key)
        {
            case 31: key = 0; break;
            case 21: key = 1; break;
            case 26: key = 2; break;
            case 20: key = 3; break;
            case 23: key = 4; break;
            case 5: key = 5; break;
            case 25: key = 6; break;
            case 22: key = 7; break;
            case 24: key = 8; break;
            case 19: key = 9; break;
            default: break;
        }

        Debug.WriteLine(key);

        if(key>7) return;
        DisplayLastScore(key);
        UpdateOverallScore(key);
        IsNextValueMinus = false;
    }

    private void MinusPressed()
    {
        IsNextValueMinus = true;
        DisplayMinus();
    }
    private void DisplayMinus()
    {
        ScoreText = "-";
        ScoreColor = Colors.DarkRed;
    }

    private void DisplayLastScore(int input)
    {
        ScoreText = input == 0 ? "x" : IsNextValueMinus ? (-input).ToString() : input.ToString();
    }
 
    private void UpdateOverallScore(int input)
    {
        int value = IsNextValueMinus ? -input : input;
        OverallMinus += IsNextValueMinus ? -input : 0;
        currentShot++;
        overallScore.Add(overallScore[currentShot-1]+value);
        _collection[currentShot-1].Text = overallScore[currentShot] == overallScore[currentShot-1] ? "x" : overallScore[currentShot].ToString();
    }
}
