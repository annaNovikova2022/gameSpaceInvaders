using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SpaceInvaders
{

    public partial class Form1 : Form
    {
        monsters mss = new monsters(); 
        player pl = new player();
        shoot sh = new shoot();
        public Form1()
        {
            InitializeComponent();
            mss.CreateMonsters(this); //Добавляем монстров на экран
            pl.CreatePlayer(this); //Добавляем игрока на экран

            playerMove.Tick += playerMove_Tick; //Добавляем таймер для игрока, чтобы передвижение было плавным
        }    

        const int limR = 730; //Правый край экрана
        const int limL = 0; //Левый край экрана

        int speed = -1; //Скорость монстров
        int left = -1; //Передвижение монстров в лево/право
        int downMons = 0; //Перемещение монстров вниз
        int downSize = 0; // Для перемещения монстров вниз, равным размеру 1 монстра

        int point = 0; //Очки

        bool game = true; //Игра активна?
        bool rightMov, leftMov; //Нажата ли клавиша право/лево?
        bool fired; //Есть ли выстрел?

        private void PressKey(object sender, KeyEventArgs e) //Для зажатой клавиши
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                leftMov = true;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                rightMov = true;
            }
            else if (e.KeyCode == Keys.Space && game && !fired) // Создается один выстрел, а не последовательность
            {
                new shoot().CreateShoot(this, pl.getX() , pl.getY(), pl.getWidth());
                fired = true;
            }
        }
        private void ReleasedKey(object sender, KeyEventArgs e) //Когда отпустили клавишу
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                leftMov = false;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                rightMov = false;
            }
            else if (e.KeyCode == Keys.Space)
            {
                fired = false;
            }
        }
        private void playerMove_Tick(object sender, EventArgs e) //Для плавного движения (timer)
        {
            if (leftMov) pl.Left(1);
            else if (rightMov) pl.Right(1);
        }
        private void ContactShoot(object sender, EventArgs e) //При соприкосновении выстрела с монстром или вылетом за карту (timer)
        {
            foreach (Control shot in this.Controls)
            {
                if (shot is PictureBox && shot.Name == "Shoot") // Для картинки с именем Shoot
                {
                    PictureBox shoot = (PictureBox)shot;
                    shoot.Top -= 5;

                    if (shoot.Location.Y <= 0) //Если вылетает за карту
                    {
                        this.Controls.Remove(sh.getShootPB());  //Удалить
                    }

                    foreach(Control mnstr in this.Controls) //Перебираем элементы формы
                    {
                        if (mnstr is PictureBox && mnstr.Name == "Monster") //Для картинок с именем Monster
                        {
                            PictureBox monster = (PictureBox)mnstr;

                            if (shoot.Bounds.IntersectsWith(monster.Bounds)) //Если прямоугольники монстра и выстрела соприкасаются  
                            {
                                this.Controls.Remove(shoot); //Удаляем выстрел
                                this.Controls.Remove(monster); //Удаляем монстра
                                mss.getList().Remove(monster); //Удаляем монстра из листа
                                point += 10; //Добавляем очки
                                Score(point); //Отображаем измененные очки
                                 
                                if (point == 500)  //Проверка на победу
                                {
                                    game = false;

                                    Label win = new Label(); //В случае победы выставляем соответствующую надпись
                                    win.AutoSize = true;
                                    win.Location = new Point(limR / 2, limR / 2);
                                    win.Text = "Вы победили!\n" + "Очки: " + point.ToString();
                                    win.ForeColor = Color.White;
                                    win.Font = new Font(win.Font.FontFamily, 20, FontStyle.Bold);
                                    this.Controls.Add(win);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void MoveMonsters(object sender, EventArgs e) //Передвижение монстров (timer)
        {

            foreach (PictureBox monstr in mss.getList()) //Для любой картинке в листе с Монстрами
            {
                monstr.Location = new Point(monstr.Location.X + left, monstr.Location.Y + downMons); //Новое расположение картинки

                int size = monstr.Height; //Высота прямоугольника(картинки) с монстром
                if ((monstr.Location.X <= limL || monstr.Location.X >= limR)&&game) //Если не выходит за границы и игра продолжается
                {
                    downMons = 1; //Спустить картинку на 1, изменяя у
                    left = 0; // Не перемещать в сторону
                    downSize++; //Растояние, на которое переместился рисунок
                    if (downSize == size) //Если расстояние равно размеру монстра, то убираем изменения по у, возвращаем скорость перемещения и меняем сторону движения монстров
                    {
                        downMons = 0; 
                        left = speed * (-1);
                    }
                    else if (downSize == size * 2) // При столкновении с другой стороной расстояние станет размеру 2-ух монстров, тогда начинаем движение в другую сторону
                    {
                        downMons = 0; 
                        left = speed; 
                        downSize = 0;
                    } //Разделение связано с тем, что left обновляется
                }

                if (monstr.Bounds.IntersectsWith(pl.getPlayerPB().Bounds)) //Если прямоугольник-монстр столкнется с каорблем, игра закончится
                {
                    gameOver();
                }
            }
        }
        private void MonsterShoot(object sender, EventArgs e) // Создание выстрела от монстра через интервал (timer)
        {
            Random sh = new Random();
            int num; // Номер монстра для выстрела

            if (mss.getList().Count > 0) //Возвращаем количество элементов в листе с монстрами и если монстры есть
            {
                num = sh.Next(mss.getList().Count);
                new monsters().MonsterShoot(mss.getList()[num], this);
            }
        }

        

        private void DetectLaser(object sender, EventArgs e) //(timer)
        {
            foreach(Control shot in this.Controls)
            {
                if (shot is PictureBox && shot.Name == "MonsterShoot") //Если есть картинка с именем MonsterShoot
                {
                    PictureBox MonsterShoot = (PictureBox)shot;
                    MonsterShoot.Top += 5; //Передвигается вверх на 5

                    if (MonsterShoot.Location.Y >= limR) //Если вылетает за карту, то удаляется
                    {
                        this.Controls.Remove(MonsterShoot); 
                    }
                    if (MonsterShoot.Bounds.IntersectsWith(pl.getPlayerPB().Bounds)) //Если соприкосается с прямоугольником игрока, то проигрыш
                    {
                        this.Controls.Remove(MonsterShoot);
                        gameOver();
                    }                    
                }
            }
        }

        private void gameOver() //Проигрыш
        {
            game = false;

            Label lose = new Label(); //В случае поражения выставляем соответствующую надпись
            lose.AutoSize = true;
            lose.Location = new Point(limR / 2, limR / 2);
            lose.Text = "Вы проиграли!\n" + "Очки: " + point.ToString();
            lose.ForeColor = Color.White;
            lose.Font = new Font(lose.Font.FontFamily, 20, FontStyle.Bold);
            this.Controls.Add(lose);
        }
        private void Score(int point) //Показываем очки
        {
            label2.Text = "Score: " + point.ToString();
        }
    }
}
