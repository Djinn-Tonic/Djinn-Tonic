using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Cloud_Curse : MonoBehaviour
{

	public GameObject Point1;
	public GameObject Point2;
	int Target_Point = 0;
	public float Position_Timer;

	//Movement
	public float m_movementSpeed = 2f;
	private Rigidbody m_rigidBody;
	public GameObject Player;
	public bool Activate;


	private void Awake()
	{
		m_rigidBody = GetComponent<Rigidbody>();
		Assert.IsNotNull(m_rigidBody);
	}


    // Start is called before the first frame update
    void Start()
    {
		Position_Timer = 2f;
		//this.gameObject.transform.position = new Vector3 (Point2.transform.position.x, Point2.transform.position.y, Point2.transform.position.z);
		//m_rigidBody.velocity = new Vector3(m_movementSpeed, 0.0f, 0.0f);
    }

	void Update(){

		Position_Timer -= Time.deltaTime;

		if (Position_Timer < 0){
			Change_Point();
			Position_Timer = 2f;
		}

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
