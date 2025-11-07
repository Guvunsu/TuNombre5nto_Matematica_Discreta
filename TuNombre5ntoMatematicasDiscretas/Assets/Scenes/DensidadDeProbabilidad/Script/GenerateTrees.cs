using UnityEngine;

public class GenerateTrees : MonoBehaviour
{
    //RandomNumbers script_RandomNumbers;
    [SerializeField] GameObject treePrefab;
    [SerializeField] float mu = 0.5f;
    [SerializeField] float sigma = 0.1f;

    void Start()
    {
        GenerateTreesInTerritory(mu, sigma);
    }

    // Update is called once per frame
    void Update()
    {

    }
     public void GenerateTreesInTerritory(float mu, float sigma)
    {

        for (int x = 0; x < 11; x++)
        {
            for (int z = 0; z < 11; z++)
            {
                // no hacerlo aleatorios porque se me encima con los otros arboles
                float randomY = RandomNumbers.NormalRandomNumber(0.25f, 0.5f);
                GameObject tree = Instantiate(treePrefab, new Vector3(x, 0, z), Quaternion.identity);
                Vector3 scaleY = new Vector3(0.25f, randomY, 0.25f);
                tree.transform.localScale = new Vector3(0.25f, randomY, 0.25f);
            }
        }
    }
}
