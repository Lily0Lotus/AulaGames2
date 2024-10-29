using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public Color hoverColor;

    private GameObject alma;

    private Renderer rend;
    private Color corIni;

    PosManager posManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        corIni = rend.material.color;
        posManager = PosManager.instance;
    }

    private void OnMouseDown()
    {
        if (posManager.pegarAlmaParaPos() == null)
            return;

        if (alma != null)
        {
            Debug.Log("Vai colocar na puta que pariu; para fazer: mostrar na tela");
            return;
        }

        //posiciona uma torre
        GameObject posAlmaTorre = PosManager.instance.pegarAlmaParaPos();
        alma = (GameObject)Instantiate(posAlmaTorre, transform.position, transform.rotation);

    }
    private void OnMouseEnter()
    {
        if (posManager.pegarAlmaParaPos() == null)
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = corIni;
    }
}
