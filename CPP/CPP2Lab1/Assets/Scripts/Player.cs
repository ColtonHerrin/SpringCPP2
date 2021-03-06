using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    CharacterController controller;
    Fire playerFire;

    [Header("Player Settings")]
    [Space(2)]
    [Tooltip("Speed value between 1 and 6")]
    [Range(1.0f, 6.0f)]
    public float speed;
    public float jumpSpeed;
    public float rotationSpeed;
    public float gravity;

    [Header("Weapon Settings")]
    public float ProjectileForce;
    public Rigidbody projectilePrefab;
    public Transform projectileSpawnPoint;

    Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        try
        {
            controller = GetComponent<CharacterController>();
            playerFire = GetComponent<Fire>();
            controller.minMoveDistance = 0.0f;

            if (speed <= 0)
            {
                speed = 6.0f;
            }

            if (jumpSpeed <= 0)
            {
                jumpSpeed = 6.0f;
            }

            if (rotationSpeed <= 0)
            {
                rotationSpeed = 10.0f;
            }

            if (gravity <= 0)
            {
                gravity = 9.81f;
            }

            moveDirection = Vector3.zero;

            if (ProjectileForce <= 0)
            {
                ProjectileForce = 10.0f;
            }

        }
        catch (NullReferenceException e)
        {
            Debug.LogWarning(e.Message);
        }
        catch (UnassignedReferenceException e)
        {
            Debug.LogWarning(e.Message);
        }
        finally
        {
            Debug.Log("Always Gets Called");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButtonDown("Jump"))
                moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.x = Input.GetAxis("Horizontal") * speed;
            moveDirection.z = Input.GetAxis("Vertical") * speed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
            Fire();

    }
    void Fire()
    {
        Debug.Log("pew pew pew");
        playerFire.FireProjectile();
    }

    [ContextMenu("Reset Stats")]
    void ResetStats()
    {
        speed = 6.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Endpoint")
        {
            Debug.Log("Game Ended");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Endpoint")
        {
            Debug.Log("Game Ended");
        }
    }

}
