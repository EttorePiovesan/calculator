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
        public enum SymbolType
        {
            Number,
            Operator,
            DecimalPoint,
            PlusMinusSign,
            Backspace,
            undefined
        }
        public struct BtnStruct
        {
            public char Content;
            public SymbolType type;
            public bool isBold;
            public BtnStruct(char c, SymbolType t=SymbolType.undefined, bool b = false)
            {
                this.Content = c;
                this.type = t;
                this.isBold = b;
            }
        }
        private BtnStruct[,] buttons =
        {
            { new BtnStruct('%'),new BtnStruct('\u0152'),new BtnStruct('C'),new BtnStruct('\u232b',SymbolType.Backspace)},
            { new BtnStruct('\u215f'),new BtnStruct('\u00b2'),new BtnStruct('\u221a'),new BtnStruct('\u00f7',SymbolType.Operator)},
            { new BtnStruct('7',SymbolType.Number,true),new BtnStruct('8',SymbolType.Number,true),new BtnStruct('9',SymbolType.Number,true),new BtnStruct('\u00d7',SymbolType.Operator)},
            { new BtnStruct('4',SymbolType.Number,true),new BtnStruct('5',SymbolType.Number,true),new BtnStruct('6',SymbolType.Number,true),new BtnStruct('-',SymbolType.Operator)},
            { new BtnStruct('1',SymbolType.Number,true),new BtnStruct('2',SymbolType.Number,true),new BtnStruct('3',SymbolType.Number,true),new BtnStruct('+',SymbolType.Operator)},
            { new BtnStruct('\u00b1',SymbolType.PlusMinusSign),new BtnStruct('0',SymbolType.Number,true),new BtnStruct(',', SymbolType.DecimalPoint),new BtnStruct('=',SymbolType.Operator)},
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
            switch (clickedButtonStruct.type)
            {
                case SymbolType.Number:
                    if (clickedButtonStruct.type == SymbolType.Number)
                    {
                        if (lblResult.Text == "0") lblResult.Text = "";
                        lblResult.Text += clickedButton.Text;
                    }
                    break;
                case SymbolType.Operator:
                    break;
                case SymbolType.DecimalPoint:
                    if (lblResult.Text.IndexOf(",") == -1)
                        lblResult.Text += clickedButton.Text;
                    break;
                case SymbolType.PlusMinusSign:
                    if (lblResult.Text != "0")
                    {
                        if (lblResult.Text.IndexOf("-") == -1)
                            lblResult.Text = "-" +lblResult.Text;
                        else
                            lblResult.Text =lblResult.Text.Substring(1);
                    } 
                    break;
                case SymbolType.Backspace:

                        lblResult.Text = lblResult.Text.Substring(0,lblResult.Text.Length-1);
                    if (lblResult.Text == "-0" || lblResult.Text.Length == 0)
                        lblResult.Text = "0";
                    break;
                case SymbolType.undefined:
                    break;
                default: 
                    break;
            }

            

        }
    }
}
