using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterManager : MonoBehaviour
{

    [SerializeField] private List<TextMeshProUGUI> textList;

    public void SpawnLettersForWord(string word)
    {
        for (int i = 0; i < textList.Count; i++)
        {
            if (i < word.Length)
            {
                char letter = word[i];
                textList[i].text = letter.ToString(); // Show the letter

                // Set the logical letter in the slot
                LetterSetting display = textList[i].GetComponent<LetterSetting>();
                if (display != null)
                {
                    display.SetLetter(letter);
                }
            }
            else
            {
                // Optional: show distractor or clear
                char randomLetter = (char)('A' + Random.Range(0, 26));
                textList[i].text = randomLetter.ToString();

                LetterSetting display = textList[i].GetComponent<LetterSetting>();
                if (display != null)
                {
                    display.SetLetter(randomLetter);
                }
            }
        }
    }
    
}
