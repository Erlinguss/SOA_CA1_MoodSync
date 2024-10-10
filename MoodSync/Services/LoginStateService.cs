﻿public class LoginStateService
{
    public bool IsLoggedIn { get; private set; }

    public event Action OnChange;

    public void Login()
    {
        IsLoggedIn = true;
        NotifyStateChanged();
    }

    public void Logout()
    {
        IsLoggedIn = false;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
