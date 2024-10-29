using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class painelAlmas : MonoBehaviour
{
    PosManager posManager;

    private void Start()
    {
        posManager = PosManager.instance;
    }

    public void selecionarPastola()
    {
        Debug.Log("Pastola selecionado");
        posManager.SetTorrePos(posManager.pastolaAlmaPrefab);
    }

    public void selecionarRaizExplosiva()
    {
        Debug.Log("Raiz explosiva selecionada");
        posManager.SetTorrePos(posManager.raizExplosivaAlmaPrefab);
    }
}
