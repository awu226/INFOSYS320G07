	using UnityEngine;
	using System.Collections;

	public class Sword : MonoBehaviour {
	
		
		Animator anim;
		// Use this for initialization

		

		void OnTriggerEnter(Collider coll){
		Debug.Log ("Trigger");
			if(coll.gameObject.name.Equals("Player"))
			{
			Debug.Log ("Player");
			if(Input.GetKey(KeyCode.C))
				{
				Debug.Log ("c");
					Application.LoadLevel("Title");

				}
			}
		}
		

	}
