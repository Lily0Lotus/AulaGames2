using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class Visao : MonoBehaviour
{
    [SerializeField]
    public float alcance = 20f;
    [SerializeField]
    public float angulo = 10f;
    [SerializeField]
    public float altura = 4f;
    public Color corVi = Color.white;

    public int FreqScan = 30;
    public LayerMask layers;
    Collider[] colliders = new Collider[50];
    int count;
    float interScan;
    float tempoScan;

    Mesh mesh;

    private void Start()
    {
        interScan = 1f / FreqScan;
    }


    private void Scan()
    {
        count = Physics.OverlapSphereNonAlloc(transform.position, alcance, colliders, layers, QueryTriggerInteraction.Collide);
    }

    private void Update()
    {
        tempoScan -= Time.deltaTime;
        if (tempoScan < 0)
        {
            tempoScan += interScan;
            Scan();
        }

    }

    Mesh CriarMalha()
    {
        Mesh mesh = new Mesh();

        int numTriangulo = 8;
        int numVertices = numTriangulo * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangulos = new int[numVertices];

        Vector3 centroBaixo = Vector3.zero;
        Vector3 esquerdaBaixo = Quaternion.Euler(-angulo, 0, 0) * Vector3.right * alcance;
        Vector3 direitaBaixo = Quaternion.Euler(angulo, 0, 0) * Vector3.right * alcance;

        Vector3 centroTopo = centroBaixo + Vector3.up * altura;
        Vector3 esquerdaTopo = esquerdaBaixo + Vector3.up * altura;
        Vector3 direitaTopo = direitaBaixo + Vector3.up * altura;

        int vert = 0;

        //lado esquerdo
        vertices[vert++] = centroBaixo;
        vertices[vert++] = esquerdaBaixo;
        vertices[vert++] = esquerdaTopo;

        vertices[vert++] = esquerdaTopo;
        vertices[vert++] = centroTopo;
        vertices[vert++] = centroBaixo;

        //lado direito
        vertices[vert++] = centroBaixo;
        vertices[vert++] = centroTopo;
        vertices[vert++] = direitaTopo;

        vertices[vert++] = direitaTopo;
        vertices[vert++] = direitaBaixo;
        vertices[vert++] = centroBaixo;

        //lado distante
        vertices[vert++] = esquerdaBaixo;
        vertices[vert++] = direitaBaixo;
        vertices[vert++] = direitaTopo;

        vertices[vert++] = direitaTopo;
        vertices[vert++] = esquerdaTopo;
        vertices[vert++] = esquerdaBaixo;

        //topo
        vertices[vert++] = centroTopo;
        vertices[vert++] = esquerdaTopo;
        vertices[vert++] = direitaTopo;

        //baixo
        vertices[vert++] = centroBaixo;
        vertices[vert++] = esquerdaBaixo;
        vertices[vert++] = direitaBaixo;

        for (int i = 0; i < numVertices; i++)
        {
            triangulos[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangulos;
        mesh.RecalculateNormals();
        return mesh;
    }

    private void OnValidate()
    {
        mesh = CriarMalha();
    }

    private void OnDrawGizmosSelected()
    {
        if (mesh)
        {
            Gizmos.color = corVi;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }

        Gizmos.DrawWireSphere(transform.position, alcance);
        for (int i = 0; i < count; i++)
        {
            Gizmos.DrawSphere(colliders[i].transform.position, 0.2f);
        }
    }
}
