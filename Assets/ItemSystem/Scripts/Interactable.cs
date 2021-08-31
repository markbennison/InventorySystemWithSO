using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	[SerializeField]
	protected ItemObject itemObject;
	[SerializeField]
	protected int quantity = 1;

	protected Interactor interator;

	GameObject itemGameObject;

	private void Awake()
	{

	}

	public virtual void Interact()
	{
		Debug.Log("Interacting with " + transform.name);
	}

	public virtual void Interact(Interactor interator)
	{
		Debug.Log("Interacting with " + transform.name + ". (Interactor passed.)");
		this.interator = interator;
	}

	//public virtual void Drop(Vector3 dropPosition)
	//{
	//itemGameObject = Instantiate(itemObject.itemPrefab, dropPosition, Quaternion.identity);
	//itemGameObject.transform.parent = transform;
	//}
}
