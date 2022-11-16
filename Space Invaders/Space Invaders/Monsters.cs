using System;
using System.Collections.Generic;
using System.Drawing; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace SpaceInvaders
{
    class monsters //Класс монстров
    {
        private int width, height; //Высота и ширина
        private int columns, rows; //Количество монстров (столбцы и строки)
        private int x, y, space; // Положение монстра и расстояние между ними
        private List<PictureBox> listMonsters; //Список всех монстров

        public monsters() //Начальные свойства монстра
        {
            width = 40;
            height = 40;
            columns = 10;
            rows = 5;
            space = 10;
            x = 150;
            y = 0; 
            listMonsters = new List<PictureBox>();
        }
        private void CreateMonster(Form p) //Создаем 1 монстра и ставим его на форму, добавляем в лист
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(x, y);
            pb.Size = new Size(width, height);
            pb.BackgroundImage = Image.FromFile(@"C:\Users\beloh\Desktop\Space Invaders\Space Invaders\monster.png");
            pb.BackgroundImageLayout = ImageLayout.Stretch;
            pb.Name = "Monster";
            listMonsters.Add(pb);
            p.Controls.Add(pb); 
        }
        public void CreateMonsters(Form p) //Создаем много монстров
        {

            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    CreateMonster(p);
                    x += width + space; 
                }
                y += height + space;
                x = 150; 
            }
        }
        public void MonsterShoot(PictureBox monstr, Form p) //Создание выстрела от монстра
        {
            PictureBox MonsterShoot = new PictureBox();
            MonsterShoot.Location = new Point(monstr.Location.X + monstr.Width / 3, monstr.Location.Y + 20);
            MonsterShoot.Size = new Size(5, 20);
            MonsterShoot.BackColor = Color.White;
            MonsterShoot.Name = "MonsterShoot";
            p.Controls.Add(MonsterShoot);
        }
        public List<PictureBox> getList() //Получить лист с монстрами
        {
            return listMonsters;
        }
    }
 }

