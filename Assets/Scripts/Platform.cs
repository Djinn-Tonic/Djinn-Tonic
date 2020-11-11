using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject m_spawnIndicatorPrefab;
    [SerializeField]
    private GameObject m_enemyTriggerPrefab;
    [SerializeField]
    private float m_enemySpawnXOffsetFromEdge;
    [SerializeField]
    private float m_enemySpawnYOffsetFromPlatform;
    [SerializeField]
    private float m_enemyTriggerXOffsetFromEdge;
    private GameObject m_leftEnemySpawn;
    private GameObject m_rightEnemySpawn;
    private GameObject m_leftEnemyTrigger;
    private GameObject m_rightEnemyTrigger;
    [SerializeField]
    private bool m_enemyInteractable;

    public bool isEnemyInteractable()
    {
        return m_enemyInteractable;
    }

    void Awake()
    {
        Assert.IsNotNull(m_spawnIndicatorPrefab);
        Assert.IsNotNull(m_enemyTriggerPrefab);

        if (m_enemyInteractable)
        {
            m_leftEnemySpawn = Instantiate(m_spawnIndicatorPrefab, new Vector3(transform.position.x + transform.localScale.x / 2.0f - m_enemySpawnXOffsetFromEdge,
                transform.position.y + m_enemySpawnYOffsetFromPlatform, transform.position.z), Quaternion.identity);

            m_rightEnemySpawn = Instantiate(m_spawnIndicatorPrefab, new Vector3(transform.position.x - transform.localScale.x / 2.0f + m_enemySpawnXOffsetFromEdge,
                transform.position.y + m_enemySpawnYOffsetFromPlatform, transform.position.z), Quaternion.identity);

            m_leftEnemyTrigger = Instantiate(m_enemyTriggerPrefab, new Vector3(transform.position.x + transform.localScale.x / 2.0f - m_enemyTriggerXOffsetFromEdge,
                transform.position.y + m_enemySpawnYOffsetFromPlatform, transform.position.z), Quaternion.identity);

            m_rightEnemyTrigger = Instantiate(m_enemyTriggerPrefab, new Vector3(transform.position.x - transform.localScale.x / 2.0f + m_enemyTriggerXOffsetFromEdge,
                transform.position.y + m_enemySpawnYOffsetFromPlatform, transform.position.z), Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public GameObject getRandomSpawn()
    {
        Assert.IsTrue(m_enemyInteractable);
        return Random.Range(0, 1) == 0 ? m_leftEnemySpawn : m_rightEnemySpawn;
    }
}