using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using System.Linq;

namespace UI
{
	public class ItemViewPresenter : MonoBehaviour
	{
		List<ItemView> itemList = new List<ItemView>();
		[SerializeField] GameObject itemViewPrefab;
		[SerializeField] Image arrow;
		[SerializeField] Color onSelectedArrowColor;
		[SerializeField] private Sprite activeSprite;
		[SerializeField] private Sprite inActiveSprite;
		[SerializeField] int itemNum;

		void Awake()
		{
			for(int i = 0; i < itemNum; i++)
			{
				var itemObj = Instantiate(itemViewPrefab);
				itemObj.transform.SetParent(transform, false);
				var itemView = itemObj.GetComponent<ItemView>();

				itemView.Setup(activeSprite, inActiveSprite, "Items");
				itemView.Default();
				itemList.Add(itemView);

				itemView.ItemButton.OnClickAsObservable().Subscribe(_ =>
				{
					ViewLogic(itemView);
				});
			}
		}

		private void ViewLogic(ItemView itemView)
		{
			if(!itemView.OnSelected)
			{
				itemView.Selected();
				foreach(var item in itemList.FindAll(item => item != itemView))
				{
					item.Unselected();
				}
				arrow.color = onSelectedArrowColor;
			}
			else
			{
				foreach(var item in itemList)
				{
					item.Default();
				}
				arrow.color = Color.white;
			}
		}
	}
}
