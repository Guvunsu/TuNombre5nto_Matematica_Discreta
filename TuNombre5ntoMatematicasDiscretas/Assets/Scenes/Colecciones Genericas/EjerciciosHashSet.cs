using System.Collections.Generic;
using UnityEngine;

public class EjerciciosHashSet : MonoBehaviour
{
    void Start()
    {
        EstudiantesEnDosCursos();
        //ProductosEnDosSucursales();
        //CancionesEnComun();
    }

    void EstudiantesEnDosCursos()
    {
        HashSet<string> cursoProgramacion = new HashSet<string>()
        {
            "Ana", "Carlos", "Luis", "María", "Pedro"
        };

        HashSet<string> cursoBasesDatos = new HashSet<string>()
        {
            "Luis", "María", "Jorge", "Elena", "Sofía"
        };

        HashSet<string> estudiantesEnAmbos = new HashSet<string>(cursoProgramacion);
        estudiantesEnAmbos.IntersectWith(cursoBasesDatos);

        Debug.Log("Estudiantes inscritos en ambos cursos (Programación y Bases de Datos):");
        if (estudiantesEnAmbos.Count > 0)
        {
            foreach (string estudiante in estudiantesEnAmbos)
            {
                Debug.Log(estudiante);
            }
        } else
        {
            Debug.Log("No hay estudiantes inscritos en ambos cursos.");
        }
    }
    void ProductosEnDosSucursales()
    {
        HashSet<string> tiendaA = new HashSet<string>()
        {
            "Pan", "Leche", "Huevos", "Arroz", "Pasta"
        };

        HashSet<string> tiendaB = new HashSet<string>()
        {
            "Leche", "Pasta", "Refresco", "Carne", "Azúcar"
        };

        HashSet<string> soloEnA = new HashSet<string>(tiendaA);
        soloEnA.ExceptWith(tiendaB);

        Debug.Log("Productos que SOLO están disponibles en la tienda A:");
        if (soloEnA.Count > 0)
        {
            foreach (string producto in soloEnA)
            {
                Debug.Log(producto);
            }
        } else
        {
            Debug.Log("Todos los productos de la tienda A también están en la tienda B.");
        }
    }
    void CancionesEnComun()
    {
        HashSet<string> listaAmigo1 = new HashSet<string>()
        {
            "Thunderstruck - AC/DC",
            "Bohemian Rhapsody - Queen",
            "Shape of You - Ed Sheeran",
            "Blinding Lights - The Weeknd"
        };

        HashSet<string> listaAmigo2 = new HashSet<string>()
        {
            "Shape of You - Ed Sheeran",
            "Smells Like Teen Spirit - Nirvana",
            "Billie Jean - Michael Jackson",
            "Bohemian Rhapsody - Queen"
        };

        HashSet<string> cancionesEnComun = new HashSet<string>(listaAmigo1);
        cancionesEnComun.IntersectWith(listaAmigo2);

        if (cancionesEnComun.Count > 0)
        {
            Debug.Log("Canciones en común entre las listas de los amigos:");
            foreach (string cancion in cancionesEnComun)
            {
                Debug.Log(cancion);
            }
        } else
        {
            Debug.Log("No hay canciones compartidas entre las dos listas de reproducción.");
        }

    }
}
