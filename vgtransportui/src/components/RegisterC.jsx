import React from 'react'
import { Link } from 'react-router-dom'

function RegisterC() {
  return (
    <div class="flex items-center justify-center min-h-screen bg-gray-100">
      
    <div
      class="relative flex flex-col m-6 space-y-8 bg-white shadow-2xl rounded-2xl md:flex-row md:space-y-0"
    >
       
      <div class="flex flex-col justify-center p-8 md:p-14">
        <h1 class="mb-3 text-4xl font-bold">Register Account Customer</h1>
        <span class="font-light text-gray-500 mb-8">
       Please fill in your details as a customer 
        </span>
 
        <div class="py-1">
          <span class="mb-2 text-md">First Name</span>
          <input
            type="text"
            class="w-full p-2 border border-gray-300 rounded-md placeholder:font-light placeholder:text-gray-500"
            name="email"
            id="email"
          />
        </div>
        <div class="py-1">
          <span class="mb-2 text-md">Surname</span>
          <input
            type="text"
            class="w-full p-2 border border-gray-300 rounded-md placeholder:font-light placeholder:text-gray-500"
            name="email"
            id="email"
          />
        </div>
        <div class="py-1">
          <span class="mb-2 text-md">Email</span>
          <input
            type="text"
            class="w-full p-2 border border-gray-300 rounded-md placeholder:font-light placeholder:text-gray-500"
            name="email"
            id="email"
          />
        </div>
        <div class="py-1">
          <span class="mb-2 text-md">Contact Number</span>
          <input
            type="text"
            class="w-full p-2 border border-gray-300 rounded-md placeholder:font-light placeholder:text-gray-500"
            name="email"
            id="email"
          />
        </div>
        <div class="py-1">
          <span class="mb-2 text-md">Address</span>
          <input
            type="text"
            name="pass"
            id="pass"
            class="w-full p-2 border border-gray-300 rounded-md placeholder:font-light placeholder:text-gray-500"
          />
        </div>
        <div class="py-1">
          <span class="mb-2 text-md">Password</span>
          <input
            type="password"
            name="pass"
            id="pass"
            class="w-full p-2 border border-gray-300 rounded-md placeholder:font-light placeholder:text-gray-500"
          />
        </div>
        <div class="flex justify-between w-full py-4">
           <div class="mr-24">
            
          </div>
         
        </div>
        <button
          class="w-full bg-black text-white p-2 rounded-lg mb-6 hover:bg-black hover:text-white hover:border hover:border-gray-300"
        >
          Sign Up
        </button>
        
        <div class="text-center  ">
       Already have an account as User?
        <Link 
                 to={'/loginc'}
                 className='ml-2 font-bold text-base text-slate-400  '>Sign in</Link>
         
        </div>

        
      </div>
       
     
      </div>
    </div>
  )
}

export default RegisterC