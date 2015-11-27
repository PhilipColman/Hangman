/*
 * Hangman is basic game that randomly selects a word for the player to guess.
 * Copyright (C) 2014  philip
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Hangman
{

    public partial class MainWindow : Window
    {
        public static string[] words = System.IO.File.ReadAllLines("Words.txt");
        public static string[] saved = System.IO.File.ReadAllLines("Data.txt");
        public static List<char> guesses = new List<char>();
        public static int lifes = 10;
        public static Random random = new Random();
        public static int r;
        public static string gameWord;
        public static char[] GameWord;
        public static char[] gameWordPLay;

        public MainWindow()
        {
            game();
        }
        public void Draw()
        {
            if (lifes < 10)
                Line1.Visibility = Visibility.Visible;
            if (lifes < 9)
                Line2.Visibility = Visibility.Visible;
            if (lifes < 8)
                Line3.Visibility = Visibility.Visible;
            if (lifes < 7)
                Line4.Visibility = Visibility.Visible;
            if (lifes < 6)
                Head.Visibility = Visibility.Visible;
            if (lifes < 5)
                Body.Visibility = Visibility.Visible;
            if (lifes < 4)
                Arm1.Visibility = Visibility.Visible;
            if (lifes < 2)
                Arm2.Visibility = Visibility.Visible;
            if (lifes < 1)
                Leg1.Visibility = Visibility.Visible;
            if (lifes < 0)
                Leg2.Visibility = Visibility.Visible;
        }
        public void letter(char c)
        {
            bool b = false;
            for (int i = 0; i < GameWord.Length; i++)
            {
                if (c == GameWord[i])
                {
                    gameWordPLay[i * 2] = c;
                    Display.Text = new string(gameWordPLay);
                    b = true;
                }
            }
            if (!b)
            {
                lifes--;
                Draw();
                if (lifes < 0)
                {
                    int temp = int.Parse(saved[1]);
                    temp = temp + 1;
                    saved[1] = temp.ToString();
                    System.IO.File.WriteAllLines("Data.txt", saved);
                    string word = gameWord.ToLower();
                    char f = word.First();
                    word = word.Remove(0, 1);
                    word = f.ToString().ToUpper() + word;
                    var a = MessageBox.Show(string.Format("You have lost do what yo play again \nThe word was: \n{0}", word), "You have lost", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (a == MessageBoxResult.Yes)
                        game();
                    else if (a == MessageBoxResult.No)
                        Close();
                }
            }
            if (b)
            {
                char[] temp = new char[gameWordPLay.Length / 2];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = gameWordPLay[i * 2];
                }
                string temp2 = new string(temp);
                if (temp2 == gameWord)
                {
                    int temp3 = int.Parse(saved[0]);
                    temp3 = temp3 + 1;
                    saved[0] = temp3.ToString();
                    System.IO.File.WriteAllLines("Data.txt", saved);
                    var a = MessageBox.Show("You have won do what yo play again", "You have won", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (a == MessageBoxResult.Yes)
                        game();
                    else if (a == MessageBoxResult.No)
                        Close();
                }
            }
        }
        public void game()
        {
            InitializeComponent();
            Score.Text = string.Format("Wins: {0}\t\t Loss: {1}", saved[0], saved[1]);
            Line1.Visibility = Visibility.Hidden;
            Line2.Visibility = Visibility.Hidden;
            Line3.Visibility = Visibility.Hidden;
            Line4.Visibility = Visibility.Hidden;
            Head.Visibility = Visibility.Hidden;
            Body.Visibility = Visibility.Hidden;
            Arm1.Visibility = Visibility.Hidden;
            Leg1.Visibility = Visibility.Hidden;
            Arm2.Visibility = Visibility.Hidden;
            Leg2.Visibility = Visibility.Hidden;
            Q.Visibility = Visibility.Visible;
            W.Visibility = Visibility.Visible;
            E.Visibility = Visibility.Visible;
            R.Visibility = Visibility.Visible;
            T.Visibility = Visibility.Visible;
            Y.Visibility = Visibility.Visible;
            U.Visibility = Visibility.Visible;
            I.Visibility = Visibility.Visible;
            O.Visibility = Visibility.Visible;
            P.Visibility = Visibility.Visible;
            A.Visibility = Visibility.Visible;
            S.Visibility = Visibility.Visible;
            D.Visibility = Visibility.Visible;
            F.Visibility = Visibility.Visible;
            G.Visibility = Visibility.Visible;
            H.Visibility = Visibility.Visible;
            J.Visibility = Visibility.Visible;
            K.Visibility = Visibility.Visible;
            L.Visibility = Visibility.Visible;
            Z.Visibility = Visibility.Visible;
            X.Visibility = Visibility.Visible;
            C.Visibility = Visibility.Visible;
            V.Visibility = Visibility.Visible;
            B.Visibility = Visibility.Visible;
            N.Visibility = Visibility.Visible;
            M.Visibility = Visibility.Visible;
            lifes = 10;
            r = random.Next(0, words.Length);
            gameWord = words[r].ToUpper().ToUpper();
            GameWord = gameWord.ToCharArray();
            gameWordPLay = new char[GameWord.Length * 2];

            for (int i = 0; i < gameWordPLay.Length; i++)
            {
                if (i % 2 == 0)
                {
                    gameWordPLay[i] = '_';
                }
                else
                {
                    gameWordPLay[i] = ' ';
                }
            }
            Display.Text = new string(gameWordPLay);
        }
        private void Q_Click(object sender, RoutedEventArgs e)
        {
            Q.Visibility = Visibility.Hidden;
            letter('Q');
        }

        private void W_Click(object sender, RoutedEventArgs e)
        {
            W.Visibility = Visibility.Hidden;
            letter('W');
        }

        private void E_Click(object sender, RoutedEventArgs e)
        {
            E.Visibility = Visibility.Hidden;
            letter('E');
        }

        private void R_Click(object sender, RoutedEventArgs e)
        {
            R.Visibility = Visibility.Hidden;
            letter('R');
        }

        private void T_Click(object sender, RoutedEventArgs e)
        {
            T.Visibility = Visibility.Hidden;
            letter('T');
        }

        private void Y_Click(object sender, RoutedEventArgs e)
        {
            Y.Visibility = Visibility.Hidden;
            letter('Y');
        }

        private void U_Click(object sender, RoutedEventArgs e)
        {
            U.Visibility = Visibility.Hidden;
            letter('U');
        }

        private void I_Click(object sender, RoutedEventArgs e)
        {
            I.Visibility = Visibility.Hidden;
            letter('I');
        }

        private void O_Click(object sender, RoutedEventArgs e)
        {
            O.Visibility = Visibility.Hidden;
            letter('O');
        }

        private void P_Click(object sender, RoutedEventArgs e)
        {
            P.Visibility = Visibility.Hidden;
            letter('P');
        }

        private void A_Click(object sender, RoutedEventArgs e)
        {
            A.Visibility = Visibility.Hidden;
            letter('A');
        }

        private void S_Click(object sender, RoutedEventArgs e)
        {
            S.Visibility = Visibility.Hidden;
            letter('S');
        }

        private void D_Click(object sender, RoutedEventArgs e)
        {
            D.Visibility = Visibility.Hidden;
            letter('D');
        }

        private void F_Click(object sender, RoutedEventArgs e)
        {
            F.Visibility = Visibility.Hidden;
            letter('F');
        }

        private void G_Click(object sender, RoutedEventArgs e)
        {
            G.Visibility = Visibility.Hidden;
            letter('G');
        }

        private void H_Click(object sender, RoutedEventArgs e)
        {
            H.Visibility = Visibility.Hidden;
            letter('H');
        }

        private void J_Click(object sender, RoutedEventArgs e)
        {
            J.Visibility = Visibility.Hidden;
            letter('J');
        }

        private void K_Click(object sender, RoutedEventArgs e)
        {
            K.Visibility = Visibility.Hidden;
            letter('K');
        }

        private void L_Click(object sender, RoutedEventArgs e)
        {
            L.Visibility = Visibility.Hidden;
            letter('L');
        }

        private void Z_Click(object sender, RoutedEventArgs e)
        {
            Z.Visibility = Visibility.Hidden;
            letter('Z');
        }

        private void X_Click(object sender, RoutedEventArgs e)
        {
            X.Visibility = Visibility.Hidden;
            letter('X');
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            C.Visibility = Visibility.Hidden;
            letter('C');
        }

        private void V_Click(object sender, RoutedEventArgs e)
        {
            V.Visibility = Visibility.Hidden;
            letter('V');
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            B.Visibility = Visibility.Hidden;
            letter('B');
        }

        private void N_Click(object sender, RoutedEventArgs e)
        {
            N.Visibility = Visibility.Hidden;
            letter('N');
        }

        private void M_Click(object sender, RoutedEventArgs e)
        {
            M.Visibility = Visibility.Hidden;
            letter('M');
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit", "Exit?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                Close();
        }


    }
}
