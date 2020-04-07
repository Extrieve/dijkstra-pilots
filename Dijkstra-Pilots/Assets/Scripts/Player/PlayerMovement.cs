using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement, mousePos; 

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera camera;

    void Update()
    {
        //Basic 2D movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Feeding mouse position data to mousePos variable
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Finding the intermediate vector, so that the character model aims 
        // where the cursor is located
        Vector2 lookDirection = mousePos - rb.position; 
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void ResetPosition()
    {
        rb.position = new Vector2(0, 0);
    }
}
