using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SkinnedMeshToMesh : MonoBehaviour
{

    public SkinnedMeshRenderer skinnedMesh;
    public VisualEffect VFXGraph;
    public float refreshRate = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (UpdateVFXGraph());
    }

    IEnumerator UpdateVFXGraph()
    {
        while (gameObject.activeSelf)
        {
            Mesh m = new Mesh();
            skinnedMesh.BakeMesh(m);
            Vector3[] vertices = m.vertices;
            //To fix a potential bug
            Mesh m2 = new Mesh();
            m2.vertices = vertices;
            VFXGraph.SetMesh("Mesh", m2); //String Reference to VFX graph

            yield return new WaitForSeconds (refreshRate);
        }
    }
}
