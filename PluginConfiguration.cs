using BepInEx.Configuration;
using UnityEngine;

namespace ObraDinn.QolPatches;

public struct Configuration
{
    public DisplayConfiguration Display;
    public GameplayConfiguration Gameplay;
}

public struct GameplayConfiguration
{
    public ConfigEntry<bool> RunInBackground;
    public ConfigEntry<float> WalkingSpeed;
}

public struct DisplayConfiguration
{
    public ConfigEntry<uint> RefreshRate;
    public ConfigEntry<bool> VSync;
    public ConfigEntry<bool> CustomEnabled;
    public ConfigEntry<Color> Background;
    public ConfigEntry<Color> Foreground;
}
