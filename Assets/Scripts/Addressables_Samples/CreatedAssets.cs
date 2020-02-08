using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = System.Object;

public class CreatedAssets : MonoBehaviour
{
    [SerializeField] private string _label;
    private List<GameObject> Assets { get; } = new List<GameObject>();

    private void Start()
    {
        CreateAndWaitUntilComplete();
    }

    private async Task CreateAndWaitUntilComplete()
    {
        await CreateAddressablesLoader.InitByNameOrLabel(_label, Assets);

        foreach (var asset in Assets)
        {
            //Asset is now fully loaded
            Debug.Log("Loaded asset: " + asset.name);
        }

        Task.Delay(TimeSpan.FromSeconds(5));

        CleanUpFinishedAssets(Assets[0]);
    }

    private async Task CleanUpFinishedAssets(Object obj)
    {
        Addressables.Release(obj);
    }
    
}
