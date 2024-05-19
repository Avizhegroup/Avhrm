namespace Avhrm.UI.Shared;
public class ComponentsContext
{
    private bool _isDrawerOpen = false;
    private bool _isDrawerShown = false;

    public bool IsDrawerOpen
    {
        get => _isDrawerOpen;
        set
        {
            _isDrawerOpen = value;
        }
    }

    public bool IsDrawerShown
    {
        get => _isDrawerShown;
        set
        {
            _isDrawerShown = value;
        }
    }
}
