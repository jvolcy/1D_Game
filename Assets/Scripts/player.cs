using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Camera mainCamera;
    public float Speed = 2f;
    float horizontalSpeed = 0f;     // -Speed, +Speed or 0
    public float jumpForce = 300f;
    public float minX = -20f;
    public float maxX = 30f;

    public Sprite orb;

    Animator animator;
    Rigidbody2D rigidbody2d;
    bool bOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        updateCameraPosition();
        animator = GetComponent<Animator>();
        animator.SetBool("bDirRight", true);
        animator.SetBool("bWalking", false);

        rigidbody2d = GetComponent<Rigidbody2D>();
        bOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bOnGround)
        {
            /* if we are in the air, continue the player's forward momentum.
             That is, continue to apply the last horizontalSpeed until the
            play is once more on the ground. */
            updatePlayerPosition();
            updateCameraPosition();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalSpeed = Speed;
            updatePlayerPosition();
            updateCameraPosition();
            animator.SetBool("bDirRight", true);
            animator.SetBool("bWalking", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalSpeed = -Speed;
            updatePlayerPosition();
            updateCameraPosition();
            animator.SetBool("bDirRight", false);
            animator.SetBool("bWalking", true);
        }
        else
        {
            horizontalSpeed = 0f;
            animator.SetBool("bWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && bOnGround)        //jump
        {
            rigidbody2d.AddForce(jumpForce * transform.up);
        }
    }


    void updatePlayerPosition()
    {
        transform.Translate(horizontalSpeed * Time.deltaTime * transform.right);
        if (transform.position.x > maxX) transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        if (transform.position.x < minX) transform.position = new Vector3(minX, transform.position.y, transform.position.z);

    }

    void updateCameraPosition()
    {
        mainCamera.transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX+7.5f, maxX-7.5f), mainCamera.transform.position.y, mainCamera.transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;
        //Debug.Log("CollisionEnter: " + otherObject.name);

        bOnGround = true;
        //if (otherObject.name == "TM Ground") bOnGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;
        //Debug.Log("CollisionExit: " + otherObject.name);

        if (otherObject.name == "TM Ground") bOnGround = false;
    }
}
