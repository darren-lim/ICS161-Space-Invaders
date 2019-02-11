using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    //This script initializes all the enemies into a 2d array
    //keeps track of firing and movement.
    public GameObject EnemyPrefab;
    public int ColNum = 11;
    public int RowNum = 5;
    public float SpacingOffset = 1.1f; // enemies spacings between each other
    public float PosOffsetX = -6f; //fix position of enemies when instantiating to fit inside camera.
    public float PosOffsetY = 0.5f;
    public GameObject[,] EnemyArray;

    public EnemyController eController;

    // Start is called before the first frame update
    void Awake()
    {
        EnemyArray = new GameObject[ColNum, RowNum];
        for (int i = 0; i < ColNum; i++)
        {
            for (int j = 0; j < RowNum; j++)
            {
                EnemyArray[i, j] = (GameObject)Instantiate(EnemyPrefab, new Vector3((i * SpacingOffset) + PosOffsetX, (j * SpacingOffset) + PosOffsetY, 0), Quaternion.identity);
                EnemyScript EScript = EnemyArray[i, j].GetComponent<EnemyScript>();
                if (j <= 1)
                {
                    EScript.Points = 10;
                }
                else if (j <= 3)
                {
                    EScript.Points = 20;
                }
                else
                {
                    EScript.Points = 40;
                }
                EScript.arrPos = new int[] { i, j };

            }
        }
        eController = this.GetComponent<EnemyController>();
        eController.EnemyObjectArray = EnemyArray;
    }
}
