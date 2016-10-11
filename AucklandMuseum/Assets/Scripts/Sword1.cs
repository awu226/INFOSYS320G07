using UnityEngine;
using UnityEngine.UI;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sword1: MonoBehaviour {
    public GameObject myPrefab;
	public Text title; 
	public Text owner;
	public Text dateUsed;
	public Text description;
	public Text category;
	public Text dimension;
	public Text personId;
	public Text personFirstName;
	public Text personGender;



    // Put your URL here
	public string _WebsiteURL = "http://ccha504.azurewebsites.net/tables/Weapon?zumo-api-version=2.0.0";
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
		Weapon[] weapons = JsonReader.Deserialize<Weapon[]> (jsonResponse);
		Person[] persons = JsonReader.Deserialize<Person[]> (jsonResponse2);



		GameObject dagger = (GameObject)Instantiate (myPrefab, new Vector3 (-2, 4, 0), Quaternion.identity);
		dagger.transform.localScale = new Vector3 (3,3, 3);
		dagger.transform.localRotation = Quaternion.Euler (90, 60, 0);
		dagger.AddComponent<Rotation> ();
	
		title.text = weapons[1].NameTitle;
		owner.text = owner.text + weapons [1].Keeper;
		dateUsed.text = dateUsed.text + weapons [1].LastModified;
	
		description.text = description.text + weapons [1].Description;
		category.text = category.text + weapons [1].Category;
		dimension.text = dimension.text + weapons [1].Dimesion;
		personId.text = personId.text + persons [0].PersonID;
		personFirstName.text = personFirstName.text + persons [0].FirstName + " " + persons [0].LastName;;

		personGender.text = personGender.text + persons [0].Gender;
	
	}

	// Update is called once per frame
	void Update () {
		
	}
}
