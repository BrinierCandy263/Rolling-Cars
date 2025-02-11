using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MapSelectorMenu : MenuManager
{
    public void HandleMapLevelToggle(int levelIndex)
    {
        MenuManager.SwitchToScene((MenuName)Enum.Parse(typeof(MenuName) , $"Level{levelIndex}"));
    }
}
