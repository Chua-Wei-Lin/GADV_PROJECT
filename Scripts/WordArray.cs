using UnityEngine;
using TMPro;

public class WordArray : MonoBehaviour
{
    [SerializeField] private string[] words;

    public string GetRandomWord()
    {
        if (words == null || words.Length == 0)
        {
            Debug.LogError("WordArray: No words set!");
            return "DEFAULT";
        }

        return words[Random.Range(0, words.Length)].ToUpper();
    }
}
