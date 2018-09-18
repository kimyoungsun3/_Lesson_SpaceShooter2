using UnityEngine;
using System.Collections;

public class AsteroidController : MoveObject {

	public float speed;
	public float speedRotate;
	Vector3 rotation;
	int point; 

	public override void Start () {
		base.Start ();
		rotation = Random.insideUnitSphere;
	}

	void OnEnable(){
		Init ();
	}

	public override void Init(){
		base.Init ();
		bDeath = false;
		point = 5;
	}

	//public void Init(int _point){
	//	Init ();
	//	point = _point;
	//}

	public override void Destroy(){ 
		//스코어 업데이트하고 돌려준다.
		base.Destroy (); 
	}

	public void AddScore(){
		GameController.ins.SetScore (point);
	}
		
		
	void Update () {
		transform.Rotate ( rotation * speedRotate * Time.deltaTime);
		transform.Translate (Vector3.forward * speed * Time.deltaTime, Space.World);
			//GetComponent<Rigidbody> ().angularVelocity = rotation * speedRotate;
	}
}
