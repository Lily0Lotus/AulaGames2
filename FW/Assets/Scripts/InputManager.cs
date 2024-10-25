using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Camera sceneCamera;

    private Vector3 ultimaPos;

    [SerializeField]
    private LayerMask colocar;

    public event Action OnClicked, OnExit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClicked?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnExit?.Invoke();
        }
    }

    public bool isPointerOverUI()
        => EventSystem.current.IsPointerOverGameObject();

    //detecta a posição do mouse
    public Vector3 getSelectedMousePosition()
    {
        Vector3 posMouse = Input.mousePosition;
        posMouse.z = sceneCamera.nearClipPlane;
        Ray ray = sceneCamera.ScreenPointToRay(posMouse);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, colocar))
        {
            ultimaPos = hit.point;
        }
        return ultimaPos;
    }
}
