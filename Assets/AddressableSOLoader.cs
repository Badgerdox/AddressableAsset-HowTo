using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AddressableSOLoader : MonoBehaviour
{
    private string label = "SO";
    [SerializeField] private ScriptableObject TestObj;
    [SerializeField] private Text debug_Txt;
    [SerializeField] private GameObject obj;

    [SerializeField] private Button goBtn;
    [SerializeField] private Button aABtn;
    
    void Start()
    {
       goBtn.onClick.AddListener(() => CreateSO(false));
        aABtn.onClick.AddListener(() => CreateSO(true));
    }
    
    private async Task CreateSO(bool isAA)
    {
        if (isAA)
        {
            var location = await Addressables.LoadResourceLocationsAsync("prefab").Task;
            var gos = new List<GameObject>();
            
            for (int i = 0; i < 500; i++)
            {
                gos.Add(await Addressables.InstantiateAsync(location[0]).Task);
                await Task.Delay(1);
            }

            await Task.Delay(TimeSpan.FromSeconds(2));

            foreach (var go in gos)
            {
                Addressables.Release(go);
                await Task.Delay(1);
            }
        }
        else
        {
            var gos = new List<GameObject>();
            for (int i = 0; i < 500; i++)
            {
                gos.Add(Instantiate(obj));
                await Task.Delay(1);
            }

            await Task.Delay(TimeSpan.FromSeconds(2));

            foreach (var go in gos)
            {
                Destroy(go);
                await Task.Delay(1);
            }
                
        }
    }
}
