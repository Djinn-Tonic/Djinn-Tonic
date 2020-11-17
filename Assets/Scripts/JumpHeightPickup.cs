using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class JumpHeightPickup : PickUp
{
    [SerializeField]
    private float m_jumpHeightIncreaseAmount = 0.25f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            Assert.IsNotNull(player);
            player.increaseJumpHeight(m_jumpHeightIncreaseAmount);
            Destroy(gameObject);
        }
    }
}
