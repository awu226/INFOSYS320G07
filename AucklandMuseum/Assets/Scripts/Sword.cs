	using UnityEngine;
	using System.Collections;
	using UnityEngine.SceneManagement;

	public class Sword : MonoBehaviour {
	
		
		Animator anim;
		// Use this for initialization

		

		void OnTriggerEnter(Collider coll){
		Debug.Log ("Trigger");
			if(coll.gameObject.name.Equals("Player")){
				Debug.Log ("Sword1");
				SceneManager.LoadScene("Sword1");
		
			}
		}
		

	}
