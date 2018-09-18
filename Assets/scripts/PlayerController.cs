using UnityEngine;
using System.Collections;



public class PlayerController : MoveObject {
	public enum STATS_FIRE_MODE { One, Two, Three, Five};
	public STATS_FIRE_MODE fireMode;

	public float speedEdit;
	public float tilt;
	public Boundary boundary;
	public Transform spawnPoint, spawnPointl, spawnPointr, spawnPointl2, spawnPointr2;
	public float spawnBetweenTime = 0.5f;
	float spawnTime;

	Rigidbody rb;
	Vector3 move;
	Vector2 touchDir;
	Plane plane = new Plane(Vector3.up, Vector3.zero);
	float distacne = 0;

	public override void Start () {
		base.Start ();
		rb = GetComponent<Rigidbody> ();	

		Init (); 
	}

	public override void Init(){
		base.Init ();
		fireMode = STATS_FIRE_MODE.Five;
	}

	void Update () {

		Move ();

		Shoot ();
	}

	void Move(){


		/*
		Vector3 _move = new Vector3 (_h, 0, _v).normalized * speed;
		rb.velocity = _move;
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);
		rb.rotation = Quaternion.Euler (0, 0, -tilt * rb.velocity.x);
		*/

		/*
		//key board
		float _h = Input.GetAxisRaw ("Horizontal");
		float _v = Input.GetAxisRaw ("Vertical");
		move = new Vector3 (_h, 0, _v).normalized * speedEdit;
		if (move.x != 0 || move.y != 0) {
			transform.Translate (move);
			transform.position = new Vector3 (
				Mathf.Clamp (transform.position.x, boundary.xMin, boundary.xMax),
				0,
				Mathf.Clamp (transform.position.z, boundary.zMin, boundary.zMax)
			);
		}
		transform.rotation = Quaternion.Euler (0, 0, -tilt * move.x);
		*/

		//touch
		//if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
		//	Ray _ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

		//pc touch
		#if UNITY_EDITOR
		//pc touch controllerz
		Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(plane.Raycast(_ray, out distacne)){
			transform.position = _ray.GetPoint(distacne);
			transform.position = new Vector3 (
				Mathf.Clamp (transform.position.x, boundary.xMin, boundary.xMax),
				0,
				Mathf.Clamp (transform.position.z, boundary.zMin, boundary.zMax)
			);
		}
		//transform.rotation = Quaternion.Euler (0, 0, -tilt * move.x);
		#else
		//mobile touch control
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
			Ray _ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			if(plane.Raycast(_ray, out distacne)){
				transform.position = _ray.GetPoint(distacne);
				transform.position = new Vector3 (
					Mathf.Clamp (transform.position.x, boundary.xMin, boundary.xMax),
					0,
					Mathf.Clamp (transform.position.z, boundary.zMin, boundary.zMax)
				);
			}
		}
		#endif
	}


	void Shoot(){
		//if (Input.GetMouseButton (0) && Time.time > spawnTime) {
		if ( Time.time > spawnTime) {
			spawnTime = Time.time + spawnBetweenTime;

			switch (fireMode) {
			case STATS_FIRE_MODE.One:
				PoolManager.ins.Instantiate ("PlayerBullet", spawnPoint.position, Quaternion.identity);
				break;
			case STATS_FIRE_MODE.Two:
				PoolManager.ins.Instantiate ("PlayerBullet", spawnPointl.position, Quaternion.identity);
				PoolManager.ins.Instantiate ("PlayerBullet", spawnPointr.position, Quaternion.identity);
				break;
			case STATS_FIRE_MODE.Three:
				PoolManager.ins.Instantiate ("PlayerBullet", spawnPoint.position, Quaternion.identity);
				PoolManager.ins.Instantiate ("PlayerBullet", spawnPointl.position, Quaternion.identity);
				PoolManager.ins.Instantiate ("PlayerBullet", spawnPointr.position, Quaternion.identity);
				break;
			case STATS_FIRE_MODE.Five:
				PoolManager.ins.Instantiate ("PlayerBullet", spawnPoint.position, Quaternion.identity);
				PoolManager.ins.Instantiate ("PlayerBullet", spawnPointl.position, Quaternion.identity);
				PoolManager.ins.Instantiate ("PlayerBullet", spawnPointr.position, Quaternion.identity);
				PoolManager.ins.Instantiate ("PlayerBullet", spawnPointr2.position, Quaternion.identity);
				PoolManager.ins.Instantiate ("PlayerBullet", spawnPointl2.position, Quaternion.identity);
				break;
			}

			SoundManager.ins.Play ("weapon_player");
		}
	}
}


[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}