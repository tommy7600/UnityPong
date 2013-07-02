using UnityEngine;
using System.Collections;

/// <summary>
/// Scene ids to keep track where the game currently is.
/// </summary>
///
public enum Scenes
{
    NONE,
    GAME
}

public class Main : MonoBehaviour
{
    private static Main instance;
    
    private FStage      _stage;
    private Scenes      _currentSceneID;
    private Scene       _currentScene   = null;
    
    /// <summary>
    /// Initialize the game
    /// </summary>
    ///
    void Start ()
    {
        instance = this;

        // say that we currently don't have a scene, needed for
        // changing scenes
        _currentSceneID = Scenes.NONE;

        // create a basic futile object with a 480 resolution level
        FutileParams fparams = new FutileParams(true,true,true,false);
        fparams.AddResolutionLevel(480.0f,  2.0f,   2.0f,   "");

        // set the origin at the center
        fparams.origin = new Vector2(0.5f,0.5f);

        // initialize futile with its params
        Futile.instance.Init (fparams);

        // create a reference to the stage
        this._stage = Futile.stage;

        // change scenes to the game scene
        this.GoToScene(Scenes.GAME);
    }
    
    /// <summary>
    /// Updates the game.
    /// </summary>
    ///
    void Update ()
    {
        if ( this._currentScene != null )
        {
            this._currentScene.Update ();   
        }
        
    }
    
    /// <summary>
    /// Goes to scene.
    /// </summary>
    /// <param name='scene'>
    /// Scene.
    /// </param>
    ///
    public void GoToScene ( Scenes scene )
    {
        // check if you are trying to open the same scene again
        if ( scene == this._currentSceneID )
        {
            Debug.Log ( "Scene is already loaded" );
            return; 
        }
        
        // create a new scene as null, so that we can check if we actually have a scene by that name
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
