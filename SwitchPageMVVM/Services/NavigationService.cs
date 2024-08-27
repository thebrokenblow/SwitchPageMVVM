using SwitchPageMVVM.Core;

namespace SwitchPageMVVM.Services;

public interface INavigationService
{
    BaseViewModel BaseViewModel { get; }
    void NavigateTo<T>() where T : BaseViewModel;
}

public class NavigationService(Func<Type, BaseViewModel> viewModelFactory) : ObservableObject, INavigationService
{
    private BaseViewModel? baseViewModel;
    public BaseViewModel? BaseViewModel 
    {
        get => baseViewModel;
        private set
        {
            baseViewModel = value;
            OnPropertyChanged();
        }
    }

    public void NavigateTo<T>() where T : BaseViewModel
    {
        BaseViewModel = viewModelFactory.Invoke(typeof(T));
    }
}
