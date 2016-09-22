using UnityEngine;
using System.Collections;

public class NextScene : MonoBehaviour 
{
	public void NextLevelButton(int index)
	{
		Application.LoadLevel(index);
	}

	public void NextLevelButton()
	{
		Application.LoadLevel("Main");
	}
}