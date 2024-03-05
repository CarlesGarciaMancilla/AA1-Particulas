using System;
using System.Numerics;

[System.Serializable]
public struct CapsuleC
{
    #region FIELDS
    public Vector3C positionA;
    public Vector3C positionB;
    public float radius;
    #endregion

    #region PROPIERTIES
    #endregion

    #region CONSTRUCTORS
    public CapsuleC(Vector3C positionA, Vector3C positionB, float radius)
    {
        this.positionA = positionA; 
        this.positionB = positionB;
        this.radius = radius;

    }

    public CapsuleC(Vector3C position, float radius, float height, Quaternion rotation) : this()
    {
        float distancia = (height/2) - radius;

        this.positionA = position + new Vector3C (0,distancia,0);
        this.positionB = position - new Vector3C(0, distancia, 0);
        this.radius = radius; 



    }
    #endregion

    #region OPERATORS
    public static bool operator ==(CapsuleC a, CapsuleC b)
    {
        if (a.positionA == b.positionA)
        {

            if (a.positionB == b.positionB)
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
        else
            return false;
    }

    public static bool operator !=(CapsuleC a, CapsuleC b)
    {
        if (a.positionA == b.positionA)
        {
         

                if (a.positionB == b.positionB)
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
        else
            return true;
    }
    #endregion

    #region METHODS

    public bool IsInside(CapsuleC capsula, Vector3C punto) 
    {
        Vector3C altura = capsula.positionA - capsula.positionB;

        float distanciaX = (float)Math.Sqrt(Math.Pow(punto.x - capsula.positionA.x, 2) + Math.Pow(punto.y - capsula.positionA.y, 2) + Math.Pow(punto.z - capsula.positionA.z, 2));

        float distanciaY = (float)Math.Sqrt(Math.Pow(punto.x - altura.x, 2) + Math.Pow(punto.y - altura.y, 2) + Math.Pow(punto.z - altura.z, 2));


        

        if (distanciaX <= capsula.radius)
        {
            if (distanciaY <= altura.magnitude)
            {
                return true;
            }
        }
        else
        {
            return false;
        }


        return false;
    }

    public override bool Equals(object obj) //he copiado bool pero no deberia serlo?
    {
        if (obj is CapsuleC)
        {
            CapsuleC other = (CapsuleC)obj;
            return other == this;
        }
        return false;//npi
    }
    #endregion

    #region FUNCTIONS
    #endregion

}