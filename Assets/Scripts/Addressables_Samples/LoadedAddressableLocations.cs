using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceLocations;

public class LoadedAddressableLocations : MonoBehaviour
{
    [SerializeField] private string _label;
    
    public IList<IResourceLocation> AssetLocations { get; } = new List<IResourceLocation>();

    private void Start()
    {
        InitAndWaitUntilLocLoaded(); 
    }

    private async Task InitAndWaitUntilLocLoaded()
    {
        await AddressableLocationLoader.GetAll(_label, AssetLocations);

        foreach (var location in AssetLocations)
        {
            //ASSET LOCATION FULLY LOADED
            Debug.Log(location.PrimaryKey);
        }
    }
}
