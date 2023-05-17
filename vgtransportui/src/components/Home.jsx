import React, {Fragment, useState} from 'react'
import BlackButton from "./BlackButton";
import ModalDriver from './ModalDriver';

const Home = () => {

    const [showModal, setShowModal] =useState(false);
  return (
    <Fragment>
    <div
    name="home"
    className="flex flex-col justify-between w-full h-screen bg-white text-black text-center md:text-left"
  >
    <div className="grid md:grid-cols-2 max-w-screen-xl m-auto px-3">
      <div className="flex flex-col justify-center md:items-start w-full px-2 py-8">
        <p className="text-2xl text-gray-500">
          Cheapest Hosting on Planet Earth
        </p>
        <h1 className="pt-1 pb-6 text-5xl md:text-7xl font-bold">
          <span className="text-lightColor">ONNN</span> Web Services
        </h1>
        <p className="text-base font-light text-gray-500">
          Explore cushions he with fowl was nodded, merely suddenly thee bore
          nevermore. My bust sitting the ease of the will.
        </p>
        {/* <BlackButton
          title="sign up"
          className="capitalize py-3 px-6 sm:w-8/12 my-8"
        /> */}
        <button className="border bg-black text-white border-white hover:bg-black hover:text-white rounded-md duration-300 ease-out capitalize py-3 px-6 sm:w-8/12 my-8" onClick={()=> setShowModal(true)}>hh</button>
      </div>

      {/* <div className="flex items-center justify-center">
        <img src={hero} alt="hero" className="w-3/4 rounded-full" />
      </div> */}
    </div>
  </div>
  <ModalDriver isVisible={showModal} onClose={()=> setShowModal(false)} >
     <div className='py-6 px-6 lg:px-8 text-left' >
        <h3 className='mb-4 text-xl font-medium text-gray-900'>Upload Your informa</h3>
        <form className='space-y-6' action='#'>
           <div>
             <label for="emaoi" className='block mb-2 text-sm font-medium text-gray-900'>
                Your Email
             </label>
              <input type='email' name='email' id='email'
              className='bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5'
              placeholder='emails yours'
              required />
               
           </div>
            
            <div>
            <label for="password" className='block mb-2 text-sm font-medium text-gray-900'>
                Your password
             </label>
              <input type='password' name='password' id='password'
              className='bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5'
              placeholder='******'
              required />
            </div>

            <div>
            <label for="password" className='block mb-2 text-sm font-medium text-gray-900'>
                Your password
             </label>
              <input type='file' name='password' id='password'
              className='bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5'
              placeholder='******'
              required />
            </div>
            <button 
            type='submit'
            className='w-full text-white bg-black  focus:ring focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center'>
               Submit
            </button>
        </form>
     </div>
    </ModalDriver>
  </Fragment>
  )
}

export default Home