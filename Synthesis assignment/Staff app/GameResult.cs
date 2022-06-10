using SynthesisAssignment.Base_classes;
using SynthesisAssignment.Manager_classes;
using SynthesisAssignment.Upload_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_app
{
    public partial class GameResult : Form
    {
        private GameManager gameManager;
        private int casee;
        public GameResult(Game game1)
        {
            InitializeComponent();
            gameManager = new GameManager(game1, new UploadGame());
            casee = 0;
            FormPreparation();
        }
        private void FormPreparation()
        {
            player1EmailLb.Text = gameManager.Game.player1Email;
            player2EmailLb.Text = gameManager.Game.player2Email;
            int[] pointsPlayer1 = gameManager.Game.Result().Item1;
            int[] pointsPlayer2 = gameManager.Game.Result().Item2;
            int pos = Array.IndexOf(pointsPlayer1, 0);
            if(pointsPlayer1.Length == 1)
            {
                Txt11.Text = pointsPlayer1[0].ToString();
                Txt12.Text = pointsPlayer2[0].ToString();
                Txt21.Visible = false;
                Txt22.Visible = false;
                Txt31.Visible = false;
                Txt32.Visible = false;
                Txt41.Visible = false;
                Txt42.Visible = false;
                Txt51.Visible = false;
                Txt52.Visible = false;
                NoLb1.Visible = true;
                NoLb2.Visible = true;
                NoLb3.Visible = true;
                NoLb4.Visible = true;
                casee = 1;
            }
            else if(pointsPlayer1.Length == 3)
            {
                Txt11.Text = pointsPlayer1[0].ToString();
                Txt12.Text = pointsPlayer2[0].ToString();
                Txt21.Text = pointsPlayer1[1].ToString();
                Txt22.Text = pointsPlayer1[1].ToString();
                Txt31.Text = pointsPlayer1[2].ToString();
                Txt32.Text = pointsPlayer1[2].ToString();
                if(pos == 1)
                {
                    Txt11.ReadOnly = true;
                    Txt12.ReadOnly = true;
                }
                else if(pos == 2)
                {
                    Txt11.ReadOnly = true;
                    Txt12.ReadOnly = true;
                    Txt21.ReadOnly = true;
                    Txt22.ReadOnly = true;
                }
                Txt41.Visible = false;
                Txt42.Visible = false;
                Txt51.Visible = false;
                Txt52.Visible = false;
                NoLb3.Visible = true;
                NoLb4.Visible = true;
                casee = 3;
            }
            else if(pointsPlayer1.Length == 5)
            {
                Txt11.Text = pointsPlayer1[0].ToString();
                Txt12.Text = pointsPlayer2[0].ToString();
                Txt21.Text = pointsPlayer1[1].ToString();
                Txt22.Text = pointsPlayer1[1].ToString();
                Txt31.Text = pointsPlayer1[2].ToString();
                Txt32.Text = pointsPlayer1[2].ToString();
                Txt41.Text = pointsPlayer1[3].ToString();
                Txt42.Text = pointsPlayer1[3].ToString();
                Txt51.Text = pointsPlayer1[4].ToString();
                Txt52.Text = pointsPlayer1[4].ToString();
                if (pos == 1)
                {
                    Txt11.ReadOnly = true;
                    Txt12.ReadOnly = true;
                } 
                else if (pos == 2) 
                {
                    Txt11.ReadOnly = true;
                    Txt12.ReadOnly = true;
                    Txt21.ReadOnly = true;
                    Txt22.ReadOnly = true;
                }
                else if (pos == 3)
                {
                    Txt11.ReadOnly = true;
                    Txt12.ReadOnly = true;
                    Txt21.ReadOnly = true;
                    Txt22.ReadOnly = true;
                    Txt31.ReadOnly = true;
                    Txt32.ReadOnly = true;
                }
                else if (pos == 4)
                {
                    Txt11.ReadOnly = true;
                    Txt12.ReadOnly = true;
                    Txt21.ReadOnly = true;
                    Txt22.ReadOnly = true;
                    Txt31.ReadOnly = true;
                    Txt32.ReadOnly = true;
                    Txt41.ReadOnly = true;
                    Txt42.ReadOnly = true;
                }
                casee = 5;
            }
        }
        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                switch (casee)
                {
                    case 1:
                        if(gameManager.PointsCheck(Convert.ToInt32(Txt11.Text), Convert.ToInt32(Txt12.Text)))
                        {
                            gameManager.RegisterResults(1, Convert.ToInt32(Txt11.Text), Convert.ToInt32(Txt12.Text));
                        }
                        else
                        {
                            MessageBox.Show("Invalid points!");
                            return;
                        }
                        break;
                    case 3:
                        if(Txt21.ReadOnly == true)
                        {
                            if (gameManager.PointsCheck(Convert.ToInt32(Txt31.Text), Convert.ToInt32(Txt32.Text)))
                            {
                                gameManager.RegisterResults(3, Convert.ToInt32(Txt31.Text), Convert.ToInt32(Txt32.Text));
                            }
                            else
                            {
                                MessageBox.Show("Invalid points!");
                                return;
                            }
                        }
                        else if(Txt11.ReadOnly == true)
                        {
                            if (gameManager.PointsCheck(Convert.ToInt32(Txt31.Text), Convert.ToInt32(Txt32.Text)) && gameManager.PointsCheck(Convert.ToInt32(Txt21.Text), Convert.ToInt32(Txt22.Text)))
                            {
                                gameManager.RegisterResults(2, Convert.ToInt32(Txt21.Text), Convert.ToInt32(Txt22.Text));
                                gameManager.RegisterResults(3, Convert.ToInt32(Txt31.Text), Convert.ToInt32(Txt32.Text));
                            }
                            else
                            {
                                MessageBox.Show("Invalid points!");
                                return;
                            }
                        }
                        else
                        {
                            if (gameManager.PointsCheck(Convert.ToInt32(Txt31.Text), Convert.ToInt32(Txt32.Text)) && gameManager.PointsCheck(Convert.ToInt32(Txt21.Text), Convert.ToInt32(Txt22.Text)) && gameManager.PointsCheck(Convert.ToInt32(Txt11.Text), Convert.ToInt32(Txt12.Text)))
                            {
                                gameManager.RegisterResults(1, Convert.ToInt32(Txt11.Text), Convert.ToInt32(Txt12.Text));
                                gameManager.RegisterResults(2, Convert.ToInt32(Txt21.Text), Convert.ToInt32(Txt22.Text));
                                gameManager.RegisterResults(3, Convert.ToInt32(Txt31.Text), Convert.ToInt32(Txt32.Text));
                            }
                            else
                            {
                                MessageBox.Show("Invalid points!");
                                return;
                            }
                        }
                        break;
                    case 5:
                        if(Txt41.ReadOnly == true)
                        {
                            if (gameManager.PointsCheck(Convert.ToInt32(Txt51.Text), Convert.ToInt32(Txt52.Text)))
                            {
                                gameManager.RegisterResults(5, Convert.ToInt32(Txt51.Text), Convert.ToInt32(Txt52.Text));
                            }
                            else
                            {
                                MessageBox.Show("Invalid points!");
                                return;
                            }
                        }
                        else if(Txt31.ReadOnly == true)
                        {
                            if (gameManager.PointsCheck(Convert.ToInt32(Txt51.Text), Convert.ToInt32(Txt52.Text)) && gameManager.PointsCheck(Convert.ToInt32(Txt41.Text), Convert.ToInt32(Txt42.Text)))
                            {
                                gameManager.RegisterResults(4, Convert.ToInt32(Txt41.Text), Convert.ToInt32(Txt42.Text));
                                gameManager.RegisterResults(5, Convert.ToInt32(Txt51.Text), Convert.ToInt32(Txt52.Text));
                            }
                            else
                            {
                                MessageBox.Show("Invalid points!");
                                return;
                            }
                        }
                        else if(Txt21.ReadOnly == true)
                        {
                            if (gameManager.PointsCheck(Convert.ToInt32(Txt51.Text), Convert.ToInt32(Txt52.Text)) && gameManager.PointsCheck(Convert.ToInt32(Txt41.Text), Convert.ToInt32(Txt42.Text)) && gameManager.PointsCheck(Convert.ToInt32(Txt31.Text), Convert.ToInt32(Txt32.Text)))
                            {
                                gameManager.RegisterResults(3, Convert.ToInt32(Txt31.Text), Convert.ToInt32(Txt32.Text));
                                gameManager.RegisterResults(4, Convert.ToInt32(Txt41.Text), Convert.ToInt32(Txt42.Text));
                                gameManager.RegisterResults(5, Convert.ToInt32(Txt51.Text), Convert.ToInt32(Txt52.Text));
                            }
                            else
                            {
                                MessageBox.Show("Invalid points!");
                                return;
                            }
                        }
                        else if(Txt11.ReadOnly == true)
                        {
                            if (gameManager.PointsCheck(Convert.ToInt32(Txt51.Text), Convert.ToInt32(Txt52.Text)) && gameManager.PointsCheck(Convert.ToInt32(Txt41.Text), Convert.ToInt32(Txt42.Text)) && gameManager.PointsCheck(Convert.ToInt32(Txt31.Text), Convert.ToInt32(Txt32.Text)) && gameManager.PointsCheck(Convert.ToInt32(Txt21.Text), Convert.ToInt32(Txt22.Text)))
                            {
                                gameManager.RegisterResults(2, Convert.ToInt32(Txt21.Text), Convert.ToInt32(Txt22.Text));
                                gameManager.RegisterResults(3, Convert.ToInt32(Txt31.Text), Convert.ToInt32(Txt32.Text));
                                gameManager.RegisterResults(4, Convert.ToInt32(Txt41.Text), Convert.ToInt32(Txt42.Text));
                                gameManager.RegisterResults(5, Convert.ToInt32(Txt51.Text), Convert.ToInt32(Txt52.Text));
                            }
                            else
                            {
                                MessageBox.Show("Invalid points!");
                                return;
                            }
                        }
                        else
                        {
                            if (gameManager.PointsCheck(Convert.ToInt32(Txt51.Text), Convert.ToInt32(Txt52.Text)) && gameManager.PointsCheck(Convert.ToInt32(Txt41.Text), Convert.ToInt32(Txt42.Text)) && gameManager.PointsCheck(Convert.ToInt32(Txt31.Text), Convert.ToInt32(Txt32.Text)) && gameManager.PointsCheck(Convert.ToInt32(Txt21.Text), Convert.ToInt32(Txt22.Text)) && gameManager.PointsCheck(Convert.ToInt32(Txt11.Text), Convert.ToInt32(Txt12.Text)))
                            {
                                gameManager.RegisterResults(1, Convert.ToInt32(Txt11.Text), Convert.ToInt32(Txt12.Text));
                                gameManager.RegisterResults(2, Convert.ToInt32(Txt21.Text), Convert.ToInt32(Txt22.Text));
                                gameManager.RegisterResults(3, Convert.ToInt32(Txt31.Text), Convert.ToInt32(Txt32.Text));
                                gameManager.RegisterResults(4, Convert.ToInt32(Txt41.Text), Convert.ToInt32(Txt42.Text));
                                gameManager.RegisterResults(5, Convert.ToInt32(Txt51.Text), Convert.ToInt32(Txt52.Text));
                            }
                            else
                            {
                                MessageBox.Show("Invalid points!");
                                return;
                            }
                        }
                        break;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid data format!");
            }
            this.Close();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
