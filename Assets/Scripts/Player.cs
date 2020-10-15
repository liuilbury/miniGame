using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Player : MonoBehaviour
    {
        public GameObject Text;
        public Board Board;
        public Texture2D picture;
        public int x, y;
        double dx = Screen.height * 1.0 / 20;
        float bg_x = (float) (Screen.width - Screen.height) / 2;
        private int turn;
        public int number;
        private string number_str;
        private void Start()
        {
            number = 0;
            double dx = Screen.height * 1.0 / 20;
            float bg_x = (float) (Screen.width - Screen.height) / 2;
            Debug.Log("player");
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2((float) (dx), (float) (dx));
            this.gameObject.GetComponent<RectTransform>().position =
                new Vector3((float) ((float) (dx * (x)) + bg_x + dx / 2), (float) (dx * (y) + dx / 2), 0);
            InvokeRepeating("Move", 0.0f, Game01.Frame);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                turn = 1;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                turn = 2;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                turn = 3;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                turn = 4;
            }
        }

        private void Move()
        {
            if (turn == 0)
            {
                
            }
            else if (turn==1)
            {
                if (y != Board.pieceY - 1) y++;
            }
            else if (turn==2)
            {
                if (x != 0) x--;
            }
            else if (turn==3)
            {
                if (y != 0) y--;
            }
            else if (turn==4)
            {
                if (x != Board.pieceX - 1) x++;
            }
            turn = 0;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2((float) (dx), (float) (dx));
            gameObject.GetComponent<RectTransform>().position =
                new Vector3((float) ((float) (dx * (x)) + bg_x + dx / 2), (float) (dx * (y) + dx / 2), 0);
            Board.ChangeBelong(x, y);
            number_str = number.ToString();
            Text.GetComponent<Text>().text = number_str;
        }
    }
}