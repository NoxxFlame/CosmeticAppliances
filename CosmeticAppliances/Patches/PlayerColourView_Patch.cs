using HarmonyLib;
using Kitchen;

namespace KitchenCosmeticAppliances
{
    [HarmonyPatch(typeof(PlayerColourView))]
    public class PlayerColourView_Patch
    {
        [HarmonyPatch("Update")]
        [HarmonyPrefix]
        public static bool Update_PrefixPatch(PlayerColourView __instance)
        {
            Traverse PCV = Traverse.Create(__instance);
            int Player = PCV.Field("Player").GetValue<int>();

            PlayerInfo playerInfo = Players.Main.Get(Player);
            bool flag = Player != 0 && playerInfo.JoinProgress < -0.5f;
            if (GameInfo.CurrentScene == SceneType.Kitchen)
            {
                PCV.Field("ShowOnInactive").SetValue(!flag);
            }
            return true;
        }
    }
}
