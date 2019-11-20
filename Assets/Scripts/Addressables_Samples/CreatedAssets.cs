using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

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
        await CreateAddressablesLoader.InitAssets(_label, Assets);

        foreach (var asset in Assets)
        {
            //Asset is now fully loaded
            Debug.Log("Loaded asset: " + asset.name);
        }
    }
}


































//[SerializeField] private string _assetName;
//[SerializeField] private string _label;
//[SerializeField] private List<string> _labels = new List<string>();
//
//[SerializeField] private List<GameObject> Assets { get; } = new List<GameObject>();
//
//private void Start()
//{
//CreateAndWaitUntilCompleted();
//}
//
//private async Task CreateAndWaitUntilCompleted()
//{
////await CreateAddressablesLoader.InitAssets(_assetName, Assets);
////await CreateAddressablesLoader.HasAllLabels(_labels, true, Assets);
//await CreateAddressablesLoader.BySpecificLabels(_labels, Assets);
//
//    foreach (var asset in Assets)
//{
//    //Asset is now loaded perform additional operations
//    Debug.Log(asset.name);
//}
//}


