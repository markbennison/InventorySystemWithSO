using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemObject", menuName = "Item System/Add Default", order = 1)]
public class ItemObject : ScriptableObject
{
	public GameObject itemPrefab;
	public Sprite icon;

	public string itemName;
	[TextArea(4,16)]
	public string description;

	public float weight = 0;
	public int maxStackableQuantity = 1;  // For when you may decide to have bundles of items, such as arrows

	public bool useOnPickup = true;  // If true, item will be used on pickup
	public bool consumable = true;  // if true, item will be destroyed (or quantity decremented if greater than 1) when used



}
