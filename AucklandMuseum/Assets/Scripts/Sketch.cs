using UnityEngine;
using UnityEngine.UI;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
    public GameObject myPrefab;
	public Text swordUsedBy; 


    // Put your URL here
	public string _WebsiteURL = "http://ccha504.azurewebsites.net/tables/Export?zumo-api-version=2.0.0";

    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        Export[] exports = JsonReader.Deserialize<Export[]>(jsonResponse);

		int totalCubes = exports.Length;
        int totalDistance = 5;
        int i = 0;

		GameObject newSword = (GameObject)Instantiate(myPrefab, new Vector3(0, 5, 0), Quaternion.identity);
		newSword.transform.localScale = new Vector3(5, 5, 5);
		newSword.transform.localRotation = Quaternion.Euler (90, 60, 0); 
		Debug.Log (swordUsedBy.text); 
		Debug.Log (exports[1].ExportType); 
		swordUsedBy.text = swordUsedBy.text + exports [1].ExportType;


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
