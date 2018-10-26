using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour {

    public Transform player;

    public Vector3 player_pos;
    private Vector3 clone_pos;
    private Vector3 clone_spwn;
    private Vector3 clone1_pos;
    private Vector3 clone1_spwn;
    private Vector3 clone2_pos;
    private Vector3 clone2_spwn;
    private Vector3 clone3_pos;
    private Vector3 clone3_spwn;
    private Vector3 clone4_pos;
    private Vector3 clone4_spwn;

    public Object player_obj;
    public Animator player_anim;

    public bool qpressed = false;
    private bool returncalledtalk, returncalledtalk1, returncalledtalk2, returncalledtalk3, returncalledtalk4;
    public bool cloned = false;
    public bool cloned1 = false;
    public bool cloned2 = false;
    public bool cloned3 = false;
    public bool cloned4 = false;
    private float timecount, timecount1, timecount2, timecount3, timecount4;
    private float returntime, returntime1, returntime2, returntime3, returntime4;
    public bool istalking;
    public bool finishedtalking;
    private bool destroying;

	void Start () {
        destroying = false;
    }
	
	// Update is called once per frame
	void Update () {

        player_pos = player.position;
        clone_pos = new Vector3(player_pos.x, player_pos.y, player_pos.z);
        CheckIfQPressed();
        FinishedTalking();
    }

    void CheckIfQPressed ()
    {
        if (destroying == false && qpressed == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                qpressed = true;
                Invoke("NoMorePressed", 1f);
                if (istalking == false)
                {
                    if (cloned == false)
                    {
                        Clone();
                    }
                    else if (cloned == true && cloned1 == false)
                    {
                        Clone1();
                    }
                    else if (cloned == true && cloned1 == true && cloned2 == false)
                    {
                        Clone2();
                    }
                    else if (cloned == true && cloned1 == true && cloned2 == true && cloned3 == false)
                    {
                        Clone3();
                    }
                    else if (cloned == true && cloned1 == true && cloned2 == true && cloned3 == true && cloned4 == false)
                    {
                        Clone4();
                    }
                }
            }
        }
    }

    void Clone()
    {
        cloned = true;
        GameObject player = GameObject.Find("Player");
        SimpleCharacterControl playerScript = player.GetComponent<SimpleCharacterControl>();
        player.tag = "Player_Clone";
        Vector3 player_direction = player.transform.forward;
        clone_spwn = clone_pos + player_direction;
        Quaternion clone_rot = player.transform.rotation;
        Object clone_obj = Instantiate(player_obj, clone_spwn, clone_rot);
        clone_obj.name = "Player_Clone";
        playerScript.canWalk = false;
        player_anim.enabled = false; //andrà sostituito con l' animazione di dejavu
        player.tag = "Player";
        if (istalking == false)
        {
            Invoke("Destroy", 6f);
        }
    }
    void Clone1()
    {
        cloned1 = true;
        GameObject player_clone = GameObject.Find("Player_Clone");
        clone1_pos = GameObject.Find("Player_Clone").transform.position;
        Vector3 clone_direction = player_clone.transform.forward;
        clone1_spwn = clone1_pos + clone_direction;
        Quaternion clone1_rot = player_clone.GetComponent<Transform>().rotation;
        SimpleCharacterControl playerScript = player_clone.GetComponent<SimpleCharacterControl>();
        Object clone_obj = Instantiate(player_clone, clone1_spwn, clone1_rot);
        clone_obj.name = "Player_Clone_1";
        playerScript.canWalk = false;
        player_anim.enabled = false; //andrà sostituito con l' animazione di dejavu
        if (istalking == false)
        {
            Invoke("Destroy1", 6f);
        }
    }
    void Clone2()
    {
        cloned2 = true;
        GameObject player_clone1 = GameObject.Find("Player_Clone_1");
        clone2_pos = GameObject.Find("Player_Clone_1").transform.position;
        Vector3 clone1_direction = player_clone1.transform.forward;
        clone2_spwn = clone2_pos + clone1_direction;
        Quaternion clone2_rot = player_clone1.GetComponent<Transform>().rotation;
        SimpleCharacterControl playerScript = player_clone1.GetComponent<SimpleCharacterControl>();
        Object clone_obj = Instantiate(player_clone1, clone2_spwn, clone2_rot);
        clone_obj.name = "Player_Clone_2";
        playerScript.canWalk = false;
        player_anim.enabled = false; //andrà sostituito con l' animazione di dejavu
        if (istalking == false)
        {
            Invoke("Destroy2", 6f);
        }
    }
    void Clone3()
    {
        cloned3 = true;
        GameObject player_clone2 = GameObject.Find("Player_Clone_2");
        clone3_pos = GameObject.Find("Player_Clone_2").transform.position;
        Vector3 clone2_direction = player_clone2.transform.forward;
        clone3_spwn = clone3_pos + clone2_direction;
        Quaternion clone3_rot = player_clone2.GetComponent<Transform>().rotation;
        SimpleCharacterControl playerScript = player_clone2.GetComponent<SimpleCharacterControl>();
        Object clone_obj = Instantiate(player_clone2, clone3_spwn, clone3_rot);
        clone_obj.name = "Player_Clone_3";
        playerScript.canWalk = false;
        player_anim.enabled = false; //andrà sostituito con l' animazione di dejavu
        if (istalking == false)
        {
            Invoke("Destroy3", 6f);
        }
    }
    void Clone4()
    {
        cloned4 = true;
        GameObject player_clone3 = GameObject.Find("Player_Clone_3");
        clone4_pos = GameObject.Find("Player_Clone_3").transform.position;
        Vector3 clone3_direction = player_clone3.transform.forward;
        clone4_spwn = clone4_pos + clone3_direction;
        Quaternion clone4_rot = player_clone3.GetComponent<Transform>().rotation;
        SimpleCharacterControl playerScript = player_clone3.GetComponent<SimpleCharacterControl>();
        Object clone_obj = Instantiate(player_clone3, clone4_spwn, clone4_rot);
        clone_obj.name = "Player_Clone_4";
        playerScript.canWalk = false;
        player_anim.enabled = false; //andrà sostituito con l' animazione di dejavu
        if (istalking == false)
        {
            Invoke("Destroy4", 6.5f);
        }
    }
    void Destroy()
    {
        if (cloned1 == false && istalking == false)
        {
            finishedtalking = false;
            Destroy(GameObject.Find("Player_Clone"));
            Invoke("CanWalk", 0.65f);
            cloned = false;
            qpressed = true;
            Invoke("NoMorePressed", 2.275f);
            Invoke("DestroyingBool", 1.8f);
            Invoke("NPCBools", 0.5f);
        }
    }
    void Destroy1()
    {
        if (cloned2 == false && istalking == false)
        {
        Destroy(GameObject.Find("Player_Clone_1"));
        cloned1 = false;
        Invoke("Destroy", 0.65f);
        destroying = true;
        }
    }
    void Destroy2()
    {
        if (cloned3 == false && istalking == false)
        {
        Destroy(GameObject.Find("Player_Clone_2"));
        cloned2 = false;
        Invoke("Destroy1", 0.65f);
        destroying = true;
        }
    }
    void Destroy3()
    {
        if (cloned4 == false && istalking == false)
        { 
        Destroy(GameObject.Find("Player_Clone_3"));
        cloned3 = false;
        Invoke("Destroy2", 0.65f);
        destroying = true;
        }
    }
    void Destroy4()
    {
        if (istalking == false)
        {
            Destroy(GameObject.Find("Player_Clone_4"));
            cloned4 = false;
            Invoke("Destroy3", 0.65f);
            destroying = true;
        }
    }
    void CanWalk()
    {
        GameObject player = GameObject.Find("Player");
        SimpleCharacterControl playerScript = player.GetComponent<SimpleCharacterControl>();
        playerScript.canWalk = true;
        player_anim.enabled = true;
    }
    void DestroyingBool()
    {
        destroying = false;
        returncalledtalk = false;
        returncalledtalk1 = false;
        returncalledtalk2 = false; 
        returncalledtalk3 = false;
        returncalledtalk4 = false;
    }
    void NoMorePressed()
    {
        qpressed = false;
    }
    void FinishedTalking()
    {
        if (finishedtalking == true && istalking == false)
        {
            GameObject timeController = GameObject.Find("TimeController");
            TimeController timeControllerScript = timeController.GetComponent<TimeController>();
            if (cloned == true)
            {
                if (returncalledtalk == false)
                {                 
                    timecount = timeControllerScript.currenttime;
                    returntime = 5.5f - timecount;
                    Invoke("Destroy", returntime);
                }
                returncalledtalk = true;
            }
             if (cloned1 == true)
            {
                if (returncalledtalk1 == false)
                {
                    timecount1 = timeControllerScript.currenttime1;
                    returntime1 = 5.5f - timecount1;
                    Invoke("Destroy1", returntime1);
                }
                returncalledtalk1 = true;
            }
             if (cloned2 == true)
            {
                if (returncalledtalk2 == false)
                {
                    timecount2 = timeControllerScript.currenttime2;
                    returntime2 = 5.5f - timecount2;
                    Invoke("Destroy2", returntime2);
                }
                returncalledtalk2 = true;
            }
             if (cloned3 == true)
            {
                if (returncalledtalk3 == false)
                {
                    timecount3 = timeControllerScript.currenttime3;
                    returntime3 = 5.5f - timecount3;
                    Invoke("Destroy3", returntime3);
                }
                returncalledtalk3 = true;
            }
             if (cloned4 == true)
            {
                if (returncalledtalk4 == false)
                {
                    timecount4 = timeControllerScript.currenttime4;
                    returntime4 = 5.5f - timecount4;
                    Invoke("Destroy4", returntime4);
                }
                returncalledtalk4 = true;
            }
        }
    }
    void NPCBools()
    {
        GameObject npc = GameObject.Find("NPC");
        NPC_Dialogue npcdialogue = npc.GetComponent<NPC_Dialogue>();
        npcdialogue.clone_near = false;
    }
}
