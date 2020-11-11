using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_levelEndGameObject;
    private int m_pickupQuantity;

    void Awake()
    {
        Assert.IsNotNull(m_levelEndGameObject);
        m_levelEndGameObject.gameObject.SetActive(false);
        m_pickupQuantity = GameObject.FindGameObjectsWithTag("PickUp").Length;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPlayerPickupCollection(int playerPickupQuantity)
    {
        Assert.IsTrue(playerPickupQuantity <= m_pickupQuantity);
        if(playerPickupQuantity == m_pickupQuantity)
        {
            m_levelEndGameObject.SetActive(true);
        }
    }
}
