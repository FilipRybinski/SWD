type SliderProps = {
  questionId: number;
  utility: string;
  setUtility: (utility: string) => void;
};

const Slider: React.FC<SliderProps> = ({ questionId, utility, setUtility }) => {
  const handleInputChoice = (e: React.ChangeEvent<HTMLInputElement>) => {
    switch (e.target.value) {
      case "0":
        setUtility("Very low");
        break;
      case "1":
        setUtility("Low");
        break;
      case "2":
        setUtility("Medium");
        break;
      case "3":
        setUtility("High");
        break;
      case "4":
        setUtility("Very high");
        break;
      default:
        setUtility("Low");
        break;
    }
  };

  const utilityToValue = (utility: string): number => {
    switch (utility) {
      case "Very low":
        return 0;
      case "Low":
        return 1;
      case "Medium":
        return 2;
      case "High":
        return 3;
      case "Very high":
        return 4;
      default:
        return 1; // Default to "Low" if no match
    }
  };
  if (questionId === 1) {
    return;
  }
  return (
    <div className="slider">
      <h3 className="slider__header">How important is that for you</h3>
      <div className="slider__choice">
        <span className="slider__desc">Low</span>
        <input
          onChange={handleInputChoice}
          type="range"
          min="0"
          max="4"
          step="1"
          value={utilityToValue(utility)} // Use a numeric value based on the current utility
        />
        <span className="slider__desc">High</span>
      </div>
      <p className="slider__desc">{utility}</p>
    </div>
  );
};

export default Slider;
