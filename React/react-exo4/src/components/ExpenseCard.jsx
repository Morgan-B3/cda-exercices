import React from 'react'
import { useDispatch } from 'react-redux'
import { removeItem } from '../store.js';

function ExpenseCard({expense}) {

  const dispatch = useDispatch();

  return (
    <div className='flex card'>
      <p>{expense.label}</p>
      <p>{expense.amount}€</p>
      <p>{expense.date}</p>
      <p>{expense.category}</p>
      <button onClick={()=>dispatch(removeItem(expense.id))}>Supprimer</button>
    </div>
  )
}

export default ExpenseCard