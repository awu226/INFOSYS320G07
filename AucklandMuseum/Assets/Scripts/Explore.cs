using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Explore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickDagger(){

		SceneManager.LoadScene ("Dagger");
	}
	public void OnClickSword(){

		SceneManager.LoadScene ("Sword1");
	}
	public void OnClickCutter(){

		SceneManager.LoadScene ("Cutter");
	}

	public void OnClickKatana(){

		SceneManager.LoadScene ("Katana");
	}
	public void OnClickRapier(){

		SceneManager.LoadScene ("Rapier");
	}
	public void OnClickEpic(){

		SceneManager.LoadScene ("SwordEpic");
	}

	public void OnClickAnthony(){

		SceneManager.LoadScene ("Anthony");
	}
	public void OnClickLisa(){

		SceneManager.LoadScene ("Lisa");
	}
	public void OnClickKenny(){

		SceneManager.LoadScene ("Kenny");
	}
	public void OnClickBack(){

		SceneManager.LoadScene ("Main");
	}


}
