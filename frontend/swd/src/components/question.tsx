type QuestionProps = {
  question: string;
  answers: string[];
  userAnswer: string;
  setUserAnswer: (answer: string) => void;
};

const Question: React.FC<QuestionProps> = ({
  question,
  answers,
  userAnswer,
  setUserAnswer,
}) => {
  return (
    <div className="box__bottom">
      <h2 className="box__question">{question}</h2>
      {answers.map((answer, index) => (
        <button
          onClick={() => setUserAnswer(answer)}
          key={index}
          className={`box__answer ${
            userAnswer === answer ? "box__answer--active" : ""
          }`}
        >
          {answer}
        </button>
      ))}
    </div>
  );
};

export default Question;
