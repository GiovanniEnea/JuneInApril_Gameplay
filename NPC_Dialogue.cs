using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class NPC_Dialogue : MonoBehaviour {

    public Button textimage;
    public Text text;

    static int y = 100;
    string[] lines = new string[y];
    private float seconds = 0.02f;

    bool player_near;
    public bool clone_near;

    bool player_dialogue, clone_dialogue;

    public GameObject choices;
    public Button choice1, choice2, choice3, choice4;
    public Text choice1_text, choice2_text, choice3_text, choice4_text;
    private int currenty;
    private bool qpressed1;
    private bool clonedtalking;
    private bool clonedwithq;
    private bool dialoguecompleted;
    private bool wrongchoice;
    private bool epressed;
    private bool charsparsing;


    void Start () {
        textimage.onClick.AddListener(Talk);
        textimage.interactable = false;
        y = 0;
    }
	
	void Update () {
        CheckIfQPressed();
        CheckIfEPressed();
        InteractWithSpace();
	}

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Player Contacted");
            player_near = true;
        }
        if (player.gameObject.tag == "Player_Clone")
        {
            Debug.Log("Player Clone Contacted");
            clone_near = true;
        }
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Player no more Contacted");
            player_near = false;
        }
        if (player.gameObject.tag == "Player_Clone")
        {
            Debug.Log("Clone no more Contacted");
            clone_near = false;
        }
    }
    void CheckIfEPressed()
    {
        if (epressed == false) {
            if (player_near == true || clone_near == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    epressed = true;
                    GameObject cloneController = GameObject.Find("Clone_Controller");
                    CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
                    bool checkclone = cloneControllerScript.cloned;
                    if (player_near == true && clone_near == false && checkclone == false)
                    {
                        GameObject player = GameObject.Find("Player");
                        SimpleCharacterControl playerScript = player.GetComponent<SimpleCharacterControl>();
                        playerScript.canWalk = false;
                        cloneControllerScript.istalking = true;
                        StartDialoguePlayer();
                    }
                    else if (player_near == false && clone_near == true)
                    {

                        if (cloneControllerScript.cloned == true && cloneControllerScript.cloned1 == false)
                        {
                            GameObject clone = GameObject.Find("Player_Clone");
                            SimpleCharacterControl cloneScript = clone.GetComponent<SimpleCharacterControl>();
                            cloneScript.canWalk = false;
                            cloneControllerScript.istalking = true;
                        }
                        else if (cloneControllerScript.cloned == true && cloneControllerScript.cloned1 == true && cloneControllerScript.cloned2 == false)
                        {
                            GameObject clone = GameObject.Find("Player_Clone_1");
                            SimpleCharacterControl cloneScript = clone.GetComponent<SimpleCharacterControl>();
                            cloneScript.canWalk = false;
                            cloneControllerScript.istalking = true;
                        }
                        else if (cloneControllerScript.cloned == true && cloneControllerScript.cloned1 == true && cloneControllerScript.cloned2 == true && cloneControllerScript.cloned3 == false)
                        {
                            GameObject clone = GameObject.Find("Player_Clone_2");
                            SimpleCharacterControl cloneScript = clone.GetComponent<SimpleCharacterControl>();
                            cloneScript.canWalk = false;
                            cloneControllerScript.istalking = true;
                        }
                        else if (cloneControllerScript.cloned == true && cloneControllerScript.cloned1 == true && cloneControllerScript.cloned2 == true && cloneControllerScript.cloned3 == true && cloneControllerScript.cloned4 == false)
                        {
                            GameObject clone = GameObject.Find("Player_Clone_3");
                            SimpleCharacterControl cloneScript = clone.GetComponent<SimpleCharacterControl>();
                            cloneScript.canWalk = false;
                            cloneControllerScript.istalking = true;
                        }
                        else
                        {
                            GameObject clone = GameObject.Find("Player_Clone_4");
                            SimpleCharacterControl cloneScript = clone.GetComponent<SimpleCharacterControl>();
                            cloneScript.canWalk = false;
                            cloneControllerScript.istalking = true;
                        }
                        StartDialogueClone();
                    }
                    else if (player_near == true && clone_near == true)
                    {
                        Debug.Log("You can't both start a dialogue with the same npc");
                    }
                    Talk();
                }
            }

        }
    }
    void CheckIfQPressed()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.istalking == true)
        {
            if (player_near == true || clone_near == true)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (qpressed1 == false)
                    {
                        clonedwithq = true;
                        qpressed1 = true;
                        currenty = y;
                    }
                    else
                    {
                        if (charsparsing == false)
                        {
                            clonedwithq = false;
                            qpressed1 = false;
                            Debug.Log(currenty);
                            y = currenty - 1;
                            Talk();
                        }
                    }
                }
            }
        }
    }
    void StartDialoguePlayer()
    {
        textimage.gameObject.SetActive(true);
        Debug.Log("dialogue with player");
    }
    void StartDialogueClone()
    {
        clonedtalking = true;
        textimage.gameObject.SetActive(true);
        Debug.Log("dialogue with clone");
    }
    void InteractWithSpace()
    {
        if (textimage.interactable == true)
        {
            if (y != 5)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Talk();
                }
            }
        }
    }
    void Talk()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        cloneControllerScript.finishedtalking = false;
        if (dialoguecompleted == false) // controlla il playerprefs per vedere se già è stato completato il primo dialogo
        {
            textimage.interactable = true;
            lines[0] = ""; // Sempre vuoto, non si visualizza
            lines[1] = "First line";
            lines[2] = "Second Line";
            lines[3] = ""; //choice
                           // lines4 dipende dalla choice
                           // lines5 salta perchè una choice sbagliata ha 2 frasi, quindi si setta y per 5 e si richiama talk()
            lines[6] = "Good, dialogue complete";
            lines[30] = "Second route";

            y = y + 1;
            //  StartCoroutine(Dialogue());
            text.text = lines[y];


            if (y == 3)
            {
                ChoiceToMakeOne();
                textimage.gameObject.SetActive(false);
                textimage.interactable = false;
            }
            if (y == 5) //o tutte le posizioni di y in cui vi è una choice 
            {
                textimage.interactable = false;
                wrongchoice = false;
                Invoke("CloseDialogue", 1f);
            }
            if (y > 30)
            {
                Invoke("CloseDialogue", 1f);
            }
        }
        else if (dialoguecompleted == true)
        {
            textimage.interactable = true;
            lines[0] = ""; // Sempre vuoto, non si visualizza
            lines[1] = "Second dialogue";
            lines[2] = " ";
            y = y + 1;
            //   StartCoroutine(Dialogue());
            text.text = lines[y];
            if (y == 2)
            {
                Invoke("CloseDialogue", 1f);
            }
            //nuovo dialogo in cui dice quattro minchiate
        }
    }
  /*  private IEnumerator Dialogue() // sdoppia i dialoghi 
    {
        yield return new WaitForSeconds(seconds);
        text.text = "";
        char[] chars = lines[y].ToCharArray();
        int charsLenght = lines[y].Length;
        int currentindex = 0;
        while (currentindex < charsLenght)
        {
            charsparsing = true;
            textimage.interactable = false;
            yield return new WaitForSeconds(seconds);
            text.text += chars[currentindex];
            currentindex++;
        }
        if (currentindex == charsLenght)
        {
            charsparsing = false;
            textimage.interactable = true;
            if (wrongchoice == true)
            {
                if (y == 5) //o tutte le posizioni di y in cui vi è una choice 
                {
                    textimage.interactable = false;
                    wrongchoice = false;
                    Invoke("CloseDialogue", 1f);
                }
            }
        }
        yield return 1;
    }*/

    void ChoiceToMakeOne()
    {
        choices.SetActive(true);
        choice1.onClick.AddListener(Choice1);
        choice2.onClick.AddListener(Choice2);
        choice3.onClick.AddListener(Choice3);
        choice4.onClick.AddListener(Choice4);
        choice1_text.text = "Single interaction wrong answer";
        choice2_text.text = "Double interaction wrong answer";
        choice3_text.text = "Good enough answer";
        choice4_text.text = "Best case scenario answer, it unlock something more";
    }

    void Choice1() {
        choices.SetActive(false);
        textimage.gameObject.SetActive(true);
        textimage.interactable = true;
        lines[5] = "You're wrong";
        y = 4;
        Talk();
        wrongchoice = true;
        //bisogna settare la frase come penultima rispetto a quella della route giusta, cosi se ci sono altre route sbagliate ma con 
        //piu frasi ci si puo gestire in modo che il dialogo finisca con y nella stessa posizione in entrambi, facilitando il lavoro
    }
    void Choice2() {
        choices.SetActive(false);
        textimage.gameObject.SetActive(true);
        textimage.interactable = true;
        lines[4] = "You're... well...";
        lines[5] = "Wrong again";
        Talk();
        wrongchoice = true;
    }
    void Choice3() {
        choices.SetActive(false);
        textimage.gameObject.SetActive(true);
        textimage.interactable = true;
        lines[4] = "La la la la la :D";
        y = 29;
        Talk();
        textimage.interactable = false;       
    }
    void Choice4() {
        choices.SetActive(false);
        textimage.gameObject.SetActive(true);
        textimage.interactable = true;
        lines[5] = "Perfect answer";
        y = 4;
        Talk();
        if (clonedtalking == false && clonedwithq == false)
        {
            //Playerprefs, salva le scelte dei dialoghi
        }
        //sicuro non funziona perchè setti y piu avanti del dialogo, appena se ne va lo zio franco aggiusta
    }
    void CloseDialogue()
    {
        if (clonedwithq == false && clonedtalking == false)
        {
            dialoguecompleted = true;
        }
        Debug.Log(dialoguecompleted);
        epressed = false;
        textimage.gameObject.SetActive(false);
        y = 0;
        Debug.Log(y);
        textimage.interactable = false;
        clonedwithq = false;
        qpressed1 = false;
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        cloneControllerScript.istalking = false;
        cloneControllerScript.finishedtalking = true;
        clone_near = false;
        if (clonedtalking == true)
        {
            clonedtalking = false;
            GameObject clone = GameObject.FindGameObjectWithTag("Player_Clone");
            if (cloneControllerScript.cloned == true)
            {
                SimpleCharacterControl cloneScript = clone.GetComponent<SimpleCharacterControl>();
                cloneScript.canWalk = true;
            }
        }
        else
        {
            GameObject player = GameObject.Find("Player");
            SimpleCharacterControl playerScript = player.GetComponent<SimpleCharacterControl>();
            playerScript.canWalk = true;
        }

        //checka se è un clone o il player e canWalk torna true, fare tutto su close dialogue, if y > x invoke CloseDialogue
    }
}
