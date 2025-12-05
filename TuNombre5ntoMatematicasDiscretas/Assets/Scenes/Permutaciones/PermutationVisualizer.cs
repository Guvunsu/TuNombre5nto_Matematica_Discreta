using UnityEngine;

public class PermutationVisualizer : MonoBehaviour
{
    [Header("Prefabs (máximo 8 prefabs)")]
    public GameObject[] objectPrefabs;

    [Header("Offsets en la escena")]
    public float xSpacing = 2f;
    public float zSpacing = 3f;

    HeapPermutations heap;

    void Start()
    {
        heap = GetComponent<HeapPermutations>();

        int n = objectPrefabs.Length;

        if (n < 1)
        {
            Debug.LogError("Debes asignar al menos 1 prefab.");
            return;
        }
        if (n > 8)
        {
            Debug.LogWarning("Se recomienda máximo 8 objetos (40,320 permutaciones).");
        }

        heap.GeneratePermutations(n);
        Visualize();
    } 

    void Visualize()
    {
        int row = 0;

        foreach (var permutation in heap.permutations)
        {
            for (int i = 0; i < permutation.Count; i++)
            {
                GameObject prefab = objectPrefabs[permutation[i]];
                Vector3 pos = new Vector3(i * xSpacing, 0, row * -zSpacing);
                Instantiate(prefab, pos, Quaternion.identity, transform);
            }

            row++;
        }
    }
}
