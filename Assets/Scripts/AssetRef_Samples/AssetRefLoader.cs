using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class AssetRefLoader
{
   public static async Task CreateAssetAddToList<T>(AssetReference reference, List<T> completedObjs) where T : Object
   {
      completedObjs.Add(await reference.InstantiateAsync().Task as T);
   }

   public static async Task CreateAssetsAddToList<T>(List<AssetReference> references, List<T> completedObjs) where T : Object
   {
      foreach (var reference in references)
         completedObjs.Add(await reference.InstantiateAsync().Task as T);
   }
}
