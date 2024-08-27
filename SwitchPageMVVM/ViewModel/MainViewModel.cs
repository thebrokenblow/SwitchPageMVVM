using SwitchPageMVVM.Core;
using SwitchPageMVVM.Services;

namespace SwitchPageMVVM.ViewModel;

public class MainViewModel : BaseViewModel
{
    public INavigationService NavigationService { get; }

    public RelayCommand NavigateToAboutCommand { get; }
    public RelayCommand NavigateToMenuCommand { get; }

    public MainViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigateToAboutCommand = new(o => navigationService.NavigateTo<AboutViewModel>());
        NavigateToMenuCommand = new(o => navigationService.NavigateTo<MenuViewModel>());
        NavigateToAboutCommand.Execute();
    }
} 
