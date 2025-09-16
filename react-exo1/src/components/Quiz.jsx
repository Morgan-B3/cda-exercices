import React, { use, useState } from 'react'
import {Flex, Progress} from 'antd'
import {QUESTIONS} from "./quiz.js"
import Question from './Question.jsx'
import Answer from './Answer.jsx';

function Quiz() {
    const [questionNumber, setQuestionNumber] = useState(0);
    const [answers, setAnswers] = useState([]);
    const [score, setScore] = useState(0);

    function increment(answer, answerId){
        setAnswers([...answers, answer])
        if(answer === answerId){
            setScore(score+1)
        }
        setQuestionNumber(questionNumber+1)
    }

    function restart(){
        setAnswers([]);
        setScore(0);
        setQuestionNumber(0);
    }

    const answersList = answers.map((answer,index)=>{
        return(
            <p key={index}>{answer}</p>
        )
    })

    let answersList2 = QUESTIONS.map((question,index)=>{
        console.log(question.id);
        
        if(questionNumber > QUESTIONS.length-1 ){         
            return(
                <Answer question={question} userAnswerId={answers[index]}></Answer>
            )
        }
    })

  return (
    <>
        <Progress percent={questionNumber < QUESTIONS.length ? (questionNumber)*((100/QUESTIONS.length)) : 100}  format={(percent)=>`${questionNumber <= QUESTIONS.length-1 ? questionNumber : QUESTIONS.length}/${QUESTIONS.length}`} title={'white'} trailColor={'white'}/>
        {questionNumber <= QUESTIONS.length-1 ? 
            <Question prompt={QUESTIONS[questionNumber].prompt} choices={QUESTIONS[questionNumber].choices} action={(answer,answerId)=>increment(answer, answerId)} answerId={QUESTIONS[questionNumber].answerId}></Question>
        :
            <div>
                <p>Score : {score}/{QUESTIONS.length}</p>
                <button onClick={()=>restart()}>Rejouer ?</button>
                <div>
                    <h2>Vos réponses :</h2>
                    {answersList2}
                </div>
            </div>
        }
    </>
  )
}

export default Quiz