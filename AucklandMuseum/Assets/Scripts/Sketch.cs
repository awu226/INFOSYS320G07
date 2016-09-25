using UnityEngine;
using UnityEngine.UI;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
    public GameObject myPrefab;
	public Text swordTitle; 
	public Text swordOwner;
	public Text swordDateUsed;
	public Text swordName;
	public Text swordDescription;
	public Text swordCategory;
	public Text swordDimension;
	public Text personId;
	public Text personFirstName;
	public Text personLastName;
	public Text personGender;


    // Put your URL here
	public string _WebsiteURL = "http://kwon709.azurewebsites.net/tables/Weapon?zumo-api-version=2.0.0";
	public string _WebsiteURL2 = "http://kwon709.azurewebsites.net/tables/Person?zumo-api-version=2.0.0";

    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);
		string jsonResponse2 = Request.GET(_WebsiteURL2);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
		Weapon[] weapons = JsonReader.Deserialize<Weapon[]>(jsonResponse);
		Person[] persons = JsonReader.Deserialize<Person[]>(jsonResponse2);

		int totalCubes = weapons.Length;
        int totalDistance = 5;
        int i = 0;

		GameObject newSword = (GameObject)Instantiate(myPrefab, new Vector3(0, 5, 0), Quaternion.identity);
		newSword.transform.localScale = new Vector3(5, 5, 5);
		newSword.transform.localRotation = Quaternion.Euler (90, 60, 0); 
	
	
		swordTitle.text = swordTitle.text;
		swordOwner.text = swordOwner.text + weapons [0].Keeper;
		swordDateUsed.text = swordDateUsed.text + weapons [0].LastModified;
		swordName.text = swordName.text + weapons [0].NameTitle;
		swordDescription.text = swordDescription.text + weapons [0].Description;
		swordCategory.text = swordCategory.text + weapons [0].Category;
		swordDimension.text = swordDimension.text + weapons [0].Dimesion;
		personId.text = personId.text + persons [0].PersonID;
		personFirstName.text = personFirstName.text + persons [0].FirstName;
		personLastName.text = personLastName.text + persons [0].LastName;
		personGender.text = personGender.text + persons [0].Gender;



        //We can now loop through the array of objects and access each object individually
//		foreach (Export e in exports)x
//        {
//            //Example of how to use the object
//            Debug.Log("This products name is: " + e.ValueCategory);
//            float perc = i / (float)totalCubes;
//            i++;
//            float x = perc * totalDistance;
//
//			if (e.ValueCategory == "High") {
//            	float y = 8.0f;
//            	float z = 0.0f;
//            	GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
//            	newCube.GetComponent<myCubeScript>().setSize(0.3f);
//				newCube.GetComponent<myCubeScript>().rotateAround = Vector3.down;
//            	newCube.GetComponent<myCubeScript>().rotateSpeed = perc;
//				newCube.GetComponentInChildren<TextMesh> ().text = e.ValueCategory;
//				newCube.GetComponent<Renderer> ().material = material1;
//
//
//			} else if (e.ValueCategory == "Medium"){
//
//				float y = 5.0f;
//				float z = 0.0f;
//				GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
//				newCube.GetComponent<myCubeScript>().setSize(0.5f);
//				newCube.GetComponent<myCubeScript>().rotateSpeed = perc;
//				newCube.GetComponentInChildren<TextMesh> ().text = e.ValueCategory;
//				newCube.GetComponent<Renderer> ().material = material3;
//
//
//
//			}
//			else {
//				float y = 2.0f;
//				float z = 0.0f;
//				GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
//				newCube.GetComponent<myCubeScript>().setSize(0.7f);
//				newCube.GetComponent<myCubeScript>().rotateSpeed = perc;
//				newCube.GetComponentInChildren<TextMesh> ().text = e.ValueCategory;
//				newCube.GetComponent<Renderer> ().material = material2 ;
//			}
//        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
