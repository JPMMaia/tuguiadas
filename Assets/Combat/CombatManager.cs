using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class CombatManager : Entity {

    public Vector3 windDirection;
    public float windStrength;

    public GameObject enemyPrefab;

    public GameObject playerTarget;

    public List<GameObject> enemyList = new List<GameObject>();
	// Use this for initialization
	void Start () {

        windDirection = Random.insideUnitCircle;
        windDirection = new Vector3(windDirection.x, 0, windDirection.y);
        windStrength = Random.Range(0f, .5f);


        Debug.Log("Wind is " + windStrength * windDirection);

        GameObject mapObject = GameObject.FindGameObjectWithTag("Map");


        // Generate Enemies
        for (int i = 0; i < 2; i++)
        {
            float x = Random.Range(-64f, 64f);
            float z = Random.Range(54f, 34f);

            GameObject enemy = Instantiate(enemyPrefab, new Vector3(x, 0, z), Quaternion.LookRotation(-mapObject.transform.forward));
            

            enemy.GetComponent<CombatAI>().target = playerTarget.transform;

            enemyList.Add(enemy);
        }



	}

    public void removeEnemy(GameObject enemy)
    {
        enemyList.Remove(enemy);
    }
	
	// Update is called once per frame
	void Update ()
    {    
        if (enemyList.Count <= 0 || Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("OMGLEAVEBITCH");
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += SceneManager_sceneLoaded;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Default");
        }

        if (playerTarget == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
	}

    private void SceneManager_sceneLoaded(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.LoadSceneMode arg1)
    {
        if(arg0.name == "Default")
            Application.View.Boat.transform.position = Application.Model.PlayerState.PositionBeforeBattle;
    }
}
