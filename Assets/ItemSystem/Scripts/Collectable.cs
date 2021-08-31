using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
	public override void Interact()
	{
		base.Interact();

		Pickup();
	}

	void Pickup()
	{
		Debug.Log("Picked up " + transform.name);

		if (itemObject.useOnPickup)
		{
			Use();
		}

			
	}

	void Use()
	{
		if (itemObject.consumable)
		{
			quantity--;
			if (quantity <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
