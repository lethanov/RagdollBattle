using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public string PlayerName = "Player1";
	public Rigidbody2D FistControl;

	public float MovementSpeed;
	public float CooldownShoot;

	private float timerShoot;

	private Rigidbody2D RigidBody;

	private float LC_XVelocity;
	private float LC_YVelocity;

	private float RC_XVelocity;
	private float RC_YVelocity;

	private bool alive;

	[HideInInspector] public bool onHit;
	
	void Start () {
		alive = true;
		RigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		OnHitManage();
	}

	void OnHitManage(){
		if (timerShoot < 0.1f) {
			onHit = true;
		} else {
			onHit = false;
		}

		if (alive) {
			timerShoot += Time.deltaTime;

			Control();
			
			RigidBody.velocity = new Vector3 (LC_XVelocity * MovementSpeed, LC_YVelocity * MovementSpeed, 0);
			

			
			//Uppercut
			if (RC_YVelocity < 0) {
				if (timerShoot > CooldownShoot) {
					timerShoot = 0;
					FistControl.AddForce (new Vector2 (0, 20000));
				}
			}

			//Hammer
			if (RC_YVelocity > 0) {
				if (timerShoot > CooldownShoot) {
					timerShoot = 0;
					FistControl.AddForce (new Vector2 (0, -20000));
				}
			}
			

			//Right shoot
			if (RC_XVelocity > 0) {
				if (timerShoot > CooldownShoot) {
					timerShoot = 0;
					FistControl.AddForce (new Vector2 (20000, 0));
				}
			}

			//Left shoot
			if (RC_XVelocity < 0) {
				if (timerShoot > CooldownShoot) {
					timerShoot = 0;
					FistControl.AddForce (new Vector2 (-20000, 0));
				}
			}
		}
	}

	public void Death(){
		alive = false;
		foreach (Transform victim in gameObject.GetComponentsInChildren<Transform>()) {
			Destroy (victim.GetComponent<HingeJoint2D> ());
		}
	}

	void Control(){
		if (PlayerName == "Player1") {
			LC_XVelocity = Input.GetAxis ("Player1Horizontal1");
			LC_YVelocity = Input.GetAxis ("Player1Vertical1");

			RC_XVelocity = Input.GetAxis ("Player1Horizontal2");
			RC_YVelocity = Input.GetAxis ("Player1Vertical2");
		}

		if (PlayerName == "Player2") {
			LC_XVelocity = Input.GetAxis ("Player2Horizontal1");
			LC_YVelocity = Input.GetAxis ("Player2Vertical1");

			RC_XVelocity = Input.GetAxis ("Player2Horizontal2");
			RC_YVelocity = Input.GetAxis ("Player2Vertical2");
		}
	}
}
