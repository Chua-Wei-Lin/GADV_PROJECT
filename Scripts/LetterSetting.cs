using TMPro;
using UnityEngine;

public class LetterSetting : MonoBehaviour
{
    [SerializeField] private TMP_Text textDisplay;

    private char storedLetter;

    public void SetLetter(char letter)
    {
        storedLetter = letter;
        if (textDisplay != null)
        {
            textDisplay.text = letter.ToString();
        }
    }

    public char GetLetter()
    {
        return storedLetter;
    }
}
