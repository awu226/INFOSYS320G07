using UnityEngine;
using UnityEngine.UI;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class PersonData : MonoBehaviour {
	public GameObject daggerprefab;
	public GameObject swordprefab;
	public GameObject cutterprefab;
	public Text personID; 
	public Text personTitle; 
	public Text personGender;
	public Text personDOB;
	public Text weapon1;
	public Text weapon2;
	public Text weapon3;
	public Text weapon1info;
	public Text weapon2info;
	public Text weapon3info;





	// Put your URL here
	public string _WebsiteURL = "http://ccha504.azurewebsites.net/tables/PersonWeapon?zumo-api-version=2.0.0";
	public string _WebsiteURL2 = "http://ccha504.azurewebsites.net/tables/Person?zumo-api-version=2.0.0";

	void Start () {
		//Reguest.GET can be called passing in your ODATA url as a string in the form:
		//http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
		//The response produce is a JSON string
		string jsonResponse = Request.GET (_WebsiteURL);
		string jsonResponse2 = Request.GET (_WebsiteURL2);

		//Just in case something went wrong with the request we check the reponse and exit if there is no response.
		if (string.IsNullOrEmpty (jsonResponse)) {
			return;
		}

		//We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
		PersonWeapon[] personweapons = JsonReader.Deserialize<PersonWeapon[]> (jsonResponse);
		Person[] persons = JsonReader.Deserialize<Person[]> (jsonResponse2);

	

		GameObject dagger = (GameObject)Instantiate (daggerprefab, new Vector3 (-11, 1, 0), Quaternion.identity);
		GameObject sword = (GameObject)Instantiate (swordprefab, new Vector3 (-1, 1, 0), Quaternion.identity);
		GameObject cutter = (GameObject)Instantiate (cutterprefab, new Vector3 (7, 1, 0), Quaternion.identity);
		dagger.transform.localScale = new Vector3 (2,2, 3);
		dagger.transform.localRotation = Quaternion.Euler (130, 60, 0); 

		sword.transform.localScale = new Vector3 (2,2, 2);
		sword.transform.localRotation = Quaternion.Euler (90, 60, 0); 

		cutter.transform.localScale = new Vector3 (3, 3, 3);
		cutter.transform.localRotation = Quaternion.Euler (90, 60, 0); 



		personID.text = personID.text + persons [0].PersonID;
		personTitle.text = persons[0].FirstName + " " + persons[0].LastName;
		personGender.text = personGender.text + persons [0].Gender;
		personDOB.text = personDOB.text + persons [0].DOB;
	
		weapon1.text = "Dagger: " + personweapons [0].ObjectID;
		weapon2.text = "Sword: " + personweapons [1].ObjectID;
		weapon3.text = "Cutter: " + personweapons [2].ObjectID;
		weapon1info.text = "From: " + personweapons[0].AccessFrom + " To: " + personweapons[0].AccessTo;
		weapon2info.text = "From: " + personweapons[1].AccessFrom + " To: " + personweapons[1].AccessTo;
		weapon3info.text = "From: " + personweapons[2].AccessFrom + " To: " + personweapons[2].AccessTo;


	}

	// Update is called once per frame
	void Update () {

	}
}
