﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class calculator : Form
    {
        public calculator()
        {
            InitializeComponent();
        }
        public struct BtnStruct
        {
            public char Content;
            public bool isBold;
            public BtnStruct(char c,bool b)
            {
                this.Content = c;
                this.isBold = b;
            }
        }
        private BtnStruct[,] buttons =
        {
            { new BtnStruct('%',false),new BtnStruct('\u0152',false),new BtnStruct('C',false),new BtnStruct('\u232b',false)},
            { new BtnStruct('\u215f',false),new BtnStruct('\u00b2',false),new BtnStruct('\u221a',false),new BtnStruct('\u00f7',false)},
            { new BtnStruct('7',true),new BtnStruct('8',true),new BtnStruct('9',true),new BtnStruct('\u00d7',false)},
            { new BtnStruct('4',true),new BtnStruct('5',true),new BtnStruct('6',true),new BtnStruct('-',false)},
            { new BtnStruct('1',true),new BtnStruct('2',true),new BtnStruct('3',true),new BtnStruct('+',false)},
            { new BtnStruct('\u00b1',false),new BtnStruct('0',true),new BtnStruct(',',false),new BtnStruct('=',false)},
        };

        private void calculator_Load(object sender, EventArgs e)
        {
            generateButton(buttons.GetLength(0), buttons.GetLength(1));
        }

        private void generateButton(int rows,int cols)
        {
            int btnWidth = 80;
            int btnHeight = 60;
            int posX = 0, posY = 80;
            int cont = 0;
            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button myButton =new Button();
                    FontStyle fs = buttons[i,j].isBold ? FontStyle.Bold : FontStyle.Regular;
                    myButton.Font = new Font("segoe UI", 16,fs);
                    myButton.BackColor = buttons[i, j].isBold ? Color.White : Color.Transparent;  
                    myButton.Text= buttons[i,j].Content.ToString();
                    myButton.Width=btnWidth;
                    myButton.Height=btnHeight;
                    myButton.Top = posY;
                    myButton.Left = posX;
                    posX += myButton.Width;
                    
                    this.Controls.Add(myButton);
                }
                posX=0; posY += btnHeight;
            }
        }
    }
}
