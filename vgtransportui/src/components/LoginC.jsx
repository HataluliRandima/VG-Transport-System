import React,{useState} from 'react'
import { Link  } from 'react-router-dom'
 

function LoginC() {

    //for toggle
    const [Toggle, setToggle] = useState("Customer");


  return (

    <div class="flex items-center justify-center min-h-screen bg-gray-100">
    <div
      class="relative flex flex-col m-6 space-y-8 bg-white shadow-2xl rounded-2xl md:flex-row md:space-y-0"
    >
      
      <div class="flex flex-col justify-center p-8 md:p-14">
        <h1 class="mb-3 text-4xl font-bold">Welcome back</h1>
        <span class="font-light text-gray-500 mb-8">
        Welcome back! Please enter you details and select your Role.
        </span>


        <div className="flex bg-bgsecondary w-fit justify-between rounded ml-5">
        <button
          className={
            Toggle === "Customer"
            ? "py-2 px-8 text-lg font-poppins font-semibold cursor-pointer rounded bg-slate-700"
            : "py-2 px-8 text-lg font-poppins font-medium text-white cursor-pointer rounded bg-slate-400"
          }
          onClick={() => {
            setToggle("Customer");
          }}
          
        >
          Customer
        </button>
        <button
           
          className={
            Toggle === "Driver"
             ? "py-2 px-8 text-lg font-poppins font-medium text-primary cursor-pointer rounded bg-slate-700"
             :"py-2 px-8 text-lg font-poppins font-medium text-white cursor-pointer rounded bg-slate-400"
          }
          onClick={() =>
        {
            setToggle("Driver");
        }}
        >
          Driver
        </button>
        <button
           
          className={
            Toggle === "Admin"
            ? "py-2 px-8 text-lg font-poppins font-medium text-primary cursor-pointer rounded bg-slate-700"
            :"py-2 px-8 text-lg font-poppins font-medium text-white cursor-pointer rounded bg-slate-400"
          }
          onClick={() =>
            {
                setToggle("Admin");
            }}
        >
          Admin
        </button>
      </div>
        


        <div class="py-4">
          <span class="mb-2 text-md">Email</span>
          <input
            type="text"
            class="w-full p-2 border border-gray-300 rounded-md placeholder:font-light placeholder:text-gray-500"
            name="email"
            id="email"
          />
        </div>
        <div class="py-4">
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
          <button className='font-bold text-base text-slate-500'>Forgot password ?</button>
        </div>
        <button
          class="w-full bg-black text-white p-2 rounded-lg mb-6 hover:bg-white hover:text-black hover:border hover:border-gray-300"
        >
          Sign in
        </button>
        
        <div class="text-center  ">
        Don't have an account as Customer?
        <Link 
                 to={'/registerc'}
                 className='ml-2 font-bold text-base text-slate-400  '>Sign up</Link>
           
        </div>

        
      </div>
       
     
      </div>
    </div>
 
  )
}

export default LoginC