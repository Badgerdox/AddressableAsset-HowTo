using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CGTests : MonoBehaviour
{
    [SerializeField] private int amt;
    [SerializeField] private string label;
    [SerializeField] private bool useAssets;
    [SerializeField] private GameObject prefab;
    
    void Start()
    {
        if (useAssets)
        {
            SpawnThenRemoveAA(amt, label); 
        }
        else
        {
            StartCoroutine(SpawnThenRemoveGO(amt, label, prefab));
        }
    }
    
    public async Task SpawnThenRemoveAA(int amt, string label)
    {
        var location = await Addressables.LoadResourceLocationsAsync(label).Task;
        var objs = new List<GameObject>();

        for (int i = 0; i < amt; i++)
            objs.Add(await Addressables.InstantiateAsync(location[0]).Task);

        await Task.Delay(TimeSpan.FromSeconds(5));

        foreach (var obj in objs)
            Addressables.Release(obj);
    }

    public IEnumerator SpawnThenRemoveGO(int amt, string label, GameObject prefab)
    {
        var objs = new List<GameObject>();
        
        for (int i = 0; i < amt; i++)
            objs.Add(Instantiate(prefab));
        
        yield return new WaitForSeconds(5);

        foreach (var obj in objs)
            Destroy(obj);
    }
}
