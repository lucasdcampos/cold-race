using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{

    public Player player;
    public InputControl input;
 

    [Space]
    public string[] lines;
    public float textSpeed;
    private int index;
    public bool onDialogue;
    public bool dialogueCompleted;
    

    [Space]
    [Header("ICONS")]
    public GameObject dialogueBox;
    public TextMeshProUGUI textComponent;
    public Sprite sprite;
    //public GameObject KEYBOARD_ENTER;
    //public GameObject PS4_X;


    public string nextScene;

    // Start is called before the first frame update
    public void Start()
    {
        
        textComponent.text = string.Empty;
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("Dialogue") && onDialogue)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());

        player.move.rb.velocity = new Vector2(0, 0);
        player.move.canMove = false;
        dialogueBox.SetActive(true);

        onDialogue = true;
    }

    IEnumerator TypeLine()
    {

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            onDialogue = true;


        }

    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            onDialogue = true;
        }
        else
        {
            dialogueCompleted = true;
            dialogueBox.SetActive(false);
            onDialogue = false;
            player.move.canMove = true;
            textComponent.text = string.Empty;

            if (nextScene != "null")
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }



    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (!onDialogue && !dialogueCompleted)
            {
               
                StartDialogue();

            }

        }

    }
}