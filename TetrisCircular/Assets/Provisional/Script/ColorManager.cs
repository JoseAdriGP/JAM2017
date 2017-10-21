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

	public BlockColor GetRandomColor() {
		int _index = Random.Range (0, 4);

		switch (_index) {
		case 0:
			return BlockColor.GREEN;
		case 1:
			return BlockColor.RED;
		case 2:
			return BlockColor.BLUE;
		case 3:
			return BlockColor.YELLOW;
		default:
			return BlockColor.GREEN;
		}
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
