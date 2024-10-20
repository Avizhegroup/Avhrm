namespace Avhrm.UI.Shared;
public class ComponentsContext
{
    private bool _isDrawerOpen = false;
    private bool _isDrawerShown = false;
    private bool _isBackButtonShown = false;

    public Action? OnChange;

    public bool IsDrawerOpen
    {
        get => _isDrawerOpen;
        set
        {
            _isDrawerOpen = value;

            OnChange?.Invoke();
        }
    }

    public bool IsDrawerShown
    {
        get => _isDrawerShown;
        set
        {
            _isDrawerShown = value;

            OnChange?.Invoke(); 
        }
    }

    public bool IsBackButtonShown
    {
        get => _isBackButtonShown;
        set
        {
            _isBackButtonShown = value;

            OnChange?.Invoke(); 
        }
    }
}
