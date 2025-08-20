using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.EventSystems.EventTrigger;

public class GraphRepresentations : MonoBehaviour {
    #region Variables
    [Header("Prefabs")]
    [SerializeField] GameObject nodo;
    [SerializeField] GameObject arista;

    [Header("Listas")]
    List<string> nodeNames = new List<string>();
    List<Vector3> nodePositions = new List<Vector3>();
    List<(string, string)> connectionList = new List<(string, string)>();

    Dictionary<string, List<string>> adjList = new Dictionary<string, List<string>>();

    #endregion Variables

    #region PublicMethods
    void Start() {
        CrearGrafo();
    }
    #endregion PublicMethods

    #region Grafo

    #region CrearGrafo
    public void CrearGrafo() {
        // Resetear listas para no duplicar
        nodeNames.Clear();
        nodePositions.Clear();

        // Definir lista de conexiones
        connectionList = new List<(string, string)> {
            ("A","C"), ("A","D"), ("A","B"), ("A","E"),
            ("F","G"), ("F","H"), ("F","E"),
            ("E","F"), ("E","A"),
            ("B","A"), ("B","G"),
            ("G","B"), ("G","F"),
            ("H","F"),
            ("D","A"),
            ("C","A")
        };

        // Definir lista de adyacencia
        adjList.Clear();
        adjList.Add("A", new List<string> { "C", "D", "B", "E" });
        adjList.Add("B", new List<string> { "A", "G" });
        adjList.Add("C", new List<string> { "A" });
        adjList.Add("D", new List<string> { "A" });
        adjList.Add("E", new List<string> { "F", "A" });
        adjList.Add("F", new List<string> { "G", "H", "E" });
        adjList.Add("G", new List<string> { "B", "F" });
        adjList.Add("H", new List<string> { "F" });

        // Instanciar
        CrearNodos();
        CrearAristas();
    }
    #endregion CrearGrafo

    #region CrearNodos
    void CrearNodos() {
        float radius = 5f; //radio de mi esfera
        int index = 0; //contador de nodos

        //recorre cada nodo dentro del diccionario adjList
        foreach (string node in adjList.Keys) {
            float angle = index * Mathf.PI * 2 / adjList.Count; // calculo el angulo de los nodos para distribuirlos
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius; //convoerte el angulos X y Y dentro del obj.

            //guardar en listas el nombre y su posicion
            nodeNames.Add(node);
            nodePositions.Add(pos);

            //invoco el gameobject en la posicion calculada
            Instantiate(nodo, pos, Quaternion.identity).name = node;

            index++;
        }
    }
    #endregion CrearNodos

    #region CrearArista
    void CrearAristas() {
        //recorro la lista connectionList
        foreach (var edge in connectionList) {
            //busca inidce en los nodos dentro de la lista de nombres
            int indexA = nodeNames.IndexOf(edge.Item1);
            int indexB = nodeNames.IndexOf(edge.Item2);
            //se obtiene la posicion de la lista de posiciones 
            Vector3 posA = nodePositions[indexA];
            Vector3 posB = nodePositions[indexB];

            // se instancia el objeto y la configuracion del lr
            GameObject edgeObj = Instantiate(arista);
            LineRenderer lr = edgeObj.GetComponent<LineRenderer>();
            //grosores
            lr.startWidth = 0.05f;
            lr.endWidth = 0.05f;
            //puntos en el plano 
            lr.SetPosition(0, posA);
            lr.SetPosition(1, posB);
        }
    }
    #endregion CrearArista

    #endregion Grafo
}
