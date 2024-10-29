using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosManager : MonoBehaviour
{
    public static PosManager instance;

    public GameObject pastolaAlmaPrefab;
    public GameObject raizExplosivaAlmaPrefab;

    private GameObject posAlmaTorre;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Tem mais de um nessa porra aqui");
            return;
        }
            
        instance = this;
    }

    public GameObject pegarAlmaParaPos()
    {
        return posAlmaTorre;
    }

    public void SetTorrePos(GameObject alma)
    {
        posAlmaTorre = alma;
    }
}
