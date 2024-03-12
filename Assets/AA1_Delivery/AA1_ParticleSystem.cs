using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using UnityEngine;
using static AA1_ParticleSystem;
using static UnityEngine.Rendering.DebugUI;

[System.Serializable]
public class AA1_ParticleSystem
{
    

    [System.Serializable]
    
    public struct Settings
    {
        public Vector3C gravity;
        public float bounce;
    }
    public Settings settings;

    [System.Serializable]
    public struct SettingsCascade
    {
        public Vector3C PointA;
        public Vector3C PointB;
        public float particlesPerSecond;
    }
    public SettingsCascade settingsCascade;

    [System.Serializable]
    public struct SettingsCannon
    {
        public Vector3C Start;
        public Vector3C Direction;
        public float angle;
        public float particlesPerSecond;
    }
    public SettingsCannon settingsCannon;

    [System.Serializable]
    public struct SettingsCollision
    {
        public PlaneC[] planes;
        public SphereC[] spheres;
        public CapsuleC[] capsules;
    }
    public SettingsCollision settingsCollision;


    [System.Serializable]
    public struct Particle
    {
        public Vector3C position;
        public Vector3C startPosition;
        public Vector3C velocidad;
        public Vector3C aceleracion;
        public float size;
        public float life;
        public bool alive;




    }


    public Particle[] Update(float dt)
    {
        Particle[] particles = new Particle[100];
        Particle[] particlesVivas = new Particle[100];


        for (int i = 0; i < particles.Length; ++i)
        {
            //particles[i].position = new Vector3C(-4.5f + i, 0.0f, 0);
            particles[i].position = settingsCannon.Start;
            particles[i].velocidad = settingsCannon.Direction;
            particles[i].startPosition = particles[i].position;
            particles[i].aceleracion = (particles[i].velocidad / dt) + settings.gravity;
            particles[i].size = 0.05f;

        }




        for (int i = 0; i < particles.Length; ++i)
        {
            particles[i].velocidad += particles[i].aceleracion * (dt);
            particles[i].position += particles[i].velocidad * (dt);
            particles[i].life -= dt;

            if (particles[i].life < 0)
            {
                particles[i].alive = false;
            }
            else 
            {
                particles[i].alive = true;
               
            }

            for (int j = 0; j < particles.Length; i++) 
            {
                if (particles[j].alive) 
                {
                    particlesVivas[j] = particles[j];
                }
            }
            

            for (int j = 0; j < settingsCollision.planes.Length; j++)
            {
                CollisionPlane(particles[i], settingsCollision.planes[j]);
            }

            for (int j = 0; j < settingsCollision.spheres.Length; j++)
            {
                CollisionSphere(particles[i], settingsCollision.spheres[j]);
            }

            for (int j = 0; j < settingsCollision.capsules.Length; j++)
            {
                CollisionCapsule(particles[i], settingsCollision.capsules[j]);
            }

        }




        return particlesVivas;


        
        
            
    }

    public void Cascade() 
    {
        float distance = (settingsCascade.PointA - settingsCascade.PointB).magnitude;


        
        for (int i = 0; i <= distance; i++) 
        {
            Particle[] particles = new Particle[100];


            for (int j = 0; j < particles.Length; ++j)
            {

                particles[j].position = new Vector3C(i,i,i);
                particles[j].startPosition = particles[i].position;
                particles[j].aceleracion =  settings.gravity;
                particles[j].size = 0.05f;
                particles[j].life = 1f;


            }

        }
    
    }

    public void CollisionPlane(Particle particle, PlaneC plano)
    {
        // Comprobar si la partícula está delante o detrás del plano
        float dotProduct = Vector3C.Dot(plano.normal, particle.position - plano.position);
        UnityEngine.Debug.Log("dot product" + dotProduct);
        if (dotProduct < 0)
        {
            // Trazar una línea/rayo desde la posición anterior a la posición actual de la partícula
            Vector3C rayo = (particle.position - particle.startPosition).normalized;

            // Calcular la intersección de la línea con el plano
            float t = Vector3C.Dot(plano.position - particle.startPosition, plano.normal) / Vector3C.Dot(rayo, plano.normal);
            Vector3C intersectionPoint = particle.startPosition + rayo * t;

            // El punto de intersección será la nueva posición de la partícula
            particle.position = intersectionPoint;

            // Reflejar la velocidad de la partícula con respecto a la normal del plano
            Vector3C reflectedVelocity = Vector3C.Reflect(particle.velocidad, plano.normal);

            // Multiplicar la velocidad de la partícula por el coefficient de restitución
            // Puedes ajustar este valor según sea necesario (debe estar entre 0 y 1)
            Vector3C finalVelocity = reflectedVelocity * settings.bounce;

            particle.velocidad = finalVelocity;
            UnityEngine.Debug.Log("vel final" + particle.velocidad);
            // Mostrar resultados

        }
        else
        {
            
        }
    }

    public void CollisionSphere(Particle particle, SphereC esfera)
    {

       
        if (esfera.IsInside(esfera, particle.position))
        {

            Vector3C rayo = (particle.position - particle.startPosition).normalized;

            float a = Vector3C.Dot(rayo, rayo);
            float b = 2 * Vector3C.Dot(particle.startPosition - esfera.position, rayo);
            float c = (particle.startPosition - esfera.position).magnitude - esfera.radius * esfera.radius;
            float discriminante = b * b - 4 * a * c;

            float t = (-b + (float)Math.Sqrt(discriminante)) / (2 * a);
            Vector3C intersectionPoint = particle.startPosition + rayo * t;
            Vector3C intersectionNormal = esfera.position - intersectionPoint;
            particle.position = intersectionPoint;

            PlaneC planoEsfera = new PlaneC(intersectionPoint, intersectionNormal.normalized);
            CollisionPlane(particle, planoEsfera);
        }
        else
        {

        }
    }


    public void CollisionCapsule(Particle particle, CapsuleC capsula)
    {
        Vector3C positionCapsula = ((capsula.positionA - capsula.positionB)/2);


        if (capsula.IsInside(capsula, particle.position))
        {

            Vector3C rayo = (particle.position - particle.startPosition).normalized;

            float a = Vector3C.Dot(rayo, rayo);
            float b = 2 * Vector3C.Dot(particle.startPosition - positionCapsula, rayo);
            float c = (particle.startPosition - positionCapsula).magnitude - capsula.radius * capsula.radius;
            float discriminante = b * b - 4 * a * c;

            float t = (-b + (float)Math.Sqrt(discriminante)) / (2 * a);
            
            Vector3C intersectionPoint = particle.startPosition + rayo * t;
            particle.position = intersectionPoint;
            Vector3C intersectionNormal = positionCapsula - intersectionPoint;


            PlaneC planoCapsula = new PlaneC(intersectionPoint, intersectionNormal.normalized);
            CollisionPlane(particle, planoCapsula);
        }
        else
        {

        }
    }





    public void Debug()
    {
        foreach (var item in settingsCollision.planes)
        {
            item.Print(Vector3C.red);
        }
        foreach (var item in settingsCollision.capsules)
        {
            //item.Print(Vector3C.green);
        }
        foreach (var item in settingsCollision.spheres)
        {
            //item.Print(Vector3C.blue);
        }


    }
}
