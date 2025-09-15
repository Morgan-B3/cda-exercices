import React, { use, useState } from 'react'
import {Flex, Progress} from 'antd'
import {QUESTIONS} from "./quiz.js"
import Question from './Question.jsx'

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

  return (
    <>
        <Progress percent={(questionNumber+1)*10} status='active' format={(percent)=>`${percent/10}/10`}/>
        {questionNumber <= QUESTIONS.length-1 ? 
            <Question prompt={QUESTIONS[questionNumber].prompt} choices={QUESTIONS[questionNumber].choices} action={(answer,answerId)=>increment(answer, answerId)} answerId={QUESTIONS[questionNumber].answerId}></Question>
        :
            <div>
                <p>Score : {score}/10</p>
                <button onClick={()=>restart()}>Rejouer ?</button>
                <div>
                    <h2>Vos réponses :</h2>
                    {answersList}
                </div>
            </div>
        }
    </>
  )
}

export default Quiz