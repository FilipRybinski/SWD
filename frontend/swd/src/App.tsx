import { useState } from "react";
import "./App.scss";
import siteImg from "/site.png";
import Question from "./components/question";
import Paging from "./components/paging";
import Slider from "./components/slider";
import { QuestionType } from "./types/questions-type";
import axios from "axios";
import { FrameworkResponse } from "./types/framework-response";

const answersType: {
  [key: string]: string[];
} = {
  project: ["Ecommerce", "Dashboard", "Blog", "Portfolio"],
  degrees: ["Rich", "Medium", "Poor"],
  content: ["High", "Mid", "Low"],
  utility: ["Very high", "High", "Mid", "Low", "Very low"],
};

const images: Record<string, string> = {
  React: "/react.png",
  Angular: "/angular.png",
  Vue: "/vue.png",
  Svelte: "/svelte.png",
};

function App() {
  const [questionnaire, setQuestionnaire] = useState<QuestionType[]>([
    {
      id: 1,
      question: "Project type:",
      answersType: "project",
      userAnswer: "",
      utility: "",
    },
    {
      id: 2,
      question: "Scalibility",
      answersType: "content",
      userAnswer: "",
      utility: "Medium",
    },
    {
      id: 3,
      question: "Performance",
      answersType: "content",
      userAnswer: "",
      utility: "Medium",
    },
    {
      id: 4,
      question: "Community Support",
      answersType: "content",
      userAnswer: "",
      utility: "Medium",
    },
    {
      id: 5,
      question: "Learning Speed",
      answersType: "content",
      userAnswer: "",
      utility: "Medium",
    },
    {
      id: 6,
      question: "Implementation Cost",
      answersType: "content",
      userAnswer: "",
      utility: "Medium",
    },
    {
      id: 7,
      question: "Ecosystem",
      answersType: "degrees",
      userAnswer: "",
      utility: "Medium",
    },
    {
      id: 8,
      question: "SEO",
      answersType: "content",
      userAnswer: "",
      utility: "Medium",
    },
  ]);

  const [currentQuestion, setCurrentQuestion] = useState<number>(0);
  const [frameworks, setFrameworks] = useState<FrameworkResponse[] | null>([]);

  const [showMore, setShowMore] = useState<boolean>(false);

  const handleChooseAnswer = (answer: string) => {
    setQuestionnaire((prev: any) => {
      const newQuestionnaire = [...prev];
      newQuestionnaire[currentQuestion].userAnswer = answer;
      return newQuestionnaire;
    });
  };

  const handleChooseUtility = (utility: string) => {
    console.log(utility, utility.replace(" ", ""));
    setQuestionnaire((prev: any) => {
      const newQuestionnaire = [...prev];
      newQuestionnaire[currentQuestion].utility = utility;
      return newQuestionnaire;
    });
  };

  const handleSubmit = async () => {
    const dataToSend = {
      ProjectType: questionnaire[0].userAnswer,
      Scalability: questionnaire[1].userAnswer,
      Performance: questionnaire[2].userAnswer,
      CommunitySupport: questionnaire[3].userAnswer,
      LearningSpeed: questionnaire[4].userAnswer,
      ImplementationCost: questionnaire[5].userAnswer,
      Ecosystem: questionnaire[6].userAnswer,
      SEO: questionnaire[7].userAnswer,
      Usage: {
        ScalabilityUsage: questionnaire[1].utility.replace(" ", ""),
        PerformanceUsage: questionnaire[2].utility.replace(" ", ""),
        CommunitySupportUsage: questionnaire[3].utility.replace(" ", ""),
        LearningSpeedUsage: questionnaire[4].utility.replace(" ", ""),
        ImplementationCostUsage: questionnaire[5].utility.replace(" ", ""),
        EcosystemUsage: questionnaire[6].utility.replace(" ", ""),
        SEOUsage: questionnaire[7].utility.replace(" ", ""),
      },
    };
    try {
      const response = await axios.post<FrameworkResponse[]>(
        "http://localhost:5000/api/framework/result",
        dataToSend,
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      console.log(response.data);
      setFrameworks(response.data);
    } catch (error) {
      console.error("Error:", error);
    }
  };

  const handleReset = () => {
    setFrameworks(null);
    setCurrentQuestion(0);
    setQuestionnaire((prev: any) => {
      const newQuestionnaire = [...prev];
      newQuestionnaire.map((question: any) => {
        question.userAnswer = "";
        question.utility = "Medium";
        return question;
      });
      return newQuestionnaire;
    });
  };

  if (frameworks !== null) {
    return (
      <div className="framework-container">
        <div className="framework-container__box">
          <h1 className="framework-container__header">Framework:</h1>
          <img
            src={images[frameworks[0].Framework]}
            alt={frameworks[0].Framework}
            className="framework-container__img"
          />
          <div className="framework-container__cont">
            <p className="framework-container__framework">
              {frameworks[0].Framework}
            </p>
            <p className=" framework-container__utility">
              Utility: {frameworks[0].Utility.toFixed(2)}
            </p>
            <button
              onClick={() => setShowMore(!showMore)}
              className="framework-container__btn"
            >
              Show more
            </button>
          </div>

          {showMore && (
            <div className="framework-container__more">
              <h2 className="framework-container__subheader">
                Other Frameworks:
              </h2>
              <div className="framework-container__items">
                {frameworks.slice(1).map((framework: FrameworkResponse) => (
                  <div
                    key={framework.Framework}
                    className="framework-container__item"
                  >
                    <img
                      src={images[framework.Framework]}
                      alt={framework.Framework}
                      className="framework-container__img--small"
                    />
                    <div className="">
                      <p className="framework-container__framework--small">
                        {framework.Framework}
                      </p>
                      <p className="framework-container__utility  framework-container__utility--small">
                        Utility: {framework.Utility.toFixed(2)}
                      </p>
                    </div>
                  </div>
                ))}
              </div>
            </div>
          )}

          <button onClick={handleReset} className="submit-btn">
            Reset
          </button>
        </div>
      </div>
    );
  }

  return (
    <div className="container">
      <main className="box">
        <img src={siteImg} alt="site" className="box__img" />
        <Question
          question={questionnaire[currentQuestion].question}
          answers={answersType[questionnaire[currentQuestion].answersType]}
          userAnswer={questionnaire[currentQuestion].userAnswer}
          setUserAnswer={handleChooseAnswer}
        />
        <Slider
          questionId={questionnaire[currentQuestion].id}
          utility={questionnaire[currentQuestion].utility}
          setUtility={handleChooseUtility}
        />
        {currentQuestion === questionnaire.length - 1 && (
          <button onClick={handleSubmit} className="submit-btn">
            Submit
          </button>
        )}
      </main>
      <Paging
        currentQuestion={currentQuestion}
        setCurrentQuestion={setCurrentQuestion}
        totalQuestions={questionnaire.length}
      />
    </div>
  );
}

export default App;
