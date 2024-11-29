using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelecionar : MonoBehaviour
{
    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 posMouse= Input.mousePosition;
        posMouse.z = 100f;
        posMouse = cam.ScreenToWorldPoint(posMouse);
        Debug.DrawRay(transform.position, posMouse - transform.position,Color.blue);
    }
}
