using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gumilar.VR
{
    public class Spawner : MonoBehaviour
    {
        void Spawn(Color color)
        {
            // Create a sphere
            GameObject sphere = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere));

            // Adjust transform
            sphere.transform.localScale *= 0.05f;
            sphere.transform.position = transform.position + transform.forward * 0.3f;

            // Set a color of sphere
            sphere.GetComponent<Renderer>().material.color = color;          

        }

        public void SpawnRed()
        {
            Spawn(Color.red);
        }

        public void SpawnGreen()
        {
            Spawn(Color.green);
        }

        public void SpawnBlue()
        {
            Spawn(Color.blue);
        }

        public void SpawnYellow()
        {
            Spawn(Color.yellow);
        }
    }
}