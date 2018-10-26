using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimCamera : MonoBehaviour
{

    public float turnSpeed = 4.0f;


    public Transform player;

    private Vector3 offset;
 

    private Transform target;
    private Transform target1;
    private Transform target2;
    private Transform target3;
    private Transform target4;


    private bool cloned;
    private bool cloned_1;
    private bool cloned_2;
    private bool cloned_3;
    private bool cloned_4;

    private bool returncalled = false;
    private bool returncalled1 = false;
    private bool returncalled2 = false;
    private bool returncalled3 = false;
    private bool returncalled4 = false;

    private bool returncalledtalk, returncalledtalk1, returncalledtalk2, returncalledtalk3, returncalledtalk4;

    private bool qpressed = false;
    private float timecount, timecount1, timecount2, timecount3, timecount4;
    private float returntime, returntime1, returntime2, returntime3, returntime4;
    private bool returning;
    private bool countlocked = false;

    private int count = 0;


    void Start()
    {
        offset = transform.position - player.transform.position;

        cloned = false;
        cloned_1 = false;
        cloned_2 = false;
        cloned_3 = false;
        cloned_4 = false;
        returning = false;
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();


    }
    void LateUpdate()
    {
        //non si potrebbe premere due volte velocemente
        CheckIfCloned();
        CheckIfQPressed();
        CheckIfRightClick();
        FinishedTalking();
        SyncQ();

    }

    void SyncQ()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.qpressed == false)
        {
            qpressed = false;
        }
        else
        {
            qpressed = true;
        }
    }
    void CheckIfQPressed()
    {
        if (returning == false && qpressed == false)
        {
            GameObject cloneController = GameObject.Find("Clone_Controller");
            CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
            if(cloneControllerScript.istalking == false) { 
                if (Input.GetKeyDown(KeyCode.Q)) 
                {
                    if (qpressed == false) 
                    {
                        qpressed = true;
                        Invoke("NoMorePressed", 1f);
                        if (count <= 5)
                        {
                            if (countlocked == false)
                            {
                                count = count + 1;
                                if (count == 1)
                                {
                                    Invoke("Cloned", 1f);
                                }
                                else if (count == 2)
                                {
                                    Invoke("Cloned1", 1f);
                                }
                                else if (count == 3)
                                {
                                    Invoke("Cloned2", 1f);
                                }
                                else if (count == 4)
                                {
                                    Invoke("Cloned3", 1f);
                                }
                                else if (count == 5)
                                {
                                    Invoke("Cloned4", 1f);
                                }
                                else if (count > 5)
                                {
                                    count = 5;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    void CheckIfRightClick()
    {
        if (Input.GetMouseButton(1))
        {
            if (cloned == false && count == 0)
            {
                Vector3 coordinates = new Vector3(player.position.x, player.position.y + 1.215f, player.position.z);
                offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
                transform.position = player.position + offset;
                transform.LookAt(coordinates);
            }
            else if (cloned == true && count == 1)
            {
                Vector3 coordinates = new Vector3(target.position.x, target.position.y + 1.215f, target.position.z);
                offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
                transform.position = target.position + offset;
                transform.LookAt(coordinates);
            }
            else if (cloned_1 == true && count == 2)
            {
                Vector3 coordinates = new Vector3(target1.position.x, target1.position.y + 1.215f, target1.position.z);
                offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
                transform.position = target1.position + offset;
                transform.LookAt(coordinates);
            }
            else if (cloned_2 == true && count == 3)
            {
                Vector3 coordinates = new Vector3(target2.position.x, target2.position.y + 1.215f, target2.position.z);
                offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
                transform.position = target2.position + offset;
                transform.LookAt(coordinates);
            }
            else if (cloned_3 == true && count == 4)
            {
                Vector3 coordinates = new Vector3(target3.position.x, target3.position.y + 1.215f, target3.position.z);
                offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
                transform.position = target3.position + offset;
                transform.LookAt(coordinates);
            }
            else if (cloned_4 == true && count == 5)
            {
                Vector3 coordinates = new Vector3(target4.position.x, target4.position.y + 1.215f, target4.position.z);
                offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
                transform.position = target4.position + offset;
                transform.LookAt(coordinates);
            }
        }
    }
    void CheckIfCloned()
    {
        if (count == 0)
        {
            transform.position = player.transform.position + offset;
        }
        if (returning == false)
        {
            GameObject cloneController = GameObject.Find("Clone_Controller");
            CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
            if (cloneControllerScript.istalking == false)
            {
                if (count == 1 && cloned == true)
                {
                    if (GameObject.Find("Player_Clone") != null)
                    {
                        target = GameObject.Find("Player_Clone").transform;
                        Vector3 new_pos;
                        new_pos = target.transform.position + offset;
                        transform.position = new_pos;

                    }

                    if (returncalled == false)
                    {
                        Invoke("Returning", 5f);
                    }
                    returncalled = true;
                }
                else if (count == 2 && cloned_1 == true)
                {
                    if (GameObject.Find("Player_Clone_1") != null)
                    {
                        target1 = GameObject.Find("Player_Clone_1").transform;
                        Vector3 new_pos_1;
                        new_pos_1 = target1.transform.position + offset;
                        transform.position = new_pos_1;

                    }

                    if (returncalled1 == false)
                    {
                        Invoke("Returning1", 5f);
                    }
                    returncalled1 = true;
                }
                else if (count == 3 && cloned_2 == true)
                {
                    if (GameObject.Find("Player_Clone_2") != null)
                    {
                        target2 = GameObject.Find("Player_Clone_2").transform;
                        Vector3 new_pos_1;
                        new_pos_1 = target2.transform.position + offset;
                        transform.position = new_pos_1;

                    }

                    if (returncalled2 == false)
                    {
                        Invoke("Returning2", 5f);
                    }
                    returncalled2 = true;
                }
                else if (count == 4 && cloned_3 == true)
                {
                    if (GameObject.Find("Player_Clone_3") != null)
                    {
                        target3 = GameObject.Find("Player_Clone_3").transform;
                        Vector3 new_pos_1;
                        new_pos_1 = target3.transform.position + offset;
                        transform.position = new_pos_1;
                    }


                    if (returncalled3 == false)
                    {
                        Invoke("Returning3", 5f);
                    }
                    returncalled3 = true;
                }
                else if (count == 5 && cloned_4 == true)
                {
                    if (GameObject.Find("Player_Clone_4") != null)
                    {
                        target4 = GameObject.Find("Player_Clone_4").transform;
                        Vector3 new_pos_1;
                        new_pos_1 = target4.transform.position + offset;
                        transform.position = new_pos_1;

                    }

                    if (returncalled4 == false)
                    {
                        Invoke("Returning4", 5f);
                    }
                    returncalled4 = true;
                }
            }
        }
    }


    void Cloned()
    {
        cloned = true;
    }
    void Cloned1()
    {
        cloned_1 = true;
    }
    void Cloned2()
    {
        cloned_2 = true;
    }
    void Cloned3()
    {
        cloned_3 = true;
    }
    void Cloned4()
    {
        cloned_4 = true;
    }

 
    void Returning()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.istalking == false)
        {
            if (count == 1 && cloned == true)
            {
                Vector3 new_pos_1;
                new_pos_1 = player.transform.position + offset;
                transform.position = new_pos_1;
                cloned = false;
                qpressed = true;
                count = count - 1;
                Invoke("ReturnBools", 2f);
                Invoke("NoMorePressed", 2.3f);

            }
        }
    }
    void Returning1()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.istalking == false)
        {
            if (count == 2 && cloned_1 == true)
            {
                Vector3 new_pos_1;
                new_pos_1 = target.transform.position + offset;
                transform.position = new_pos_1;
                cloned_1 = false;
                count = count - 1;
                returning = true;
                countlocked = true;
                qpressed = true;
                Invoke("Returning", 0.5f);
            }
        }
    }
    void Returning2()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.istalking == false)
        {
            if (count == 3 && cloned_2 == true)
            {
                Vector3 new_pos_1;
                new_pos_1 = target1.transform.position + offset;
                transform.position = new_pos_1;
                cloned_2 = false;
                count = count - 1;
                returning = true;
                countlocked = true;
                qpressed = true;
                Invoke("Returning1", 0.5f);
            }
        }
    }
    void Returning3()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.istalking == false)
        {
            if (count == 4 && cloned_3 == true)
            {
                Vector3 new_pos_1;
                new_pos_1 = target2.transform.position + offset;
                transform.position = new_pos_1;
                cloned_3 = false;
                count = count - 1;
                countlocked = true;
                returning = true;
                qpressed = true;
                Invoke("Returning2", 0.5f);
            }
        }
    }
    void Returning4()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.istalking == false)
        {
            if (count == 5 && cloned_4 == true)
            {
                Vector3 new_pos_1;
                new_pos_1 = target3.transform.position + offset;
                transform.position = new_pos_1;
                cloned_4 = false;
                count = count - 1;
                returning = true;
                countlocked = true;
                qpressed = true;
                Invoke("Returning3", 0.5f);
            }
        }
    }
    void ReturnBools()
    {
        returncalled4 = false;
        returncalled = false;
        returncalled1 = false;
        returncalled2 = false;
        returncalled3 = false;
        returncalledtalk = false;
        returncalledtalk1 = false;
        returncalledtalk2 = false;
        returncalledtalk3 = false;
        returncalledtalk4 = false;
        countlocked = false;
        returning = false;
    }

    void NoMorePressed()
    {
        qpressed = false;
    }
    void FinishedTalking()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.finishedtalking == true)
        {
            GameObject timeController = GameObject.Find("TimeController");
            TimeController timeControllerScript = timeController.GetComponent<TimeController>();
            if (count == 1 && cloned == true)
            {
                if (returncalledtalk == false)
                {
                 //   cloneControllerScript.finishedtalking = false;
                    timecount = timeControllerScript.currenttime;
                    returntime = 5.3f - timecount;
                    Invoke("Returning", returntime);
                }
                returncalledtalk = true;
            }            
            else if (count == 2 && cloned_1 == true)
            {
                if (returncalledtalk1 == false)
                {
                //   cloneControllerScript.finishedtalking = false;
                    timecount1 = timeControllerScript.currenttime1;
                    returntime1 = 5.3f - timecount1;
                    Invoke("Returning1", returntime1);
                }
                returncalledtalk1 = true;
            }
            else if (count == 3 && cloned_2 == true)
            {
                if (returncalledtalk2 == false)
                {
              //      cloneControllerScript.finishedtalking = false;
                    timecount2 = timeControllerScript.currenttime2;
                    returntime2 = 5.3f - timecount2;
                    Invoke("Returning2", returntime2);
                }
                returncalledtalk2 = true;
            }
            else if (count == 4 && cloned_3 == true)
            {
                if (returncalledtalk3 == false)
                {
                  //  cloneControllerScript.finishedtalking = false;
                    timecount3 = timeControllerScript.currenttime3;
                    returntime3 = 5.3f - timecount3;
                    Invoke("Returning3", returntime3);
                }
                returncalledtalk3 = true;
            }
            else if (count == 5 && cloned_4 == true)
            {
                if (returncalledtalk4 == false)
                {
              //    cloneControllerScript.finishedtalking = false;
                    timecount4 = timeControllerScript.currenttime4;
                    returntime4 = 5.3f - timecount4;
                    Invoke("Returning4", returntime4);
                }
                returncalledtalk4 = true;
            }
        }
    }
}
