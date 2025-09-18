import React from 'react'

function Question({id, prompt, choices, answerId, explanation, action}) {

    const choicesList = choices.map((choice,index)=>{
        return(
            <button key={choice.id} onClick={()=>action(choice.id, answerId)}>{choice.label}</button>
        )
    })



  return (
    <>
        <h2>{prompt}</h2>
        {choicesList}
    </>
  )
}

export default Question