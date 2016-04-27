using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class HitAttempt : MonoBehaviour {

	public string Player;
	public string Target;

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject != null){
			if(other.gameObject.name == Target + "Head"){
				if(GameObject.Find(Player).GetComponent<PlayerControl>().onHit){
					GameObject.Find(Target).GetComponent<PlayerControl>().Death();
				}	
			}
		}
	}
}
