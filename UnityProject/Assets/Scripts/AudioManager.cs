using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
  private static AudioManager s_instance = null;

  public static AudioManager get() {return s_instance;}

  void Awake()
  {
    if(s_instance != null)
      throw new System.Exception("AudioManager is a singleton!");

    s_instance = this;

  }

  public void PlayOnce(AudioClip sound)
  {
    if(sound != null)
    {
      AudioSource source = null;
      try
      {
        source = m_sources[sound.name];
      }
      catch(KeyNotFoundException)
      {
        source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
        source.loop = false;
        source.clip = sound;
        m_sources.Add(sound.name, source);
      }

      source.Play();
    }
  }

  public void Play(AudioClip sound)
  {
    if(sound != null && !m_sources.ContainsKey(sound.name))
    {
      AudioSource source = gameObject.AddComponent<AudioSource>();
      source.clip = sound;
      source.loop = true;
      source.playOnAwake = false;

      source.Play();

      m_sources.Add(sound.name, source);
    }
  }

  public void Stop(AudioClip sound)
  {
    if(sound != null && m_sources.ContainsKey(sound.name))
    {
      AudioSource source = m_sources[sound.name];
      source.Stop();
      m_sources.Remove(sound.name);
      Destroy(source);
    }
  }

  /*mapping clip name to source*/
  private Dictionary<string, AudioSource> m_sources = new Dictionary<string, AudioSource>();


}
