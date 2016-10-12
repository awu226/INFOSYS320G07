using UnityEngine;
using UnityEngine.UI;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Katana: MonoBehaviour {
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



		GameObject dagger = (GameObject)Instantiate (myPrefab, new Vector3 (-9, 5, 0), Quaternion.identity);
		dagger.transform.localScale = new Vector3 (7,7, 7);
		dagger.transform.localRotation = Quaternion.Euler (90, 60, 0); 
		dagger.AddComponent<Rotation> ();
	
	
		title.text = weapons[3].NameTitle;
		owner.text = owner.text + weapons [3].Keeper;
		dateUsed.text = dateUsed.text + weapons [3].LastModified;
	
		description.text = description.text + weapons [3].Description;
		category.text = category.text + weapons [3].Category;
		dimension.text = dimension.text + weapons [3].Dimesion;
		personId.text = personId.text + persons [1].PersonID;
		personFirstName.text = personFirstName.text + persons [1].FirstName + " " + persons [1].LastName;;

		personGender.text = personGender.text + persons [1].Gender;
	
	}

	// Update is called once per frame
	void Update () {
		
	}
}
