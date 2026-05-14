using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); // A y D
        float y = Input.GetAxisRaw("Vertical");   // W y S

        Vector2 movement = new Vector2(x, y).normalized;
        transform.Translate(movement * speed * Time.deltaTime);
    }
}