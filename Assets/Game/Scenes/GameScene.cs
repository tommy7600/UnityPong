using UnityEngine;
using System.Collections;

public class GameScene : Scene
{
    private Player      _player;
    private Computer    _computer;
    private Ball        _ball;
    
    public override void Start ()
    {
        Futile.atlasManager.LoadAtlas ( "Atlases/Atlas" );
        
        
        _player     = new Player ();
        _computer   = new Computer ();
        _ball       = new Ball ();
        
        _computer.ball = _ball;
        
        _ball.player1 = _player;
        _ball.player2 = _computer;
        
        AddChild ( _player );
        AddChild ( _computer );
        AddChild ( _ball );
        
        _ball.Reset ();
        this.ResetPaddles ();
    }
    
    private void ResetPaddles ()
    {
        _player.x = - Futile.screen.halfWidth + _player.width/2;
        _player.y = 0;
        
        _computer.x = Futile.screen.halfWidth - _player.width/2;
        _computer.y = 0;
    }
    
    public override void Update ()
    {
        _ball.Update ();
        _player.Update ();
        _computer.Update ();
    }
}

