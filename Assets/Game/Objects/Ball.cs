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

    /// <summary>
    /// Update the ball's instance.
    /// </summary>
    ///
    public void Update ()
    {
        // get the change in time
        float dt = Time.deltaTime;

        // find the new velocity based on the acceleration and the change in time
        _velocity.x += _acceleration.x * dt;
        _velocity.y += _acceleration.y * dt;

        // get the new position of x and y
        float newX = _velocity.x * dt + this.x;
        float newY = _velocity.y * dt + this.y;

        // create rects for the ball and paddles
        Rect ballRect       = this.localRect.CloneAndOffset(newX, newY);
        Rect player1Rect    = _player1.localRect.CloneAndOffset ( _player1.x, _player1.y );
        Rect player2Rect    = _player2.localRect.CloneAndOffset ( _player2.x, _player2.y );
        
        if ( ballRect.CheckIntersect ( player1Rect ) || ballRect.CheckIntersect ( player2Rect ) )
        {
            // reflect ball if collided with either player or computer paddle
            _velocity.x = - _velocity.x;
        }
        else if ( this.HorizontalWallCollision (newX, newY ) )
        {
            // reset if the ball collided with the sides
            this.Reset ();
        }
        else if ( !this.VerticalWallCollision ( newX, newY ) )
        {
            // move if there is no collisition
            this.x = newX;
            this.y = newY;
        }
        else
        {
            // reflect ball if it hits the top or bottom
            _velocity.y = -_velocity.y;

        }
    }

    /// <summary>
    /// Horizontal wall collision.
    /// </summary>
    /// <returns>
    /// The wall collision.
    /// </returns>
    /// <param name='x'>
    /// If set to <c>true</c> x.
    /// </param>
    /// <param name='y'>
    /// If set to <c>true</c> y.
    /// </param>
    ///
    private bool HorizontalWallCollision ( float x, float y )
    {
        if ( x + this.width/2 < Futile.screen.halfWidth
            && x - this.width/2 > - Futile.screen.halfWidth )
        {
            return false;
        }
            
        return true;
    }

    /// <summary>
    /// Vertical wall collision.
    /// </summary>
    /// <returns>
    /// The wall collision.
    /// </returns>
    /// <param name='x'>
    /// If set to <c>true</c> x.
    /// </param>
    /// <param name='y'>
    /// If set to <c>true</c> y.
    /// </param>
    ///
    private bool VerticalWallCollision ( float x, float y )
    {
        if ( y + this.height/2 < Futile.screen.halfHeight
            && y - this.height/2 > - Futile.screen.halfHeight )
        {
            return false;
        }
            
        return true;
    }

    /// <summary>
    /// Gets or sets the player1.
    /// </summary>
    /// <value>
    /// The player1.
    /// </value>
    ///
    public Paddle player1
    {
        get { return _player1; }
        
        set { _player1 = value; }
    }

    /// <summary>
    /// Gets or sets the player2.
    /// </summary>
    /// <value>
    /// The player2.
    /// </value>
    ///
    public Paddle player2
    {
        get { return _player2; }
        
        set { _player2 = value; }
    }

    /// <summary>
    /// Gets or sets the velocity.
    /// </summary>
    /// <value>
    /// The velocity.
    /// </value>
    /// 
    public Vector2 velocity
    {
        get { return _velocity; }
        
        set { _velocity = value; }
    }
}

