﻿using StaticData;
using UnityEngine;

namespace Logic.Generator
{
    public class GridDataGenerator
    {
        private readonly float _placementThreshold;   

        public GridDataGenerator(GeneratorSo generatorSo)
        {
            _placementThreshold = generatorSo.PlacementThreshold;
        }

        public int[,] FromDimensions(int sizeRows, int sizeCols)
        {
            int[,] maze = new int[sizeRows, sizeCols];

            int rMax = maze.GetUpperBound(0);
            int cMax = maze.GetUpperBound(1);

            for (int i = 0; i <= rMax; i++)
            {
                for (int j = 0; j <= cMax; j++)
                {
                    if (i == 0 || j == 0 || i == rMax || j == cMax)
                    {
                        maze[i, j] = 1;
                    }
                    else if (i % 2 == 0 && j % 2 == 0)
                    {
                        if (Random.value > _placementThreshold)
                        {
                            maze[i, j] = 1;
                            int a = Random.value < .5 ? 0 : (Random.value < .5 ? -1 : 1);
                            int b = a != 0 ? 0 : (Random.value < .5 ? -1 : 1);
                            maze[i+a, j+b] = 1;
                        }
                    }
                }
            }
            return maze;
        }
    }
}