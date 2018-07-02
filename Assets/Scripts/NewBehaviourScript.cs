using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
public class NewBehaviourScript : MonoBehaviour
{
	[SerializeField] private GameObject prefab;
	[SerializeField] private Sprite activeSprite;
	[SerializeField] private Sprite inActiveSprite;

	// Use this for initialization
	void Start () {

		for(int i = 0; i < 5; i++)
		{
			var obj = Instantiate(prefab);
			obj.transform.SetParent(this.transform, false);
			obj.GetComponentInChildren<ItemView>().Setup(activeSprite, inActiveSprite, "Item" + i.ToString());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}
