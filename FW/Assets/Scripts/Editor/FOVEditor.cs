using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FOV))]
public class FOVEditor : Editor
{
    //cria uma esfera que é o quão longe a torre pode ver e um "cone" que é o campo de visão 
    private void OnSceneGUI()
    {
        FOV fov = (FOV)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

        Vector3 visaoAngulo1 = direcaoAngulo(fov.transform.eulerAngles.y, -fov.angulo / 2);
        Vector3 visaoAngulo2 = direcaoAngulo(fov.transform.eulerAngles.y, fov.angulo / 2);

        Handles.color = Color.blue;
        Handles.DrawLine(fov.transform.position, fov.transform.position + visaoAngulo1 * fov.radius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + visaoAngulo2 * fov.radius);

        if (fov.podeVerSombra)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position, fov.sombraRef.transform.position);
        }
    }

    //cria o ângulo de visão da torre
    Vector3 direcaoAngulo(float eulerY, float anguloEmGraus)
    {
        anguloEmGraus += eulerY;

        return new Vector3(Mathf.Sin(anguloEmGraus * Mathf.Deg2Rad), 0, Mathf.Cos(anguloEmGraus * Mathf.Deg2Rad));
    }
}
