import React from "react";
import Form from "./Form.jsx";
import Category from "./Category.jsx";
import { useSelector } from "react-redux";
import ExpenseCard from "./ExpenseCard.jsx";
import { categories } from "../../data/bank/categories.js";

function Bank() {  
  const expenses = useSelector(state=>state.expenses.items);
  
  let totalAmount = 0;
  expenses.map(expense=>{
    totalAmount += expense.amount
  })

  const categoriesList = categories.map(category=>{
    let amount = 0;
    const categoryExpenses = expenses.filter(expense => expense.category === category);
    categoryExpenses.map(expense=> amount+=expense.amount)
    
    return(
      <Category key={category} category={category} amount={amount}></Category>
    )
  })

  const expensesList = expenses.map(expense=>{
    return(
      <ExpenseCard key={expense.id} expense={expense}></ExpenseCard>
    )
  })

  return(
    <div className="flex flex-col">
      <h1>Mes dépenses</h1>
      <div className="flex">
        <Category category={"Total"} amount={totalAmount}></Category>
        {categoriesList}
      </div>
      <Form></Form>
      <div className=" flex flex-col">
        {expensesList}
      </div>
    </div>
  )
}

export default Bank;
