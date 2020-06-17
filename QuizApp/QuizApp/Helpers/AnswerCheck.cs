using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Helpers
{
    public class AnswerCheck
    {
        public static int Grade(int[] answers)
        {
            int rightAnswers = 0;
            if (answers[0] == 2)
            {
                rightAnswers++;
            }

            if (answers[1] == 4)
            {
                rightAnswers++;

            }

            if (answers[2] == 3)
            {
                rightAnswers++;
            }

            if (answers[3] == 2)
            {
                rightAnswers++;
            }

            if (answers[4] == 2)
            {
                rightAnswers++;
            }

            if (rightAnswers == 0)
            {
                rightAnswers = 1;
            }

            return rightAnswers;
        }
    }
}
