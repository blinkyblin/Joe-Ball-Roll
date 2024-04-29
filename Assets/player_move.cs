using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public float speed = 5f;
    public Transform cam;

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    Vector3 velocity;

    private bool isJumping;
    public bool isPoweredUp;
    public float powerBounceStrength;
    public float powerupTime = 7f;

    [SerializeField] private LayerMask ground;

    private Rigidbody playerRB;

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.5f);
    }

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }



    private void Update()
    {

        Debug.DrawRay(transform.position, -Vector3.up, Color.red);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(isGrounded());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            isPoweredUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerupTime);
        isPoweredUp = false;
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVirtcal = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVirtcal);

        if (movement.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            playerRB.AddForce(movement * speed * Time.deltaTime);
        }


    }


    private void Jump()
    {
        if (isGrounded() == true)
        {
            playerRB.AddForce(Vector3.up * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isPoweredUp)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 bouncedDir = (collision.gameObject.transform.position - transform.position);
            enemyRB.AddForce(bouncedDir * powerBounceStrength, ForceMode.Impulse);
        }
    }
}
    

