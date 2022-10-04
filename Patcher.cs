using System;
using System.Reflection;
using HarmonyLib;

namespace SubMeshFlags {

    public static class Patcher
    {
        private const string HarmonyId = "jaijai.submeshflags";

        private static bool patched = false;

        public static void PatchAll()
        {
            if (patched) return;

            patched = true;

            var harmony = new Harmony(HarmonyId);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public static void UnpatchAll()
        {
            if (!patched) return;

            var harmony = new Harmony(HarmonyId);
            harmony.UnpatchAll(HarmonyId);

            patched = false;
        }
    }

    [HarmonyPatch]
    public static class UserFlagSupportedPatch
    {
        static MethodBase TargetMethod()
        {
            return typeof(REEnumBitmaskSet).GetMethod("UserFlagSupported", BindingFlags.NonPublic | BindingFlags.Instance).MakeGenericMethod(typeof(int));
        }

        public static bool Prefix(Type type)
        {
            return (typeof(Building.Flags) == type) | (typeof(Vehicle.Flags) == type);
        }

        public static void Postfix(ref bool __result)
        {
            __result = true;
        }
    }
}
