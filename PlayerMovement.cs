using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Setting up the variables and assets 
    public CharacterController controller; 
    public GameObject winpanel;
    public static bool GameIsPaused = false;
    public float speed = 8f;
    public TextMeshProUGUI countText;
    public int count;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Animator animator;
    
    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start ()
    {   
        //winpanel is not active until the player wins the game
        winpanel.SetActive(false);
        //seting initial count value to zero
        count = 0; 

        SetCountText();
    }

    void SetCountText ()
    {
        //count display
        countText.text = "Count:" + count.ToString() + "/3";
    }
    void Update()
    {
        //Win condition function. Changes properies of assets  in order to take player out of game state into a pause.
        if (count == 3)
        {
            winpanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        //verticle velocity equals to zero as the ground check object (at character's feet's position) is on the ground.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        //linking the mouse to Unity system input of axises to the character
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //creating direction of movement based on x and z movement & player's facing
        Vector3 move = transform.right * x + transform.forward * z;

        //moving function. connect to the Character Controller conponent and also link to the speed variable to allow me change character's moving speed.
        controller.Move(move * speed * Time.deltaTime);

        //gravity function. to make character falls as in air with the speed using public float gravity. using the function (y=0.5g * t^2)
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //keyboard control function and animation. using the animator to assign animation to corresponding movement - W (forward), A(left), S (backwards), D (right).
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
    //trigger function of the aim object. to make it collectable which means as the character is in contact with the object, the object disappears
    //enabling the count display function which means as one objectt is claimed, count text increases by one
    private void OnTriggerEnter(Collider Redsquares)
    {
        if(Redsquares.gameObject.CompareTag("PickUpObject"))
        {
            Redsquares.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
    //back to level selection page funcion after winning the game. the button is shown on the win panel.
       public void LoadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }
}