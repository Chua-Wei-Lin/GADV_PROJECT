using UnityEngine;
using TMPro;

public class WordArray : MonoBehaviour
{
    [SerializeField] private string[] words;

    public string GetRandomWord()
    {
        // Validates that a word list exists to prevent runtime errors
        if (words == null || words.Length == 0)
        {
            Debug.LogError("WordArray: No words set!");
            return "DEFAULT";
        }

        // Uses Random.Range for even distribution and ensures uppercase for consistency
        return words[Random.Range(0, words.Length)].ToUpper();
    }
}
