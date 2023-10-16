using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{

    private bool movement = false;
    public float timer = 1.0f;
    private string lastMove = "";
    private Vector3 newPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!movement)
        {
            if (Input.GetKeyDown(KeyCode.Q) && !lastMove.Equals("right-down"))
            {
                DiagonalMovement(-1, 1);
                lastMove = "left-up";
            }
            else if (Input.GetKeyDown(KeyCode.E) && !lastMove.Equals("left-down"))
            {
                DiagonalMovement(1, 1);
                lastMove = "right-up";
            }
            else if (Input.GetKeyDown(KeyCode.A) && !lastMove.Equals("right-up"))
            {
                DiagonalMovement(-1, -1);
                lastMove = "left-down";
            }
            else if (Input.GetKeyDown(KeyCode.D) && !lastMove.Equals("left-up"))
            {
                DiagonalMovement(1, -1);
                lastMove = "right-down";
            }
        }

        if (movement)
        {
            float jump = Time.deltaTime / timer;
            transform.position = Vector3.MoveTowards(transform.position, newPoint, jump);
            if(transform.position == newPoint)
            {
                movement = false;
            }
        }
    }

    private void DiagonalMovement(int x, int y)
    {
        newPoint = transform.position + new Vector3(x, y, 0);
        movement = true;
    }
}
