import React from 'react'



function Category({category, amount}) {
  return (
    <div className='flex card'>
      <p>{category}</p>
      <p>{amount}€</p>
    </div>
  )
}

export default Category