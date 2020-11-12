using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Behemoth : MonoBehaviour
{

	[SerializeField]
	private Player m_player;
	public GameObject Platform;

	public float Sight;

    void Start()
    {


		m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		Assert.IsNotNull(m_player);
    }


    // Update is called once per frame
    void Update()
    {
		if ((this.gameObject.transform.position - m_player.transform.position).sqrMagnitude < Sight){

			Destroy (Platform);

		}
    }
}
