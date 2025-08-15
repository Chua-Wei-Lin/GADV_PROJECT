using TMPro;
using UnityEngine;

public class LetterSetting : MonoBehaviour
{
    [SerializeField] private TMP_Text textDisplay;

    private char storedLetter;

    public void SetLetter(char letter)
    {
        storedLetter = letter; // Store logically so game can check letter value without reading from UI text
        if (textDisplay != null)
        {
            textDisplay.text = letter.ToString(); // Updates visible representation so players see it immediately
        }
    }

    public char GetLetter()
    {
        // Encapsulates letter access so future changes to storage don't break other scripts
        return storedLetter;
    }
}
