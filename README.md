# MonoGame_BasicGUI
Rebuilding the Legacy GUI from Unity3D for MonoGame
http://docs.unity3d.com/462/Documentation/Manual/gui-Basics.html

![win1](https://cloud.githubusercontent.com/assets/1466920/13226860/f7430764-d993-11e5-8687-4e2555abc24f.PNG)

```C#
        void OnGUI()
        {
            GUI.Init(spriteBatch, mouseRect);
            GUI.Label(new Rectangle(10, 10, 0, 0), "Test");
            GUI.Label(new Rectangle(15, 200, 0, 0), "WOW !");
            GUI.Box(new Rectangle(500, 150, 100, 100), "BOOOX !");

            if (GUI.Button(new Rectangle(100, 15, 100, 50), "Button !"))
            {
                sound.Play();
                Console.WriteLine("Works!");
            }
       }
```


```C#
        void OnGUI()
        {
            GUI.Init(spriteBatch, mouseRect);
            GUILayout.BeginArea(new Rectangle(500, 0, 100, 50));
            GUILayout.Label("Test1");
            GUILayout.Label("Test2");
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rectangle(600, 0, 100, 50));

            if (GUILayout.Button("Button1"))
            {
                sound1.Play();
            }
            
            GUILayout.Space(1);

            if (GUILayout.Button("Button2"))
            {
                sound2.Play();
            }

            GUILayout.EndArea();
       }
```


Art by Kenney:
http://opengameart.org/content/ui-pack

Font by Ubuntu:
http://font.ubuntu.com/
