using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas.Bowling
{
    public class Game
    {
        const int TOTAL_SHOTS_COUNT = 21;
        const int TOTAL_FRAMES_COUNT = 10;
        private int currentRoll;

        public Game()
        {
            Frames = new List<Frame>();
            for (int i = 0; i < TOTAL_FRAMES_COUNT; i++)
            {
                var newFrame = new Frame();
                Frames.Add(newFrame);
            }
        }

        public void Roll(int pins)
        {
            int currentFrameIndex = currentRoll / 2;
            if (currentFrameIndex >= TOTAL_FRAMES_COUNT)
                currentFrameIndex = TOTAL_FRAMES_COUNT - 1;
            Frames[currentFrameIndex].PinsHitList.Add(pins);

            //_rolls[currentRoll++] = pins;
            currentRoll++;
        }

        public int Score()
        {
            int score = 0;

            for (int frameIndex = 0; frameIndex < Frames.Count; frameIndex++)
            {
                if (Frames[frameIndex].IsStrike)
                {
                    score +=
                        Frame.TOTAL_PINS_COUNT
                        + (frameIndex + 1 >= Frames.Count ? Frame.TOTAL_PINS_COUNT : Frames[frameIndex + 1].PinsHitList.FirstOrDefault())
                        + (frameIndex + 2 >= Frames.Count ? Frame.TOTAL_PINS_COUNT : Frames[frameIndex + 2].PinsHitList.FirstOrDefault());
                }
                else if(Frames[frameIndex].IsSpare)
                {
                    score +=
                        Frame.TOTAL_PINS_COUNT +
                        Frames[frameIndex + 1].PinsHitList.FirstOrDefault();
                }
                else
                {
                    score += Frames[frameIndex].Score;
                }
            }
            return score;
        }

        public List<Frame> Frames { get; set; }
    }

    public class Frame
    {
        public Frame()
        {
            PinsHitList =  new List<int>();
        }

        public const int TOTAL_PINS_COUNT = 10;

        public List<int> PinsHitList { get; set; }

        public int Score => PinsHitList.Any() ? PinsHitList.Sum() : 0;

        public bool IsStrike => PinsHitList.Any() && (PinsHitList.First() == TOTAL_PINS_COUNT);

        public bool IsSpare => PinsHitList.Any() && (PinsHitList.First() < TOTAL_PINS_COUNT && Score == TOTAL_PINS_COUNT);
    }

    //public class Game1
    //{
    //    private int[] rolls = new int[21];
    //    private int currentRoll = 0;

    //    public void Roll(int pins)
    //    {
    //        rolls[currentRoll++] = pins;
    //    }

    //    public int Score()
    //    {
    //        int score = 0;
    //        int frameIndex = 0;
    //        for (int frame = 0; frame < 10; frame++)
    //        {
    //            if (isStrike(frameIndex))
    //            {
    //                score += 10 + strikeBonus(frameIndex);
    //                frameIndex++;
    //            }
    //            else if (isSpare(frameIndex))
    //            {
    //                score += 10 + spareBonus(frameIndex);
    //                frameIndex += 2;
    //            }
    //            else
    //            {
    //                score += sumOfBallsInFrame(frameIndex);
    //                frameIndex += 2;
    //            }
    //        }
    //        return score;
    //    }

    //    private bool isStrike(int frameIndex)
    //    {
    //        return rolls[frameIndex] == 10;
    //    }

    //    private int sumOfBallsInFrame(int frameIndex)
    //    {
    //        return rolls[frameIndex] + rolls[frameIndex + 1];
    //    }

    //    private int spareBonus(int frameIndex)
    //    {
    //        return rolls[frameIndex + 2];
    //    }

    //    private int strikeBonus(int frameIndex)
    //    {
    //        return rolls[frameIndex + 1] + rolls[frameIndex + 2];
    //    }

    //    private bool isSpare(int frameIndex)
    //    {
    //        return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
    //    }
    //}
}
