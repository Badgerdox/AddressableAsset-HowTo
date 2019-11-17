using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceLocations;

public class LoadedAddressableLocations : MonoBehaviour
{
    [SerializeField] private string _label;
    
    public IList<IResourceLocation> AssetLocations { get; } = new List<IResourceLocation>();

    private void Start()
    {
        InitAndWaitUntilLoaded(_label);
    }

    public async Task InitAndWaitUntilLoaded(string label)
    {
        await AddressableLocationLoader.GetAll(label, AssetLocations);

        foreach (var location in AssetLocations)
        {
            //ASSET IS NOW FULLY LOADED
            //Debug.Log(location.PrimaryKey);
        }
    }
}
