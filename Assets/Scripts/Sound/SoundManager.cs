using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
	AudioSource _sfxAudioSource;

	// Use this for initialization
	void Start ()
	{
		_sfxAudioSource = gameObject.AddComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySfx(string name)
	{
		if (!_sfxAudioSource.isPlaying)
		{
			AudioClip audioClip = Resources.Load(name) as AudioClip;

			if (audioClip != null)
			{
				StartCoroutine(SourcePlayClip(_sfxAudioSource, audioClip));
			}
			else
			{
				Debug.Log("Not found audio:" + name);
			}
		}
		else
		{
			Debug.Log("AudioSource in use");
		}
	}

	public bool IsPlayingSfx()
	{
		return _sfxAudioSource != null && _sfxAudioSource.isPlaying;
	}

	IEnumerator SourcePlayClip(AudioSource source, AudioClip clip) 
	{
		source.clip = clip;
		source.Play();
		yield return new WaitForSeconds(clip.length);
		source.clip = null;
	}
}
