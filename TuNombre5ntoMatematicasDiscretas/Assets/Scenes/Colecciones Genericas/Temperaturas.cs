using UnityEngine;
using System.Collections.Generic;

public class Temperaturas : MonoBehaviour
{

    void NewSeason(List<float> list)
    {
        List<float> temperatura = new List<float> { 20, 25 };
        temperatura.Add(21);
        temperatura.Add(22);
        temperatura.Add(23);
        Debug.Log(temperatura.Count);
        //List<float> list2Temperatura = new List<float> { };
        temperatura.Sort();
        Debug.Log(temperatura.Count);
        temperatura.GetRange(0, 5);
        Debug.Log(temperatura.Count);
    }
    void ListInvitados()
    {
        List<string> nombres = new List<string> { "Mario", "Luigi", "Toad", "Peach", "Daisy" };
        nombres.Add("Iwata");
        nombres.Add("Kojima");
        nombres.Add("Juasjuasjuas");
        nombres.Add("Regi");
        foreach (var invitado in nombres)
        {
            string Link;
            if (nombres.Contains("Link"))
            {

            }
            Debug.Log(invitado);
            return;
        }
        nombres.Remove("Juasjuasjuas");
    }
}
