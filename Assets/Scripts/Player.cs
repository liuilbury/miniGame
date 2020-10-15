using System;
using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        public Board Board;
        public Texture2D picture;
        public int x, y;

        private void Start()
        {
            Debug.Log("player");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (y != 0) y--;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (x != 0) x--;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (y != Board.pieceY - 1) y++;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (x != Board.pieceX - 1) x++;
            }
            Board.ChangeBelong(x,y);
        }

        private void OnGUI()
        {
            var dx = Screen.height * 1.0 / 20;
            var dy = Screen.height * 1.0 / 20;
            float bg_x = (float) (Screen.width - Screen.height) / 2;
            GUI.DrawTexture(new Rect((float) (dx * (x)) + bg_x, (float) (dy * (y)), (float) (dx), (float) (dx)),
                picture);
        }
    }
}