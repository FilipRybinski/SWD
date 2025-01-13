type PagingProps = {
  currentQuestion: number;
  setCurrentQuestion: (page: number) => void;
  totalQuestions: number;
};

const Paging: React.FC<PagingProps> = ({
  currentQuestion,
  setCurrentQuestion,
  totalQuestions,
}) => {
  const handleClick = (page: number) => {
    setCurrentQuestion(page);
  };

  return (
    <div className="paging">
      {Array.from({ length: totalQuestions }, (_, i) => (
        <button
          key={i}
          className={`paging__item ${
            i === currentQuestion ? "paging__item--active" : ""
          }`}
          onClick={() => handleClick(i)}
        >
          {i + 1}
        </button>
      ))}
    </div>
  );
};

export default Paging;
