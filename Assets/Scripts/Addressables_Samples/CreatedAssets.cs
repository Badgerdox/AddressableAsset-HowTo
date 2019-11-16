using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CreatedAssets : MonoBehaviour
{
    private LoadedAddressableLocations _loadedLocations;
    
    [SerializeField] private string _label;
    [SerializeField] private List<string> _labels = new List<string>();
    [field: SerializeField] public List<GameObject> Assets { get; private set; } = new List<GameObject>();

    void Start()
    {
        
        CreateAndWaitUntilComplete();
    }

    private async void CreateAndWaitUntilComplete()
    {
        //Takes a pre-loaded locations
        //_loadedLocations = GetComponent<LoadedAddressableLocations>();
        //await Task.Delay(TimeSpan.FromSeconds(.5f));
        //await CreateAddressablesLoader.ByAddress(_label, _loadedLocations.AssetLocations, Assets);
          
        //await CreateAddressablesLoader.ByAddress(_label, Assets);
        //await CreateAddressablesLoader.ByName(_label, "Circle", Assets);
        //await CreateAddressablesLoader.ByLabel(_label, Assets);
        //await CreateAddressablesLoader.SearchByLabels(_labels, true, Assets);
        await CreateAddressablesLoader.ContainingAllLabels(_labels, Assets);
        
        //OBJECT(S) NOW FULLY LOADED
        AfterLoadActions();
    }

    private void AfterLoadActions()
    {
        foreach (var asset in Assets)
        {
            //asset.transform.SetParent(GetComponent<Transform>());
            //asset.SetActive(false);
        }
    }

    private void ClearAsset(GameObject go)
    {
        Addressables.Release(go);
    }

    private void ClearAssets(List<GameObject> gos)
    {
        foreach (var go in gos)
        {
            Addressables.Release(go);
        }
    }
}
