using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

public class ItemRandomSpawnSystem : MonoBehaviour
{
    [SerializeField] private Item[] items;
    [SerializeField] private List<Transform> itemSpawnPosList = new();

    private void Start()
    {
        StartCoroutine(ItemSpawn());
    }

    private void Awake()
    {
        itemSpawnPosList = GetComponentsInChildren<Transform>().ToList();
        itemSpawnPosList.Remove(transform);
    }

    private IEnumerator ItemSpawn()
    {
        foreach (Transform itemPos in itemSpawnPosList)
        {
            int randomItem = Random.Range(0, items.Length);
            GameObject spawnItem = Instantiate(items[randomItem].gameObject, itemPos);
            spawnItem.transform.position = itemPos.position;
        }

        while (true)
        {
            foreach (var itemPos in itemSpawnPosList)
            {
                int randomItem = Random.Range(0, items.Length);
                if (!itemPos.GetChild(itemPos.childCount - 1).gameObject.activeSelf)
                {
                    yield return new WaitForSeconds(1.5f);
                    GameObject spawnItem = Instantiate(items[randomItem].gameObject, itemPos);
                    spawnItem.transform.position = itemPos.position;
                }
            }
            yield return null;
        }
    }
}
