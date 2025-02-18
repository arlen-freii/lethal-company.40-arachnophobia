#pragma warning disable IDE0051

using System.IO;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace _40Arachnophobia;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class _40Arachnophobia : BaseUnityPlugin 
{
    public static _40Arachnophobia Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger { get; private set; } = null!;
    internal static Harmony? Harmony { get; set; }

    public GameObject? SpiderTextPrefab; 

    private void Awake() {
        
        Logger = base.Logger;
        Instance = this;

        var modAssets = AssetBundle.LoadFromFile(
            Path.Combine(Path.GetDirectoryName(Info.Location), "assets/40arachnophobia")
        );

        GameObject spiderTextPrefab = modAssets.LoadAsset<GameObject>("Assets/LethalCompany/Game/Meshes/SpiderText.prefab");
        SpiderTextPrefab = spiderTextPrefab;

        Patch();

        Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");

    }

    internal static void Patch() {

        Harmony ??= new Harmony(MyPluginInfo.PLUGIN_GUID);

        Logger.LogDebug("Patching...");

        Harmony.PatchAll();

        Logger.LogDebug("Finished patching!");

    }

    internal static void Unpatch() {

        Logger.LogDebug("Unpatching...");

        Harmony?.UnpatchSelf();

        Logger.LogDebug("Finished unpatching!");

    }

}
