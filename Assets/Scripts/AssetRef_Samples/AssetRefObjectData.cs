using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetRefObjectData : MonoBehaviour
{
    [SerializeField] private AssetReference _sqrARef;
    [SerializeField] private List<AssetReference> _references = new List<AssetReference>();
    [SerializeField] private List<GameObject> _objects = new List<GameObject>();
    void Start()
    {
        _references.Add(_sqrARef);

        StartCoroutine(LoadAndWaitUntilComplete());
    }

    private IEnumerator LoadAndWaitUntilComplete()
    {
       yield return AssetRefLoader.CreateAssetsAddToList(_references, _objects);
    }
}
