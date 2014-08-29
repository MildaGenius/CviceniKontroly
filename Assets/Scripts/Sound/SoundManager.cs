using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
	AudioSource _sfxAudioSource;

	private bool _playLoop;
	private int _indexToPlay;
	private List<string> _playList;
	private string _path = "cz/milda/";

	// Use this for initialization
	void Start ()
	{
		_playList = new List<string> ();
		_sfxAudioSource = gameObject.AddComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//can we play next sfx
		if (!IsPlayingSfx())
		{
			//something to play
			if (_indexToPlay < _playList.Count)
			{
				PlaySfx(_playList[_indexToPlay]);
				_indexToPlay++;
			}
			else if (_playLoop)
			{
				_indexToPlay = 0;//play from start again
			}
		}
	}

	public void AddToPlayList(string initialSfx, List<string> sfxToPlay, bool loop)
	{
		_playLoop = loop;

		_playList.Clear();
		_playList.Add(initialSfx);
		_playList.AddRange(sfxToPlay);
	}

	public void PlaySfx(string name)
	{
		if (!_sfxAudioSource.isPlaying)
		{
			AudioClip audioClip = Resources.Load(_path + name, typeof(AudioClip)) as AudioClip;

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
