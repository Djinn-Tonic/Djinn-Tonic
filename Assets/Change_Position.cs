using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Change_Position : MonoBehaviour
{ 
	//Position
	public GameObject Point1;
	public GameObject Point2;
	int Target_Point = 0;
	public float Position_Timer;

	//Movement
	//public float Movement_Speed = 2f;
	public GameObject Player;
	public bool Activate;

	[SerializeField]
	private float m_movementSpeed;
	private Rigidbody m_rigidBody;

	private void Awake()
	{
		m_rigidBody = GetComponent<Rigidbody>();
		Assert.IsNotNull(m_rigidBody);
		m_rigidBody.velocity = new Vector3(m_movementSpeed, 0.0f, 0.0f);
	}

    // Start is called before the first frame update
    void Start()
    {
		//Position_Timer = 2f;
		this.gameObject.transform.position = new Vector3 (Point2.transform.position.x, Point2.transform.position.y, Point2.transform.position.z);

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

//		if ((this.gameObject.transform.position - Player.transform.position).sqrMagnitude < 100f){
//
//			Activate = true;
//		
//		}
//		else{
//			Activate = false;
//		}
//
//		if (Activate == true){
		Position_Timer -= Time.deltaTime;

		if (Position_Timer < 0){
			Change_Point();
			Position_Timer = 2f;
		}
//		}

		
    }

	void Change_Point(){
	
		Target_Point ++;

		switch (Target_Point){

		case 1:
			this.gameObject.transform.position = new Vector3 (Point1.transform.position.x, Point1.transform.position.y, Point1.transform.position.z);
			break;
		case 2:
			this.gameObject.transform.position = new Vector3 (Point2.transform.position.x, Point2.transform.position.y, Point2.transform.position.z);
			Target_Point = 0;
			break;
		}

	}


}
