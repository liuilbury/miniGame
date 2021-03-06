﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Piece : MonoBehaviour
    {
        public GameObject Text;
        public Player Player;
        public float x, y;
        private int number;
        private Belong belong = Belong.None;
        private string number_str;

        enum Belong
        {
            None = 1,
            Own = 2,
            Enemy = 3,
        }

        public void Start()
        {
            number = -2;
            InvokeRepeating("AddNumber", 0.0f, Game01.Frame);
        }

        public void AddNumber()
        {
            if (Math.Abs(x - Player.x) + Math.Abs(y - Player.y) <= 2)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }

            if (Math.Abs(x - Player.x) + Math.Abs(y - Player.y) == 0)
            {
                Player.number += number;
                number = 0;
            }
            else if (belong != Belong.None)
            {
                number += 1;
                number_str = number.ToString();
            }

            Text.GetComponent<Text>().text = number_str;
        }

        public void ChangeBelong()
        {
            Player.number += number+1;
            number = 0;
            number_str = number.ToString();
            belong = Belong.Own;
            this.gameObject.GetComponent<Image>().color = Color.gray;
            Text.GetComponent<Text>().text = number_str;
        }
    }
}