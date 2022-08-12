﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desencriptador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        // Clave Caesar
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26 )+ d);
        }

        public static string caesarEncipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }

        public static string caesarDecipher(string input, int key)
        {
            return caesarEncipher(input, 26 - key);
        }

        // Fin Clave Caesar

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Caesar":
                    if (radioEncrypt.Checked)
                    {
                        string userString = userStringBox.Text;
                        int key = Convert.ToInt32(shiftBox.Text);
                        
                        string cipherText = caesarEncipher(userString, key);
                        
                        Result.Text = cipherText;
                    }
                    
                    else if (radioDecrypt.Checked)
                    {
                        // Decript
                        string userString = userStringBox.Text;
                        int key = Convert.ToInt32(shiftBox.Text);
                        
                        string cipherText = caesarEncipher(userString, key);
                        string t = caesarDecipher(cipherText, key);
                        
                        Result.Text = t;
                    }
                    else
                    {
                        // Error
                        MessageBox.Show("Seleccione una opcion \n Encriptado o Desencriptado");
                    }
                        break;    
                    
                    
                default:
                    MessageBox.Show("Seleccione una clave!");
                    break;
            }
        }
    }
}
