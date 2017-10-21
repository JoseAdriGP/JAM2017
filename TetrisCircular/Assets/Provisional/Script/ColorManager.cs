using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {

	public enum BlockColor {
		GREEN,
		RED,
		BLUE,
		YELLOW
	}

	public Sprite GreenBlock;
	public Sprite RedBlock;
	public Sprite BlueBlock;
	public Sprite YellowBlock;

	public Dictionary<BlockColor, Sprite> _spritesByColor;
	public Dictionary<BlockColor, Sprite> SpritesByColor {
		get { return _spritesByColor; }
		private set { _spritesByColor = value; }
	}

	public static ColorManager _instance;
	public static ColorManager Instance {
		get { return _instance; }
		private set { _instance = value; } 
	}

	void Awake () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);

			SpritesByColor = new Dictionary<BlockColor, Sprite> {
				{ BlockColor.GREEN, GreenBlock },
				{ BlockColor.RED, RedBlock },
				{ BlockColor.BLUE, BlueBlock },
				{ BlockColor.YELLOW, YellowBlock }
			};
		} else
			Destroy (gameObject);
	}
}
