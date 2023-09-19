using System;
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
            public bool isNumber;
            public BtnStruct(char c,bool b=false, bool n=false)
            {
                this.Content = c;
                this.isBold = b;
                this.isNumber = n;
            }
        }
        private BtnStruct[,] buttons =
        {
            { new BtnStruct('%'),new BtnStruct('\u0152'),new BtnStruct('C'),new BtnStruct('\u232b')},
            { new BtnStruct('\u215f'),new BtnStruct('\u00b2'),new BtnStruct('\u221a'),new BtnStruct('\u00f7')},
            { new BtnStruct('7',true,true),new BtnStruct('8',true,true),new BtnStruct('9',true,true),new BtnStruct('\u00d7')},
            { new BtnStruct('4',true,true),new BtnStruct('5',true,true),new BtnStruct('6',true,true),new BtnStruct('-')},
            { new BtnStruct('1',true,true),new BtnStruct('2',true,true),new BtnStruct('3',true,true),new BtnStruct('+')},
            { new BtnStruct('\u00b1'),new BtnStruct('0',true,true),new BtnStruct(','),new BtnStruct('=')},
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
                    myButton.Tag = buttons[i,j];
                    myButton.Width=btnWidth;
                    myButton.Height=btnHeight;
                    myButton.Top = posY;
                    myButton.Left = posX;
                    posX += myButton.Width;
                    myButton.Click += button_Click;
                    this.Controls.Add(myButton);
                }
                posX=0; posY += btnHeight;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton =(Button)sender;
            BtnStruct clickedButtonStruct=(BtnStruct)clickedButton.Tag;
            lblResult.Text += clickedButton.Text;
            if (clickedButton.Tag.  )

        }
    }
}
