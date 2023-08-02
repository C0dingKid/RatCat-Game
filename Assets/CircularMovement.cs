using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CircularMovement : MonoBehaviour
{
    public float radius = 2f;
    public float speed = 1f;
    private float angle = 0f;
    private float maxDistance = 4.0f;
    private float ptAng;
    public GameObject circle;
    public GameObject mouse;

    void Update()
    {
        Vector2 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rayOrigin = mouse.transform.position;
        Vector2 rayDirection = (inputPos - rayOrigin).normalized;



        //Creates a raycast from rat to mouse
        if (MainMenu.game == 0)
        {
            rayDirection = (inputPos - rayOrigin).normalized;
        }

        //Creates a raycast from rat to closest border (using center to rat direction)
        else if (MainMenu.game == 1)
        {
            rayDirection = (rayOrigin - Vector2.zero).normalized;
        }


        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, maxDistance);
        //Debug.DrawRay(rayOrigin, rayDirection*maxDistance, Color.red);
        Debug.DrawLine(rayOrigin, hit.point, Color.red);
        if (hit.collider != null)
        {
            // Print the point of the hit
            //Debug.Log("Hit point" + hit.point);
        }


        // Calculate the new position of the game object along the circular path
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        Vector2 newPos = new Vector2(x, y);
        // Move the game object to the new position
        transform.position = newPos;

        // Update the angle for the next frame

        if(hit.point.y >= 0)
            ptAng = Mathf.Acos(hit.point.x / radius);
        else
            ptAng = 2 * 3.1415926f - Mathf.Acos(hit.point.x / radius);

        if (angle > 2.0*3.1415926)
        {
            angle = angle - 2*3.1415926f;
        }
        else if(angle < 0)
        {
            angle = 2 * 3.1415926f;
        }

        float degree = angle * 180 / 3.1415926f;
        float ptDeg = ptAng * 180 / 3.1415926f;

        float diff = ptAng - angle;

        if(inputPos == rayOrigin)
        {
        }
        else if(diff >= 0)
        {
            if (diff >= 3.1415926f)
            {
                angle -= Time.deltaTime * speed;
            }
            else if (Mathf.Abs(ptAng - angle) < 3.1415926f)
            {
                angle += Time.deltaTime * speed;
            }
        }
        else if(diff < 0)
        {
            if (Mathf.Abs(diff) >= 3.1415926f)
            {
                angle += Time.deltaTime * speed;
            }
            else if (Mathf.Abs(diff) < 3.1415926f)
            {
                angle -= Time.deltaTime * speed;
            }
        }


    }
    public bool lol = false;
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(lol != false)
        {
            Debug.Log("Cat caught mouse!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        lol = true;

    }
}
