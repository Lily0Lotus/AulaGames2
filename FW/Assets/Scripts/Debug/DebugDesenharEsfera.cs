using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDesenharEsfera : MonoBehaviour
{
    //desenha uma esfera
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.05f);
    }
}
