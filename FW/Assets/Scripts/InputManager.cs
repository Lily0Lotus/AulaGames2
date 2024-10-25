using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Camera sceneCamera;

    private Vector3 ultimaPos;

    [SerializeField]
    private LayerMask colocar;

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
