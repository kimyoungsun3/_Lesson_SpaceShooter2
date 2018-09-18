using UnityEngine;
using System.Collections;

public class TriggerCheck : MonoBehaviour {

	void OnTriggerEnter(Collider _other){
		//Debug.Log (gameObject.tag + " <- " + _other.tag);
		if (_other.CompareTag ("Boundary")) {
			return;
		}
		
		//Debug.Log ("check ->");
		if (gameObject.CompareTag ("Enemy") && _other.CompareTag ("PlayerBullet")) {
			//총알 -> 행성, 적(C).
			//     - 파티클, 점수, 총알, 행성 파괴.
			//Debug.Log (" > Enemy <- PlayerBullet");
			AsteroidController _enemy = GetComponent<AsteroidController> ();
			Bullet _bullet = _other.GetComponent<Bullet> ();
			Vector3 _point = _other.transform.position;
				
			//asteroid and this destroy
			if (!_enemy.Damage (_bullet.power)) {
				//데미지를 줌.
				//Debug.Log("  > Damage");
				PoolManager.ins.Instantiate ("explosion_asteroid", _point, _other.transform.rotation); 
				SoundManager.ins.Play ("explosion_asteroid");

				_bullet.Destroy ();
			} else {
				//완파.
				//Debug.Log("  > Damage and destroy");
				PoolManager.ins.Instantiate ("explosion_asteroid2", _point, _other.transform.rotation); 
				SoundManager.ins.Play ("explosion_asteroid");

				_bullet.Destroy ();
				_enemy.AddScore ();
				_enemy.Destroy ();
			}
		} else if (gameObject.CompareTag ("Player") && (_other.CompareTag ("Enemy") || _other.CompareTag ("EnemyBullet"))) {
			//유저 <- 행성, 적(C)
			//		  GameOver()
			//Debug.Log (" > Player <- Enemy, EnemyBullet");

			MoveObject _player = GetComponent<PlayerController> ();
			MoveObject _enemy = _other.GetComponent<MoveObject> ();
			if (_enemy != null) {
				PoolManager.ins.Instantiate ("explosion_asteroid", transform.position, transform.rotation); 
				PoolManager.ins.Instantiate ("explosion_player", _other.transform.position, _other.transform.rotation); 
				SoundManager.ins.Play ("explosion_player");

				GameController.ins.GameOver ();

				_enemy.Destroy ();
				_player.Destroy ();
			}
		}
	}

	//약간 오차가 있음.
	//Vector3 HitPoint(Vector3 v1, Vector3 v2, float v1radius){
	//	return v2 + (v2 - v1).normalized * v1radius;
	//}
}
