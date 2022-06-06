using System;
using System.Collections.Generic;
using System.Threading;

namespace Ball
{
    struct Vector
    {
        public int X;
        public int Y;
       
        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    internal class Program
    {
        static object x = new object();
        public static void Move()
        {
            lock (x)
            {
                Vector ballLocation = new Vector(40, 12);
                Vector direction = new Vector(-1, -1);

                while (true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(ballLocation.X, ballLocation.Y);
                    Console.Write((char) 4);

                    ballLocation.X += direction.X;
                    ballLocation.Y += direction.Y;
                    Thread.Sleep(100);

                    if (ballLocation.X == 0 || ballLocation.X == 79)
                        direction.X = -direction.X;
                    if (ballLocation.Y == 0 || ballLocation.Y == 24)
                        direction.Y = -direction.Y;
                }
            }
        }
        
        public static void Main(string[] args)
        {
            // Thread thread = new Thread(Move);
            // thread.IsBackground = true;
            // thread.Start();

            lock (x)
            {
                Move();
            }
           
            Console.ReadKey(true);
        }
    }
}