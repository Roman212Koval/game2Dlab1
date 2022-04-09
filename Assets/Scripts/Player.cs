using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 destinationPoint;

    public GameManager gm;
    public float runSpeed = 10f;
    public float strafeSpeed = 50f;
    public float jumpForce = 9f;

    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool doJump = false;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            gm.EndGame();
            Debug.Log("Зiткнення");
        }

        if (collision.collider.tag == "Mine")
        {
            rb.AddForce(Vector3.up * 12f, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            strafeLeft = true;
        }
        else
        {
            strafeLeft = false;
        }

        if (Input.GetKey("d"))
        {
            strafeRight = true;
        }
        else
        {
            strafeRight = false;
        }

        if (Input.GetKey("space"))
        {
            doJump = true;
        }

        if (transform.position.y < -5f)
        {
            gm.EndGame();
        }
    }

    void FixedUpdate()
    {
        //rb.AddForce(0, 0, - runSpeed * Time.deltaTime);
        Vector3 step = Vector3.forward * runSpeed * Time.deltaTime * 4f;
        rb.MovePosition(transform.position - step/4);
        

        if (strafeLeft)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position - Vector3.left * 1f - step, 0.20f);
        }
    

        if (strafeRight)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.left * 1f - step, 0.20f);
        }

        if (Time.deltaTime < 1000 && doJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            doJump = false;
        }
    }
}
