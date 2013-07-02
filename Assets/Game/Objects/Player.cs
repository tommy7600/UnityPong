using UnityEngine;
using System.Collections;

public class Player : Paddle
{
    private float _speed;

    public Player () : base ( "player" )
    {
        _speed = 75.0f;
    }

    /// <summary>
    /// Update the player instance.
    /// </summary>
    /// 
    public override void Update ()
    {
        // get the input from the player for veritcal movement
        float vertical = Input.GetAxis ( "Vertical" );

        // calculate the change in y
        float y     = vertical * Time.deltaTime * _speed + this.y;

        // get the max and min positions for the paddle (the bottom and top of the paddle)
        float maxY  = y + this.height/2;
        float minY  = y - this.height/2;

        if (this.VerticalWallCollision ( this.x, maxY ) )
        {
            // don't move if collided with top wall
            this.y = Futile.screen.halfHeight - this.height/2;
        }
        else if (this.VerticalWallCollision ( this.x, minY ) )
        {
            // dont move if collided with bottom wall
            this.y = -Futile.screen.halfHeight + this.height/2;
        }
        else
        {
            // move if no collision
            this.y = y; 
        }
        
        base.Update ();
    }
    
}

