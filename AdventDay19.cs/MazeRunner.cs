using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay19
{
    public class MazeRunner
    {
        List<string> lines = new List<string>();

        int currentY;
        int currentX;

        enum Direction
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3
        }

        Direction currentDirection = Direction.Down;

        public MazeRunner(string mazeFile)
        {
            using (var reader = new StreamReader(mazeFile))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }
        }

        public string GetMazeLetterOrder()
        {
            currentY = 0;
            currentX = lines[currentY].IndexOf('|');
            var width = lines[currentY].Length;
            var height = lines.Count;
            var builder = new StringBuilder();
            bool lostContinuity = false;
            while (!lostContinuity)
            {
                switch (currentDirection)
                {
                    case Direction.Up:
                        currentY--;
                        break;
                    case Direction.Left:
                        currentX--;
                        break;
                    case Direction.Down:
                        currentY++;
                        break;
                    case Direction.Right:
                        currentX++;
                        break;
                }

                char currentChar;
                try
                {
                    currentChar = lines[currentY][currentX];
                }
                catch (ArgumentOutOfRangeException)
                {
                    lostContinuity = true;
                    break;
                }

                if (char.IsLetter(currentChar))
                {
                    builder.Append(currentChar);
                }

                if (currentChar == '+')
                {
                    if (currentDirection == Direction.Up || currentDirection == Direction.Down)
                    {
                        if (currentX - 1 >= 0 && lines[currentY][currentX - 1] == '-')
                        {
                            currentDirection = Direction.Left;
                            Debug.WriteLine("Changing to go left");
                            continue;
                        }
                        if (currentX + 1 < width && lines[currentY][currentX + 1] == '-')
                        {
                            currentDirection = Direction.Right;
                            Debug.WriteLine("Changing to go right");
                            continue;
                        }
                        throw new Exception("Couldn't find valid turn direction");
                    }
                    else
                    {
                        if (currentY - 1 >= 0 && lines[currentY - 1][currentX] == '|')
                        {
                            currentDirection = Direction.Up;
                            Debug.WriteLine("Changing to go up");
                            continue;
                        }
                        if (currentY + 1 < height && lines[currentY + 1][currentX] == '|')
                        {
                            currentDirection = Direction.Down;
                            Debug.WriteLine("Changing to go down");
                            continue;
                        }
                        lostContinuity = true;
                        throw new Exception("Couldn't find valid turn direction");
                    }
                }
            }
            return builder.ToString();
        }
    }
}
