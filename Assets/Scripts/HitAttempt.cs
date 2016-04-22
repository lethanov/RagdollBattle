using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class HitAttempt : MonoBehaviour {

	public UnityEvent Collision;
	public PlayerControl Player;
	public GameObject Target;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (Collision != null) {
			if(other.gameObject == Target && Player.onHit)	Collision.Invoke ();
		}
	}
}
