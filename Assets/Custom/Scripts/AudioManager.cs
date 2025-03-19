using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //reference to music clips
    public Music[] musics;

    private string currentMusicID;

    private void Awake()
    {
        //create audiosources
        foreach (Music m in musics)
        {
            m.musicSource = gameObject.AddComponent<AudioSource>();
            m.musicSource.clip = m.musicClip;
        }

        //play first music
        currentMusicID = musics[0].musicID; 
        musics[0].musicSource.Play();
    }

    public void ChangeMusic(string newMusicID)
    {
        //stop current music
        foreach (Music m in musics)
        {
            if (m.musicID == currentMusicID)
            {
                m.musicSource.Stop();
                break;
            }
        }

        //change currentmusicID
        currentMusicID = newMusicID;

        //play new music
        foreach (Music m in musics)
        {
            if (m.musicID == currentMusicID)
            {
                m.musicSource.Play();
                break;
            }
        }
    }
}
