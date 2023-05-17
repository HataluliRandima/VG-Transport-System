import React from 'react'
//import { Link  } from 'react-router-dom'

const BlackButton = ({ title, onClick, className }) => {
  return (
    <button  
    className={
      "border bg-black text-white border-white hover:bg-transparent hover:text-white rounded-md duration-300 ease-out" +
      " " +
      className
    }
    onClick={onClick}
  >
    {title}
  </button>
  )
}

export default BlackButton