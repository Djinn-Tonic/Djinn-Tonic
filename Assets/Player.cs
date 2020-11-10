﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject m_platform;

    [SerializeField]
    private float m_movementSpeed;
    [SerializeField]
    private float m_ladderMovementSpeed;
    [SerializeField]
    private float m_jumpSpeed;
    [SerializeField]
    private int m_health;

    private bool m_onLadder;
    private int m_pickUpCount;
    private Rigidbody m_rigidBody;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rigidBody);

        m_onLadder = false;
        m_pickUpCount = 0;
        m_platform = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Health: " + m_health);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            m_platform = other.gameObject;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ladder"))
        {
            m_rigidBody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            m_onLadder = true;
        }
        if(other.gameObject.CompareTag("LevelEnd"))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            --m_health;
            Debug.Log("Health: " + m_health);
            if(m_health <= 0)
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            }
        }

		if(other.gameObject.CompareTag("Ghoul"))
		{
			
				SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

		}

        if(other.gameObject.CompareTag("PickUp"))
        {
            ++m_pickUpCount;
            Destroy(other.gameObject);
            Debug.Log("PickUp Count: " + m_pickUpCount);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Ladder"))
        {
            m_onLadder = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float movementSpeed = 0.0f;
        if(m_onLadder)
        {
            m_rigidBody.velocity = new Vector3(0.0f, 0.0f, m_rigidBody.velocity.z);
            m_rigidBody.useGravity = false;
            movementSpeed = m_ladderMovementSpeed;
        }
        else
        {
            m_rigidBody.velocity = new Vector3(0.0f, m_rigidBody.velocity.y, m_rigidBody.velocity.z);
            m_rigidBody.useGravity = true;
            movementSpeed = m_movementSpeed;
        }
       
        m_rigidBody.useGravity = !m_onLadder;

        if(transform.position.y <= -10.0f)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_rigidBody.velocity += Vector3.right * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_rigidBody.velocity -= Vector3.right * movementSpeed;
        }
        if(m_onLadder && Input.GetKey(KeyCode.W))
        {
            m_rigidBody.velocity += Vector3.up * m_ladderMovementSpeed;
        }
        if(m_onLadder && Input.GetKey(KeyCode.S))
        {
            m_rigidBody.velocity += Vector3.down * m_ladderMovementSpeed;
        }
		if (m_platform && Input.GetKeyDown(KeyCode.W))
        {
            m_rigidBody.AddForce(Vector3.up * m_jumpSpeed, ForceMode.Impulse);
            m_platform = null;
        }

        transform.position += m_rigidBody.velocity * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
        transform.rotation = Quaternion.identity;
    }
}