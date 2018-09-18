using UnityEngine;
using System.Collections;

public class PoolReturnTime : MonoBehaviour {
	//지정된 시간이 되면 풀에 돌려주기.
	public float lifeTime;

	void OnEnable(){
		Invoke ("Destroy", lifeTime);
	}

	void Destroy(){
		//if (transform.position.z < 17)
		//	Debug.Log (transform.position);
		gameObject.SetActive (false);
	}

	void OnDisalbe(){
		CancelInvoke ();
	}
}
