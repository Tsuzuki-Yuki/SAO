using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

namespace UI
{
	public class ItemViewPresenter : MonoBehaviour
	{
		List<ItemView> itemList = new List<ItemView>();
		[SerializeField] GameObject itemViewPrefab;
		[SerializeField] Color onSelectedArrowColor;
		[SerializeField] private Sprite activeSprite;
		[SerializeField] private Sprite inActiveSprite;
		[SerializeField] int itemNum;

		[SerializeField] Image arrow;
		[SerializeField] RectTransform rect;

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
				OnSelectedAutoScroll(itemView);
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

		private void OnSelectedAutoScroll(ItemView selectedItem)
		{
			var index = itemList.IndexOf(selectedItem);
			rect.DOAnchorPosY(index * (100f + 5f), 0.3f);
		}
	}
}
