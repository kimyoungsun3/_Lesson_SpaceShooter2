using UnityEngine;
using System.Collections;

public class TestMan : MonoBehaviour {

	public float fireSpeed = 10;
	public float moveSpeed = 5;
	public float turnSpeed = 180;
	public int cursor = 0;
	public Transform firePoint; 

	// FPS 총변경처럼 구성...
	void Update () {
		if (Input.GetKey (KeyCode.Alpha1)) {
			cursor = 0;
		} else if (Input.GetKey (KeyCode.Alpha2)) {
			cursor = 1;
		} else if (Input.GetKey (KeyCode.Alpha3)) {
			cursor = 2;
		}

		//if (Input.GetMouseButtonDown (0)) {
			//이름을 알면 직접, 전 Pooling에 순서대로...
			string _name = PoolManager.ins.objList [cursor].name;
			GameObject _obj = PoolManager.ins.Instantiate (_name, firePoint.position, firePoint.rotation);
			Rigidbody _rb = _obj.GetComponent<Rigidbody> ();
			_rb.velocity = firePoint.forward * fireSpeed;
			//delay setting value and check this point.
		//	GameObjectPoolReturn _scp = _obj.GetComponent<GameObjectPoolReturn> ();
		//	if (_scp != null) {
		//		_scp.checkLayerMask ();
		//	}
		//}

		float _h = Input.GetAxis ("Horizontal");
		float _v = Input.GetAxis ("Vertical");
		if (Mathf.Abs (_h) > 0.1f || Mathf.Abs (_v) > 0.1f) {
			transform.Translate ( Vector3.forward * _v * moveSpeed * Time.deltaTime);
			transform.Rotate(Vector3.up * _h * turnSpeed * Time.deltaTime);
		}
	
	}
}
