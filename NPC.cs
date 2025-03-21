using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{ 
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    
    private int index;
    public GameObject contButton; 
    public float wordSpeed;
    public bool playerIsClose = true;


//UPDATE
 //--------------------------------------------------------------------   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if(dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }  
        }
        if(dialogueText.text == dialogue[index]){
            contButton.SetActive(true);
        }
    }
//--------------------------------------------------------------------
    
     void Start()
    {
        dialogueText.text = "";
    }
//ZERO TEXT
//--------------------------------------------------------------------
    public void zeroText()
{
        dialogueText.text="";
        index = 0;
        dialoguePanel.SetActive(false);
}
//--------------------------------------------------------------------   

//TYPING
//--------------------------------------------------------------------   
    IEnumerator Typing()
{
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
}    
//--------------------------------------------------------------------   

//NEXTLINE
//--------------------------------------------------------------------   
    public void NextLine()
    {
        contButton.SetActive(false);
    
        if(index < dialogue.Length -1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
}
//--------------------------------------------------------------------   

//ON TRIGGER ENTER 2D
//--------------------------------------------------------------------    
private void onTriggerEnter2D(Collider2D other)
    {
            Debug.Log("OnCollisionEnter2D");
            playerIsClose=true;
        

    }
//--------------------------------------------------------------------


//ON TRIGGER EXIT 2D
//--------------------------------------------------------------------
    private void onTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose=false;
            zeroText();
        }
    }
//--------------------------------------------------------------------

   
}
