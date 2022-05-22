using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh myMesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize;
    public int zSize;
    public float ySize;

    GameObject[] verticerigidbodies;
    public GameObject verticeBody;
    // Start is called before the first frame update
    void Start()
    {
        myMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = myMesh;
        GetComponent<MeshCollider>().sharedMesh = myMesh;
        CreateShape();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1)*(zSize+1)];
        verticerigidbodies = new GameObject[(xSize+1)*(zSize+1)];
        for(int i = 0, z =0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * 0.1f, z * 0.1f) * ySize;
                vertices[i] = new Vector3(x, y, z);
                if (!verticerigidbodies[i])
                {
                    verticerigidbodies[i] = Instantiate(verticeBody, vertices[i] + this.transform.position, Quaternion.Euler(0f, 0f, 0f));
                    //verticerigidbodies[i].GetComponent<RelatedMesh>().mymeshcoörds = this.transform.position;
                }
                i++;
            }
        }
        triangles = new int[xSize*zSize*6];
        int vert = 0;
        int tris = 0;

        for(int z =0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris] = vert;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
                vert++;
                tris += 6;

            }
            vert++;
        }
    }

    void UpdateMesh()
    {
        myMesh.Clear();

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[i] = verticerigidbodies[i].GetComponent<Rigidbody>().position-this.transform.position;
                i++;
            }
        }

        myMesh.vertices = vertices;
        myMesh.triangles = triangles;

        myMesh.RecalculateNormals();


    }

    

}
