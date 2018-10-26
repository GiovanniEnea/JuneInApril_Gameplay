using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

//    public Text time, time1, time2, time3, time4;

    private float timecount, timecount1, timecount2, timecount3, timecount4;

    public float currenttime, currenttime1, currenttime2, currenttime3, currenttime4;

    private int count;

    private bool cloned, cloned1, cloned2, cloned3, cloned4;

    private bool reset, reset1, reset2, reset3, reset4;

    private bool qpressed;
    private bool returning;
    public Slider timeslider;
    public Slider timeslider1;
    public Slider timeslider2;
    public Slider timeslider3;
    public Slider timeslider4;


    void Start () {
        count = 0;
        SetSliderValues();

    }
	

	void Update () {
        Count();
        CheckIfQPressed();
	}
    void SetSliderValues()
    {
        timeslider.maxValue = 6;
        timeslider.direction = Slider.Direction.RightToLeft;
        timeslider1.maxValue = 6;
        timeslider1.direction = Slider.Direction.RightToLeft;
        timeslider2.maxValue = 6;
        timeslider2.direction = Slider.Direction.RightToLeft;
        timeslider3.maxValue = 6;
        timeslider3.direction = Slider.Direction.RightToLeft;
        timeslider4.maxValue = 6;
        timeslider4.direction = Slider.Direction.RightToLeft;
    }
    void CheckIfQPressed()
    {
        if (qpressed == false)
        {
            if(returning == false) { 
            GameObject cloneController = GameObject.Find("Clone_Controller");
            CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
                if (cloneControllerScript.istalking == false)
                {

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        qpressed = true;
                        Invoke("NoMorePressed", 1f);
                        count = count + 1;
                    }
                }
            }
        }
    }
    void Count()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.istalking == false)
        {
            if (returning == false)
            {
                /*      if (count == 0)
                  {
                      time.text = "";
                      time1.text = "";
                      time2.text = "";
                      time3.text = "";
                      time4.text = "";
                  }*/

                if (count == 1)
                {
                    if (cloned == false)
                    {

                        timecount = timecount + Time.deltaTime;
                        // time.text = "Time 1st Clone: " + timecount + "";
                        currenttime = timecount;
                        timeslider.gameObject.SetActive(true);
                        timeslider.value = timecount;
                        if (reset == false)
                        {
                            Invoke("ResetCount", 6f);
                        }
                        reset = true;

                    }

                }
                else if (count == 2)
                {
                    cloned = true;
                    if (cloned1 == false)
                    {
                        timecount1 = timecount1 + Time.deltaTime;
                        //   time1.text = "Time 2nd Clone: " + timecount1 + "";
                        currenttime1 = timecount;
                        timeslider1.gameObject.SetActive(true);
                        timeslider1.value = timecount1;
                        if (reset1 == false)
                        {
                            Invoke("ResetCount1", 6f);
                        }
                        reset1 = true;
                    }

                }
                else if (count == 3)
                {
                    cloned1 = true;
                    if (cloned2 == false)
                    {
                        timecount2 = timecount2 + Time.deltaTime;
                        //   time2.text = "Time 3rd Clone: " + timecount2;
                        currenttime2 = timecount;
                        timeslider2.gameObject.SetActive(true);
                        timeslider2.value = timecount2;
                        if (reset2 == false)
                        {
                            Invoke("ResetCount2", 6f);
                        }
                        reset2 = true;
                    }
                }
                else if (count == 4)
                {
                    cloned2 = true;
                    if (cloned3 == false)
                    {
                        timecount3 = timecount3 + Time.deltaTime;
                        //    time3.text = "Time 4th Clone: " + timecount3;
                        currenttime3 = timecount;
                        timeslider3.gameObject.SetActive(true);
                        timeslider3.value = timecount3;
                        if (reset3 == false)
                        {
                            Invoke("ResetCount3", 6f);
                        }
                        reset3 = true;
                    }
                }
                else if (count == 5)
                {
                    cloned3 = true;
                    if (cloned4 == false)
                    {
                        timecount4 = timecount4 + Time.deltaTime;
                        //    time4.text = "Time 5th Clone: " + timecount4;
                        currenttime4 = timecount;
                        timeslider4.gameObject.SetActive(true);
                        timeslider4.value = timecount4;
                        if (reset4 == false)
                        {
                            Invoke("ResetCount4", 6f);
                        }
                        reset4 = true;
                    }
                }
            }
        }
         if (count > 5)
        {
            count = 5;
        }
    }
    private void ResetCount()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.istalking == true)
        {
            float remainingtime = 6 - timecount;
            Invoke("ResetCount", remainingtime);
            Debug.Log(remainingtime);
        }
        else if (cloneControllerScript.istalking == false)
        {
            if (count == 1)
            {
                qpressed = true;
                reset = false;
                count = count - 1;
                timecount = 0;
                Invoke("NoMorePressed", 2.4f);
                returning = false;
                cloned = false;
                cloned1 = false;
                cloned2 = false;
                cloned3 = false;
                cloned4 = false;
                timeslider.gameObject.SetActive(false);
                timeslider1.gameObject.SetActive(false);
                timeslider2.gameObject.SetActive(false);
                timeslider3.gameObject.SetActive(false);
                timeslider4.gameObject.SetActive(false);

            }
        }
    }
    private void ResetCount1()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.istalking == true)
        {
            float remainingtime = 6 - timecount1;
            Invoke("ResetCount1", remainingtime);
        }
        if (cloneControllerScript.istalking == false)
        {
            if (count == 2)
            {
                qpressed = true;
                reset1 = false;
                count = count - 1;
                timecount1 = 0;
                Invoke("ResetCount", 0.5f);
                returning = true;
            }
        }
    }
    private void ResetCount2()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.istalking == true)
        {
            float remainingtime = 6 - timecount2;
            Invoke("ResetCount2", remainingtime);
            returning = true;
        }
        if (cloneControllerScript.istalking == false)
        {
            if (count == 3)
            {
                qpressed = true;
                reset2 = false;
                count = count - 1;
                timecount2 = 0;
                Invoke("ResetCount1", 0.5f);
                returning = true;
            }
        }
    }
    private void ResetCount3()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.istalking == true)
        {
            float remainingtime = 6 - timecount3;
            Invoke("ResetCount3", remainingtime);
        }
        if (cloneControllerScript.istalking == false)
        {
            if (count == 4)
            {
                qpressed = true;
                reset3 = false;
                count = count - 1;
                timecount3 = 0;
                Invoke("ResetCount2", 0.5f);
                returning = true;
            }
        }
    }
    private void ResetCount4()
    {
        GameObject cloneController = GameObject.Find("Clone_Controller");
        CloneController cloneControllerScript = cloneController.GetComponent<CloneController>();
        if (cloneControllerScript.istalking == true)
        {
            float remainingtime = 6 - timecount4;
            Invoke("ResetCount4", remainingtime);
        }
        if (cloneControllerScript.istalking == false)
        {
            if (count == 5)
            {
                returning = true;
                qpressed = true;
                reset4 = false;
                count = count - 1;
                timecount4 = 0;
                Invoke("ResetCount3", 0.5f);
            }
        }
    }

    void NoMorePressed()
    {
        qpressed = false;
    }

}
