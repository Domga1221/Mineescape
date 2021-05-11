using System;
using Microsoft.Xna.Framework;

namespace GameTest.Models
{
    public class Enemy
    {
        private static Random rnd = new Random();

        public Enemy(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.WorldX = x / 32;
            this.WorldY = y / 32;
            this.MoveDist = 1;
            this.Visible = true;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public int WorldX { get; set; }

        public int WorldY { get; set; }

        public int MoveDist { get; set; }

        public bool Visible { get; set; }

        public static int Distance(Vector2 value1, Vector2 value2)
        {
            int v1 = Convert.ToInt32(value1.X - value2.X);
            int v2 = Convert.ToInt32(value1.Y - value2.Y);

            return Convert.ToInt32(Math.Sqrt((v1 * v1) + (v2 * v2)));
        }

        public void Update(Level level, Player player)
        {
            int distToPlayer;

            Vector2 enemyVector = new Vector2(this.WorldX, this.WorldY);
            Vector2 playerVector = new Vector2(player.WorldX, player.WorldY);
            distToPlayer = Distance(playerVector, enemyVector);

            bool clearsight = this.CanSeePlayer(level, player);

            if (distToPlayer < 5 && clearsight == true)
            {
                Vector2 direction;
                direction = playerVector - enemyVector;

                int directionX = Convert.ToInt32(direction.X);
                int directionY = Convert.ToInt32(direction.Y);

                if (directionX != 0)
                {
                    directionX = directionX / Math.Abs(directionX);
                }

                if (directionY != 0)
                {
                    directionY = directionY / Math.Abs(directionY);
                }

                this.WorldX = this.WorldX + directionX;
                this.WorldY = this.WorldY + directionY;

                this.X = this.WorldX * 32;
                this.Y = this.WorldY * 32;

                if (level.Map[this.WorldY, this.WorldX].Solid == true)
                {
                    this.WorldX = Convert.ToInt32(this.WorldX - directionX);
                    this.WorldY = Convert.ToInt32(this.WorldY - directionY);
                    this.X = this.WorldX * 32;
                    this.Y = this.WorldY * 32;
                }
            }
            else
            {
                int a;
                int b;

                // Second Argument: Exclusive upper bound
                a = rnd.Next(-1, 2);
                b = rnd.Next(-1, 2);
                this.WorldX = this.WorldX + a;
                this.WorldY = this.WorldY + b;
                this.X = this.WorldX * 32;
                this.Y = this.WorldY * 32;

                if (level.Map[this.WorldY, this.WorldX].Solid == true)
                {
                    this.WorldX = this.WorldX - a;
                    this.WorldY = this.WorldY - b;
                    this.X = this.WorldX * 32;
                    this.Y = this.WorldY * 32;
                }
            }
        }

        public bool CanSeePlayer(Level level, Player player)
        {
            if (player.CloakedTurns > 0)
            {
                return false;
            }

            Vector2 middleOfPlayer = new Vector2(player.X + 16, player.Y + 16);
            Vector2 middleOfEnemy = new Vector2(this.X + 16, this.Y + 16);

            Vector2 direction = middleOfPlayer - middleOfEnemy;
            float distanceToPlayer = Vector2.Distance(middleOfEnemy, middleOfPlayer);
            int visionLength = 5;

            // If the enemy can see farther than the player's distance,
            if (visionLength * 32 > distanceToPlayer)
            {
                if (direction != Vector2.Zero)
                {
                    direction.Normalize();
                }

                // loop through every tile,
                for (int y = 0; y < level.Map.GetLength(1); ++y)
                {
                    for (int x = 0; x < level.Map.GetLength(0); ++x)
                    {
                        // and if the block is solid,
                        if (level.Map[y, x].Solid == true)
                        {
                            Vector2 currentPos = middleOfEnemy;
                            float lengthOfLine = 0.0f;

                            Rectangle tileRect = new Rectangle(x * 32, y * 32, 32, 32);

                            // check every point along the line
                            while (lengthOfLine < distanceToPlayer + 1.0f)
                            {
                                currentPos += direction;

                                // to see if the tile contains it
                                if (tileRect.Contains(currentPos))
                                {
                                    return false;
                                }

                                lengthOfLine = Vector2.Distance(middleOfEnemy, currentPos);
                            }
                        }
                    }
                }

                // If every tile does not contain a single point along the line from the enemy to the player,
                return true;
            }

            return false;
        }
    }
}
