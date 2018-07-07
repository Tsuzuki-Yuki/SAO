using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace UI
{
	public class ItemView : MonoBehaviour
	{

		[SerializeField] private Button button;
		public Button ItemButton { get { return button; } }
		[SerializeField] private Image iconImage;
		[SerializeField] private Text itemText;
		[SerializeField] private Image backgroundImage;

		[SerializeField] private Color selectedImageColor;
		[SerializeField] private Color unSelectedImageColor;
		[SerializeField] private Color selectedTextColor;
		[SerializeField] private Color unSelectedTextColor;

		private Sprite activeSprite;
		private Sprite inActiveSprite;

		private bool _onSelected;
		public bool OnSelected { get { return _onSelected; } }

		public void Setup(Sprite activeSprite, Sprite inActiveSprite, string itemText)
		{
			this.activeSprite = activeSprite;
			this.inActiveSprite = inActiveSprite;
			this.iconImage.sprite = inActiveSprite;
			this.itemText.text= itemText;
			_onSelected = false;
		}

		public void Selected()
		{
			iconImage.sprite = activeSprite;
			iconImage.color = Color.white;
			itemText.color = selectedTextColor;
			backgroundImage.color = selectedImageColor;
			_onSelected = true;
		}

		public void Unselected()
		{
			iconImage.sprite = inActiveSprite;
			iconImage.color = unSelectedImageColor;
			itemText.color = unSelectedTextColor;
			backgroundImage.color = unSelectedImageColor;
			_onSelected = false;
		}

		public void Default()
		{
			iconImage.sprite = inActiveSprite;
			iconImage.color = Color.white;
			itemText.color = Color.black;
			backgroundImage.color = Color.white;
			_onSelected = false;
		}
	}
}
