using System.Collections.Generic;
using TMPro;
using UnityEngine;

// This class is poorly named, its more like "the thing that intereacts with interactables"
public class Inventory : MonoBehaviour
{
    public float reachDistance = 1;
    public TextMeshProUGUI toolTipText;
    public Transform reachOrigin;
    public List<GameObject> itemGameObjects;

    private HashSet<ItemType> items;
    private Interactable lookingAt;

    private void Awake()
    {
        items = new HashSet<ItemType>();
    }

    private void Update()
    {
        toolTipText.gameObject.SetActive(false);
        bool didHit = Physics.Raycast(reachOrigin.position, reachOrigin.forward, out RaycastHit hit, reachDistance);
        bool hitIntereactable = false;
        if (didHit)
        {
            // If we hit something interesting
            hitIntereactable = hit.transform.TryGetComponent(out Interactable interectable);
            if (hitIntereactable)
            {
                if (interectable != lookingAt)
                {
                    interectable.OnBeginLook();
                }

                lookingAt = interectable;

                toolTipText.gameObject.SetActive(true);
                toolTipText.SetText(interectable.GetToolTip(gameObject));

                // And if we want to interact with it
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log($"Interacting with {interectable.name}");
                    interectable.Interact(gameObject);
                }
            }
        }

        if ((!didHit || !hitIntereactable) && lookingAt != null)
        {
            lookingAt.OnEndLook();
            lookingAt = null;
        }
    }

    public void AddItem(ItemType item)
    {
        items.Add(item);
        itemGameObjects[(int)item].SetActive(true);
    }

    public void RemoveItem(ItemType item)
    {
        if (items.Remove(item))
        {
            itemGameObjects[(int)item].SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(new Ray(reachOrigin.position, reachOrigin.forward * reachDistance));
    }
}

public enum ItemType
{
    Flashlight
}
