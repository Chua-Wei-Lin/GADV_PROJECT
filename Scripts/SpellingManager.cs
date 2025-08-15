using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpellingManager : MonoBehaviour
{
    [SerializeField] private WordArray wordArray;
    [SerializeField] private LetterManager letterSetting;
    [SerializeField] private TMP_Text targetWordTMP;  // Top word placeholder (optional, can hide)
    [SerializeField] private TMP_Text progressTMP;    // Underscores display

    private string currentWord;
    private char[] progress;

    private void OnEnable()
    {
        ItemDestruction.LetterCollect += OnLetterCollected;
    }

    private void OnDisable()
    {
        ItemDestruction.LetterCollect -= OnLetterCollected;
    }

    private void Start()
    {
        StartNewWord();
    }

    private void StartNewWord()
    {
        currentWord = wordArray.GetRandomWord();
        progress = new string('_', currentWord.Length).ToCharArray();

        if (targetWordTMP != null)
            targetWordTMP.text = currentWord; // Or "" if you want to hide the answer

        UpdateProgressDisplay();
        letterSetting.SpawnLettersForWord(currentWord);
    }

    private void OnLetterCollected(Collider2D collision)
    {
        LetterSetting letter = collision.GetComponent<LetterSetting>();
        if (letter == null) return;

        char collectedChar = letter.GetLetter();
        bool updated = false;

        for (int i = 0; i < currentWord.Length; i++)
        {
            if (currentWord[i] == collectedChar && progress[i] == '_')
            {
                progress[i] = collectedChar;
                updated = true;
                break;  // Stop after filling one position!
            }
        }

        if (updated)
        {
            UpdateProgressDisplay();

            if (new string(progress) == currentWord)
            {
                Debug.Log("Word Complete!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        // Optional: clear or hide the collected letter
        Destroy(collision.gameObject); // or set inactive, or fade out, etc.
    }

    private void UpdateProgressDisplay()
    {
        progressTMP.text = string.Join(" ", progress);
    }

}
