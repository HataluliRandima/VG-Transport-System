import React from 'react'

const Tsetse = () => {
  return (
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
  )
}

export default Tsetse