using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int damage = 1;
	public float speed = 10f;
	public LayerMask mask;
	public bool bDebug = true;

	float lifeTime = 1.0f;
	float plusCheckRadius = .1f;

	void Start(){
		Destroy (gameObject, lifeTime);

		Collider[] _hits = Physics.OverlapSphere (transform.position, 0.1f, mask);
		if (_hits.Length > 0) {
			OnHitObject(_hits [0], transform.position);
		}
	}

	public void SetSpeed(float _speed){
		speed = _speed;
	}


	void Update () {
		float _moveDistance = speed * Time.deltaTime + plusCheckRadius;

		CheckCollision (_moveDistance);

		Vector3 old = transform.position;
		transform.Translate (Vector3.forward * _moveDistance);

		if (bDebug) {
			Debug.DrawLine (old, transform.position, Color.red); 
		}
	}

	void CheckCollision(float _moveDistance){

		Ray _ray = new Ray (transform.position, transform.forward);
		RaycastHit _hit;
		if (Physics.Raycast (_ray, out _hit, _moveDistance, mask, QueryTriggerInteraction.Collide)) {
			OnHitObject (_hit.collider, _hit.point);
		}
	}

	//------------------------
	//날아가면서 체킹.
	//void OnHitObject(RaycastHit _hit){
	//	//Debug.Log (_hit.collider.gameObject.name);
	//
	//	IDamageable _damageable = _hit.collider.GetComponent<IDamageable> ();
	//	if (_damageable != null) {
	//		_damageable.TakeHit (damage, _hit);
	//	}
	//	Destroy (gameObject);
	//}

	//처음 생성될때 체킹.
	void OnHitObject(Collider _collider, Vector3 _hitPoint){
		IDamageable _damageable = _collider.GetComponent<IDamageable> ();
		if (_damageable != null) {
			_damageable.TakeHit (damage, _hitPoint, transform.forward);
		}
		Destroy (gameObject);
	}
}
