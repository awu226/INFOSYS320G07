using UnityEngine;
using UnityEngine.UI;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class PersonDataKenny : MonoBehaviour {
	public GameObject rapierprefab;
	public Text personID; 
	public Text personTitle; 
	public Text personGender;
	public Text personDOB;
	public Text weapon1;
	public Text weapon1info;







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

	

		GameObject rapier = (GameObject)Instantiate (rapierprefab, new Vector3 (-9, 2, 0), Quaternion.identity);


		rapier.transform.localScale = new Vector3 (2,2, 2);
		rapier.transform.localRotation = Quaternion.Euler (130, 60, 0); 



	

		personID.text = personID.text + persons [2].PersonID;
		personTitle.text = persons[2].FirstName + " " + persons[2].LastName;
		personGender.text = personGender.text + persons [2].Gender;
		personDOB.text = personDOB.text + persons [2].DOB;
	
		weapon1.text = "Rapier (" + personweapons [4].ObjectID + ")";


		weapon1info.text = personweapons[4].AccessFrom + " - " + personweapons[4].AccessTo;



	}

	// Update is called once per frame
	void Update () {

	}
}
