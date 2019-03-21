using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

	private static SoundManagerScript mInstance;

	public static SoundManagerScript Instance
	{
		get
		{
			if (mInstance == null)
			{
				GameObject[] tempObjectList = GameObject.FindGameObjectsWithTag("SoundManager");

				if (tempObjectList.Length > 1) 
				{
					Debug.LogError ("You have more than 1 Sound Manager in the scene");
				}
				else if (tempObjectList.Length == 0)
				{
					// If i can't find a game manager in the game
					GameObject obj = new GameObject("_SoundManager");
					mInstance = obj.AddComponent<SoundManagerScript> ();
					obj.tag = "SoundManager";
				}
				else
				{
					if (tempObjectList[0] != null)
					{
						Debug.Log("Found a Sound Manager");
						mInstance = tempObjectList[0].GetComponent<SoundManagerScript>();
					}
				}
				DontDestroyOnLoad(mInstance.gameObject);
			}
			return mInstance;
		}
	}

	public static SoundManagerScript CheckInstance ()
	{
		return mInstance;
	}

	public enum AudioClipID
	{
		SFX_SHOOT = 0,
		SFX_DEATH,
		BGM_MAINMENU = 99,
		BGM_BOSS,
		BGM_LEVEL,
	}

	[System.Serializable]
	public class AudioClipInfo
	{
		public AudioClipID audioID;
		public AudioClip audioClip;
	}

	public List<AudioClipInfo> audioClipList = new List<AudioClipInfo>();

	public AudioSource sfxAudioSource;
	public AudioSource bgmAudioSource;

	public float sfxVolume;
	public float bgmVolume;

	// Use this for initialization
	void Start () 
	{
		if (SoundManagerScript.CheckInstance())
		{
			Destroy(this.gameObject);
		}
	}

	AudioClip FindAudioClip (AudioClipID audioID)
	{
		for (int i = 0; i < audioClipList.Count; i++)
		{
			if (audioClipList[i].audioID == audioID)
			{
				return audioClipList[i].audioClip;
			}
		}

		Debug.Log ("Cannot find audioClip : " + audioID);
		return null;
	}

	// BGM Functions
	public void PlayBGM (AudioClipID bgmAudioID)
	{
		bgmAudioSource.volume = bgmVolume;
		bgmAudioSource.clip = FindAudioClip(bgmAudioID);
		bgmAudioSource.loop = true;
		bgmAudioSource.Play();
	}

	public void PauseBGM ()
	{
		if (bgmAudioSource.isPlaying)
		{
			bgmAudioSource.Pause();
		}
		else
		{
			bgmAudioSource.UnPause();
		}
	}

	public void StopBGM ()
	{
		if (bgmAudioSource.isPlaying)
		{
			bgmAudioSource.Stop();
		}
		else
		{
			bgmAudioSource.Play();
		}
	}

	// SFX Functions
	public void PlaySFX (AudioClipID sfxAudioID)
	{
		sfxAudioSource.volume = bgmVolume;
		sfxAudioSource.PlayOneShot(FindAudioClip(sfxAudioID), sfxVolume);
	}

	public void StopSFX ()
	{

	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}