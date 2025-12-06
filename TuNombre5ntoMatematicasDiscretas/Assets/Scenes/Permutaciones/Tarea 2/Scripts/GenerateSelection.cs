using System.Collections.Generic;
using UnityEngine;

public class GenerateSelection : MonoBehaviour
{
    public int numberCards = 52;
    public int numberHand = 5;

    private List<int> elements = new List<int>();
    private int currentHand = 0; 

    void Start()
    {
        //inicializo desde el cero hasta menor que 52, osea 51 cartas de la baraja
        for (int n = 0; n < numberCards; n++)
        {
            elements.Add(n);
        }
    }

    void Update()
    {
        // si apreto clcik del mouse o Barra espaciadora 
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            // sucedera si mi mano es mmenor a 10
            if (currentHand < 10)
            {
                //llamo a mi funcion GenerateHand
                GenerateHand();
                //se va acumular mi mano 1 en 1
                currentHand++;
                //si no =>
            } else
            {
                Debug.Log("Ya se generaron las 10 manos.");
            }
        }
    }

    void GenerateHand()
    {
        //Una lista el cual guardara 5 cartas aleatorias gracias a la funcion Selection() establecido por la cantidad de numberHand
        List<int> selection = Selection(numberHand);
        //una variable string para usarlo en la consola y dibujo lo que mostrara
        string handString = "Mano #" + (currentHand + 1) + ": ";
        //recorro 5 cartas 
        for (int i = 0; i < selection.Count; i++)
        {
            //se vuelve una cadena de texto para la consola y cuales fueron las cartas
            handString += selection[i].ToString() + ", ";
        }
        //muestro cuales fueron en la consola 
        Debug.Log(handString);
    }

    // Selecciona k elementos sin repetir
    public List<int> Selection(int k)
    {
        //forma una lista el cual guardara mis resultados sacados
        List<int> result = new List<int>();
        //mientras mi cantidad de mi resultadoi es menor que K, osea 5, seguira generando numeroes sin repetir cartas/numeros 
        while (result.Count < k)
        {
            //genero aleatoriamente numeros enteros de 0 a 52 cartas de la baraja española
            int randomIndex = Random.Range(0, elements.Count);
            //guardo en un entero ese numero aleatorio previamente en la lista de elementos 
            int randomElement = elements[randomIndex];
            //si el numero aleatorio todavia no esta en la lista
            if (!result.Contains(randomElement))
            {
                //lo agrego 
                result.Add(randomElement);
            }
        }

        return result;
    }
}