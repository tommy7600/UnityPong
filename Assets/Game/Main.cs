using UnityEngine;
using System.Collections;

public enum Scenes
{
	NONE,
	GAME
}

public class Main : MonoBehaviour
{
	private static Main instance;
	
	private FStage 		_stage;
	private Scenes		_currentSceneID;
	private Scene		_currentScene	= null;
	
	// Use this for initialization
	void Start ()
	{
		instance = this;
		
		_currentSceneID = Scenes.NONE;
		
		FutileParams fparams = new FutileParams(true,true,true,false);
		fparams.AddResolutionLevel(480.0f,	2.0f,	2.0f,	"");

		fparams.origin = new Vector2(0.5f,0.5f);

		Futile.instance.Init (fparams);
		
		this._stage = Futile.stage;

		this.GoToPage(Scenes.GAME);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ( this._currentScene != null )
		{
			this._currentScene.Update ();	
		}
		
	}
	
	/// <summary>
	/// Gos to page.
	/// </summary>
	/// <param name='scene'>
	/// Scene.
	/// </param>
	public void GoToPage ( Scenes scene )
	{
		// you are trying to open the same scene again
		if ( scene == this._currentSceneID )
		{
			Debug.Log ( "Scene is already loaded" );
			return;	
		}
		
		// creating a new scene as null, to check if we actually have a scene by that name
		Scene newScene = null;
		
		// create the scene if we have one
		switch ( scene )
		{
			case Scenes.GAME:
				newScene = new GameScene ();
				break;
		}
		
		// if we have the scene, add it to the stage and start it
		if ( newScene != null )
		{
			this._currentSceneID = scene;
			
			if ( this._currentScene != null )
			{
				this._stage.RemoveChild ( this._currentScene );
			}
			
			this._currentScene = newScene;
			this._stage.AddChild ( this._currentScene );
			this._currentScene.Start ();
		}
	}
		
}
