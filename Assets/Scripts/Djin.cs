using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Djin : MonoBehaviour
{
    private Player m_player;
    [SerializeField]
    private Platform m_platform;
    [SerializeField]
    private float m_movementSpeed;
    [SerializeField]
    private float m_rayCollisionDistance = 10.0f;
    private Rigidbody m_rigidBody;

    void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Assert.IsNotNull(m_player);

        m_rigidBody = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rigidBody);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody.velocity = new Vector3(Random.Range(0, 100) < 50 ? -m_movementSpeed : m_movementSpeed, 0.0f, 0.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ChangeEnemyDirection"))
        {
            m_rigidBody.velocity = -m_rigidBody.velocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += m_rigidBody.velocity * m_movementSpeed * Time.deltaTime;

        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, m_rayCollisionDistance) &&
            hitInfo.transform.gameObject.CompareTag("Platform"))
        {
            m_platform = hitInfo.transform.gameObject.GetComponent<Platform>();
        }

        Assert.IsNotNull(m_player);
        if (m_platform && m_player.m_platform && m_player.m_platform.isEnemyInteractable() &&
            m_player.m_platform.transform.position != m_platform.transform.position)
        {
            transform.position = m_player.m_platform.getRandomSpawn().transform.position;
            m_rigidBody.velocity = new Vector3(Random.Range(0, 100) < 50 ? -m_movementSpeed : m_movementSpeed, 0.0f, 0.0f);
        }
    }
}