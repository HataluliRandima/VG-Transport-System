import React from 'react'

const ModalDriver = ({ isVisible,onClose, children}) => {


    if(!isVisible) return null;

    const handleclose =(e) => {
     if(e.target.id === 'hata') onClose();

    }

  return (
    <div className='fixed inset-0 bg-black bg-opacity-25 backdrop-blur-sm flex justify-center items-center' id="hata" onClick={handleclose}> 
    <div className='w-[600px] flex flex-col' >

      <button className='text-white text-xl place-self-end' onClick={() => onClose()}>X</button>

       <div className='bg-white p-2 rounded
       '>
           {children}
       </div>
    </div>


    </div>
  )
}

export default ModalDriver