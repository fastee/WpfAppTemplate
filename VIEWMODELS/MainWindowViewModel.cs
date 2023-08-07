using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace $safeprojectname$.ViewModels
{
    partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "Title in ViewModel";



        // Implement command methods here
        [RelayCommand]
        private void Open()
        {
            // Code for opening a file
            throw new System.NotImplementedException();
        }
    }
}
