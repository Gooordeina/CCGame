using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject winpanel;
    public float speed = 8f;
    public TextMeshProUGUI countText;
    private int count;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Animator animator;
    
    Vector3 velocity;
    bool isGrounded;

    void Start ()
    {
        winpanel.SetActive(false);
        count = 0; 

        SetCountText();
    }

    void SetCountText ()
    {
        countText.text = "Count:" + count.ToString() + "/3";
    }
    void Update()
    {
        if (count == 3)
        {
            winpanel.SetActive(true);
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        animator.GetBool("Walk");
        animator.GetBool("Bool");

        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Walk", true);
        }

        if(Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Walk", true);
        }
        else if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Walk", false);
        }

         if(Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Bool", true);
        }

        if(Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Bool", true);
        }
        else if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Bool", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUpObject"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
}
