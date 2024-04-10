using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoSingleton<SoundSystem>
{
    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource shopSource;
    [SerializeField] AudioSource sfxSource;

    public void BgmPlay(AudioClip bgm)
    {
        bgmSource.PlayOneShot(bgm);
    }

    public void ShopPlay(bool value)
    {
        if (value == true)
        {
            bgmSource.enabled = false;
            shopSource.enabled = true;
        }
        else
        {
            bgmSource.enabled = true;
            shopSource.enabled = false;
        }
    }

    public void SfxPlay(AudioClip sfx, float volume)
    {
        sfxSource.PlayOneShot(sfx, volume);
    }
}