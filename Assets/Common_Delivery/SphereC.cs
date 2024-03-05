using System;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

[System.Serializable]
public struct SphereC
{
    #region FIELDS
    public Vector3C position;
    public float radius;
    #endregion

    #region PROPIERTIES
    public Vector3C unitary { get 
    {
            float magnitud = (float)Math.Sqrt(Math.Pow(radius - position.x, 2) + Math.Pow(radius - position.y, 2) + Math.Pow(radius - position.z, 2));

            Vector3C unitarY = new Vector3C((radius - position.x), (radius - position.y), (radius - position.z) / magnitud);
            
            return unitarY; } }
    #endregion

    #region CONSTRUCTORS
    public SphereC(Vector3C position, float radius)
    {
        this.position = position;
        this.radius = radius;

    }
    #endregion

    #region OPERATORS
    public static bool operator ==(SphereC a, SphereC b)
    {
        if (a.position == b.position)
        {
            if (a.radius == b.radius)
            {
                

                    return true;
               
            }
            else
                return false;


        }
        else
            return false;
    }

    public static bool operator !=(SphereC a, SphereC b)
    {
        if (a.position == b.position)
        {
            if (a.radius == b.radius)
            {


                return false;

            }
            else
                return true;


        }
        else
            return true;
    }
    #endregion

    #region METHODS

    public bool IsInside(SphereC esfera, Vector3C punto) 
    {
        float distancia = (float)Math.Sqrt(Math.Pow(punto.x - esfera.position.x, 2) + Math.Pow(punto.y - esfera.position.y, 2) + Math.Pow(punto.z - esfera.position.z, 2));

        if (distancia <= esfera.radius)
        {
            return true;
        }    
        else
        {
            return false;
        }

    }


    public override bool Equals(object obj) //he copiado bool pero no deberia serlo?
    {
        if (obj is SphereC)
        {
            SphereC other = (SphereC)obj;
            return other == this;
        }
        return false;//npi
    }
    #endregion

    #region FUNCTIONS
    #endregion

}