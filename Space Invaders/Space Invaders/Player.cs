using System;
using System.Collections.Generic;
using System.Drawing; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace SpaceInvaders
{
    class player //Класс для космического корабля
    {
        private int width, height; //Ширина и высота корабля
        private int x, y; //Координаты начала корабля
        private PictureBox pb; // Область картинки корабля
        public player() // Начальные свойства корабля
        {
            width = 60;
            height = 50;
            x = 150;
            y = 700;
        }
        public void CreatePlayer(Form p) //Создаем корабль на форме
        {
            pb = new PictureBox();
            pb.Location = new Point(x, y);
            pb.Size = new Size(width, height);
            pb.BackgroundImageLayout = ImageLayout.Stretch;
            pb.BackgroundImage = Image.FromFile(@"C:\Users\beloh\Desktop\Space Invaders\Space Invaders\SpaceShip.png");
            p.Controls.Add(pb);
        }

        public int getX() //Получаем положение корабля по х
        {
            return x;
        }
        public int getY() //Получаем положение корабля по у
        {
            return y;
        }
        public int getWidth() //Получаем высоту корабля
        {
            return width;
        }
        public PictureBox getPlayerPB() //Получаем объект-картинку корабля
        {
            return pb;
        }
        public void Left(int r) //Движение корабля влево на r
        {
            if(x>=0){
                x-=r;
                pb.Location = new Point(x,y);
            }
            
        }
        public void Right(int r) //Движение корабля вправо на r
        {
            if (x <= 730)
            {
                x += r;
                pb.Location = new Point(x, y);
            }
        }
    }
} 
