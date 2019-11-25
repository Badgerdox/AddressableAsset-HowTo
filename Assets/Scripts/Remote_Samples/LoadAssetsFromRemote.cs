using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadAssetsFromRemote : MonoBehaviour
{
    [SerializeField] private string _label;

    private void Start()
    {
        Get(_label);
    }

    private async Task Get(string label)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;

        foreach (var location in locations)
        {
            await Addressables.InstantiateAsync(location).Task;
        }
    }
}
