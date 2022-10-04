using CitiesHarmony.API;
using ColossalFramework.UI;
using ICities;
using System;
using System.IO;
using System.Xml.Serialization;

namespace SubMeshFlags
{
    public class Mod : IUserMod
    {
        public string Name => "Sub Mesh Flags";
        public string Description => "Allows using all sub mesh flags";

        public void OnEnabled()
        {
            HarmonyHelper.DoOnHarmonyReady(() => Patcher.PatchAll());
        }

        public void OnDisabled()
        {
            if (HarmonyHelper.IsHarmonyInstalled) Patcher.UnpatchAll();
        }
    }

}
