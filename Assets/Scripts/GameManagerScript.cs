using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour 
{
	private static GameManagerScript mInstance;

	public static GameManagerScript Instance
	{
		get
		{
			if (mInstance == null)
			{
				GameObject[] tempObjectList = GameObject.FindGameObjectsWithTag("GameManager");

				if (tempObjectList.Length > 1) 
				{
					Debug.LogError ("You have more than 1 Game Manager in the scene");
				}
				else if (tempObjectList.Length == 0)
				{
					// If i can't find a game manager in the game
					GameObject obj = new GameObject("_GameManager");
					mInstance = obj.AddComponent<GameManagerScript> ();
					obj.tag = "GameManager";
				}
				else
				{
					if (tempObjectList[0] != null)
					{
						Debug.Log("Found a Game Manager");
						mInstance = tempObjectList[0].GetComponent<GameManagerScript>();
					}

				}
			}
			return mInstance;
		}
	}

	// Use this for initialization
	void Start ()
	{
		Scene curScene = SceneManager.GetActiveScene();
		if (curScene.buildIndex == 0)
		{
			SoundManagerScript.Instance.PlayBGM(SoundManagerScript.AudioClipID.BGM_MAINMENU);
		}
		else if (curScene.buildIndex == 1)
		{
			SoundManagerScript.Instance.PlayBGM(SoundManagerScript.AudioClipID.BGM_LEVEL);
		}
		else if (curScene.buildIndex == 2)
		{
			SoundManagerScript.Instance.StopBGM();
		}
		else if (curScene.buildIndex == 3)
		{
			SoundManagerScript.Instance.StopBGM();
		}
	}

	public void btn_StartGame()
	{
		SceneManager.LoadScene(1);
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}	
	}
}