﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GameAsteroid.VisualObjects;

namespace GameAsteroid
{
    /// <summary> Класс игровой логики </summary>
    internal static class Game
    {
        /// <summary> Интервал времени таймера формирования кадра игры </summary>
        private const int __TimerInterval = 100;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        private static VisualObject[] __GameObjects;
        //private static Bullet __Bullet;
        private static readonly List<Bullet> __Bullets = new List<Bullet>();
        private static Spaceship __Spaceship;
        private static Timer __Timer;

        /// <summary> Ширина игрового поля </summary>
        public static int Width { get; private set; }

        /// <summary> Высота игрового поля </summary>
        public static int Height { get; private set; }

        /// <summary> Инициализация игровой логики </summary>
        /// <param name="form"> Игровая форма </param>
        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            __Timer = new Timer { Interval = __TimerInterval };
            __Timer.Tick += OnVimerTick;
            __Timer.Start();

            form.KeyDown += OnFormKeyDown;
            
            //var test_button = new Button();
            //test_button.Width = 70;
            //test_button.Height = 30;
            //test_button.Text = "123";
            //test_button.Left = 20;
            //test_button.Top = 30;
            //test_button.Click += OnTestButtonClick;
            //form.Controls.Add(test_button);
        }

        private static void OnTestButtonClick(object Sender, EventArgs e)
        {
            MessageBox.Show("Кнопка нажата!");
        }

        private static void OnFormKeyDown(object snder, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    //__Bullet = new Bullet(__Spaceship.Rect.Y);
                    __Bullets.Add(new Bullet(__Spaceship.Rect.Y));
                    break;

                case Keys.Up:
                    __Spaceship.MoveUp();
                    break;

                case Keys.Down:
                    __Spaceship.MoveDown();
                    break;
            }
        }

        private static void OnVimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;

            //Background
            g.Clear(Color.Black);
            //g.DrawRectangle(Pens.White, new Rectangle(50, 50, 200, 200));
            //g.FillEllipse(Brushes.Red, new Rectangle(100, 50, 70, 120));

            foreach (var game_object in __GameObjects)
                game_object?.Draw(g);

            //if (__Bullet != null)
            //    __Bullet.Draw(g); - эквивалент
            __Spaceship.Draw(g);

            //__Bullet?.Draw(g);
            __Bullets.ForEach(bullet => bullet.Draw(g));

            if (!__Timer.Enabled) return;
            __Buffer.Render();
        }

        public static void Load()
        {
            List<VisualObject> game_objects = new List<VisualObject>();            

            //for (var i = 0; i < 30; i++)
            //{
            //    game_objects.Add(new VisualObject(
            //        new Point(600, i * 20),
            //        new Point(15 - i, 20 - i),
            //        new Size(20, 20)));
            //}

            for (var i = 0; i < 10; i++)
            {
                game_objects.Add (new Star(
                    new Point(600, (int)(i / 2.0 * 20)),
                    new Point(-i, 0),
                    10));
            }

            var rnd = new Random();
            const int asteroid_count = 10;
            const int asteroid_size = 25;
            const int asteroid_max_speed = 20;
            for (var i = 0; i < asteroid_count; i++)
                game_objects.Add(new Asteroid(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, asteroid_max_speed), 0),
                    asteroid_size));

            //__Bullet = new Bullet(200);
            __GameObjects = game_objects.ToArray();

            __Spaceship = new Spaceship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
            __Spaceship.Destroyed += OnShipDestroyed;
        }

        private static void OnShipDestroyed(object sender, EventArgs e)
        {
            __Timer.Stop();
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);
            g.DrawString("Game over!!!", new Font(FontFamily.GenericSerif, 40, FontStyle.Bold), Brushes.White, 200, 200);
            __Buffer.Render();
        }

            public static void Update()
        {
            foreach (var game_object in __GameObjects)
                game_object?.Update();

            //__Bullet?.Update();
            __Bullets.ForEach(b => b.Update());

            foreach (var bullet_to_remove in __Bullets.Where(b => b.Rect.Left > Width).ToArray())
                __Bullets.Remove(bullet_to_remove);

            for (var i =0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;

                    __Spaceship.CheckCollision(collision_object);

                    foreach (var bullet in __Bullets.ToArray())
                        if (bullet.CheckCollision(collision_object))
                        {
                            //__Bullet = null;
                            __Bullets.Remove(bullet);
                            __GameObjects[i] = null;
                            System.Media.SystemSounds.Beep.Play();
                        }
                }
            }
        }
    }

}
