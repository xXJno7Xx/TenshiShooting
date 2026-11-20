using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // --------------- Score
    public float score = 0f; 


    // --------------- Parallax
    //stage Scrollspeed
    public float stageSpeedX = 1;
    public float stageSpeedY = 1;

    //Stretches the Distance between Background Layers
    public float stageDistanceFOV = 1;

    private float currentXgoal = 1f;
    private float currentFOVgoal = 1f;
    public float endless_AccelerationSpeed = 0.5f;

    // --------------- Stage Actions
    public GameObject EnemyA;
    public bool endlessMode = false;
    public float enemySpawnFreq = 10f;
    public float enemySpawnFreqLimit = 2f;
    private float enemySpawnFreqTimer = 10f;

    public int enemySpawnVariation = 0;


    void Update()
    {

        if(PlayerPrefs.GetFloat("highscore") < score)
        {
            PlayerPrefs.SetFloat("highscore", score);

            Debug.Log("HIGHSCORE: " + PlayerPrefs.GetFloat("highscore"));
        }












        if(endlessMode)
        {
            enemySpawnFreqTimer -= Time.deltaTime;


            float rand = Random.Range(0, 4f);
            enemySpawnVariation = Mathf.RoundToInt(rand);


            if (enemySpawnFreqTimer <= 0)
            {
                enemySpawnFreqTimer = enemySpawnFreq;

                switch (enemySpawnVariation)
                {
                    case 0:
                        Instantiate(EnemyA, transform.position, Quaternion.identity);
                        EnemyA.GetComponent<Enemy>().animation = "TestAnimation";
                        break;
                    case 1:
                        Instantiate(EnemyA, transform.position, Quaternion.identity);
                        EnemyA.GetComponent<Enemy>().animation = "EnterScreen0001";
                        break;
                    case 2:
                        Instantiate(EnemyA, transform.position, Quaternion.identity);
                        EnemyA.GetComponent<Enemy>().animation = "EnterScreen0002";
                        break;
                    case 3:
                        Instantiate(EnemyA, transform.position, Quaternion.identity);
                        EnemyA.GetComponent<Enemy>().animation = "EnterScreen0003";
                        break;
                    case 4:
                        Instantiate(EnemyA, transform.position, Quaternion.identity);
                        EnemyA.GetComponent<Enemy>().animation = "EnterScreen0004";
                        break;
                }
            }


            if (enemySpawnFreq > enemySpawnFreqLimit)
            {
                enemySpawnFreq -= 0.04f * Time.deltaTime;
            }

            // Background

            if(stageSpeedX <= currentXgoal + 0.2f && stageSpeedX >= currentXgoal - 0.2f)
            {                
                rand = Random.Range(-5f, 10f);

                currentXgoal = rand;
                
            }
            else if (stageSpeedX < currentXgoal)
            {
                stageSpeedX += endless_AccelerationSpeed * Time.deltaTime;
            }
            else if (stageSpeedX > currentXgoal)
            {
                stageSpeedX -= endless_AccelerationSpeed * Time.deltaTime;
            }




            if (stageDistanceFOV <= currentFOVgoal + 0.2f && stageDistanceFOV >= currentFOVgoal - 0.2f)
            {
                rand = Random.Range(-5f, 5f);

                currentFOVgoal = rand;

            }
            else if (stageDistanceFOV < currentFOVgoal)
            {
                stageDistanceFOV += endless_AccelerationSpeed * Time.deltaTime;
            }
            else if (stageDistanceFOV > currentFOVgoal)
            {
                stageDistanceFOV -= endless_AccelerationSpeed * Time.deltaTime;
            }





        }

    }
}
