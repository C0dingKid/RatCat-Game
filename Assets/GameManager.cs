using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public GameObject mouse; // Assign the object you want to track in the inspector
    public GameObject circle; // Assign the end circle in the inspector
    public GameObject cat;
    bool ifInside = true;

    private void Update()
    {

        if(ifInside && Vector2.Distance(circle.transform.position, mouse.transform.position) > 2)
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);

            ifInside = false;
        }

    }
}
