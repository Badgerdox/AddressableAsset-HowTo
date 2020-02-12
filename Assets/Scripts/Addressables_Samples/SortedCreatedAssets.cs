  using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SortedCreatedAssets : MonoBehaviour
{
    [SerializeField] private string[] _labels;

    private void Start()
    {
        SortWaitToComplete(_labels);
    }

    private async Task SortWaitToComplete(List<string> labels)
    {
        var locations = await Addressables.LoadResourceLocationsAsync
            (labels.ToArray(), Addressables.MergeMode.Intersection).Task;

        foreach (var location in locations)
        {
            Addressables.InstantiateAsync(location);
        }
    }
}
