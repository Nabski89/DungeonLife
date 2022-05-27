using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    //I just took this code from a codemonkey tutorial
    //https://www.youtube.com/watch?v=3I5d2rUJ0pE
    public enum Scene
    {
        Title,
        Sandbox
    }
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}