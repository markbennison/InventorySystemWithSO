using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Inventory attachedInventory;

    Transform actorCamera;
    LayerMask layerMask;

    [SerializeField]
    private float maxDistanceFromCameraToObjects = 100f;
    [SerializeField]
    private float interactableDistance = 3f;
    private float distanceToInteractable;

    void Start()
    {
        layerMask = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    public void Interact()
	{
        if (Input.GetKeyDown(KeyCode.F))
        {
            actorCamera = Camera.main.transform;
            Debug.Log("Main Camera: " + actorCamera.name);

            Ray ray = new Ray(actorCamera.position, actorCamera.forward);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit, maxDistanceFromCameraToObjects, layerMask))
            {
                if (raycastHit.transform != null)
                {
                    distanceToInteractable = Vector3.Distance(transform.position, raycastHit.transform.position);
                    if (distanceToInteractable <= interactableDistance)
                    {
                        Debug.Log("In range: " + raycastHit.transform.name + " (" + distanceToInteractable.ToString("0.00") + " units)");
                        Interactable interactable = raycastHit.transform.GetComponent<Interactable>();
                        if (interactable != null)
                        {
                            interactable.Interact(this);
                        }
                    }

                }
                //raycastHit

            }

        }
    }

    public void PutInStorage(ItemObject itemObject, int quantity)
	{
        if (attachedInventory != null)
        {
            attachedInventory.AddItem(itemObject, quantity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactableDistance);
    }
}
