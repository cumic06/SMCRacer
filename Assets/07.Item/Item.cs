using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite sprite;
    [SerializeField] protected string useString;
    [SerializeField] protected int value;
    [SerializeField] protected Color color;
    [SerializeField] AudioClip useSound;

    private Coroutine cor;

    protected void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCar player))
        {
            EatItem();
        }
    }

    public virtual void EatItem()
    {
        PlayerCar.Instance.inventory.AddItem(this);
        gameObject.SetActive(false);
    }

    public virtual void UseItem()
    {
        if (cor != null)
        {
            StopCoroutine(cor);
        }
        cor = InGameUIManager.Instance.StartCoroutine(InGameUIManager.Instance.UseItem(useString, color));

        SoundSystem.Instance.SfxPlay(useSound, 0.5f);
    }
}
