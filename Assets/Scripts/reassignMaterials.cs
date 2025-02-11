using UnityEngine;

public class ReassignMaterials : MonoBehaviour
{
    public Material defaultMaterial;

    void Start()
    {
        Renderer[] renderers = FindObjectsOfType<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            for (int i = 0; i < renderer.sharedMaterials.Length; i++)
            {
                if (renderer.sharedMaterials[i] == null)
                {
                    renderer.sharedMaterials[i] = defaultMaterial;
                }
            }
        }
    }
}
