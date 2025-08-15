using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpellingManager : MonoBehaviour
{
    [SerializeField] private WordArray wordArray; // Holds possible words for gameplay variety
    [SerializeField] private LetterManager letterSetting; // Coordinates letter spawning logic
    [SerializeField] private TMP_Text targetWordTMP;  // Top word placeholder 
    [SerializeField] private TMP_Text progressTMP;    // Displays current progress with underscores

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
        StartNewWord(); // Ensures gameplay starts with a word loaded
    }

    private void StartNewWord()
    {
        currentWord = wordArray.GetRandomWord(); // Randomizes for replay value
        progress = new string('_', currentWord.Length).ToCharArray();

        if (targetWordTMP != null)
            targetWordTMP.text = currentWord; 

        UpdateProgressDisplay();
        letterSetting.SpawnLettersForWord(currentWord); // Populates game world with matching and distractor letters
    }

    private void OnLetterCollected(Collider2D collision)
    {
        LetterSetting letter = collision.GetComponent<LetterSetting>();
        if (letter == null) return;

        char collectedChar = letter.GetLetter();
        bool updated = false;

        // Only fills one matching slot per collection to pace game progression
        for (int i = 0; i < currentWord.Length; i++)
        {
            if (currentWord[i] == collectedChar && progress[i] == '_')
            {
                progress[i] = collectedChar;
                updated = true;
                break;  
            }
        }

        if (updated)
        {
            UpdateProgressDisplay();

            // Reloads scene on word completion to restart gameplay loop
            if (new string(progress) == currentWord)
            {
                Debug.Log("Word Complete!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

       
        Destroy(collision.gameObject); 
    }

    private void UpdateProgressDisplay()
    {
        // Spaces letters/underscores for readability
        progressTMP.text = string.Join(" ", progress);
    }

}
