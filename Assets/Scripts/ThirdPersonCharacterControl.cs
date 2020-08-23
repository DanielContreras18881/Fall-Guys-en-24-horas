using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonCharacterControl : MonoBehaviour
{
    public float speed, MaxSpeed, jumpSpeed;
    float h, v;
    bool isGrounded, dive;
    Rigidbody rb;
    public AnimationManager animMan;
    public Transform cam;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        PlayerInput();
        Walking();
        animMan.SetGrounded(isGrounded);
        animMan.SetSpeed(Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.z));
    }
    void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }
    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumping();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            StartCoroutine(Diving());
        }
    }
    void Walking()
    {
        rb.AddForce(transform.right * speed * h);
        rb.AddForce(transform.forward * speed * v);
        if (rb.velocity.x > MaxSpeed)
        {
            rb.velocity = new Vector3(MaxSpeed, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.z > MaxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, MaxSpeed);
        }
        if (rb.velocity.x < -MaxSpeed)
        {
            rb.velocity = new Vector3(-MaxSpeed, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.z < -MaxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -MaxSpeed);
        }
        if (Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.z) > 0)
        {
            transform.Rotate(new Vector3(0, cam.localEulerAngles.y, 0), Space.World);
        }
    }
    void Jumping()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    IEnumerator Diving()
    {
        if (!dive)
        {
            rb.AddForce((transform.TransformDirection(Vector3.up) + transform.TransformDirection(Vector3.forward)) * jumpSpeed, ForceMode.Impulse);
            dive = true;
            animMan.SetDiving(dive);
            yield return new WaitForSeconds(1.6f);
            dive = false; 
            animMan.SetDiving(dive);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("CanBeGrounded") || collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Player"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("CanBeGrounded") || collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Player"))
        {
            isGrounded = false;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("CanBeGrounded") || collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Player"))
        {
            isGrounded = true;
        }
    }
}