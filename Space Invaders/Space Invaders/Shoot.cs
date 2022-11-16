using System;
using System.Collections.Generic;
using System.Drawing; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace SpaceInvaders
{
    class shoot //Класс выстрела корабля
    {
        private int width, height; //Ширина и высота
        private int x, y; //Начальное положение
        PictureBox shot; //Объект-картинка
        public shoot() //Начальные свойства выстрела
        {
            width = 5;
            height = 20;
        }
        public void CreateShoot(Form p, int pl_x, int pl_y, int pl_width) //Создать выстрел, относительно корабля
        {
            shot = new PictureBox();
            x = pl_x + pl_width / 2;
            y = pl_y - 20;
            shot.Location = new Point(x, y);
            shot.Size = new Size(width, height);
            shot.BackColor = Color.Red;
            shot.Name = "Shoot";
            p.Controls.Add(shot);
        }
        public PictureBox getShootPB() //Получить объект-картинку выстрела
        {
            return shot;
        }
    }
}
