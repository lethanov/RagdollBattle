using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	[Header("[DEBUG] Global parameters [DEBUG]")]
	public float Gravity = 9.81f;
	public int ScoreLimit = 3;
	public float PlayerMovementSpeed = 20;
	[Header("(in seconds)")]
	public float PlayerCooldownShoot = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
