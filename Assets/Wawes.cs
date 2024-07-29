using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wawes : MonoBehaviour
{
    public int Dimension = 10;
    public Octave[] Octaves;
    protected MeshFilter MeshFilter;
    protected Mesh Mesh;

    // Start is called before the first frame update
    void Start()
    {
        MeshFilter = gameObject.GetComponent<MeshFilter>();
        if (MeshFilter == null)
        {
            MeshFilter = gameObject.AddComponent<MeshFilter>();
        }

        Mesh = new Mesh();
        Mesh.name = gameObject.name;

        Mesh.vertices = GenerateVerts();
        Mesh.triangles = GenerateTris();
        Mesh.RecalculateBounds();
        Mesh.RecalculateNormals();

        MeshFilter.mesh = Mesh;
    }

    private Vector3[] GenerateVerts()
    {
        var verts = new Vector3[(Dimension + 1) * (Dimension + 1)];
        for (int x = 0; x <= Dimension; x++)
        {
            for (int z = 0; z <= Dimension; z++)
            {
                verts[Index(x, z)] = new Vector3(x, 0, z);
            }
        }
        return verts;
    }

    private int Index(int x, int z)
    {
        return x * (Dimension + 1) + z;
    }

    private int[] GenerateTris()
    {
        var tris = new int[Dimension * Dimension * 6];
        int triIndex = 0;

        for (int x = 0; x < Dimension; x++)
        {
            for (int z = 0; z < Dimension; z++)
            {
                tris[triIndex + 0] = Index(x, z);
                tris[triIndex + 1] = Index(x + 1, z + 1);
                tris[triIndex + 2] = Index(x + 1, z);
                tris[triIndex + 3] = Index(x, z);
                tris[triIndex + 4] = Index(x, z + 1);
                tris[triIndex + 5] = Index(x + 1, z + 1);

                triIndex += 6;
            }
        }
        return tris;
    }

    // Update is called once per frame
    void Update()
    {
        var verts = Mesh.vertices;
        for (int x = 0; x <= Dimension; x++)
        {
            for (int z = 0; z <= Dimension; z++)
            {
                var y = 0f;
                for (int o = 0; o < Octaves.Length; o++)
                {
                    if (Octaves[o].alternate)
                    {
                        var perl = Mathf.PerlinNoise((x * Octaves[o].scale.x) / Dimension, (z * Octaves[o].scale.y) / Dimension) * Mathf.PI * 2f;
                        y += Mathf.Cos(perl + Octaves[o].speed.magnitude * Time.time) * Octaves[o].height;
                    }
                    else
                    {
                        var perl = Mathf.PerlinNoise((x * Octaves[o].scale.x + Time.time * Octaves[o].speed.x) / Dimension, (z * Octaves[o].scale.y + Time.time * Octaves[o].speed.y) / Dimension) - 0.5f;
                        y += perl * Octaves[o].height;
                    }
                }
                verts[Index(x, z)] = new Vector3(x, y, z);
            }
        }
        Mesh.vertices = verts;
        Mesh.RecalculateNormals(); // To ensure normals are updated for lighting
    }

    [Serializable]
    public struct Octave
    {
        public Vector2 speed;
        public Vector2 scale;
        public float height;
        public bool alternate;
    }
}
