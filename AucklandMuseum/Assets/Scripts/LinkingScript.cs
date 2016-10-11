	using UnityEngine;
	using System.Collections;
	using UnityEngine.SceneManagement;

	public class LinkingScript : MonoBehaviour {
	
		
		Animator anim;
		// Use this for initialization

		

		void OnTriggerEnter(Collider coll){
		Debug.Log ("Trigger");

		if (coll.gameObject.name.Equals ("Player")) {
			Debug.Log (transform.name);
			if (transform.name.Equals ("Cube")) {
				SceneManager.LoadScene ("Dagger");
			} else if (transform.name.Equals ("CSword")) {
				SceneManager.LoadScene ("Sword1");
			} else if (transform.name.Equals ("CRapier")) {
				SceneManager.LoadScene ("Rapier");
			} else if (transform.name.Equals ("CKatana")) {
				SceneManager.LoadScene ("Katana");
			} else if (transform.name.Equals ("CCutter")) {
				SceneManager.LoadScene ("Cutter");
			} else if (transform.name.Equals ("CEpic")) {
				SceneManager.LoadScene ("SC2");
			} else if (transform.name.Equals ("CDag")) {
				SceneManager.LoadScene ("Dagger");
			}else if (transform.name.Equals ("abcd")) {
				SceneManager.LoadScene ("SwordEpic");
			}
		}
		

	}
	}
