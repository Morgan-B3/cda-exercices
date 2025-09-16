import React from 'react'

function Answer({question, id, answerId, prompt, choices, explanation, userAnswerId}) {
    
    const goodChoice = question.choices?.find((choice)=>choice.id === question.answerId);
    const userChoice = question.choices?.find((choice)=>choice.id === userAnswerId);

    console.log(question.explanation);
    
  return (
    <div key={question.id}>
        <h3>{question.prompt}</h3>
        <div>
            <p className={goodChoice == userChoice ? 'good' : 'bad'}>Votre réponse : {userAnswerId} - {userChoice.label}</p>
            <p>Bonne réponse : {question.answerId} - {goodChoice.label}</p>
            <p>Explication : {question.explanation}</p>
        </div>
    </div>
  )
}

export default Answer