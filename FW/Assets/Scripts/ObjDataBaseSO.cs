using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjDataBaseSO : ScriptableObject
{
    public List<ObjetoData> objsData;
}

[Serializable]
public class ObjetoData
{
    [field: SerializeField]
    public string Nome { get; private set; }

    [field: SerializeField]
    public int ID { get; private set; }

    [field: SerializeField]
    public Vector2Int Tam { get; private set; } = Vector2Int.one;

    [field: SerializeField]
    public GameObject Prefab { get; private set; }
}