using TMPro;
using UnityEngine;

public class HillCipherUI : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text outputText;
    [SerializeField] private HillCipher hillCipher;

    public void OnEncryptButton()
    {
        string plainText = inputField.text;
        string encrypted = hillCipher.Encrypt(plainText);
        outputText.text =  encrypted;
    }
}
