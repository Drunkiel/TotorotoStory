using System;

[Serializable]
public class QuestionBase
{
    [Serializable]
    public class Question
    {
        public int id;
        public string questionContent;
        public string[] answers = new string[3];
        public char correctAnswer;
    }
}
