using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistPosicao : MonoBehaviour
{
    [SerializeField]
    private GameObject indicadorMouse, indicadorCela;
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private Grid grid;

    [SerializeField]
    private ObjDataBaseSO database;
    private int objSelecionadoIndex = -1;

    [SerializeField]
    private GameObject visualizacaoGrade;

    private void Start()
    {
        pararPos();
    }

    public void comecarPos(int ID)
    {
        pararPos();
        objSelecionadoIndex = database.objsData.FindIndex(data => data.ID == ID);
        if (objSelecionadoIndex < 0)
        {
            Debug.LogError($"ID não encntrado {ID}");
            return;
        }
        visualizacaoGrade.SetActive(true);
        indicadorCela.SetActive(true);
        inputManager.OnClicked += PosTorre;
        inputManager.OnExit += pararPos;
    }

    private void PosTorre()
    {
        if (inputManager.isPointerOverUI())
        {
            return;
        }
        Vector3 posMouse = inputManager.getSelectedMousePosition();
        Vector3Int posGrade = grid.WorldToCell(posMouse);
        GameObject novoObj = Instantiate(database.objsData[objSelecionadoIndex].Prefab);
        novoObj.transform.position = grid.CellToWorld(posGrade);
    }

    private void pararPos()
    {
        objSelecionadoIndex = -1;
        visualizacaoGrade.SetActive(false);
        indicadorCela.SetActive(false);
        inputManager.OnClicked -= PosTorre;
        inputManager.OnExit -= pararPos;
    }

    private void Update()
    {
        if(objSelecionadoIndex < 0)
            return;
        Vector3 posMouse = inputManager.getSelectedMousePosition();
        Vector3Int posGrade = grid.WorldToCell(posMouse);
        indicadorMouse.transform.position = posMouse;
        indicadorCela.transform.position = grid.CellToWorld(posGrade);
    }
}
