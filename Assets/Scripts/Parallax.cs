using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float distance = 10f;
    public float speedX = 10f;
    public float speedY = 10f;

    public float tresholdX = 20f;
    public float tresholdY = 10f;

    public bool is_clone = true;

    public GameObject clone0;
    public GameObject sm;


    void Start()
    {
        sm = GameObject.Find("StageManager");

        if (!is_clone)
        {
            clone0 = Instantiate(this.gameObject);
            clone0.GetComponent<Parallax>().is_clone = true;
            clone0.transform.position = new Vector3(0 - tresholdX, 0, 0);

            /*
            GameObject clone1 = Instantiate(this.gameObject);
            clone1.GetComponent<Parallax>().is_clone = true;
            clone1.transform.position = new Vector3(0 + tresholdX, 0, 0);
            */
        }

        /*
        for (int i = 0; i < 3; i++)
        {
            GameObject clone = Instantiate(this.gameObject);
        }*/
    }

    void Update()
    {
        sm = GameObject.Find("StageManager");

        speedX = sm.GetComponent<StageManager>().stageSpeedX;
        float distanceTemp = distance + sm.GetComponent<StageManager>().stageDistanceFOV;


        Vector3 temp = new Vector3();
        temp = transform.position;

        if (transform.position.x < -tresholdX)
        {
            transform.position = new Vector3(tresholdX, temp.y, 0);
        }


        else if (transform.position.x > tresholdX)
        {
            transform.position = new Vector3(-tresholdX, temp.y, 0);
        }



        temp = transform.position;


        if(!is_clone)
        {
            if (transform.position.x < 0)
            {
                transform.position = new Vector3(temp.x - speedX * distanceTemp * Time.deltaTime, temp.y, 0);
                clone0.GetComponent<Transform>().position = new Vector3(temp.x - speedX * distanceTemp * Time.deltaTime + tresholdX, temp.y, 0);
            }
            else
            {
                transform.position = new Vector3(temp.x - speedX * distanceTemp * Time.deltaTime, temp.y, 0);
                clone0.GetComponent<Transform>().position = new Vector3(temp.x - speedX * distanceTemp * Time.deltaTime - tresholdX, temp.y, 0);
            }
        }

        /*
        float posX = temp.x - speedX * distance * Time.deltaTime;
        float posXround = Mathf.Round(posX * 100)/100;

        if (!is_clone)
        {
            if (posXround < 0)
            {
                while (posXround < clone0.GetComponent<Transform>().position.x - tresholdX )
                {
                    posXround += 0.001f;
                    Debug.Log("while+");
                }
                while (posXround > clone0.GetComponent<Transform>().position.x - tresholdX)
                {
                    posXround -= 0.001f;
                    Debug.Log("while-");
                }
            }

            transform.position = new Vector3(posXround, temp.y, 0);
        }
        else
        {
            transform.position = new Vector3(posXround, temp.y, 0);
            //Debug.Log("");
        }
        */



    }
}
