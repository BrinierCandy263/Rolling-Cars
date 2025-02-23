using System;

public class MapSelectorMenu : MenuManager
{
    public void HandleMapLevelToggle(int levelIndex)
    {
        MenuManager.SwitchToScene((MenuName)Enum.Parse(typeof(MenuName) , $"Level{levelIndex}"));
    }
}
