using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOTEST", menuName = "SO_Test_Obj")]
public class SO_TEST : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private int age;
}
