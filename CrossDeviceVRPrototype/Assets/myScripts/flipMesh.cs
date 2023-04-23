// FROM https://answers.unity.com/questions/476810/flip-a-mesh-inside-out.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class flipMesh : MonoBehaviour
{
    [ContextMenu("Flip")]
    public void FlipMeshContext()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
    }
}