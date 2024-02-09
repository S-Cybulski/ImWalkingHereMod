using System;
using GameNetcodeStuff;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImWalkingHereMod.Patches
{
    [HarmonyPatch(typeof(HoarderBugAI))]
    internal class ChitterSFXPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]

        static void OverrideAudio(HoarderBugAI __instance)
        {
            __instance.chitterSFX = ImWalkingHereBase.SoundFX.ToArray();
        }
    }
}
