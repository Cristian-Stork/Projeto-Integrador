using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;  

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; 
    public GameObject[] panels; 
    public string[] dialogues; 
    private int currentDialogueIndex = 0; 

    public float typingSpeed = 0.05f; 

    public Button nextButton; 

    void Start()
    {
        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }

        nextButton.onClick.AddListener(OnNextButtonClicked);

        StartCoroutine(DisplayDialogue());
    }

    public void OnNextButtonClicked()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            StopAllCoroutines();
            StartCoroutine(DisplayDialogue());
        }
    }

    IEnumerator DisplayDialogue()
    {
        dialogueText.text = "";
        foreach (char letter in dialogues[currentDialogueIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        currentDialogueIndex++;

        
        if (currentDialogueIndex == 9) 
        {
            panels[0].SetActive(true);
        }
        else if (currentDialogueIndex == 12) 
        {
            panels[1].SetActive(true);
        }
        else if (currentDialogueIndex == 16) 
        {
            panels[2].SetActive(true);
        }
        else if (currentDialogueIndex == 19) 
        {
            panels[3].SetActive(true);
        }

        if (currentDialogueIndex >= dialogues.Length)
        {
            Debug.Log("Fim do diálogo.");
            foreach (var panel in panels)
            {
                panel.SetActive(false);
            }

            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
