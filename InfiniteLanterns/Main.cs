using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace InfiniteLanterns
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        public const string GUID = "com.app24.infinitelanterns";
        public const string NAME = "Infinite Lanterns";
        public const string VERSION = "1.0.1";

        internal static ManualLogSource logSource;

        private void Awake()
        {
            logSource = Logger;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), GUID);
        }
    }
}
