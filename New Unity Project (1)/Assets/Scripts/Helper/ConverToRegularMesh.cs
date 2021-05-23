using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class ConverToRegularMesh : MonoBehaviour
{
    [ContextMenu("Conver to regular mesh")]
    void Convert()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
        meshRenderer.sharedMaterials = skinnedMeshRenderer.sharedMaterials;
        DestroyImmediate(skinnedMeshRenderer);
        DestroyImmediate(this);
    }
}
