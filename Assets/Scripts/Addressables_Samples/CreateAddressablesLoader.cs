using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;

public static class CreateAddressablesLoader
{
    public static async Task InitAssets<T>(string assetNameOrLabel, List<T> createdAssets)
        where T : Object
    {
        var locations = await Addressables.LoadResourceLocationsAsync(assetNameOrLabel).Task;
            foreach (var location in locations)
                createdAssets.Add(await Addressables.InstantiateAsync(location).Task as T);
    }
    
    public static async Task ByLoadedAddress<T>(IList<IResourceLocation> loadedLocations, List<T> createdObjs)
    where T : Object
    {
        foreach (var location in loadedLocations)
        {
            var obj = await Addressables.InstantiateAsync(location).Task as T;
            createdObjs.Add(obj);
        }
    }

    public static async Task HasAllLabels<T>(List<string> labels, bool removeDupes, List<T> createdObjs) where T : Object
    {
        IList<IResourceLocation> locations = new List<IResourceLocation>();

        foreach (var label in labels)
        {
            foreach (var resourceLocation in await Addressables.LoadResourceLocationsAsync(label).Task) 
                locations.Add(resourceLocation);
        }

        if (removeDupes)
            await FindDuplicateEntries(locations, true);
        
        foreach (var location in locations)
        {
            createdObjs.Add(await Addressables.InstantiateAsync(location).Task as T);
        }
    }
    
    public static async Task BySpecificLabels<T>(List<string> labels, List<T> createdObjects) where T : Object
    {
        IList<IResourceLocation> locations = new List<IResourceLocation>();

        foreach (var label in labels)
        {
            var tempLoc = await Addressables.LoadResourceLocationsAsync(label).Task;
            locations = tempLoc.ToList();
        }
        
        foreach (var location in locations)
            createdObjects.Add(await Addressables.InstantiateAsync(location).Task as T);
    }

    private static async Task FindDuplicateEntries(IList<IResourceLocation> locations, bool toRemove = false, bool toGet = false)
    {
       var dups = locations.GroupBy(s => s)
            .Where(g => g.Count() > 1)
            .Select(y => y.Key)
            .ToList();

        if (toRemove)
            foreach (var dup in dups)
                locations.Remove(dup);
    }
}














