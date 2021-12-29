using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Camera mainCamera;
    public float Speed = 2f;
    public float jumpForce = 300f;

    Animator animator;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        updateCameraPosition();
        animator = GetComponent<Animator>();
        animator.SetBool("bDirRight", true);
        animator.SetBool("bWalking", false);

        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < 20f) transform.Translate(Speed * Time.deltaTime * transform.right);
            updateCameraPosition();
            animator.SetBool("bDirRight", true);
            animator.SetBool("bWalking", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -20f) transform.Translate(-Speed * Time.deltaTime * transform.right);
            updateCameraPosition();
            animator.SetBool("bDirRight", false);
            animator.SetBool("bWalking", true);
        }
        else
        {
            animator.SetBool("bWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))        //jump
        {
            rigidbody2d.AddForce(jumpForce * transform.up);
        }
    }


    void updateCameraPosition()
    {
        mainCamera.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12.5f, 12.5f), mainCamera.transform.position.y, mainCamera.transform.position.z);
    }
}
