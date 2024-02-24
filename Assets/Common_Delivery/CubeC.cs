using System;

[System.Serializable]
public struct CubeC
{
    #region FIELDS
    public Vector3C position;
    public float scale;
    public Vector3C rotation;//no se si es un vector o quaternion
    public float radius;

    #endregion

    #region PROPIERTIES
    #endregion

    #region CONSTRUCTORS
    #endregion

    #region OPERATORS
    public static bool operator ==(CubeC a, CubeC b)
    {
        if (a.position == b.position)
        {

            if (a.scale == b.scale)
            {

                if (a.rotation == b.rotation)
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
        else
            return false;
    }

    public static bool operator !=(CubeC a, CubeC b)
    {
        if (a.position == b.position)
        {
            if (a.position == b.position)
            {

                if (a.scale == b.scale)
                {

                    if (a.rotation == b.rotation)
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
            else
                return true;

        }
        else
            return true;
    }
    #endregion

    #region METHODS
    public bool IsInside(CubeC cubo, Vector3C punto) 
    {
        float cubeMinX = cubo.position.x - cubo.radius;
        float cubeMinY = cubo.position.y - cubo.radius;
        float cubeMinZ = cubo.position.z - cubo.radius;
        float cubeMaxX = cubo.position.x + cubo.radius;
        float cubeMaxY = cubo.position.y + cubo.radius;
        float cubeMaxZ = cubo.position.z + cubo.radius;

        if ((punto.x >= cubeMinX && punto.x <= cubeMaxX &&
            punto.y >= cubeMinY && punto.y <= cubeMaxY &&
            punto.z >= cubeMinZ && punto.z <= cubeMaxZ))
        {
            return true;
        }
        else
            return false;


    }



    public override bool Equals(object obj) //he copiado bool pero no deberia serlo?
    {
        if (obj is CubeC)
        {
            CubeC other = (CubeC)obj;
            return other == this;
        }
        return false;//npi
    }
    #endregion

    #region FUNCTIONS
    #endregion

}