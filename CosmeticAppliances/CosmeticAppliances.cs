using HarmonyLib;
using KitchenMods;

namespace KitchenCosmeticAppliances
{
    internal class CosmeticAppliances : IModInitializer
    {
        public void PostActivate(Mod mod)
        {
            var harmony = new Harmony("noxxflame.plateup.cosmeticappliances");
            harmony.PatchAll(GetType().Assembly);
        }

        public void PreInject() { }

        public void PostInject() { }
    }
}
