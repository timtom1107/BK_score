using Avalonia.Media;
using BK_score.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BK_score.Models 
{
    public partial class GridItem : ObservableObject
    {
        [ObservableProperty]
        private string _text;

        public GridItem()
        {
            _text = string.Empty;
        }
    }
}
