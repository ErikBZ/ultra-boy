using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Texture))]
public class LivesCounter : MonoBehaviour {


	[SerializeField]
	private Text _livesText;
	// Use this for initialization
	void Start () {
		
	}

	void Awake(){
		_livesText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		HealthController health = new HealthController ();
		_livesText.text = "HEALTH:  " + health.Health;
		
	}

}
