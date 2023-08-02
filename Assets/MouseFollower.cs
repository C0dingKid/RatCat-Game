using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseFollower : MonoBehaviour
{
    public float speed = 3.0f;

    private void Update()
    {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 currentPos = transform.position;
            Vector2 direction = (mousePos - currentPos).normalized;

            transform.position = Vector2.MoveTowards(currentPos, mousePos, speed * Time.deltaTime);

    }
}