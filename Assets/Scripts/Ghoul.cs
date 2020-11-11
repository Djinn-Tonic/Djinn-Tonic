using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Ghoul : MonoBehaviour
{
	[SerializeField]
	private float m_movementSpeed;
	[SerializeField]
	private float m_attackRange;
	[SerializeField]
	private float m_FOV = 60.0f;
	private Rigidbody m_rigidBody;
	private Player m_player;
	private bool m_droppedToPlayer = false;

	private void Awake()
	{
		m_rigidBody = GetComponent<Rigidbody>();
		Assert.IsNotNull(m_rigidBody);
		m_rigidBody.velocity = new Vector3(m_movementSpeed, 0.0f, 0.0f);

		m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		Assert.IsNotNull(m_player);
	}

	// Start is called before the first frame update
	void Start()
	{ }


	void OnTriggerExit(Collider other)
    {
		if(other.gameObject.CompareTag("Platform"))
        {
			Debug.Log("ExitCollision");
			GetComponent<Collider>().isTrigger = false;
		}
    }

	// Update is called once per frame
	void Update()
	{
		//Debug.DrawRay(transform.position, (Vector3.down + (Vector3.left * (m_FOV / 2.0f) / 90.0f)).normalized * m_attackRange, Color.red);
		//Debug.DrawRay(transform.position, (Vector3.down + (Vector3.right * (m_FOV / 2.0f) / 90.0f)).normalized * m_attackRange, Color.red);

		if(!m_droppedToPlayer)
        {
			Debug.DrawRay(transform.position, Vector3.down * m_attackRange, Color.red);
			Vector3 vDifference = m_player.transform.position - transform.position;
			if (vDifference.sqrMagnitude <= m_attackRange * m_attackRange &&
				Vector3.Angle(Vector3.down, vDifference.normalized) <= m_FOV / 2.0f)
			{
				GetComponent<Collider>().isTrigger = true;
				m_droppedToPlayer = true;
			}
		}
	}
}
