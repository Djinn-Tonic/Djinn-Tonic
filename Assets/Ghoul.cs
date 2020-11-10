using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Ghoul : MonoBehaviour
{
	public GameObject Player;
	public bool Activate;
	public float Timer;

	[SerializeField]
	private float m_movementSpeed;
	private Rigidbody m_rigidBody;

	public GameObject Ground;

	private void Awake()
	{
		m_rigidBody = GetComponent<Rigidbody>();
		Assert.IsNotNull(m_rigidBody);
		m_rigidBody.velocity = new Vector3(m_movementSpeed, 0.0f, 0.0f);
	}


    // Start is called before the first frame update
    void Start()
    {
        
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("ChangeEnemyDirection"))
		{
			m_rigidBody.velocity = -m_rigidBody.velocity;    
		}
//		if (other.gameObject.CompareTag("Ground") && Activate == true){
//			Debug.Log("TEST");
//			Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
//
//		}
	}
		

    // Update is called once per frame
    void Update()
    {
		transform.position += m_rigidBody.velocity * m_movementSpeed * Time.deltaTime;

		if ((this.gameObject.transform.position - Player.transform.position).sqrMagnitude < 100f){

			Activate = true;

			//this.transform.position = Vector3.MoveTowards(Player.transform.position, Player.transform.position, -0.27f);
			//Activate = true;
				
		}
	}
}
