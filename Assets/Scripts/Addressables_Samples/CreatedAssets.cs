using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CreatedAssets : MonoBehaviour
{
  private LoadedAddressableLocations _loadedLocations;
  
  [SerializeField] private List<GameObject> Assets { get; } = new List<GameObject>();

  private void Start()
  {
    CreateAndWaitUntilCompleted();
  }

  private async Task CreateAndWaitUntilCompleted()
  {
    _loadedLocations = GetComponent<LoadedAddressableLocations>();

    await Task.Delay(TimeSpan.FromSeconds(1));

    await CreateAddressablesLoader.ByLoadedAddress(_loadedLocations.AssetLocations, Assets);

    foreach (var asset in Assets)
    {
      Debug.Log(asset.name);
    }
  }
  
  
  
}



























//    //await CreateAddressablesLoader.ByAddress(_label, Assets);
//        //await CreateAddressablesLoader.ByName(_label, "Circle", Assets);
//        //await CreateAddressablesLoader.ByLabel(_label, Assets);
//        //await CreateAddressablesLoader.SearchByLabels(_labels, true, Assets);
//        await CreateAddressablesLoader.ContainingAllLabels(_labels, Assets);
//        
//        //OBJECT(S) NOW FULLY LOADED
//        AfterLoadActions();
//    }
//
//    private void AfterLoadActions()
//    {
//        foreach (var asset in Assets)
//        {
//            //asset.transform.SetParent(GetComponent<Transform>());
//            //asset.SetActive(false);
//        }
//    }
//
//    private void ClearAsset(GameObject go)
//    {
//        Addressables.Release(go);
//    }
//
//    private void ClearAssets(List<GameObject> gos)
//    {
//        foreach (var go in gos)
//        {
//            Addressables.Release(go);
//        }
//    }
//}
