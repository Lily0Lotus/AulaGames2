using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosManager : MonoBehaviour
{
    public static PosManager instance;

    public GameObject standarAlmaPrefab;

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

    private void Start()
    {
        posAlmaTorre = standarAlmaPrefab;
    }

    public GameObject pegarAlmaParaPos()
    {
        return posAlmaTorre;
    }
}
