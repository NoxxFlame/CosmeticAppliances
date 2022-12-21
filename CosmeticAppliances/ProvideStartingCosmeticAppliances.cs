using Kitchen;
using KitchenData;
using KitchenMods;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace KitchenCosmeticAppliances
{
    public class ProvideStartingCosmeticAppliances : RestaurantSystem, IModSystem
    {
        protected override void OnUpdate()
        {
            if (!base.HasSingleton<ProvideStartingCosmeticAppliances.SProvided>())
            {
                if (base.Has<SLayout>())
                {
                    base.World.Add<ProvideStartingCosmeticAppliances.SProvided>();
                    List<Vector3> postTiles = base.GetPostTiles(false);
                    int num = 0;
                    Vector3 fallbackTile;
                    int[] appliances = { AssetReference.OutfitStation, AssetReference.CosmeticStation, AssetReference.ColourStation };
                    for (int i = 0; i < 3; i++)
                    {
                        if (!this.FindTile(ref num, postTiles, out fallbackTile))
                        {
                            fallbackTile = base.GetFallbackTile();
                        }
                        PostHelpers.CreateApplianceParcel(base.EntityManager, fallbackTile, appliances[i]);
                    }
                }
            }
        }

        public bool FindTile(ref int placed_tile, List<Vector3> floor_tiles, out Vector3 candidate)
        {
            candidate = Vector3.zero;
            bool flag = false;
            while (!flag && placed_tile < floor_tiles.Count)
            {
                int num = placed_tile;
                placed_tile = num + 1;
                candidate = floor_tiles[num];
                if (base.GetOccupant(candidate, OccupancyLayer.Default) == default(Entity))
                {
                    flag = true;
                }
            }
            return flag;
        }

        private struct SProvided : IComponentData, IModComponent
        {

        }
    }
}
