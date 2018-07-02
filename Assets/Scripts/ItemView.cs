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
	[SerializeField] Toggle _toggle;
	[SerializeField] private Image _activeIcon;
	[SerializeField] private Image _inActiveIcon;
	[SerializeField] private Text _itemText;
	[SerializeField] private Image _backgroundImage;
	[SerializeField] private Color _onSelectedImageColor;
	[SerializeField] private Color _onUnSelectedImageColor;
	[SerializeField] private Color _onSelectedTextColor;
	[SerializeField] private Color _onUnSelectedTextColor;

	[SerializeField] private BoolReactiveProperty _isSelected;
	public IReadOnlyReactiveProperty<bool> IsSelected { get { return _isSelected; } }

	public void Setup(Sprite activeIconSprite, Sprite inActiveIconSprite, string itemText)
	{
		_activeIcon.sprite = activeIconSprite;
		_inActiveIcon.sprite = inActiveIconSprite;
		_itemText.text = itemText;

		_toggle.graphic = _activeIcon;
		_toggle.group = GetComponentInParent<ToggleGroup>();

		_toggle.onValueChanged.AddListener(_ => OnvalueChanged());

		
	}

	private void OnvalueChanged()
	{
		if(_toggle.isOn)
		{
			_backgroundImage.color = _onSelectedImageColor;
			_itemText.color = _onSelectedTextColor;

		}
		else
		{
			_backgroundImage.color = _onUnSelectedImageColor;
			_inActiveIcon.color = _onUnSelectedImageColor;
			_itemText.color = _onUnSelectedTextColor;
		}

		_isSelected.Value = _toggle.isOn;

		
	}
}
}
