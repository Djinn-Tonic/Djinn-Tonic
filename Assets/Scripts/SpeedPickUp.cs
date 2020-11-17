using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SpeedPickUp : PickUp
{
    [SerializeField]
    private float m_playerSpeedModifier = 0.25f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            Assert.IsNotNull(player);
            player.modifySpeed(m_playerSpeedModifier);
            Destroy(gameObject);
        }
    }
}
