using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {
	public int healthMax = 5;
	protected int health;
	protected bool bDeath = false;

	public virtual void Start(){
		Init ();
	}

	public virtual void Destroy(){
		gameObject.SetActive (false);
	}

	public bool Damage(int _damage){
		bool _rtn = false;
		health -= _damage;
		if (health <= 0 && !bDeath) {
			bDeath = true;
			health = 0;
			_rtn = true;
		}

		return _rtn;
	}

	public virtual void Init(){
		health = healthMax;
	}
}
