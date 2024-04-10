using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    [SerializeField] AudioClip crashSound;
    private void Start()
    {
        StartCoroutine(DestroyEffect());
        SoundSystem.Instance.SfxPlay(crashSound, 0.5f);
    }

    private IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
