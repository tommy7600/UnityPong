using UnityEngine;
using System.Collections;

public class Computer : Paddle
{
    
    private Ball _ball = null;
    private float _speed;
    
    public Computer () : base ( "computer" )
    {
        _speed = 75.0f;
    }
    
    public override void Update ()
    {
        // only update if the ball is moving towards the computer's paddle and
        // if there even is a ball
        if ( _ball != null && _ball.velocity.x > 0 )
        {
            // get the ball's position
            float y = _ball.y;

            // check if the ball is above or below the paddle's center
            if ( y - this.y > 0 )
            {
                y = Time.deltaTime * _speed + this.y;
            }
            else
            {
                y = -Time.deltaTime * _speed + this.y;
            }

            // get the top and bottom position of the paddle
            float maxY  = y + this.height/2;
            float minY  = y - this.height/2;
        
            if (this.VerticalWallCollision ( this.x, maxY ) )
            {
                // don't let the paddle go past the top
                this.y = Futile.screen.halfHeight - this.height/2;
            }
            else if (this.VerticalWallCollision ( this.x, minY ) )
            {
                // don't let the paddle go past the bottom
                this.y = -Futile.screen.halfHeight + this.height/2;
            }
            else if ( this._ball.y > maxY || this._ball.y < minY )
            {
                // only move if you have to
                this.y = y; 
            }
        
        }
        
        base.Update (); 
    }

    /// <summary>
    /// Gets or sets the ball.
    /// </summary>
    /// <value>
    /// The ball.
    /// </value>
    public Ball ball
    {
        get { return _ball; }
        
        set { _ball = value; } 
    }
}

