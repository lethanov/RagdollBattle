using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControl : MonoBehaviour {

	[Header("[DEBUG] Global parameters [DEBUG]")]
	public float Gravity = 9.81f;
	public int ScoreLimit = 3;
	public float PlayerMovementSpeed = 20;
	[Header("(in seconds)")]
	public float PlayerCooldownShoot = 1;

	public Transform FirstSpawner;
	public Transform SecondSpawner;

	private string _gameStatus;
	private float _timer;
	private Text _readyGoText;
	// Use this for initialization
	void Start () {
		_gameStatus = "init";
		_readyGoText = GameObject.Find("321Play").GetComponent<Text>();
		Physics.gravity = new Vector3(0, -Gravity, 0);
	}
	
	// Update is called once per frame
	void Update () {
		_timer += Time.deltaTime;
		if(_gameStatus == "init"){
			Instantiate(Resources.Load("321Sound"), transform.position, Quaternion.identity);
			_gameStatus = "ready";
			_readyGoText.text = "3";
		}
		if(_gameStatus == "ready"){
			if(_timer > 0.4f){
				_readyGoText.text = "2";
			}
			if(_timer > 0.8f){
				_readyGoText.text = "1";
			}
			if(_timer > 1.2f){
				_readyGoText.text = "Débattez !";
				_gameStatus = "play";
				GameObject Hollande = (GameObject)Instantiate(Resources.Load("Hollande"), FirstSpawner.position, Quaternion.identity);
				GameObject Sarkozy = (GameObject)Instantiate(Resources.Load("Sarkozy"), SecondSpawner.position, Quaternion.identity);
				Hollande.name = "Hollande";
				Sarkozy.name = "Sarkozy";
			}
		}
		if(_gameStatus == "play"){
			if(_timer > 2){
				_readyGoText.text = "";
			}
		}
	}
}
