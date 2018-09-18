using UnityEngine;
using System.Collections;

public class Bullet : MoveObject {

	public float speed;
	public int power = 1;

	//필요는 없다.
	//public override void Start () { 
	//	base.Start ();
	//}


	public override void Init(){
		base.Init ();
		power = 1;
	}

	void Update(){
		transform.Translate (Vector3.forward * speed);
	}

}
