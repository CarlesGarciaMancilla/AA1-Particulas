using System;
using System.Numerics;
using UnityEngine;
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



    public struct Particle
    {
        public Vector3C position;
        public Vector3C velocidad;
        public Vector3C aceleracion;
        public float size;
    }

    public Particle[] Update(float dt)
    {
        Particle[] particles = new Particle[10];
        for (int i = 0; i < particles.Length; ++i)
        {
            //particles[i].position = new Vector3C(-4.5f + i, 0.0f, 0);
            particles[i].position = settingsCannon.Start;
            particles[i].size = 0.1f;
        }


        //hacer euler
        for (int i = 0; i < particles.Length; ++i)
        {
            //puede que no sea solo el delta time
           // Vector3C velInicial = particles[i].velocidad;
            
            float aTiempo = Time.time + dt;
            Vector3C acInicial = (particles[i].velocidad / aTiempo) + settings.gravity;
            particles[i].aceleracion = acInicial;
            Vector3C posFinal = particles[i].position + particles[i].velocidad * (aTiempo) + (acInicial * (aTiempo));
            Vector3C velFinal = particles[i].velocidad + acInicial * (aTiempo);
            particles[i].position = posFinal;
            particles[i].velocidad = velFinal;


            CollisionPlane(particles[i], settingsCollision.planes[0]);

        }





        return particles;


        
        
            
    }

    public void CollisionPlane(Particle particle, PlaneC plano)
    {
        float distance = Vector3C.Dot(plano.normal, (particle.position - plano.position)) - particle.size / 2;

        if (distance < 0)
        {
            particle.size = 100;
            // Se ha detectado una colisión
            // Ajustar la posición de la partícula para corregir la colisión
            particle.position -= plano.normal * distance;

            // Calcular y ajustar la velocidad de la partícula en respuesta a la colisión
            float dotProduct = Vector3C.Dot(particle.velocidad, plano.normal);
            particle.velocidad -=  plano.normal * 2 * dotProduct;
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
