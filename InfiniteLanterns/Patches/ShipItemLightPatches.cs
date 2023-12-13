using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace InfiniteLanterns.Patches
{
    internal static class ShipItemLightPatches
    {
        [HarmonyPatch(typeof(ShipItemLight), "ExtraLateUpdate")]
        private static class ExtraLateUpdatePatch
        {
            [HarmonyPrefix]
            public static bool Prefix(bool ___on, Light ___light)
            {
                if (___on)
                {
                    if (Settings.lanternShadows)
                    {
                        ___light.shadows = LightShadows.Soft;
                    }
                    else
                    {
                        ___light.shadows = LightShadows.None;
                    }
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(ShipItemLight), "UpdateLookText")]
        private static class UpdateLookTextPatch
        {
            [HarmonyPostfix]
            public static void Postfix(ShipItemLight __instance)
            {
                if (__instance.sold)
                {
                    __instance.description = "∞%";
                }
            }
        }
    }
}
