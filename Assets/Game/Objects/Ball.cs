using UnityEngine;
using System.Collections;

public class Ball : FSprite
{
    private Vector2     _velocity;
    private Vector2     _acceleration;
    private float       _angle; // radians
    private float       _maxVelocity;
    private Paddle      _player1;
    private Paddle      _player2;
    
    public Ball () : base ( "ball" )
    {
        _velocity       = new Vector2 ( 0.0f, 0.0f );
        _acceleration   = new Vector2 ( 0.0f, 0.0f );
        _angle          = 0;
        _maxVelocity    = 100.0f;
    }
    
    public void Reset ()
    {
        // reset accelerationn
        _acceleration   = new Vector2 ( 0.0f, 0.0f );
        
        // need a random angle from 0 - 45 degrees
        _angle = Mathf.PI / 4 * RXRandom.Float ();
        
        // reset position
        this.x = 0;
        this.y = 0;
        
        // reset velocity
        _velocity.x = -_maxVelocity * Mathf.Cos ( _angle );
        _velocity.y = _maxVelocity * Mathf.Sin ( _angle );
        
    }
    
    public void Update ()
    {
        float dt = Time.deltaTime;
        
        _velocity.x += _acceleration.x * dt;
        _velocity.y += _acceleration.y * dt;
        
        float newX = _velocity.x * dt + this.x;
        float newY = _velocity.y * dt + this.y;
        
        Rect ballRect       = this.localRect.CloneAndOffset(newX, newY);
        Rect player1Rect    = _player1.localRect.CloneAndOffset ( _player1.x, _player1.y );
        Rect player2Rect    = _player2.localRect.CloneAndOffset ( _player2.x, _player2.y );
        
        if ( ballRect.CheckIntersect ( player1Rect ) || ballRect.CheckIntersect ( player2Rect ) )
        {
            _velocity.x = - _velocity.x;
        }
        else if ( this.HorizontalWallCollision (newX, newY ) )
        {
            this.Reset ();
        }
        else if ( !this.VerticalWallCollision ( newX, newY ) )
        {
            this.x = newX;
            this.y = newY;
        }
        else
        {   
            if ( this.HorizontalWallCollision ( newX, newY ) )
            {
                _velocity.x = -_velocity.x;
            }
            else
            {
                _velocity.y = -_velocity.y;
            }
        }
    }
    
    private bool HorizontalWallCollision ( float x, float y )
    {
        if ( x < Futile.screen.halfWidth 
            && x > - Futile.screen.halfWidth )
        {
            return false;
        }
            
        return true;
    }
    
    private bool VerticalWallCollision ( float x, float y )
    {
        if ( y < Futile.screen.halfHeight
            && y > - Futile.screen.halfHeight )
        {
            return false;
        }
            
        return true;
    }
    
    public Paddle player1
    {
        get { return _player1; }
        
        set { _player1 = value; }
    }
    
    public Paddle player2
    {
        get { return _player2; }
        
        set { _player2 = value; }
    }
    
    public Vector2 velocity
    {
        get { return _velocity; }
        
        set { _velocity = value; }
    }
}

