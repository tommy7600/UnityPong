using UnityEngine;
using System.Collections;

public class Paddle : FSprite
{
    private string  _name;
    private int     _score;

    public Paddle ( string name ) : base ( "paddle" )
    {
        this._name = name;
        _score = 0;
 
    }

    /// <summary>
    /// Update the instance of the paddle.
    /// </summary>
    /// 
    virtual public void Update ()
    {
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
    protected bool VerticalWallCollision ( float x, float y )
    {
        if ( y < Futile.screen.halfHeight
            && y > - Futile.screen.halfHeight )
        {
            return false;
        }
            
        return true;
    }
}

