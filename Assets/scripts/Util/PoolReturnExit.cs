using UnityEngine;
using System.Collections;

public class PoolReturnExit : MonoBehaviour {


	void OnTriggerExit(Collider _other){
		//Debug.Log (_other.tag);
		if (_other.CompareTag ("PlayerBullet") 
			|| _other.CompareTag ("Enemy")  
			|| _other.CompareTag("EnemyBullet")) {
				MoveObject _move = _other.GetComponent<MoveObject> ();
				if (_move != null) {
					_move.Destroy ();
				}
		}
	}
}
