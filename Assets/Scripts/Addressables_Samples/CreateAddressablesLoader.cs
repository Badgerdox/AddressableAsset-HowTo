using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;

public static class CreateAddressablesLoader 
{
    public static async Task ByLoadedAddress<T>(IList<IResourceLocation> loadedLocations, List<T> createdObjs)
        where T : Object
    {
        foreach (var location in loadedLocations)
        {
            var obj = await Addressables.InstantiateAsync(location).Task as T;
            createdObjs.Add(obj);
        }
    }
}




































//public static async Task ByAddress<T>(string label, List<T> createdAssets) where T : Object
//    {
//       var tempLocations = new List<IResourceLocation>();
//       await AddressableLocationLoader.GetAll(label, tempLocations);
//        
//        foreach (var location in tempLocations)
//        {
//            var obj = await Addressables.InstantiateAsync(location).Task as T;
//            
//            createdAssets.Add(obj);
//        }
//    }
//
//    public static async Task ByLabel<T>(string label, List<T> createdAssets) where T : Object
//    {
//        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
//
//        foreach (var location in locations)
//        {
//            createdAssets.Add(await Addressables.InstantiateAsync(location).Task as T);
//        }
//    }
//
//    public static async Task ByName<T>(string label, string assetName, List<T> createdObjects = null) where T : Object
//    {
//        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
//
//        foreach (var location in locations)
//        {
//            if (!location.PrimaryKey.Contains(assetName)) break;
//
//            if (createdObjects == null)
//            {
//                Addressables.InstantiateAsync(assetName); 
//            }
//            else
//            {
//                createdObjects.Add(await Addressables.InstantiateAsync(assetName).Task as T);
//            }
//        }
//    }
//
//    public static async Task SearchByLabels<T>(List<string> labels, bool removeDupes, List<T> createdObjs) where T : Object
//    {
//        IList<IResourceLocation> locations = new List<IResourceLocation>();
//
//        foreach (var label in labels)
//        {
//            foreach (var resourceLocation in await Addressables.LoadResourceLocationsAsync(label).Task) 
//                locations.Add(resourceLocation);
//        }
//
//        if (removeDupes)
//            await FindDuplicateEntries(locations, true);
//
//        if (createdObjs == null)
//        {
//            foreach (var location in locations)
//                await Addressables.InstantiateAsync(location).Task;
//        }
//        else
//        {
//            foreach (var location in locations)
//            {
//                createdObjs.Add(await Addressables.InstantiateAsync(location).Task as T);
//            }
//        }
//    }
//
//    public static async Task ContainingAllLabels<T>(List<string> labels, List<T> createdObjects = null) where T : Object
//    {
//        IList<IResourceLocation> locations = new List<IResourceLocation>();
//
//        foreach (var label in labels)
//        {
//            foreach (var resourceLocation in await Addressables.LoadResourceLocationsAsync(label).Task)
//                locations.Add(resourceLocation);
//        }
//
//        await FindDuplicateEntries(locations, false, true);
//
//        if (createdObjects == null)
//        {
//            foreach (var location in locations)
//                await Addressables.InstantiateAsync(location).Task;
//        }
//        else
//        {
//            foreach (var location in locations)
//            {
//                createdObjects.Add(await Addressables.InstantiateAsync(location).Task as T);
//            }
//        }
//    }
//
//    private static async Task FindDuplicateEntries(IList<IResourceLocation> locations, bool toRemove = false, bool toGet = false)
//    {
//       var dups = locations.GroupBy(s => s)
//            .Where(g => g.Count() > 1)
//            .Select(y => y.Key)
//            .ToList();
//
//        if (toRemove)
//            foreach (var dup in dups)
//                locations.Remove(dup);
//
//        if (toGet)
//        {
//            foreach (var dup in dups)
//                for (int i = locations.Count - 1; i >= 0; i--)
//                    if (!dup.PrimaryKey.Equals(locations[i].PrimaryKey))
//                        locations.RemoveAt(i);
//        }
//    }
//}


















