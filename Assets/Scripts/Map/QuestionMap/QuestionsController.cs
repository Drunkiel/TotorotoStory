using TMPro;
using UnityEngine;

public class QuestionsController : MonoBehaviour
{
    public QuestionBase.Question[] _questions;

    public TMP_Text titleText;
    public TMP_Text questionText;
    public TMP_Text[] answersText;

    private int actualQuestion;
    private int correctAnswers;

    void Start()
    {
        LoadQuestion(0);
    }

    void LoadQuestion(int id)
    {
        titleText.text = "Question" + id + "#";
        questionText.text = _questions[id].questionContent;
        answersText[0].text = _questions[id].answers[0];
        answersText[1].text = _questions[id].answers[1];
        answersText[2].text = _questions[id].answers[2];
    }

    public void Answer(char playerChoose)
    {
        if (playerChoose == _questions[actualQuestion].correctAnswer) correctAnswers++;

        actualQuestion++;
    }
}
