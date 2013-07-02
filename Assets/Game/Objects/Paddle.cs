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
    
    virtual public void Update ()
    {
    }
    
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

