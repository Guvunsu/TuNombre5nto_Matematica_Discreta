using System.Text;
using UnityEngine;

public class HillCipher : MonoBehaviour
{
    [Header("Matriz Clave")]
    [SerializeField] MatrixRow[] MatrixRow;
    int[,] MatrixColumn;

    private string alphabet = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"; // 27 letras

    private void Awake()
    {
        int n = MatrixRow.Length;
        MatrixColumn = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                MatrixColumn[i, j] = MatrixRow[i].row[j];
            }
        }
    }

    public string Encrypt(string input)
    {
        input = input.ToUpper().Replace(" ", "");

        int size = MatrixColumn.GetLength(0);
        int mod = alphabet.Length; // 27

        while (input.Length % size != 0)
            input += "X";

        string output = "";

        for (int i = 0; i < input.Length; i += size)
        {
            int[] block = new int[size];

            for (int j = 0; j < size; j++)
                block[j] = alphabet.IndexOf(input[i + j]); // soporte Ñ

            int[] result = new int[size];

            for (int row = 0; row < size; row++)
            {
                int sum = 0;
                for (int col = 0; col < size; col++)
                    sum += MatrixColumn[row, col] * block[col];

                result[row] = ((sum % mod) + mod) % mod; // módulo seguro
            }

            for (int j = 0; j < size; j++)
                output += alphabet[result[j]];
        }

        return output;
    }
}