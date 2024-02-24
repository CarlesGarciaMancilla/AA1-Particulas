using System;
using System.Drawing;

[System.Serializable]
public struct Vector3C
{
    #region FIELDS
    public float x;
    public float y;
    public float z;
    #endregion

    #region PROPIERTIES
    public float magnitude { get { return Magnitude( x,  y,  z); } }
    public Vector3C normalized { get { return Normalize( x,  y, z); } }



    public static Vector3C zero { get { return new Vector3C(0, 0, 0); } }
    public static Vector3C one { get { return new Vector3C(1, 1, 1); } }
    public static Vector3C right { get { return new Vector3C(1, 0, 0); } }
    public static Vector3C up { get { return new Vector3C(0, 1, 0); } }
    public static Vector3C forward { get { return new Vector3C(0, 0, 1); } }

    #endregion

    #region CONSTRUCTORS
    public Vector3C(float x, float y, float z)
    {
        this.x = x; this.y = y; this.z = z;
               
    }

    public Vector3C(Vector3C pointA, Vector3C pointB) :this()
    {
        this.x = pointB.x - pointA.x;
        this.x = pointB.y - pointA.y;
        this.x = pointB.z - pointA.z;

    }
    #endregion

    #region OPERATORS
    public static Vector3C operator +(Vector3C a)
    {
        return +a;
    }

    public static Vector3C operator -(Vector3C a)
    {
        return -a;
    }

    public static Vector3C operator +(Vector3C a, Vector3C b)
    {
        return new Vector3C(a.x + b.x, a.y+b.y, a.z+b.z); //si no va hacerlo por cada propiedad (a.x + b.x)
    }

    public static Vector3C operator -(Vector3C a, Vector3C b)
    {
        return  new Vector3C(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static Vector3C operator *(Vector3C a, Vector3C b)
    {
        
        return new Vector3C(a.y * b.z-a.z*b.y, a.z * b.x-a.x*b.z, a.x*b.y -a.y* b.x);
    }

    public static Vector3C operator /(Vector3C a, Vector3C b)
    {

        return new Vector3C(a.x / b.x, a.y / b.y, a.z / b.z);
    }

    public static Vector3C operator *(Vector3C a, float b)
    {

        return new Vector3C(a.x * b, a.y * b, a.z * b);
    }

    public static Vector3C operator /(Vector3C a, float b)
    {

        return new Vector3C(a.x / b, a.y / b, a.z / b);
    }

    public static bool operator ==(Vector3C a, Vector3C b)
    {
        if (a.x == b.x) 
        {
            if (a.y == b.y) 
            {
                if (a.z == b.z) 
                {
                
                        return true;
                }
                else
                    return false;
            }
            else
                return false;


        }
        else
        return false;
    }

    public static bool operator !=(Vector3C a, Vector3C b)
    {
        if (a.x == b.x)
        {
            if (a.y == b.y)
            {
                if (a.z == b.z)
                {

                    return false;
                }
                else
                    return true;
            }
            else
                return true;


        }
        else
            return true;
    }




    #endregion

    #region METHODS
    public Vector3C Normalize(float x, float y, float z)
    {
        float distance = (float)Math.Sqrt(x * x + y * y + z*z);
        return new Vector3C(x / distance, y / distance, z/distance);

    }
    public float Magnitude(float x, float y, float z)
    {

        float magnitude = (float)Math.Sqrt(x * x + y * y + z * z);
        return magnitude;
    }

    public override bool Equals(object obj) //he copiado bool pero no deberia serlo?
    {
        if (obj is Vector3C) 
        {
            Vector3C other = (Vector3C)obj;
            return other == this;
        }
        return false;//npi
    }
    #endregion

    #region FUNCTIONS
    public static float Dot(Vector3C v1, Vector3C v2)
    {
        return v1.x * v2.x+ v1.y*v2.y+v1.z*v2.z;
    }
    public static Vector3C Cross(Vector3C v1, Vector3C v2)
    {
        return new Vector3C((v1.y*v2.z)-(v1.z*v2.y), (v1.z * v2.x) - (v1.x * v2.z), (v1.x * v2.x) - (v1.y * v2.x));
    }
    #endregion

}