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


    private void Update()
    {
        Vector3 posMouse = inputManager.getSelectedMousePosition();
        Vector3Int posGrade = grid.WorldToCell(posMouse);
        indicadorMouse.transform.position = posMouse;
        indicadorCela.transform.position = grid.CellToWorld(posGrade);
    }
}
