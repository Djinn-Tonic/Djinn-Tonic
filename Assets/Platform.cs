﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject m_spawnIndicatorPrefab;
    [SerializeField]
    private float m_xOffsetFromEdge;
    [SerializeField]
    private float m_yOffsetFromPlatform;
    private GameObject m_leftSpawn;
    private GameObject m_rightSpawn;

    void Awake()
    {
        m_leftSpawn = Instantiate(m_spawnIndicatorPrefab, new Vector3(transform.position.x + transform.localScale.x / 2.0f - m_xOffsetFromEdge,
            transform.position.y + m_yOffsetFromPlatform, transform.position.z), Quaternion.identity);

        m_rightSpawn = Instantiate(m_spawnIndicatorPrefab, new Vector3(transform.position.x - transform.localScale.x / 2.0f + m_xOffsetFromEdge,
            transform.position.y + m_yOffsetFromPlatform, transform.position.z), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        m_leftSpawn.transform.position = new Vector3(transform.position.x + transform.localScale.x / 2.0f - m_xOffsetFromEdge,
            transform.position.y + m_yOffsetFromPlatform, transform.position.z);

        m_rightSpawn.transform.position = new Vector3(transform.position.x - transform.localScale.x / 2.0f + m_xOffsetFromEdge,
            transform.position.y + m_yOffsetFromPlatform, transform.position.z);
    }

    public GameObject getRandomSpawn()
    {
        return Random.Range(0, 1) == 0 ? m_leftSpawn : m_rightSpawn;
    }
}
