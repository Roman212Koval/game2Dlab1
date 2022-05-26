using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    enum State
    {
        STATE_ONFLOOR,
        STATE_JUMPING,
        STATE_OFF_ROAD
    };

    private State currentState = State.STATE_ONFLOOR;
    [SerializeField] private PhysicsMovement _movement;
    public Rigidbody rb;
    Vector3 destinationPoint;

    public GameManager gm;
    public float runSpeed = 4f;
    public float strafeSpeed = 50f;
    public float jumpForce = 30f;
    float horizontal = 0f;

    protected bool doJump = false;
    private Vector3 step;
    private bool isOpenMenu = false;

    public GameObject CanvMenu;
    public GameObject Victory;

    public AudioSource audioGameOver, audioJump, audioVictory;//, audioMove;
   

    private void GoMenu()
    {
        CanvMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    private void GoVictory()
    {
        Victory.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        _movement.Move(new Vector3(horizontal, 0, -runSpeed));
        

        if (transform.position.y < -5f)
        {
            audioGameOver.Play();
            gm.EndGame();
            GoMenu();
        }

        if (transform.position.z < -80f)
        {
            audioVictory.Play();
            gm.EndGame();
            GoVictory();
        }
    }

    void FixedUpdate()
    {
        
        //rb.velocity = new Vector3(0, 0, -runSpeed);
        //rb.AddForce(Vector3.down * jumpForce, ForceMode.Impulse);
        CaptureInput();

        switch (currentState)
        {
            case State.STATE_JUMPING:
                
                runSpeed = 7f;
                break;

            case State.STATE_OFF_ROAD:
                
                runSpeed = 5f;
                break;

            case State.STATE_ONFLOOR:
            
                runSpeed = 10f;
                break;

        }
    }
    

    private void CaptureInput()
    {
        horizontal = 0f;

        if ((currentState != State.STATE_JUMPING) && Input.GetButtonDown("Jump"))
        {
            audioJump.Play();
            Debug.Log("STATE_JUMPING");
            currentState = State.STATE_JUMPING;
            rb.AddForce(Vector3.up * 2f* jumpForce, ForceMode.Impulse);
        }

        if (currentState != State.STATE_JUMPING)
        {

            if (Input.GetKey("a"))
            {
                horizontal = runSpeed;
            }
            else if (Input.GetKey("d"))
            {
                horizontal = -runSpeed;
            }
        }

        if (Input.GetKey(KeyCode.Escape) && !isOpenMenu)
        {
            GoMenu();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            gm.EndGame();
            audioGameOver.Play();
           // audioSource.PlayOneShot(audioClip);
            Debug.Log("Зiткнення");
            GoMenu();
        }

        if (collision.collider.tag == "Mine")
        {
            //  audioGameOver.Play();
            audioJump.Play();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if ((currentState != State.STATE_ONFLOOR) && (collision.collider.tag == "Floor"))
        {
            Debug.Log("STATE_ONFLOOR");
            currentState = State.STATE_ONFLOOR;
        }

        if (collision.collider.tag == "no-road")
        {
            Debug.Log("STATE_OFF_ROAD");
            currentState = State.STATE_OFF_ROAD;
        }

    }
}
