using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_Config_Map : MonoBehaviour
{
    //Music
    private bool Som = true;
    public AudioSource BackMusic;

    //Sprite Button
    public Sprite SpriteOnSond;
    public Sprite SpriteOffSond;

    public Image MuteImage;

    //slider
    public Slider VolumeSlier;


    public void OnOffSond()
    {
        Som = !Som;
        BackMusic.enabled = Som;

        if (Som)
        {
            MuteImage.sprite = SpriteOnSond;
        }
        else
        {
            MuteImage.sprite = SpriteOffSond;
        }
    }

    //Slide
    public void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlier.value;
        Save();
    }

    private void Load()
    {
        VolumeSlier.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", VolumeSlier.value);
    }

}
