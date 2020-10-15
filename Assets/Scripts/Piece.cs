using System;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Random = System.Random;

namespace Game
{
    public class Piece : MonoBehaviour
    {
        public Player Player;
        public Texture2D picture;
        private float x, y, d;
        private int number;
        private Belong belong = Belong.None;
        private string number_str;
        private float i, j; enum Belong
        {
            None = 1,
            Own = 2,
            Enemy = 3,
        }

        public void init(float x, float y, float d,float i,float j)
        {
            this.x = x;
            this.y = y;
            this.d = d;
            this.i = i;
            this.j = j;
        }

        public void Start()
        {
            number = 0;
            InvokeRepeating("AddNumber", 1.0f, 1.0f);
        }

        private void OnGUI()
        {
            GUIStyle titleStyle = new GUIStyle();
            titleStyle.normal.textColor = Color.red;
            if (belong == Belong.None)
            {
            }
            else if (belong == Belong.Own)
            {
                titleStyle.normal.textColor = Color.blue;
            }
            else
            {
                titleStyle.normal.textColor = Color.red;
            }

            if (Math.Abs(i - Player.x) + Math.Abs(j - Player.y) <= 2)
            {
                GUI.DrawTexture(new Rect((float) x, (float) y, d, d), picture);
                GUI.Label(new Rect((float) (x + 2), (float) y, d, d), number_str, titleStyle);
            }
        }

        public void AddNumber()
        {
            if (belong != Belong.None)
            {
                number += 1;
                number_str = number.ToString();
            }
        }

        public void debug()
        {
            Debug.Log(x + y + d);
        }

        public void ChangeBelong()
        {
            number_str = number.ToString();
            belong = Belong.Own;
        }
    }
}