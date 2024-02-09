using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using ImWalkingHereMod.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ImWalkingHereMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class ImWalkingHereBase : BaseUnityPlugin
    {
        private const string modGUID = "LegoStego.ImWalkingHereMod";
        private const string modName = "Im Walking Here Mod";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static ImWalkingHereBase Instance;

        internal ManualLogSource mls;

        internal static List<AudioClip> SoundFX;
        internal static AssetBundle Bundle;

        void Awake()
        {
            if(Instance == null) 
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("The ImWalkingHereMod has awaken");

            harmony.PatchAll(typeof(ChitterSFXPatch));

            mls = Logger;

            SoundFX = new List<AudioClip>();
            string folderLocation = Instance.Info.Location;
            folderLocation = folderLocation.TrimEnd("ImWalkingHereMod.dll".ToCharArray());
            Bundle = AssetBundle.LoadFromFile(folderLocation + "imwalkinghere");

            if(Bundle != null)
            {
                mls.LogInfo("Successfully loaded asset bundle");
                SoundFX = Bundle.LoadAllAssets<AudioClip>().ToList();
            }
            else
            {
                mls.LogError("Failed to load asset bundle");
            }
        }
    }
}
