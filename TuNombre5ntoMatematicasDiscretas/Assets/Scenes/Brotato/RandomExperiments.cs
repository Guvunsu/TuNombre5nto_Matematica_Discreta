using System.Collections.Generic;
using UnityEngine;

public class RandomExperiments : MonoBehaviour
{
    public int numbers;
    void Start()
    {
        List<float> list = new List<float>();
        List<float> list1 = new List<float>();
        List<float> list2 = new List<float>();
        for (int n = 0; n < numbers; n++)
        {
            float rand = RandomNumbers.NormalRandomNumber(10, 2);
            if (7f < rand && rand < 9f)
            {
                list.Add(rand);
            }
            if (9f < rand && rand < 11f)
            {
                list1.Add(rand);
            }
            if (11f < rand && rand < 13f)
            {
                list2.Add(rand);
            }
            if (7f < rand || rand < 9f)
            {
                list.Add(rand);
            }

        }
        Debug.Log("son estos" + list.Count);
        Debug.Log("son estos" + list1.Count);
        Debug.Log("son estos" + list2.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
