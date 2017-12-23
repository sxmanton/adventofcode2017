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

        public string GetMazeLetterOrder(out int numSteps)
        {
            numSteps = 1;
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

                if (currentY < 0 || currentY >= height || currentX < 0 || currentX >= width)
                {
                    lostContinuity = true;
                    break;                    
                }

                char currentChar = lines[currentY][currentX];
                if (currentChar == ' ')
                {
                    lostContinuity = true;
                    break;
                }

                numSteps++;

                if (char.IsLetter(currentChar))
                {
                    builder.Append(currentChar);
                }

                if (currentChar == '+')
                {
                    if (currentDirection == Direction.Up || currentDirection == Direction.Down)
                    {
                        if (currentX - 1 >= 0)
                        {
                            var leftChar = lines[currentY][currentX - 1];
                            if (leftChar == '-' || char.IsLetter(leftChar))
                            {
                                currentDirection = Direction.Left;
                                Debug.WriteLine("Changing to go left");
                                continue;
                            }
                        }
                        if (currentX + 1 < width)
                        {
                            var rightChar = lines[currentY][currentX + 1];
                            if (rightChar == '-' || char.IsLetter(rightChar))
                            {
                                currentDirection = Direction.Right;
                                Debug.WriteLine("Changing to go right");
                                continue;
                            }
                        }
                        throw new Exception("Couldn't find valid turn direction");
                    }
                    else
                    {
                        if (currentY - 1 >= 0 )
                        {
                            var upChar = lines[currentY - 1][currentX];
                            if (upChar == '|' || char.IsLetter(upChar))
                            {

                                currentDirection = Direction.Up;
                                Debug.WriteLine("Changing to go up");
                                continue;
                            }
                        }
                        if (currentY + 1 < height)
                        {
                            var downChar = lines[currentY + 1][currentX];
                            if (downChar == '|' || char.IsLetter(downChar))
                            {
                                currentDirection = Direction.Down;
                                Debug.WriteLine("Changing to go down");
                                continue;
                            }
                        }
                        throw new Exception("Couldn't find valid turn direction");
                    }
                }
            }
            return builder.ToString();
        }
    }
}
