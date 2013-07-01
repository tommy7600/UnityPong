using UnityEngine;
using System.Collections;

public class GameScene : Scene
{
	public override void Start ()
	{
		Futile.atlasManager.LoadAtlas ( "Atlases/Atlas" );
		FSprite ball = new FSprite ( "paddle" );
		Futile.stage.AddChild ( ball );
		Debug.Log ( "start" );
	}
}

